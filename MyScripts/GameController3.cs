using UnityEngine;
using System.Collections;

public class GameController3 : MonoBehaviour {

    public HelicopterController3 helli;

    private bool gameStart;
    private int timeChecker;

    // Use this for initialization
    void Start () {

        timeChecker = 0;
	}
	
	// Update is called once per frame
	void Update () {

        if (helli.IsOnGround == false)
            gameStart = true;

        if (gameStart == true && helli.IsOnGround == true)
        {
            Time.timeScale = 0;
            gameStart = false;
        }

        if (Time.timeScale == 0)
            timeChecker++;

        if(timeChecker == 60)
        {
            Time.timeScale = 0.7f;
            timeChecker = 0;
        }

	}
}
