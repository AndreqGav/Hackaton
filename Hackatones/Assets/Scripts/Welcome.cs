using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Welcome : MonoBehaviour {

	[SerializeField] private Text _welcome;

	void Start ()
	{
		_welcome.text = "Приятно познакомиться, " + DataPlayer.data.name + "!" + "Давай я покажу, как пользоваться нашим приложением";
	}
	

	void Update () 
	{
		
	}
}
