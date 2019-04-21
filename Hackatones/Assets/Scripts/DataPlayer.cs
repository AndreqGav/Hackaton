using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class DataPlayer : MonoBehaviour {

	public struct Lesson
	{
		int complete;
	}

	public string name;
	public int age;
	public int level = 1;

	public string Plus_1;
	public string Plus_2;
	public string Plus_3;

	[SerializeField] private Text _textMoney;
	public int money;
	public float addMoney;

	public List<Lesson> progress = new List<Lesson> ();
	[SerializeField]
	private List<GameObject> lessons;

	public bool Test = false;


	public static DataPlayer data = null;

	public string WindowManagerTagStartWindow;

	float a = 0;
	public float speedMMoney= 1;
	void Awake()
	{
		GameObject _data = GameObject.FindGameObjectWithTag ("data");
		if (_data != null && _data != gameObject)
			Destroy (gameObject);
		if (data == null)
			data = this;

		DontDestroyOnLoad (this.gameObject);
	}

	void Start () 
	{

	}

	void Update () 
	{
		if (_textMoney == null) {
			GameObject txt = GameObject.FindWithTag ("textMoney");
			if (txt != null)
				_textMoney = txt.GetComponent<Text> ();
		} else {
			_textMoney.text = "" + money;
		}
		if (Test) {
			
			if (addMoney > 0) {
				a += speedMMoney;
				if (a >= 1) {
					addMoney--;
					money += 1;
					a = 0;
				}
			} else {
				addMoney = 0;
				Test = false;
			}
		}

	
	}

	public void AddMoney(int value)
	{
		addMoney = value;
		Test = true;
	}

	public void PPP()
	{
		if (Plus_1 == "" || Plus_1 == "" || Plus_1 == "")
			return;
		Plaus (Plus_1);
		Plaus (Plus_2);
		Plaus (Plus_3);
		//Plus_1 = Plus_2 = Plus_3 = "";
	}

	public void Plaus(string _plus)
	{
		string[] str = new string[2];
		str = _plus.Split(' ');

		string value = str [0];;
		string name = str[1];

	
		//Debug.Log (value);

		var obj = GameObject.Find (name);
		Debug.Log (name);
		if (obj != null) {
			Debug.Log (name);
			switch (name [0]) {
			case '1':
				{
					int a = int.Parse (obj.GetComponent<Text> ().text);
					int b = int.Parse (value);
					int c = a + b;
					obj.GetComponent<Text> ().text = "" + a + b;
					break;
				}
			case '2':
				{
					int a = int.Parse (obj.GetComponent<Text> ().text);
					int b = int.Parse (value);
					int c = a + b;
					obj.GetComponent<Text> ().text = "" + a + b;
					break;
				}
			case '3':
				{
					obj.GetComponent<Image> ().color = Color.green;
					break;
				}



			}
		}
	}

		
}
