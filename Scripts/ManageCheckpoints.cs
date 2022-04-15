using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageCheckpoints : MonoBehaviour
{
    public List<Checkpoint> checkpointList; // List for checkpoints

    private Checkpoint checkpoint; // reference checkpoint class

    [SerializeField] private List<Transform> racecarList; // List of cars
    private List<int> nextCheckpointList; // index for the next checkpoint to go to
    //private List<int> nextCheckpointIndexList;

    public event EventHandler PlayerCorrectCheckpoint;
    public event EventHandler PlayerWrongCheckpoint;

    private void Awake()
    {
        foreach(Checkpoint checkpoint in checkpointList)
        {
            checkpoint.SetCheckpoints(this);
        }
        nextCheckpointList = new List<int>();
        foreach(Transform racecar in racecarList)
        {
            nextCheckpointList.Add(0);
        }
        //nextCheckpointList = 0;
    }

    public void RacerCollision(Checkpoint checkpoint, Transform racecar)
    {
        int nextCheckpointIndex = nextCheckpointList[racecarList.IndexOf(racecar)];
        if(checkpointList.IndexOf(checkpoint) == nextCheckpointIndex) // correct checkpoint
        {
            Debug.Log("Correct");

            nextCheckpointList[racecarList.IndexOf(racecar)] = (nextCheckpointIndex + 1) % checkpointList.Count;

            Debug.Log(nextCheckpointIndex);

            PlayerCorrectCheckpoint?.Invoke(this, EventArgs.Empty);
        }
        else // wrong checkpoint
        {
            Debug.Log("Wrong");

            PlayerWrongCheckpoint?.Invoke(this, EventArgs.Empty);

            Debug.Log(nextCheckpointIndex);
        }
       // Debug.Log(checkpoint.transform.name);
    }
}
