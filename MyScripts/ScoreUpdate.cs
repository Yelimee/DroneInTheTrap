// made by Soryung Lee
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreUpdate : MonoBehaviour {
	Text ScoreLabel;
	// Use this for initialization
	void Start () {
		ScoreLabel = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		ScoreLabel.text = "Score : "+ ScoreManager.score[ScoreManager.scoreIndex].ToString () ;
		Debug.Log ("Score Update");
	}
}
