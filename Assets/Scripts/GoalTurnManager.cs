using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class GoalTurnManager : MonoBehaviour
{

    [SerializeField]
    public TextMeshProUGUI scoreTextP1;
    [SerializeField]
    public TextMeshProUGUI scoreTextP2;
    

    [SerializeField]
    private GameObject goal;
    private int score1=0;
    private int score2=0;
    public int currentPlayer=1;

    public bool turnInProgress;

    void Start(){


      scoreTextP1.text =  score1.ToString() ;
        scoreTextP2.text = score2.ToString() ;

    }

    public void incrementScore(string Playertag){

        if (Playertag == "Player"){
            score1++;
            scoreTextP1.text =score1.ToString() ;

        } else if (Playertag == "Player2" ){
            score2++;
            scoreTextP2.text =score2.ToString() ;

        } else 
            return; 

    }
    public void beginTurn(){
        turnInProgress = true; 
    }
   public void endTurn(){
        turnInProgress = false;
        currentPlayer = (currentPlayer % 2) + 1;
   }
    
}
