using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Reading : MonoBehaviour
{
   
    [SerializeField] private Toggle toggle1, toggle2, toggle3, toggle4;
    public ToggleGroup tGroup;
    public Text question;
    public Text answer1;
    public Text answer2;
    public Text answer3;
    public Text answer4;
    public Text pages;
    public GameObject buttonQuestion;
    public GameObject buttonCorrect;
    public GameObject blackPanel;
    public Animator animatorFade;
    public FadeInOut fade;
    public Image panelFade;

   // public Animator animatorFadeOut;
    private Animator animatorBook;

    //Orden de las respuetas correctas 3, 3, 4, 1
    private string final1;
    private string final2;
    private string final3;
    private string final4;

    private string question1 = "Question 1";
    private string question2 = "Question 2";
    private string question3 = "Question 3";
    private string question4 = "Question 4";

    private string answer1q1 = "Answer 1.1";
    private string answer2q1 = "Answer 1.2";
    private string answer3q1 = "Answer 1.3";
    private string answer4q1 = "Answer 1.4";

    private string answer1q2 = "Answer 2.1";
    private string answer2q2 = "Answer 2.2";
    private string answer3q2 = "Answer 2.3";
    private string answer4q2 = "Answer 2.4";

    private string answer1q3 = "Answer 3.1";
    private string answer2q3 = "Answer 3.2";
    private string answer3q3 = "Answer 3.3";
    private string answer4q3 = "Answer 3.4";

    private string answer1q4 = "Answer 4.1";
    private string answer2q4 = "Answer 4.2";
    private string answer3q4 = "Answer 4.3";
    private string answer4q4 = "Answer 4.4";

    // Start is called before the first frame update
    void Start()
    {
        fade.FadeIn(animatorFade);
        buttonCorrect.SetActive(true);
        buttonQuestion.SetActive(false);

        pages.text = "1/4";
        question.text = question1;
        answer1.text = answer1q1;
        answer2.text = answer2q1;
        answer3.text = answer3q1;
        answer4.text = answer4q1;

        animatorBook = GetComponent<Animator>();
        animatorBook.SetBool("Enter", true);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void NextQuestion()
    {
        toggle1.enabled = true;
        toggle2.enabled = true;
        toggle3.enabled = true;
        toggle4.enabled = true;

        buttonQuestion.SetActive(false);
        buttonCorrect.SetActive(true);

        if (question.text == question1)
        {
            toggle1.image.color = Color.white;
            toggle2.image.color = Color.white;
            toggle3.image.color = Color.white;
            toggle4.image.color = Color.white;

            question.text = question2;
            answer1.text = answer1q2;
            answer2.text = answer2q2;
            answer3.text = answer3q2;
            answer4.text = answer4q2;
            pages.text = "2/4";

        }

        else if (question.text == question2)
        {
            toggle1.image.color = Color.white;
            toggle2.image.color = Color.white;
            toggle3.image.color = Color.white;
            toggle4.image.color = Color.white;

            question.text = question3;
            answer1.text = answer1q3;
            answer2.text = answer2q3;
            answer3.text = answer3q3;
            answer4.text = answer4q3;
            pages.text = "3/4";
        }

        else if (question.text == question3)
        {
            toggle1.image.color = Color.white;
            toggle2.image.color = Color.white;
            toggle3.image.color = Color.white;
            toggle4.image.color = Color.white;

            question.text = question4;
            answer1.text = answer1q4;
            answer2.text = answer2q4;
            answer3.text = answer3q4;
            answer4.text = answer4q4;
            pages.text = "4/4";
        }

        else if (question.text == question4)
        {
            buttonCorrect.SetActive(false);
            animatorBook.SetBool("Exit", true);
            StartCoroutine(Wait());
        }

    }


    public string toggleSelected()
    {
        if (toggle1.isOn)
        {
            return answer1.text;
        }

        else if (toggle2.isOn)
            return answer2.text;

        else if (toggle3.isOn)
            return answer3.text;

        else
            return answer4.text;
    }

    public void correctAnwser()
    {
        buttonCorrect.SetActive(false);
        buttonQuestion.SetActive(true);

        toggle1.enabled = false;
        toggle2.enabled = false;
        toggle3.enabled = false;
        toggle4.enabled = false;

        if (question.text == question1)
        {
            final1 = toggleSelected();
            toggle3.image.color = Color.green;

            if(answer1.text == final1)
            {
                toggle1.image.color = Color.red;
            }

            if (answer2.text == final1)
            {
                toggle2.image.color = Color.red;
            }

            if (answer4.text == final1)
            {
                toggle4.image.color = Color.red;
            }
        }


        else if (question.text == question2)
        {
            final2 = toggleSelected();
            toggle3.image.color = Color.green;

            if (answer1.text == final2)
            {
                toggle1.image.color = Color.red;
            }

            if (answer2.text == final2)
            {
                toggle2.image.color = Color.red;
            }

            if (answer4.text == final2)
            {
                toggle4.image.color = Color.red;
            }
        }

        else if (question.text == question3)
        {
            final3 = toggleSelected();
            toggle4.image.color = Color.green;

            if (answer1.text == final3)
            {
                toggle1.image.color = Color.red;
            }

            if (answer2.text == final3)
            {
                toggle2.image.color = Color.red;
            }

            if (answer3.text == final3)
            {
                toggle3.image.color = Color.red;
            }
        }

        else if (question.text == question4)
        {
            final4 = toggleSelected();
            toggle1.image.color = Color.green;

            if (answer2.text == final4)
            {
                toggle2.image.color = Color.red;
            }

            if (answer3.text == final4)
            {
                toggle3.image.color = Color.red;
            }

            if (answer4.text == final4)
            {
                toggle4.image.color = Color.red;
            }

            
        }

    }

    IEnumerator Wait()
    {
        //To wait, type this:

        //Stuff before waiting
        yield return new WaitForSeconds(1.5f);
        fade.FadeOut(animatorFade);
    }

}
