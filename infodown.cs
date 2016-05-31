using UnityEngine;
using System.Collections;

public class infodown : MonoBehaviour {
	public GameObject InfoDisplay;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown()
	{
		//this.enabled = false;
		InfoDisplay.SetActive(false);
	}
}
