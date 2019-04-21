using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using DG.Tweening;

public class WindowManager : MonoBehaviour {

	public string tagStartWindow = "";
	//			//			//			//			//			//			//			//
	public static WindowManager manager = null;
	public Transform curWidnow;
	public Transform lastWindow;
	public float speed = 1f;


	void Awake()
	{
		if (manager == null)
			manager = this;
	}

	void Start () {
		
		GameObject DataObj = GameObject.FindWithTag ("data");
		if (DataObj != null) {
			tagStartWindow = DataObj.GetComponent<DataPlayer> ().WindowManagerTagStartWindow;
		}
		if (tagStartWindow == "") {
			tagStartWindow = "menu";
		}
		GameObject startwindow = GameObject.FindWithTag (tagStartWindow);
		LoadWindow (startwindow.transform);
	}

	void Update () {
		
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Back ();
		}
	}

	public void LoadWindow(Transform new_window)
	{
		Debug.Log (new_window.name);
		//if (new_window == curWidnow)
		//	return;
		
		new_window.localPosition = new Vector2 (1000, 0); 
		curWidnow.DOLocalMoveX (-1000, speed);
		new_window.DOLocalMoveX (0, speed);

		lastWindow = new_window.GetComponent<window>().lastWindow;
		curWidnow = new_window;
	}

	void Back()
	{
		if (lastWindow == null)
			return;
		
		Transform new_window = lastWindow;
		new_window.localPosition = new Vector2 (-1000, 0); 
		curWidnow.DOLocalMoveX (1000, speed);
		new_window.DOLocalMoveX (0, speed);

		lastWindow = new_window.GetComponent<window>().lastWindow;;
		curWidnow = new_window;
	}
}
