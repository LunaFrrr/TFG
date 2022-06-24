using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;
    public GameObject dialogueBox, startDialogueButton, character;
    

    private Queue<string> sentences;
    private Queue<string> names;

    public bool end;
    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
        names = new Queue<string>();
        end = false;
        
    }

    public void StartDialogue(Dialogue dialogue)
    {
        dialogueBox.SetActive(true);
        startDialogueButton.SetActive(false);
        character.SetActive(true);
        sentences.Clear();
        names.Clear();

        foreach (string name in dialogue.names)
        {
            names.Enqueue(name);
        }

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);    
        }
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        string name = names.Dequeue();

        //Para evitar solapar las animaciones de texto
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence, name));

    }

    //Introducir texto letra a letra
    IEnumerator TypeSentence (string sentence, string name)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }

        nameText.text = name;
    }

    void EndDialogue()
    {
        dialogueBox.SetActive(false);
        character.SetActive(false);
        end = true;
    }
}
