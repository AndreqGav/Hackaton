using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

	public string key;
	private Vector2 pointerOffset = new Vector2(25f,-25f);
	private RectTransform rectDrag; 
	private RectTransform rect;

	private Transform oldSlot;
	private Text _valueText;

	private Transform FirstParent;


	void Start () 
	{
		FirstParent = transform.parent;

		rect = GetComponent<RectTransform> ();
		rectDrag = GameObject.FindWithTag ("DragItem").GetComponent<RectTransform>();
	}

	public void OnBeginDrag(PointerEventData data)
	{
		oldSlot = transform.parent;
		if (oldSlot != null) {

		}
		rect.SetParent (rectDrag.transform);
		GetComponent<CanvasGroup> ().blocksRaycasts = false;
		oldSlot.GetComponent<CanvasGroup> ().blocksRaycasts = true;
	}

	public void OnDrag(PointerEventData data)
	{
		Vector2 localPointerPosition;
		if (RectTransformUtility.ScreenPointToLocalPointInRectangle(rectDrag, Input.mousePosition, data.pressEventCamera, out localPointerPosition))
		{
			rect.localPosition = localPointerPosition - pointerOffset;
		}
	}

	public void OnEndDrag(PointerEventData data)
	{
		Transform newSlot = oldSlot;
		GetComponent<CanvasGroup> ().blocksRaycasts = true;

		if (data.pointerEnter != null) {
			newSlot = data.pointerEnter.transform;
			//Debug.Log ("tag new slot  " + newSlot.tag +"   name  " + newSlot.name);
			if (newSlot.tag == "Item" && newSlot != transform) {
				SwapItem (newSlot);
			}
			if (newSlot == null || newSlot.tag != "Slot") {
				newSlot = oldSlot;
			}
		}



		SetSlot (newSlot);
		ParentSlot.Check = true;
		//oldSlot.GetComponent<Slot> ().UpdateSlot ();
		//newSlot.GetComponent<Slot> ().UpdateSlot ();
	}


	void SwapItem(Transform newItem)
	{
		Transform newSlot = newItem;
		newSlot = newSlot.parent;
		if (newSlot != null && newSlot.tag == "Slot") {
			newItem.SetParent (oldSlot);
			newItem.localPosition = Vector2.zero;
			oldSlot = newSlot;
		}

	}



	void SetSlot(Transform newSlot)
	{
		newSlot.GetComponent<CanvasGroup> ().blocksRaycasts = true;
		rect.SetParent (newSlot);
		rect.localPosition = Vector2.zero;
	}

	public void SetOldSlot()
	{
		SetSlot (oldSlot);
	}
	// // // // // доделать
	private void Erase()
	{
		SetSlot (FirstParent);
	}

}
