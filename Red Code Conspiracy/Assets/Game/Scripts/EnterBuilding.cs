using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterBuilding : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private GameObject player;
    [SerializeField] private float xcam, ycam, xplayer, yplayer;

    private bool canEnter = false;

    private void Update() {
        if (canEnter && (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))) {
            cam.transform.position = new Vector3(xcam, ycam, cam.transform.position.z);
            player.transform.position = new Vector3(xplayer, yplayer, player.transform.position.z);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canEnter = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.CompareTag("Player"))
            canEnter = false;
    }
}
