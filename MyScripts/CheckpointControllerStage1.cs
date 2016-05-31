using UnityEngine;
using System.Collections;
using System.Linq;
using System.Security.Policy;
using UnityEngine.SceneManagement;
using System;

public class CheckpointControllerStage1 : MonoBehaviour
{
    public Checkpoint[] CheckpointsList;
    public LookAtTargetController Arrow;

    public Checkpoint CurrentCheckpoint;
    private int CheckpointId;

	public GameObject SuccessPanel; // soryung: for success panel presentation
	public GameObject FailPanel; // soryung: for fail panel presentation
	public GameObject joystick;
	public GameObject joystick2;
	public GameObject ExitButton;

    void Start ()
	{
        if (CheckpointsList.Length==0) return;

	    for (int index = 0; index < CheckpointsList.Length; index++)
            CheckpointsList[index].gameObject.SetActive(false);

	    CheckpointId = 0;
        SetCurrentCheckpoint(CheckpointsList[CheckpointId]);
		ScoreManager.scoreIndex = 0; // soryung: for setting index of score array
    }

    IEnumerator sDelayTime(float waitTime)
    {
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene("selectStage");
    }

    IEnumerator fDelayTime(float waitTime)
    {
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene("stage1");
    }

    private void SetCurrentCheckpoint(Checkpoint checkpoint)
    {
        if (CurrentCheckpoint != null)
        {
            CurrentCheckpoint.gameObject.SetActive(false);
            CurrentCheckpoint.CheckpointActivated -= CheckpointActivated;
            if (CheckpointId == 2)
            {
                CurrentCheckpoint.gameObject.SetActive(true);
                CurrentCheckpoint.CheckpointActivated -= CheckpointActivated;
            }
            else if (CheckpointId == 3)
            {          
                CheckpointsList[1].gameObject.SetActive(false);
                CurrentCheckpoint.CheckpointActivated -= CheckpointActivated;

                CurrentCheckpoint.gameObject.SetActive(false);
                CurrentCheckpoint.CheckpointActivated -= CheckpointActivated;

				// soryung: for presenting panel
				if (ScoreManager.score [ScoreManager.scoreIndex] >= ScoreManager.scoreLimit) {
                    SuccessPanel.SetActive (true);

					joystick.SetActive (false);
					joystick2.SetActive (false);
					ExitButton.SetActive (false);
                    
					StartCoroutine(sDelayTime(3.0f));
                    // SceneManager.LoadScene("selectStage");
                    SingleTon.getInstance.reached1 = 1;
                }
                else {
					FailPanel.SetActive (true);

					joystick.SetActive (false);
					joystick2.SetActive (false);
					ExitButton.SetActive (false);

                    StartCoroutine(fDelayTime(3.0f));
                   // SceneManager.LoadScene("stage1");
                }
            }
            
        }

        CurrentCheckpoint = checkpoint;
        CurrentCheckpoint.CheckpointActivated += CheckpointActivated;
        Arrow.Target = CurrentCheckpoint.transform;
        CurrentCheckpoint.gameObject.SetActive(true);
    }

    private void StartCoroutine(Func<IEnumerator> delayTime)
    {
        throw new NotImplementedException();
    }

    private void CheckpointActivated()
    {
		// soryung: for updating score
		if (CheckpointId == 0) {
			ScoreManager.score [ScoreManager.scoreIndex] += 30; // soryung: straight up score 
		} else if (CheckpointId == 1) {
			ScoreManager.score [ScoreManager.scoreIndex] += 35; // soryung: rotate on the present place
		} else { // soryung: CheckpointId == 2
			ScoreManager.score [ScoreManager.scoreIndex] += 35; // soryung: straight down score
		}

        CheckpointId++;
		if (CheckpointId >= CheckpointsList.Length) {
			CurrentCheckpoint.gameObject.SetActive (false);
			CurrentCheckpoint.CheckpointActivated -= CheckpointActivated;
			Arrow.gameObject.SetActive (false);
			return;
		}

        SetCurrentCheckpoint(CheckpointsList[CheckpointId]);
    }

    // Update is called once per frame
	void Update () {
	
	}
}
