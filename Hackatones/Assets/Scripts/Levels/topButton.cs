using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;


public class topButton : MonoBehaviour {

	[SerializeField] private Transform task;

	[SerializeField] private Color color_1;
	[SerializeField] private Color color_2;

	void Start () {
		
	}
	

	void Update () 
	{
		if (task.GetComponent<task> ().Opened) {
			GetComponent<Image> ().color = color_1;
		} else {
			GetComponent<Image> ().color = color_2;
		}
	}

	public void Inputing()
	{
		if (task.GetComponent<task> ().Opened && ManagerTask.manager.CurTask != task) {
			task.GetComponent<task> ().Erase ();

			ManagerTask.manager.CurTask.DOLocalMoveX (-1000, 1f);
			ManagerTask.manager.CurTask = task;
			ManagerTask.manager.HideAll ();

			task.DOLocalMoveX (-0, 1f);
		}
	}
		
}
