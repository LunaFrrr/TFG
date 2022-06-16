using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CompleteSentence : MonoBehaviour
{
    public GameObject correctButton, nextButton, gap, complete;
    public Text nPages, correct, sentence1, sentence2, gapText;
    public Text[] wordTexts;

    public PlayFabSelect fabSelect;
    public SelectDay sDay;

    private int nQuestion;

    //Order anwsers 1, 5, 6, 2, 6
    private string[] words1 = { "itchy", "sore", "twisted", "dry", "allergy", "cast" };
    private string[] words2 = { "vomit", "bruise", "flu", "cold", "cough", "rash" };
    private string[] words3 = { "syringe", "fever", "infectious", "recovery", "nurse", "antibiotics" };
    private string[] words4 = { "blood", "runny", "wound", "disease", "alliviate", "surgery" };
    private string[] words5 = { "plaster", "deaf", "dose", "shot", "prescription", "headache" };

    private List<Vector2> initialPos  = new List<Vector2>();
    private bool stopWords;

    // Start is called before the first frame update
    void Start()
    {
        nQuestion = 0;
        nPages.text = "1/5";

        stopWords = false;


        if (sDay.days < 4 && sDay.days != 0)
        {
            Debug.Log("ENTRA IF");
            sDay.days = 4;
            fabSelect.SaveDays();
        }
            

        sentence1.text = "My skin is ";
        sentence2.text = ". I can't stop scratching.";

        for(int i = 0; i < wordTexts.Length; i++)
        {
            wordTexts[i].text = words1[i];
            initialPos.Add(wordTexts[i].transform.position);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (stopWords)
        {
            for(int i = 0; i < wordTexts.Length; i++)
            {
                wordTexts[i].transform.position = initialPos[i];
            }
        }

    }

    public void Correct()
    {
        stopWords = true;
        correctButton.SetActive(false);
        nextButton.SetActive(true);

        for(int i = 0; i < wordTexts.Length; i++)
        {
            if ( wordTexts[i].transform.position.y == gap.transform.position.y)
            {
                Debug.Log("Entra");
                if (nQuestion == 0 && wordTexts[i].text == words1[0])
                {
                    correct.text = "Correct!";
                    gapText.text = wordTexts[i].text;
                    break;
                }


                if (nQuestion == 1 && wordTexts[i].text == words2[4])
                {
                    correct.text = "Correct!";
                    gapText.text = wordTexts[i].text;
                    break;
                }

                if (nQuestion == 2 && wordTexts[i].text == words3[5])
                {
                    correct.text = "Correct!";
                    gapText.text = wordTexts[i].text;
                    break;
                }

                if (nQuestion == 3 && wordTexts[i].text == words4[1])
                {
                    correct.text = "Correct!";
                    gapText.text = wordTexts[i].text;
                    break;
                }

                if (nQuestion == 4 && wordTexts[i].text == words5[5])
                {
                    correct.text = "Correct!";
                    gapText.text = wordTexts[i].text;
                    break;
                }

                gapText.text = wordTexts[i].text;
            }

            else
                correct.text = "Incorrect...";

            
        }


    }

    public void Next()
    {
        nQuestion++;
        nPages.text = (nQuestion + 1) + "/5";
        correctButton.SetActive(true);
        nextButton.SetActive(false);
        correct.text = "";
        gapText.text = "________________";

        stopWords = false;

        for(int i = 0; i < wordTexts.Length; i++)
        {
            wordTexts[i].transform.position = initialPos[i]; 
        }

        if(nQuestion == 1)
        {
            sentence1.text = "You should cover your mouth when you ";
            sentence2.text = ".";

            for (int i = 0; i < wordTexts.Length; i++)
            {
                wordTexts[i].text = words2[i];
            }
            Vector3 temp = new Vector3(310.0f, 0, 0);
            complete.transform.position += temp;
        }

        if (nQuestion == 2)
        {
            sentence1.text = "If you're on ";
            sentence2.text = " you shouldn't drink any alcohol.";

            for (int i = 0; i < wordTexts.Length; i++)
            {
                wordTexts[i].text = words3[i];
            }
            Vector3 temp = new Vector3(-359.0f, 0, 0);
            complete.transform.position += temp;
        }

        if (nQuestion == 3)
        {
            sentence1.text = "She has a ";
            sentence2.text = " nose and a sore throat.";

            for (int i = 0; i < wordTexts.Length; i++)
            {
                wordTexts[i].text = words4[i];
            }
            Vector3 temp = new Vector3(50.0f, 0, 0);
            complete.transform.position += temp;
        }

        if (nQuestion == 4)
        {
            sentence1.text = "I hope Quinn doesn't have a ";
            sentence2.text = " tonight.";
            for (int i = 0; i < wordTexts.Length; i++)
            {
                wordTexts[i].text = words5[i];
            }
            Vector3 temp = new Vector3(175.0f, 0, 0);
            complete.transform.position += temp;
        }

        if (nQuestion > 4)
        {
            correctButton.SetActive(false);
            nPages.text = "5/5";
            StartCoroutine(Wait());

        }
    }

    IEnumerator Wait()
    {
        //To wait, type this:

        //Stuff before waiting
        yield return new WaitForSeconds(1.5f);
        //fade.FadeOut(animatorFade);
        yield return new WaitForSeconds(3.5f);
        //SceneManager.LoadScene("Transition");
    }
}
