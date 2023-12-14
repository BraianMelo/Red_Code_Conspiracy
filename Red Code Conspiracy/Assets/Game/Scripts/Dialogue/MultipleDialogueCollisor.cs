using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultipleDialogueCollisor : MonoBehaviour
{
    public DialogueManager dialogueManager;
    public Dialogue dialogue;
    public GameObject[] next_dialogues;

    private bool alreadyTriggered = false;
    private Queue<GameObject> queue;
    private GameObject next_dialogue;
    private bool isCoroutineRunning = false;

    void Start()
    {
        queue = new Queue<GameObject>();
    }

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !alreadyTriggered) //this.gameObject.activeSelf
        {
            TriggerDialogue();
            foreach (GameObject next_dialogue in next_dialogues)
                queue.Enqueue(next_dialogue);
            next_dialogue = queue.Dequeue();
            alreadyTriggered = true;
            //this.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        if (!isCoroutineRunning && next_dialogue!=null)
            StartCoroutine("TriggerNextDialogues");
    }

    private IEnumerator TriggerNextDialogues() {
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
