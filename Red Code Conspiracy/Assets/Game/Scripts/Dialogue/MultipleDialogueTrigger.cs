using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultipleDialogueTrigger : MonoBehaviour
{
    public DialogueManager dialogueManager;
    public Dialogue dialogue;
    public GameObject[] next_dialogues;

    private Queue<GameObject> queue;
    private GameObject next_dialogue;
    private bool isCoroutineRunning = false;
    private bool startedDialogue = false;

    void Start()
    {
        queue = new Queue<GameObject>();
        foreach (GameObject next_dialogue in next_dialogues) {
            queue.Enqueue(next_dialogue);
            Debug.Log(next_dialogue);
        }
        next_dialogue = queue.Dequeue();
    }

    public void TriggerDialogue()
    {
        startedDialogue = true;
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    private void FixedUpdate()
    {
        Debug.Log("entrou no update");
        if (!isCoroutineRunning && next_dialogue!=null && startedDialogue) {
            StartCoroutine("TriggerNextDialogues");
        }
    }

    private IEnumerator TriggerNextDialogues() {
        Debug.Log("entrou na corrotina");
        isCoroutineRunning = true;
        if (!next_dialogue.gameObject.activeSelf && !dialogueManager.isDialogueRunning)
        {
            yield return new WaitForSeconds(0.3f);
            next_dialogue.gameObject.SetActive(true);
            
            if (queue.Count == 0)
            {
                this.gameObject.SetActive(false);
                yield break;
            }
            next_dialogue = queue.Dequeue();
        }
        isCoroutineRunning = false;
    }
}
