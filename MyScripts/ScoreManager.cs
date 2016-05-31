// made by Soryung Lee
using UnityEngine;
using System.Collections;

public class ScoreManager : MonoBehaviour {
	public static int[] score = new int[5];
	public static int scoreIndex = 0;
	public static int scoreLimit = 60;

	// Use this for initialization
	void Start () {
		for (int i = 0; i < 5; i++) {
			score[i] = 0;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
