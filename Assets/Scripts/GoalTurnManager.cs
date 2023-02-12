using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class GoalTurnManager : MonoBehaviour
{

    [SerializeField]
    public TextMeshProUGUI scoreText;

    [SerializeField]
    private GameObject goal;
    private int score1=0;
    private int score2=0;
    private int currentPlayer=1;

    void Start(){


      scoreText.text = score1 + " - " + score2;
    }

    public void incrementScore(string Playertag){

        if (Playertag == "Player"){
            score1++;
        } else if (Playertag == "Player2" ){
            score2++;
        } else 
            return; 
        scoreText.text = score1 + " - " + score2;

    }
   
    
}
