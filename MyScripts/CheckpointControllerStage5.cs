using UnityEngine;
using System.Collections;
using System.Linq;
using System.Security.Policy;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.UI;

public class CheckpointControllerStage5 : MonoBehaviour
{
    public Checkpoint[] CheckpointsList;
    public LookAtTargetController Arrow;

    public HelicopterController5 heli;

    public Checkpoint CurrentCheckpoint;
    private int CheckpointId;

    public GameObject SuccessPanel; // soryung: for success panel presentation
    public GameObject FailPanel; // soryung: for fail panel presentation
	public GameObject joystick;
	public GameObject joystick2;
	public GameObject ExitButton;

    // Use this for initialization
    void Start()
    {
        if (CheckpointsList.Length == 0) return;

        for (int index = 0; index < CheckpointsList.Length; index++)
            CheckpointsList[index].gameObject.SetActive(false);

        CheckpointId = 0;
        SetCurrentCheckpoint(CheckpointsList[CheckpointId]);
        ScoreManager.scoreIndex = 4; // soryung: for setting index of score array
    }

    IEnumerator sDelayTime(float waitTime)
    {
        yield return new WaitForSeconds(1.0f);
        SuccessPanel.SetActive(true);
        yield return new WaitForSeconds(1.0f);
        //SuccessPanel.SetActive(false);
        // CertificatePanel.SetActive(true);
        SceneManager.LoadScene("certification");
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

            // soryung: for program end
            if (CheckpointId == 6)
            {
                heli.EngineForce = 0f;
                // soryung: for presenting panel
                if (ScoreManager.score[ScoreManager.scoreIndex] >= ScoreManager.scoreLimit)
                {
                    //SuccessPanel.SetActive (true);

					joystick.SetActive (false);
					joystick2.SetActive (false);
					ExitButton.SetActive (false);

                    StartCoroutine(sDelayTime(3.0f));
                    //SuccessPanel.SetActive (false);
                    //CertificatePanel.SetActive (true);
                    // SceneManager.LoadScene("selectStage"); // soryung: need to change into "main stage"

                }
                else
                {
                    FailPanel.SetActive(true);
                    
					joystick.SetActive (false);
					joystick2.SetActive (false);
					ExitButton.SetActive (false);

					StartCoroutine(fDelayTime(3.0f));
                    // SceneManager.LoadScene("selectStage");
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
        switch (CheckpointId)
        {
            case 0:
                ScoreManager.score[ScoreManager.scoreIndex] += 10; // soryung: straight up score
                break;
            case 1:
            case 2:
            case 3:
            case 4:
            case 5:
                //default:
                ScoreManager.score[ScoreManager.scoreIndex] += 18; // soryung: others' score
                break;
        }

        CheckpointId++;
        if (CheckpointId >= CheckpointsList.Length)
        {
            CurrentCheckpoint.gameObject.SetActive(false);
            CurrentCheckpoint.CheckpointActivated -= CheckpointActivated;
            Arrow.gameObject.SetActive(false);
            return;
        }

        SetCurrentCheckpoint(CheckpointsList[CheckpointId]);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
