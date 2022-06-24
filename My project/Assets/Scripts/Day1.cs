using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Day1 : MonoBehaviour
{
    public GameObject pauseMenu;
    public DialogueManager dialogueManager;
    public FadeInOut fade;
    public Animator animatorFade;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseMenu.SetActive(true);
        }

        if (dialogueManager.end)
        {
            StartCoroutine(Wait());
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1.0f);
        fade.FadeOut(animatorFade);
        yield return new WaitForSeconds(3.5f);
        SceneManager.LoadScene("Day 2 - Cafe");
    }

}
