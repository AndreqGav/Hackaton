using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerButton : MonoBehaviour {

	public string answer_ = "";
	public char[] answer = new char[1];

	void Start ()
	{
		//for (int i = 0; i < answer.Length; ++i) {
		//	answer [i] = '0';
		//}
		if (answer.Length == 0 || answer_ != "") {
			answer = new char[answer_.Length];

			for (int i = 0; i < answer.Length; ++i) {
				answer [i] = answer_ [i];
			}
		}
	}
	

	void Update () 
	{
		
	}

	public void Answer(string answ)
	{
		if (answ != "") { // Уууухххх факс
			ManagerTask.manager.CurTask.GetComponent<task> ().Answer (answ);
		} else {
			ManagerTask.manager.CurTask.GetComponent<task> ().Answer (ToStringIZChar(answer));
		}
	}

	private string ToStringIZChar(char[] answ)
	{
		string a = "";
		for (int i = 0; i < answ.Length; ++i) {
			a += answ [i];
		}
		Debug.Log (a);
		return a;
	}
}
