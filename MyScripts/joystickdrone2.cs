using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class joystickdrone2 : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler {

	private Image bgImg2;
	private Image joystickImg2;
	private Vector3 inputVector;

	private void Start()
	{
		bgImg2 = GetComponent<Image> ();
		joystickImg2 = transform.GetChild (0).GetComponent<Image> ();
	}

	public virtual void OnDrag(PointerEventData ped)
	{
		Vector2 pos;
		if(RectTransformUtility.ScreenPointToLocalPointInRectangle(bgImg2.rectTransform
			, ped.position, ped.pressEventCamera, out pos))
		{
			pos.x = (pos.x / bgImg2.rectTransform.sizeDelta.x);
			pos.y = (pos.y / bgImg2.rectTransform.sizeDelta.y);

			inputVector = new Vector3 (pos.x, 0, pos.y);
			inputVector = (inputVector.magnitude > 1.0f) ? inputVector.normalized : inputVector;
		

			// Move Joystick IMG
			joystickImg2.rectTransform.anchoredPosition =
				new Vector3 (inputVector.x * (bgImg2.rectTransform.sizeDelta.x/2)
					, inputVector.z * (bgImg2.rectTransform.sizeDelta.y/2));

		}
	}

	public virtual void OnPointerDown(PointerEventData ped)
	{
		OnDrag (ped);
	}

	public virtual void OnPointerUp(PointerEventData ped)
	{
		inputVector = Vector3.zero;
		joystickImg2.rectTransform.anchoredPosition = Vector3.zero;

	}

	public float Horizontal()
	{
		if (inputVector.x != 0)
			return inputVector.x;
		else
			return Input.GetAxis ("Horizontal");
	}

	public float Vertical()
	{
		if (inputVector.z != 0)
			return inputVector.z;
		else
			return Input.GetAxis ("Vertical");
	}
}
