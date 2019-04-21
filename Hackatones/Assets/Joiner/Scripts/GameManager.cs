using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	[SerializeField] private GameObject LineObj;
	[SerializeField] private Color startColor;
	[SerializeField] private Color endColorBegin;
	[SerializeField] private Color endColorEnd;
	[SerializeField] private Color lineColorNormal;
	[SerializeField] private Color lineColorIntesect;
	[SerializeField] private DrawLine scriptDrawLine;
	[SerializeField] private Material lineMaterial;

	private Transform endPoint;
	private List<Transform> startPoints = new List<Transform>();

	public GameObject GetLineObj{
		get{return LineObj;}
	}
	public Color GetStartColor{
		get{ return startColor; }
	}
	public Color GetEndColorBegin{
		get{ return endColorBegin; }
	}
	public Color GetLineColorNormal{
		get{ return lineColorNormal; }
	}
	public Color GetLineColorIntersect{
		get{ return lineColorIntesect; }
	}
	public Transform EndPoint{
		get{ return endPoint; } set{endPoint = value;}
	}
	public List<Transform> GetStartPoints{
		get{ return startPoints; }
	}

	public List<Transform> Points = new List<Transform>();
	public List<Transform> CompletedPoints = new List<Transform>();

	public static GameManager Manager = null;

	void Awake()
	{
		if (Manager == null) {
			Manager = this;
		} else if (Manager == this) {
			Destroy (gameObject);
		}
	}
	void Start () {
		lineMaterial.color = lineColorNormal;
	}

	void Update () {
		
	}

	// Добавление в завершенные точку
	public void AddCompletePoints(Point point, LineRenderer line = null){

		point.ConnetcLine (line);

		if (point.isPointComplete ()){ // если min кол-во линий соединено для точки
			if(!CompletedPoints.Contains(point.transform))
				CompletedPoints.Add (point.transform);
				}

		// Осталось соединить последнюю точку
		//if (CompletedPoints.Count == Points.Count - 1) {
		//	if (endPoint != null) {
	//			var End = endPoint.GetComponent<EndPoint> ();
		//		End.EnableCollider (true);
		//		End.ChangeColor (endColorEnd);
		//	}
		//}
		//Все точки соединены
		//if (CompletedPoints.Count == Points.Count) {
		//	scriptDrawLine.enabled = false;
		//}
			
	}

	public void AddPoint(Transform point){
		Points.Add (point);
	}

	public void AddStartPoint(Transform point)
	{
		startPoints.Add (point);
	}
}
