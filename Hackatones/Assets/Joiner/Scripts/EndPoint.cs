using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPoint : Point {
	void Start()
	{
		AddToPoint ();
		SetEndPoint ();
		ChangeColor (GameManager.Manager.GetEndColorBegin);
	}

	public void SetEndPoint(){
		GameManager.Manager.EndPoint = transform;
	}
}
