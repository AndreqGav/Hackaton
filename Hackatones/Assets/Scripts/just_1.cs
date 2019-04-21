using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class just_1 : MonoBehaviour {

	private GameObject DataObj;

	void Start () {
		DataObj = GameObject.FindWithTag ("data");
		if (DataObj != null) {
			DataObj.GetComponent<DataPlayer> ().PPP ();
		}
	}
	

	void Update () {
		
	}


}
