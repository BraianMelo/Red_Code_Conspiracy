using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Intro : MonoBehaviour
{
    public TMP_Text intro_text0;
    public TMP_Text intro_text1;
    public TMP_Text intro_text2;
    public TMP_Text intro_text3;
    public TMP_Text bottom_text;
    private string text0, text1, text2, text3;

    private void Start()
    {
        text0 = intro_text0.text;
        text1 = intro_text1.text;
        text2 = intro_text2.text;
        text3 = intro_text3.text;
        intro_text0.gameObject.SetActive(true);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            if (intro_text0.gameObject.activeSelf && intro_text0.text == text0)
            {
                intro_text0.gameObject.SetActive(false);
                intro_text1.gameObject.SetActive(true);

            }
            else if (intro_text1.gameObject.activeSelf && intro_text1.text == text1)
            {
                intro_text1.gameObject.SetActive(false);
                intro_text2.gameObject.SetActive(true);
            }
            else if (intro_text2.gameObject.activeSelf && intro_text2.text == text2)
            {
                intro_text2.gameObject.SetActive(false);
                intro_text3.gameObject.SetActive(true);
            }
            else if (intro_text3.gameObject.activeSelf && intro_text3.text == text3)
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
