using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoad : MonoBehaviour {

	[SerializeField] private string nameLevel;


	public void Inputing()
	{
		SceneManager.LoadScene (nameLevel);
	}
}
