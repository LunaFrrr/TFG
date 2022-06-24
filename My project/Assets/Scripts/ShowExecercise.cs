using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowExecercise : MonoBehaviour
{
    public DialogueManager dManager;
    public GameObject panel, dialogue;

    // Update is called once per frame
    void Update()
    {
        if (dManager.end)
        {
            dialogue.SetActive(false);
            panel.SetActive(true);
        }

    }
}
