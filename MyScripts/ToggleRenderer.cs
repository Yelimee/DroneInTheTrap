// made by soryung
// for rendering to toggle text

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ToggleRenderer : MonoBehaviour {
	public Text TouchScreen;

	// Use this for initialization
	void Start () {
		TouchScreen.enabled = true;
	}

	// Toggle the Object's visibility each second.
	void Update () {
		// Find out whether current second is odd or even
		bool oddeven = Mathf.FloorToInt(Time.time) % 2 == 0;

		// Enable renderer accordingly
		TouchScreen.enabled = oddeven;
	}
}
