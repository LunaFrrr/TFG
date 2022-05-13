using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Reading : MonoBehaviour
{
    public Text question;
    public Text answer1;
    public Text answer2;
    public Text answer3;
    public Text answer4;
    public Text pages;

    private int correctAnswers;

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
        correctAnswers = 0;

        pages.text = "1/4";
        question.text = question1;
        answer1.text = answer1q1;
        answer2.text = answer2q1;
        answer3.text = answer3q1;
        answer4.text = answer4q1;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void NextQuestion()
    {
        if(question.text == question1)
        {
            question.text = question2;
            answer1.text = answer1q2;
            answer2.text = answer2q2;
            answer3.text = answer3q2;
            answer4.text = answer4q2;
            pages.text = "2/4";
        }
        if (question.text == question2)
        {
            question.text = question3;
            answer1.text = answer1q3;
            answer2.text = answer2q3;
            answer3.text = answer3q3;
            answer4.text = answer4q3;
            pages.text = "3/4";
        }
        if (question.text == question3)
        {
            question.text = question4;
            answer1.text = answer1q4;
            answer2.text = answer2q4;
            answer3.text = answer3q4;
            answer4.text = answer4q4;
            pages.text = "4/4";
        }
        if (question.text == question4)
        {
            //backButton.hide();
        }
    }
}
