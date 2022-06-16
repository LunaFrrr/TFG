using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Listening : MonoBehaviour
{
    private string[] sentences = {"dessert", "vegeterian", "the menu", "waitress", "hot chocolate", "hot chocolate", "cup of tea", "to book a table", "is this chair taken?", "can i take your order?", "can we have the bill please?" };
    private int nQuestion;

    public ControlAudio controlAudio;
    public InputField inputField;
    public GameObject nextButton;
    public GameObject correctButton;
    public Text correct;
    public Text nPages;
    public Animator animatorFade;
    public FadeInOut fade;

    public PlayFabSelect fabSelect;
    public SelectDay sDay;

    // Start is called before the first frame update
    void Start()
    {
        nQuestion = 0;
        fade.FadeIn(animatorFade);


        if (sDay.days < 2 && sDay.days != 0)
        {
            sDay.days = 2;
            Debug.Log("Antes de guardar es " + sDay.days);
            fabSelect.SaveDays();
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Correct()
    {
        
        correctButton.SetActive(false);
        nextButton.SetActive(true);

        inputField.enabled = false;

        if (sentences[nQuestion] == inputField.text.ToLower())
        {
            correct.text = "Correct!";
        }

        else
        {
            correct.text = "Incorrect...";
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

        if(nQuestion > 9)
        {
            correctButton.SetActive(false);
            nPages.text = "10/10";
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
}
