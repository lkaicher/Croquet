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
    private int currentPlayer=1;

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
   
    
}
