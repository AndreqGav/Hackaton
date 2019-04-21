using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentSlot : MonoBehaviour {

	public Transform[] child;

	public static bool Check = false;

	void Start () {
		child = transform.GetComponentsInChildren<Transform> ();
	}

	void Update()
	{
		if (Check) {
			Cheking ();
			Check = false;
		}
	}
	public void Cheking()
	{
		for (int i = 0; i < child.Length; ++i) {
			if (child [i].GetComponent<Slot> ()) {

				child [i].GetComponent<Slot> ().UpdateSlot ();
			}
		}
	}
}
