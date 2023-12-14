using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalPlatform : MonoBehaviour
{
    private PlatformEffector2D effector;
    private BoxCollider2D bcollider;

    private void Start()
    {
        effector = GetComponent<PlatformEffector2D>();
        bcollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            bcollider.enabled = false;
        }

        if(Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.S))
        {
            bcollider.enabled = true;
        }
    }
}
