using UnityEngine;
using System.Collections;
using System.Linq;
using System.Security.Policy;
using UnityEngine.SceneManagement;

public class CheckpointControllerStage3 : MonoBehaviour
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

	// Use this for initialization
	void Start ()
	{
        if (CheckpointsList.Length==0) return;

	    for (int index = 0; index < CheckpointsList.Length; index++)
            CheckpointsList[index].gameObject.SetActive(false);

	    CheckpointId = 0;
        SetCurrentCheckpoint(CheckpointsList[CheckpointId]);
		ScoreManager.scoreIndex = 2; // soryung: for setting index of score array
	}

    IEnumerator sDelayTime(float waitTime)
    {
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene("selectStage");
    }

    IEnumerator fDelayTime(float waitTime)
    {
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene("stage5");
    }

    private void SetCurrentCheckpoint(Checkpoint checkpoint)
    {
        if (CurrentCheckpoint != null)
        {
            
            CurrentCheckpoint.gameObject.SetActive(false);
            CurrentCheckpoint.CheckpointActivated -= CheckpointActivated;

            if (CheckpointId == 6)
            {
                CurrentCheckpoint.gameObject.SetActive(false);
                CurrentCheckpoint.CheckpointActivated -= CheckpointActivated;

				// soryung: for presenting panel
				if (ScoreManager.score [ScoreManager.scoreIndex] >= ScoreManager.scoreLimit) {
					SuccessPanel.SetActive (true);

					joystick.SetActive (false);
					joystick2.SetActive (false);
					ExitButton.SetActive (false);

                    StartCoroutine(sDelayTime(3.0f));
                    //SceneManager.LoadScene("selectStage");
                    SingleTon.getInstance.reached3 = 3;
                }
                else {
					FailPanel.SetActive (true);

					joystick.SetActive (false);
					joystick2.SetActive (false);
					ExitButton.SetActive (false);

                    StartCoroutine(fDelayTime(3.0f));
                    //SceneManager.LoadScene("selectStage");
                }
            }
        }

        CurrentCheckpoint = checkpoint;
        CurrentCheckpoint.CheckpointActivated += CheckpointActivated;
        Arrow.Target = CurrentCheckpoint.transform;
        CurrentCheckpoint.gameObject.SetActive(true);

    }

    private void CheckpointActivated()
    {
		// soryung: for updating score
		switch (CheckpointId) {
		case 0:
		case 5: 
			ScoreManager.score [ScoreManager.scoreIndex] += 10; // soryung: straight up and down score
			break;
		case 1:
		case 2:
		case 3:
		case 4:
			ScoreManager.score [ScoreManager.scoreIndex] += 20; // soryung: (go and back) * (up and down) score
			break;
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
