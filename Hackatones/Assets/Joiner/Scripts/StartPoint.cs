using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPoint : Point {


	void Start()
	{
		Inizialize ();
		AddToStartPoint ();
	}

	public void AddToStartPoint(){
		GameManager.Manager.AddStartPoint (transform);
	}
}
