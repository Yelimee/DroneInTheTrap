using UnityEngine;
using System.Collections;
using System.Linq;
using System.Security.Policy;

public class CheckpointController : MonoBehaviour
{
    public Checkpoint[] CheckpointsList;
    public LookAtTargetController Arrow;

    private Checkpoint CurrentCheckpoint;
    private int CheckpointId;

	// Use this for initialization
	void Start ()
	{
        if (CheckpointsList.Length==0) return;

	    for (int index = 0; index < CheckpointsList.Length; index++)
            CheckpointsList[index].gameObject.SetActive(false);

	    CheckpointId = 0;
        SetCurrentCheckpoint(CheckpointsList[CheckpointId]);
	}

    private void SetCurrentCheckpoint(Checkpoint checkpoint)
    {
        if (CurrentCheckpoint != null)
        {
            //			CheckpointId %= 3;
            //			int loopId = CheckpointId % 3;
            //			int loop = CheckpointId / 3;
            //			CurrentCheckpoint.gameObject.SetActive(false);
            //			CurrentCheckpoint.CheckpointActivated -= CheckpointActivated;

            //			if (CheckpointId == 1) {
            //				CurrentCheckpoint.gameObject.SetActive (false);
            //				CurrentCheckpoint.CheckpointActivated -= CheckpointActivated;
            //			} 
            CurrentCheckpoint.gameObject.SetActive(false);
            CurrentCheckpoint.CheckpointActivated -= CheckpointActivated;
            if (CheckpointId == 7) {
				CurrentCheckpoint.gameObject.SetActive (true);
				CurrentCheckpoint.CheckpointActivated -= CheckpointActivated;
			}
            else if (CheckpointId == 8) {
//			else if (loopId == 0) {
				
				CheckpointsList [6].gameObject.SetActive (false);
				CurrentCheckpoint.CheckpointActivated -= CheckpointActivated;

				CurrentCheckpoint.gameObject.SetActive (false);
				CurrentCheckpoint.CheckpointActivated -= CheckpointActivated;
			}
        }

        CurrentCheckpoint = checkpoint;
        CurrentCheckpoint.CheckpointActivated += CheckpointActivated;
        Arrow.Target = CurrentCheckpoint.transform;
        CurrentCheckpoint.gameObject.SetActive(true);
    }

    private void CheckpointActivated()
    {
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
