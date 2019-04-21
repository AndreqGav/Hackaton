using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ManagerTask : MonoBehaviour {

	public Transform CurTask;

	public Transform goodPanel;
	public Transform badPanel;

	public static ManagerTask manager = null;

	public bool Test = false;

	public static bool test_;

	void Awake()
	{
		if (manager == null)
			manager = this;

		test_ = Test;
	}


	void Start () {

		MakeOpenedCur ();

		if(Test)
		CurTask.DOLocalMoveX (0, 1f);
	}

	void Update () {

	}
		

	public void GiveAnswer(string answ)
	{
		CurTask.GetComponent<task>().Answer(answ);
	}

	public void NextTask()
	{
		CurTask.GetComponent<task> ().NextTask ();
	}

	public void EraseAnswer()
	{
		CurTask.GetComponent<task> ().Erase ();
		//gameObject.SendMessage ("MassengeErease");
	}

	public void HideAll()
	{
		goodPanel.DOKill ();
		badPanel.DOKill ();
		goodPanel.transform.localPosition = new Vector3 (0, -350, 0);
		badPanel.transform.localPosition = new Vector3 (0, -350, 0);
	}

	public void MakeOpenedCur()
	{
		CurTask.GetComponent<task>().Opened = true;
	}


}
