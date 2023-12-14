using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextDialog : MonoBehaviour
{
    public Dialogue dialogue;

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    private void OnEnable()
    {
        TriggerDialogue();
        this.gameObject.SetActive(false);
    }
}
