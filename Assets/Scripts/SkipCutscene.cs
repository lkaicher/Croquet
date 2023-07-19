using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SkipCutscene : MonoBehaviour
{
    TMP_Text skipCutsceneText;
    ScenesManager sceneManager;
    void Start()
    {
        skipCutsceneText = GetComponentInChildren<TMP_Text>();
        sceneManager = FindObjectOfType<ScenesManager>();
    }
    void Update()
    {
        OscillateOpacity();
        if (Input.GetKeyDown(KeyCode.Space))
            sceneManager.LoadNextLevel();
    }
    void OscillateOpacity()
    {
        float textAlpha = 0.5f * (Mathf.Sin(Time.time - (Mathf.PI / 2)) + 1); //Normalizes oscillations between 0 and 1 instead of -1 and 1
        skipCutsceneText.alpha = textAlpha;
    }
}
