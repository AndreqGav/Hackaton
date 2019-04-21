using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DrawLine : MonoBehaviour{

	[SerializeField] private Text Finded;
	public int maxFinded;
	private int curFinded;

	private GameObject LineObj;
	private Color startColor;
	private Color lineColorNormal;
	private Color lineColorIntersect;
	private List<Transform> startPoints = new List<Transform>();

	private List<LineRenderer> ListLine = new List<LineRenderer> ();
	private LineRenderer CurrentLine = null;

	private Transform currentPoint = null;
	private Transform beginPonit;
	private Transform lastPoint = null;

	private bool isDraw = false;
	private bool isCursorOnPanel = false;

	public List<string> names = new List<string> ();


	private GameObject DataObj;
	public int add = 100;

	struct Line
	{
		public Vector2 startPoint;
		public Vector2 endPoint;

		public Line(Vector3 start, Vector3 end)
		{
			startPoint = start;
			endPoint = end;
		}
	}

	void Start ()
	{
		DataObj = GameObject.FindWithTag ("data");

		Inizialize ();
	}

	void Inizialize()
	{
		LineObj = GameManager.Manager.GetLineObj;
		startColor = GameManager.Manager.GetStartColor;
		lineColorNormal = GameManager.Manager.GetLineColorNormal;
		lineColorIntersect = GameManager.Manager.GetLineColorIntersect;
		startPoints = GameManager.Manager.GetStartPoints;
	}

	void Update () 
	{
		if (Input.GetMouseButtonDown (0) && isCursorOnPanel) {
				CurrentLine = CreateLine ();
		}

		if (isDraw) {
			Drawing ();
		}

		if (Input.GetMouseButtonUp (0) || !isCursorOnPanel) {
			if (isDraw) {
				isDraw = false;
				PushLine ();
			}
		}

		if (Input.GetKeyDown (KeyCode.Escape)) {
			if (DataObj != null) {
				DataObj.GetComponent<DataPlayer> ().WindowManagerTagStartWindow = "training";
				DataObj.GetComponent<DataPlayer> ().AddMoney (add);
			}

			SceneManager.LoadScene ("more12");

		}
	}

	// создаем новую линию
	private LineRenderer CreateLine()
	{
		Vector3 currentPointPosition;

		// впервые создаем => нужно выбрать нач. точку
		if (currentPoint == null) {
			Transform point = CursorOverPoint ();
			if (point == null || !startPoints.Contains (point))
				return null;
			else {
				currentPoint = point;
				ChangeColorStartPoints (Color.black, point);
			}
		}
		currentPointPosition = currentPoint.transform.position;
		currentPointPosition.z = 0;

		GameObject obj = Instantiate (LineObj, currentPointPosition, Quaternion.identity, transform);
		var _lineRender = obj.GetComponent<LineRenderer> ();

		if (_lineRender != null) {
			isDraw = true;

			int index = _lineRender.positionCount;
			_lineRender.positionCount += 2;
			_lineRender.SetPosition (index,currentPointPosition);
		}

		return _lineRender;
	}

	// "тянем" линию за курсором
	void Drawing()
	{
		Vector3 position = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		position.z = 0;

		int index = CurrentLine.positionCount-1;
		CurrentLine.SetPosition (index, position);

		isIntersect ();
	}

	// Поставить линию
	void PushLine()
	{
		Transform point = CursorOverPoint ();
		bool _intersect = isIntersect ();
		if (point != null && point != currentPoint && point != lastPoint && !_intersect) {

			// Запомнить первую точку
			if (ListLine.Count == 0) {	
				beginPonit = currentPoint;
				GameManager.Manager.AddCompletePoints (beginPonit.GetComponent<Point>());
			}
			// Запонить последнюю соединенную точку
			lastPoint = currentPoint;
			currentPoint.GetComponent<Point>().AddLineToList(CurrentLine);
			currentPoint = point;
			Vector3 newStartPos = CurrentLine.GetPosition (CurrentLine.positionCount - 2);
			Vector3 endPose = currentPoint.position;
			newStartPos.z = currentPoint.position.z + 1;
			endPose.z += 1;
			CurrentLine.SetPosition (CurrentLine.positionCount - 2, newStartPos);
			CurrentLine.SetPosition(CurrentLine.positionCount-1,endPose);
			ListLine.Add(CurrentLine);

			// Добавить эту точку в завершенные(или уменьшить кол-во допутимых линий)
			GameManager.Manager.AddCompletePoints (currentPoint.GetComponent<Point>(), CurrentLine);
			// // // // // // // // // 

			if (currentPoint.GetComponent<EndPoint> ()) {
				string name_ = GetName ();
				Debug.Log (name_);
				//if (names.Contains (name_)) {
					curFinded++;
			
					Finded.text += name_;
					if (curFinded == maxFinded) {
						Debug.Log ("Complede");
					}
				//}

			}

		} else {
			Destroy(CurrentLine.gameObject);
			ChangeColorLine (ListLine, lineColorNormal); 

			if (ListLine.Count == 0) { // Если первую точку "неудачно" выбрали
				currentPoint = null;
				ChangeColorStartPoints (startColor);
			}
		}
		CurrentLine = null;
	}

	private string GetName(){
		List<Transform> list = GameManager.Manager.CompletedPoints;
		string name = "";
		for (int i = 0; i < list.Count; ++i) {
				name += list [i].name;
		}

		return name;
	}
	//Выдать точку под курсором, если есть
	private Transform CursorOverPoint()
	{
		RaycastHit2D hit;
		Vector2 mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		hit = Physics2D.Raycast (new Vector2(mousePos.x, mousePos.y), Vector2.zero);

		bool check = false;

		if(hit.collider != null)
			check = hit.collider.tag == "Point";

		if (check) {
			return hit.transform;
		}

		return null;
	}

	// поменять цвет начальным точкам, кроме point(если нужно)
	void ChangeColorStartPoints(Color _color, Transform point = null)
	{
		foreach (Transform trans in startPoints) {
			if (trans != point)
				trans.GetComponent<Point> ().ChangeColor (_color);
		}
	}

	// Сравнение на пересечение текущей линии и остальными
	bool isIntersect()
	{

		if (currentPoint == null)
			return false;
		
		List<LineRenderer> otherLines = new List<LineRenderer> ();// линии не соединенные с текущей точкой
		List<LineRenderer> connectedLine = currentPoint.GetComponent<Point> ().GetConnectedLines(); // линии соединенные с текущей точкой

		for (int j = 0; j < ListLine.Count; j++) {
			if (!connectedLine.Contains (ListLine [j])) {
				otherLines.Add (ListLine [j]);
			}
		}
		int l = otherLines.Count;
		int l1 = connectedLine.Count;
		//l = (l >= 2)?ListLine.Count-1 : ListLine.Count;// ибо последняя всегда имеет общую точку (начало линии) (сделал в цикле l-1)

		
		bool Intersect = false;

		Line L1 = new Line (CurrentLine.GetPosition(0), CurrentLine.GetPosition(1));

		List<LineRenderer> collise = new List<LineRenderer> ();
		List<LineRenderer> Notcollise = new List<LineRenderer> ();

		int i = 0;
		while (i < l) {
			Line L2 = new Line (otherLines [i].GetPosition (0), otherLines [i].GetPosition (1));
			if (IntersectLines (L1, L2)) {
				collise.Add (otherLines [i]);
			} else {
				Notcollise.Add (otherLines [i]);
			}
			++i;
		}
		// проверка для соединенных с вершиной линий
		for (int j = 0; j < l1; j++) {
			//Debug.Log (j);
			Line L3 = new Line (connectedLine [j].GetPosition (0), connectedLine [j].GetPosition (1));
			float angle = AngleBetweenLine (L1, L3);
			float distanceStart = Vector2.Distance (L1.startPoint, L3.startPoint); // если прямые из одной точки, то angle < 5
			if (angle >= 175f && distanceStart > 0.5f || (angle <= 5f && distanceStart < 0.5f)) {
				collise.Add (connectedLine [j]);
			} else {
				Notcollise.Add (connectedLine [j]);
			}
		}

		Intersect = collise.Count > 0;

		// замена цвета
		ChangeColorLine(collise, lineColorIntersect);
		ChangeColorLine(Notcollise, lineColorNormal);
		return Intersect;
	}

	// Сравнение на пересечение двух линий
	bool IntersectLines(Line L1, Line L2)
	{
		return Transection (L1.startPoint.x, L1.startPoint.y, L1.endPoint.x, L1.endPoint.y, L2.startPoint.x, L2.startPoint.y, L2.endPoint.x, L2.endPoint.y);
	}
	// Проверка на пересечение (функция)
	bool Transection(float ax1, float ay1, float ax2, float ay2, float bx1, float by1, float bx2, float by2)
	{
		float v1 = (bx2 - bx1) * (ay1 - by1) - (by2 - by1) * (ax1 - bx1);
		float v2 = (bx2 - bx1) * (ay2 - by1) - (by2 - by1) * (ax2 - bx1);
		float v3 = (ax2 - ax1) * (by1 - ay1) - (ay2 - ay1) * (bx1 - ax1);
		float v4 = (ax2 - ax1) * (by2 - ay1) - (ay2 - ay1) * (bx2 - ax1);

		return ((v1 * v2 <= 0) && (v3 * v4 <= 0));
	}

	// Вычисление угла между прямыми
	float AngleBetweenLine(Line L1, Line L2)
	{
		Vector3 LineFrom = new Vector3 (L1.endPoint.x - L1.startPoint.x, L1.endPoint.y - L1.startPoint.y);
		Vector3 LineTo = new Vector3 (L2.endPoint.x - L2.startPoint.x, L2.endPoint.y - L2.startPoint.y);

		float angle = Vector3.Angle (LineFrom, LineTo);
		return angle;
	}

	// Смена цвета линиям в list
	void ChangeColorLine(List<LineRenderer> list, Color _color)
	{
		foreach (LineRenderer lr in list) {
			lr.material.color = _color;
		}
	}

	public void CursorOnGamePanel(bool value)
	{
		isCursorOnPanel = value;
	}
		
}
	