using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour {

	[SerializeField] private Color colorAttach;
	[SerializeField] private Color NotcolorAttach;

	[SerializeField] private string GoodAnswer;

	[SerializeField] private int nomberChar;

	[SerializeField] private bool AnswerSlot = false;

	[SerializeField] private AnswerButton _buttom;

	public void UpdateSlot()
	{
		

		if (AnswerSlot) {

			string key = "";

			if (transform.childCount > 0) {

				GetComponent<Image> ().color = colorAttach;
				var child = transform.GetChild (0);

				if (child != null) {
					var drag = child.GetComponent<DragItem> ();

					if (drag != null) {
						key = drag.key;
					}
					Debug.Log (key);
				}
			} else {
				// Нет потомков
				if (AnswerSlot) {
					_buttom.answer [nomberChar] = '0';
				}

				GetComponent<Image> ().color = NotcolorAttach;
			}

			if (GoodAnswer == key) {
				_buttom.answer [nomberChar] = '1';
			} else {
				_buttom.answer [nomberChar] = '0';
			}
		}
	}

}
