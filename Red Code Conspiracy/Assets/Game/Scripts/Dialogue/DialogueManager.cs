using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TMP_Text nameText;
    public TMP_Text dialogueText;
    public Animator animator;

    private Queue<string> sentences;
    private string sentence;
    public bool isDialogueRunning;
    private IEnumerator coroutine;
    private bool isCoroutineRunning;
    
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue (Dialogue dialogue)
    {
        isDialogueRunning = true;
        animator.SetBool("isOpen", true);
        nameText.text = dialogue.name;
        sentences.Clear();
        foreach (string sentence in dialogue.sentences)
            sentences.Enqueue(sentence);
        DisplayNextSentence();
    }

    public void DisplayNextSentence ()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        sentence = sentences.Dequeue();
        
        coroutine = TypeSentence(sentence);
        //StopAllCoroutines();
        StartCoroutine(coroutine);
    }

    private void Update() {
        if(Input.GetMouseButtonDown(0) && isDialogueRunning){
            if (isCoroutineRunning) {
                StopCoroutine(coroutine);
                isCoroutineRunning = false;
                dialogueText.text = sentence;
            }
            else
                DisplayNextSentence();
        }
    }

    IEnumerator TypeSentence (string sentence)
    {
        isCoroutineRunning = true;
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.03f);
        }
        isCoroutineRunning = false;
    }

    void EndDialogue()
    {
        animator.SetBool("isOpen", false);
        isDialogueRunning = false;
    }

}
