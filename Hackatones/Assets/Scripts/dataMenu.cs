using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dataMenu : MonoBehaviour {

	public Text _text;

	private GameObject DataObj;

	void Start () {
		DataObj = GameObject.FindWithTag ("data");

		if (DataObj != null) {
			_text.text = DataObj.GetComponent<DataPlayer> ().name;

		}
	}

}
