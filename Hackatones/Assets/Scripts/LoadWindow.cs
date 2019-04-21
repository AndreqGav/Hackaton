using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LoadWindow : MonoBehaviour {

	//[SerializeField] private float speed = 1f;
	//[SerializeField] private Transform thisWindow;
	[SerializeField]private Transform openWindow;

	public void Inputing()
	{
		WindowManager.manager.LoadWindow (openWindow);
	}


}
