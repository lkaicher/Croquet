using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startGame : MonoBehaviour
{
    [SerializeField] private string newGame= "Sample Scene";
    public void ChangeMenuScene()
    {
        SceneManager.LoadScene(newGame);
    }
}