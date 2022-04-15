using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrongCheckpointHUD : MonoBehaviour
{
    [SerializeField] private ManageCheckpoints manageCheckpoints;

    // Start is called before the first frame update
    void Start()
    {
        manageCheckpoints.PlayerCorrectCheckpoint += ManageCheckpoints_PlayerCorrectCheckpoint;
        manageCheckpoints.PlayerWrongCheckpoint += ManageCheckpoints_PlayerWrongCheckpoint;

        Hide();
    }

    private void ManageCheckpoints_PlayerWrongCheckpoint(object sender, System.EventArgs e)
    {
        Show();
    }

    private void ManageCheckpoints_PlayerCorrectCheckpoint (object sender, System.EventArgs e)
    {
        Hide();
    }

    private void Show()
    {
        gameObject.SetActive(true);
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }
}
