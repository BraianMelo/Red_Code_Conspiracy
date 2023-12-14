using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class AreaDialog : MonoBehaviour
{
    public UnityEngine.UI.Button button;

    private bool alreadyTriggered = false;

    private void Start()
    {
        button.onClick.AddListener(Click);
    }
    
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player") && !alreadyTriggered) {
            button.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.CompareTag("Player") && !alreadyTriggered) {
            button.gameObject.SetActive(false);
        }
    }

    private void Click() {
        button.gameObject.SetActive(false);
        alreadyTriggered = true;
    }
}
