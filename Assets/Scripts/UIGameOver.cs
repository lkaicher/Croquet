using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIGameOver : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI winnerText;
    private void Start()
    {
        winnerText.text = FindObjectOfType<GoalTurnManager>().winner + " Won!";
        Destroy(GameObject.Find("Goal Manager"));
    }
}