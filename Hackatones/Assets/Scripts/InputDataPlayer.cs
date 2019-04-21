using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InputDataPlayer : MonoBehaviour {

	[SerializeField] private Text _name;
	[SerializeField] private Text _age;


	void Start () 
	{

	}

	void Update () 
	{

	}

	public void Complete()
	{
		DataPlayer.data.name = _name.text;
		int age = int.Parse (_age.text);

		if (age <= 0) {
			Debug.Log ("Не играй со мной!");
			age = 12;
		}

		DataPlayer.data.age = age;

		if (age < 12) {
			SceneManager.LoadScene ("less12");
		} else {
			SceneManager.LoadScene ("more12");
		}
	}
}
