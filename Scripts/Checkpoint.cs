using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private ManageCheckpoints manageCheckpoints;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<CarController>(out CarController player))
        {
            manageCheckpoints.RacerCollision(this, other.transform);
            //Debug.Log("Checkpoint");
        }
    }

    public void SetCheckpoints(ManageCheckpoints manageCheckpoints)
    {
        this.manageCheckpoints = manageCheckpoints;
    }
}
