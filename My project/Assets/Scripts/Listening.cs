using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using PlayFab;
using PlayFab.ClientModels;

public class Listening : MonoBehaviour
{
    private string[] sentences = {"dessert", "vegeterian", "the menu", "waitress", "hot chocolate", "cup of tea", "to book a table", "is this chair taken?", "can i take your order?", "can we have the bill please?" };
    private int nQuestion;

    public ControlAudio controlAudio;
    public InputField inputField;
    public GameObject nextButton, correctButton, pauseMenu;
    public Text correct, nPages, inputText;
    public Animator animatorFade, animatorBook;
    public FadeInOut fade;

    public PlayFabSelect fabSelect;
    public PlayFabLeaderboard fabLeader;
    public SelectDay sDay;
    public DialogueManager dialogueManager;

    public int correctAnswers;

    // Start is called before the first frame update
    void Start()
    {
        nQuestion = 0;
        animatorBook.SetBool("Enter", true);

        if (sDay.days < 2 && sDay.days != 0)
        {
            sDay.days = 2;
            Debug.Log("Antes de guardar es " + sDay.days);
            fabSelect.SaveDays();
        }

        correctAnswers = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseMenu.SetActive(true);
        }

    }

    public void Correct()
    {
        
        correctButton.SetActive(false);
        nextButton.SetActive(true);

        inputField.enabled = false;

        if (sentences[nQuestion] == inputField.text.ToLower())
        {
            correct.text = "Correct!";
            correctAnswers++;
            inputText.color = new Color(0.05677315f, 0.3867925f, 0.02335349f);
        }

        else
        {
            correct.text = "Incorrect...";
            inputText.color = Color.red;
        }
        
    }

    public void Next()
    {
        nQuestion++;
        nPages.text = (nQuestion + 1) + "/10";
        inputField.enabled = true;
        correctButton.SetActive(true);
        nextButton.SetActive(false);
        correct.text = "";
        inputField.text = "";
        inputText.color = new Color(0.196f, 0.196f, 0.196f);

        if (nQuestion > 9)
        {
            correctButton.SetActive(false);
            nPages.text = "10/10";
            animatorBook.SetBool("Exit", true);
            fabLeader.SendLeaderboardListening(correctAnswers);
            SaveCorrectListening();
            
            StartCoroutine(Wait());

        }
    }

    public void PlaySound()
    {
        controlAudio.SelectAudio(nQuestion);
    }

    IEnumerator Wait()
    {
        //To wait, type this:

        //Stuff before waiting
        yield return new WaitForSeconds(1.5f);
        fade.FadeOut(animatorFade);
        yield return new WaitForSeconds(3.5f);
        SceneManager.LoadScene("Day 3 - Library");
    }

    public void SaveCorrectListening()
    {
        var request = new UpdateUserDataRequest
        {
            Data = new Dictionary<string, string>
            {
                {"CorrectAnswersListening", correctAnswers.ToString() },
            }
        };
        PlayFabClientAPI.UpdateUserData(request, OnDataSend, OnError);
    }

    void OnDataSend(UpdateUserDataResult result)
    {
        Debug.Log("Succesfull user data send!");
    }

    public void OnError(PlayFabError error)
    {
        Debug.Log("OnERROR");
    }

}
