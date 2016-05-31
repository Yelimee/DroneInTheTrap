using UnityEngine;
using System.Collections;
using System.Linq;
using System.Security.Policy;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.UI;

public class UIGameController : MonoBehaviour
{
    public Text EngineForceView;
	public Text ScoreLabel; // soryung: for score presentation
    public GameObject RestartButton;
    public GameObject InfoButton;
	public GameObject ExitButton;
    public GameObject InfoPanel;
	public GameObject StartPanel; // soryung: add StartPanel
	public GameObject SuccessPanel; // soryung: add SuccessPanel
	public GameObject FailPanel; // soryung: add FailPanel
	public GameObject joystick;
	public GameObject joystick2;

    private bool startFlag; // soryung: for start panel presentation

	// Use this for initialization
    public static UIGameController runtime;

    private void Awake()
    {
        runtime = this;
    }

    void Start ()
	{
		startFlag = true; // soryung: initial settings
		HideStart (); // soryung: initial settings
		HideFinish (); // soryung: initial settings

		ShowStart(); // soryung: initial settings
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private void ShowInfoPanel(bool isShow)
    {
        EngineForceView.gameObject.SetActive(!isShow);
		ScoreLabel.gameObject.SetActive (!isShow); // soryung: for score presentation
        RestartButton.SetActive(!isShow);
        InfoButton.SetActive(!isShow);
		ExitButton.SetActive (!isShow);

		joystick.SetActive(!isShow);
		joystick2.SetActive(!isShow);

        InfoPanel.SetActive(isShow);
    }

    public void ShowInfo()
    {
        ShowInfoPanel(true);
    }
    public void HideInfo()
    {
        ShowInfoPanel(false);
    }

	private void ShowStartPanel(bool isShow)
	{ // soryung: for showing and hiding StartPanel presentation
		EngineForceView.gameObject.SetActive(!isShow);
		ScoreLabel.gameObject.SetActive (!isShow); 
		RestartButton.SetActive(!isShow);
		InfoButton.SetActive(!isShow);
		ExitButton.SetActive (!isShow);

		joystick.SetActive(!isShow);
		joystick2.SetActive(!isShow);

		StartPanel.SetActive (isShow);
	}

	public void ShowStart()
	{ // soryung: for showing StartPanel presentation
		if (startFlag) 
		{
			ShowStartPanel (true);
			startFlag = false;
		}
	}

	public void HideStart()
	{ // soryung: for hiding StartPanel presentation
		ShowStartPanel (false);
	}

	public void HideFinish()
	{  // soryung: for hiding SuccessPanel and FailPanel presentation
		SuccessPanel.SetActive (false);
		FailPanel.SetActive (false);
	}

    public void RestartGame()
    {
		ScoreManager.score [ScoreManager.scoreIndex] = 0; // soryung: initialize current score
        switch(ScoreManager.scoreIndex)
        {
            case 0:
                SceneManager.LoadScene("stage1");
                break;
            case 1:
                SceneManager.LoadScene("stage2");
                break;
            case 2:
                SceneManager.LoadScene("stage3");
                break;
            case 3:
                SceneManager.LoadScene("stage4");
                break;
            case 4:
                SceneManager.LoadScene("stage5");
                break;
        }  
    }

	public void GoSelectStage()
	{
		ScoreManager.score [ScoreManager.scoreIndex] = 0;
		SceneManager.LoadScene ("selectStage");
	}
}
