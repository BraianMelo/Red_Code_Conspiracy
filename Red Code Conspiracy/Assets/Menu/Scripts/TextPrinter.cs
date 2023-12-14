using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TextPrinter : MonoBehaviour
{
    TMP_Text subtitleTextMesh;
    string text;

    void Awake()
    {
        subtitleTextMesh = GetComponent<TMP_Text>();
    }
    void OnEnable()
    {
        StartCoroutine("TypeTextCO");
    }

    private void Update() {
        if(Input.GetMouseButtonDown(0)){
            StopCoroutine("TypeTextCO");
            subtitleTextMesh.text = text;
        }
    }

    IEnumerator TypeTextCO()
    {
        text = subtitleTextMesh.text;
        subtitleTextMesh.text = string.Empty;

        for (int i = 0; i < text.Length; i++) {
            subtitleTextMesh.text += text[i];
            yield return new WaitForSeconds(0.05f);
        }
        yield return null;
    }
}
