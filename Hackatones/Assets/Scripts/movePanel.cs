using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class movePanel : MonoBehaviour {

	[SerializeField]public float open_x = 400;
	[SerializeField]public float close_x = -600;

	private bool open = false;

	void Start () {
		transform.DOLocalMoveX(close_x,0.5f);
	}

	void Update () {

		if (Input.GetKey (KeyCode.Escape) && open) {
		//	Back ();
		}
	}

	public void movingPanel()
	{
		open = !open;

		float move = (open) ? open_x : close_x;
		transform.DOLocalMoveX(move,0.5f);
	}

	void Back()
	{
		transform.DOLocalMoveX(close_x,0.5f);
	}
}
