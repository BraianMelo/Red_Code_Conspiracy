using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickupItem : MonoBehaviour
{
    public GameObject player;
    public string action;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")){
            Destroy(gameObject);
            if (action == "double jump")
                player.GetComponent<PlayerJump>().doubleJump = true;
            else if (action == "knife")
                player.GetComponent<PlayerCombat>().haveKnife = true;
        }
    }
}
