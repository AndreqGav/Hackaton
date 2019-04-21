using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Point : MonoBehaviour {

	[SerializeField] private Text _text;
	[SerializeField] private int MinNomberLines = 1;
	[SerializeField] private int MaxNomberLines = 1;
	[SerializeField] private Image _image;

	private List<LineRenderer> ConnectedLine = new List<LineRenderer> ();

	private int _countLines = 0;

	void Start()
	{
		Inizialize ();
	}
	protected void Inizialize()
	{
		AddToPoint ();
	
		if (MinNomberLines > 1)
			MaxNomberLines = MinNomberLines;
		else
			MinNomberLines = 1;

		UpdateText ();
		UpdateDataPoint ();
	}

	public void AddToPoint(){
		GameManager.Manager.AddPoint (transform);
	}
	public void ChangeColor(Color _color){
		_image.color = _color;
	}

	public void EnableCollider(bool enable)
	{
		Collider2D[] colliders = gameObject.GetComponentsInChildren<Collider2D> ();

		foreach (Collider2D collider in colliders) {
				collider.enabled = enable;
		}

	}

	public void ConnetcLine(LineRenderer line)
	{
		_countLines++;
		UpdateText ();
		UpdateDataPoint ();
		AddLineToList (line);
	}

	protected void UpdateText()
	{
		_text.text = (MaxNomberLines > 1) ? (MaxNomberLines - _countLines).ToString () : "";

		if (_countLines < MinNomberLines && MinNomberLines > 1)
			_text.color = Color.red;
		else
			_text.color = Color.green;
	}

	public void UpdateDataPoint()
	{
		if(isLinesEnd()) // Если уже не можем добавить линии
			EnableCollider (false);
	}

	public bool isLinesEnd()
	{
		return MaxNomberLines == _countLines;
	}

	public bool isPointComplete()
	{
		return _countLines >= MinNomberLines;
	}

	public List<LineRenderer> GetConnectedLines()
	{
		return ConnectedLine;
	}

	public void AddLineToList(LineRenderer line)
	{
		if(line != null)
			ConnectedLine.Add (line);
	}
}
