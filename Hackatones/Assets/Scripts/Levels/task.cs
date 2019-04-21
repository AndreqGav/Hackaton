using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class task : MonoBehaviour {

	[SerializeField] private string GoodAnsw;

	 private Transform goodPanel;
	 private Transform badPanel;

	[SerializeField] private Transform NextLevel;

	private bool Complete = false;

	public bool Opened = false;
	public bool Completed = false;

	void Awake()
	{
		
	}

	void Start () {

		if(ManagerTask.test_)
			transform.DOLocalMoveX (-1000, 0.01f);
		
		goodPanel = ManagerTask.manager.goodPanel;
		badPanel = ManagerTask.manager.badPanel;
		Erase ();
	}
	

	void Update () {
		
	}

	public void Answer(string answ)
	{
		if (Complete)
			return;
		HideAll ();

		if (CheckAnsw (answ)) {
			ShowGood ();
			Completed = true;
		} else {
			ShowBad ();
		}

		Complete = true;
	}

	bool CheckAnsw(string answ)
	{
		return answ == GoodAnsw;
	}

	void ShowGood()
	{
		goodPanel.DOLocalMove (Vector3.zero, 1f);
	}

	void ShowBad()
	{
		badPanel.DOLocalMove (Vector3.zero, 1f);
	}

	void HideAll()
	{
		goodPanel.DOLocalMove (new Vector3(0,-350,0), 1f);
		badPanel.DOLocalMove (new Vector3(0,-350,0), 1f);
	}

	public void Erase()
	{
		Complete = false;
		HideAll ();
	}

	public void NextTask()
	{
		transform.DOLocalMoveX (-1000, 1f);
		NextLevel.DOLocalMoveX (0, 1f);

		StartCoroutine ("CompleteTween");
		ManagerTask.manager.HideAll ();


	}

	IEnumerator CompleteTween()
	{
		
		yield return new WaitForSeconds (1f);
		ManagerTask.manager.CurTask = NextLevel;
		ManagerTask.manager.MakeOpenedCur ();
		ManagerTask.manager.HideAll ();
	}
}
