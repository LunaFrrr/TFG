using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Reading : MonoBehaviour
{
   
    [SerializeField] private Toggle toggle1, toggle2, toggle3, toggle4;
    public ToggleGroup tGroup;
    public Text question, answer1, answer2, answer3, answer4, pages, text, read;
    public GameObject buttonQuestion, buttonCorrect, blackPanel, pauseMenu;
    public Animator animatorFade;
    public FadeInOut fade;
    public Image panelFade;
    public PlayFabControls playFabManager;

    public SelectDay sDay;
    public PlayFabSelect fabSelect;

   // public Animator animatorFadeOut;
    private Animator animatorBook;

    //Orden de las respuetas correctas 3, 3, 4, 1
    private string final1;
    private string final2;
    private string final3;
    private string final4;

    private string question1 = "Why doesn’t Alicia drink from the bottle in the first place?";
    private string question2 = "Where does Oliver want to be sent?";
    private string question3 = "Which is the meaning of success for Mr Knightley?";
    private string question4 = "Who does his mother blame for her son not passing the examination for the ordinary degree?";

    private string answer1q1 = "Because her friends taught her not to.";
    private string answer2q1 = "Because she would end up eaten by wild beasts.";
    private string answer3q1 = "Because it could be marked as poison.";
    private string answer4q1 = "Because she was in a hurry.";

    private string answer1q2 = "Back to the orphan.";
    private string answer2q2 = "With Mr Bumble.";
    private string answer3q2 = "Back to the place where they might possibly hit him.";
    private string answer4q2 = "Far away from the orphan.";

    private string answer1q3 = "Making a lucky guess.";
    private string answer2q3 = "Making a match.";
    private string answer3q3 = "Plan how to achieve something.";
    private string answer4q3 = "Try hard to achieve something.";

    private string answer1q4 = "The examiners.";
    private string answer2q4 = "Monsieur Bovary.";
    private string answer3q4 = "Herself.";
    private string answer4q4 = "Her son.";

    private int correct;

    // Start is called before the first frame update
    void Start()
    {
        fade.FadeIn(animatorFade);
        buttonCorrect.SetActive(true);
        buttonQuestion.SetActive(false);


        if (sDay.days < 3 && sDay.days != 0)
        {
            sDay.days = 3;
            fabSelect.SaveDays();
        }

        read.text = "ALICE'S ADVENTURES IN WONDERLAND";

        text.text = "This time she found a little bottle on it, ('which certainly was not here before,' said"
            + " Alice,) and round the neck of the bottle was a paper label, with the words 'DRINK ME' beautifully printed on"
            + " it in large letters.\n It was all very well to say 'Drink me,' but the wise little Alice was not going to do THAT"
            + " in a hurry. 'No, I'll look first,' she said, 'and see whether it's marked \"poison\" or not'; for she had read"
            + " several nice little histories about children who had got burnt, and eaten up by wild beasts and other unpleasant"
            + " things, all because they WOULD not remember the simple rules their friends had taught them: such as, that a red"
            + "- hot poker will burn you if you hold it too long; and that if you cut your finger VERY deeply with a knife, it"
            + " usually bleeds; and she had never forgotten that, if you drink much from a bottle marked 'poison,' it is almost"
            + " certain to disagree with you, sooner or later.";

        pages.text = "1/4";
        question.text = question1;
        answer1.text = answer1q1;
        answer2.text = answer2q1;
        answer3.text = answer3q1;
        answer4.text = answer4q1;

        animatorBook = GetComponent<Animator>();
        animatorBook.SetBool("Enter", true);

        correct = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseMenu.SetActive(true);
        }
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
            read.text = "OLIVER TWIST";

            text.text = "Oliver fell on his knees, and clasping his hands together, prayed that they would order him back to the "
                + "dark room—that they would starve him—beat him—kill him if they pleased— rather than send him away with that "
                + "dreadful man. 'Well!' said Mr. Bumble, raising his hands and eyes with most impressive solemnity. 'Well! of all "
                + "the artful and designing orphans that ever I see, Oliver, you are one of the most barefacedest.'\n 'Hold your "
                + "tongue, Beadle,' said the second old gentleman, when Mr. Bumble had given vent to this compound adjective.";

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
            read.text = "EMMA";

            text.text = "‘I do not understand what you mean by ‘success,’’ said Mr Knightley. ‘Success supposes endeavour. "
                + "Your time has been properly and delicately spent, if you have been endeavouring for the last four years to "
                + "bring about this marriage. A worthy employment for a young lady’s mind! But if, which I rather imagine, your "
                + "making the match, as you call it, means only your planning it, you're saying to yourself one idle day, ‘I "
                + "think it would be a very good thing for Miss Taylor if Mr Weston were to marry her,’ and saying it again to "
                + "yourself every now and then afterwards, why do you talk of success? Where is your merit? What are you proud of? "
                + "You made a lucky guess; and that is all that can be said.";

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
            read.text = "MADAME BOVARY";

            text.text = "Thanks to these preparatory labours, he failed completely in his examination for an ordinary degree. "
                + "He was expected home the same night to celebrate his success. He started on foot, stopped at the beginning "
                + "of the village, sent for his mother, and told her all. She excused him, threw the blame of his failure on "
                + "the injustice of the examiners, encouraged him a little, and took upon herself to set matters straight. It "
                + "was only five years later that Monsieur Bovary knew the truth; it was old then, and he accepted it. " 
                + "Moreover, he could not believe that a man born of him could be a fool.";

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
            playFabManager.SendLeaderboardReading(correct);
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

            if (answer3.text == final1)
                correct++;
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

            if (answer3.text == final2)
                correct++;
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

            if (answer4.text == final3)
                correct++;
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

            if (answer1.text == final4)
                correct++;

            
        }

    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1.5f);
        fade.FadeOut(animatorFade);
        yield return new WaitForSeconds(3.5f);
        SceneManager.LoadScene("Day 4 - Hospital");
    }

    

}
