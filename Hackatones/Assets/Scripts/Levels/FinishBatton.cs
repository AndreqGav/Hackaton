using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishBatton : MonoBehaviour {

	public string tagWinddowToLoad = "";
	private GameObject DataObj;
	public int add = 100;

	public string data_1="";
	public string data_2="";
	public string data_3="";

	void Start()
	{
		DataObj = GameObject.FindWithTag ("data");
	}
	public void Inputing()
	{
		if (DataObj != null) {
			DataObj.GetComponent<DataPlayer> ().WindowManagerTagStartWindow = tagWinddowToLoad;
			DataObj.GetComponent<DataPlayer> ().AddMoney (add);
			DataObj.GetComponent<DataPlayer> ().Plus_1 = data_1;
			DataObj.GetComponent<DataPlayer> ().Plus_2 = data_2;
			DataObj.GetComponent<DataPlayer> ().Plus_3 = data_3;
		}
		SceneManager.LoadScene ("more12");
	}
}
