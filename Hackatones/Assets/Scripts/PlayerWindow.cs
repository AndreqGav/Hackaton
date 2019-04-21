using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerWindow : MonoBehaviour {

	[SerializeField] private Text name;
	[SerializeField] private Text level;

	private DataPlayer data;

	void Start () {
		
		GameObject _data = GameObject.FindWithTag ("data");
		if (_data != null) {
			data = _data.GetComponent<DataPlayer> ();
			if (data == null)
				return;
		}
		name.text = "Имя: " + data.name;
		level.text = "Уровень: " + data.level;
	}

	void Update () {
		
	}
}
