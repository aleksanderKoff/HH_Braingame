using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuConfirmPanel : MonoBehaviour
{
    public GameObject confirmationPanel;

    public void enableConfirmation()
    {
        confirmationPanel.SetActive(true);
    }
    public void disableConfirmation()
    {
        confirmationPanel.SetActive(false);
    }
}
