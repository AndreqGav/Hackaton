using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class window : MonoBehaviour {

	public Transform lastWindow;

	void Start()
	{
		transform.localPosition = new Vector2 (-1000, 0); 
	}

}
