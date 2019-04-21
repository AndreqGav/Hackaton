using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MovePanelLoadWindow : MonoBehaviour {

	[SerializeField] Transform openWindow;

	public void Inputing()
	{
		WindowManager.manager.LoadWindow (openWindow);
	}
}
