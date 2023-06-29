using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flamingo : MonoBehaviour
{
    string winner;
    bool isGameOver;
    GoalTurnManager goalTurnManager;

    [SerializeField] bool debugWinner;

    private void Awake()
    {
        goalTurnManager = FindObjectOfType<GoalTurnManager>();
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (goalTurnManager.p1WinningScoreReached)
            {
                winner = "Alice";
                isGameOver = true;
            }
        }
        if (other.gameObject.tag == "Player2") 
        {
            if (goalTurnManager.p2WinningScoreReached)
            {
                winner = "Queen";
                isGameOver = true;
            }
        }
    }

    public string GetWinner()
    {
        if (debugWinner) return "Amogus";
        else return winner;
    }
    public bool GetIsGameOver()
    {
        if (debugWinner) return true;
        else return isGameOver;
    }
}
