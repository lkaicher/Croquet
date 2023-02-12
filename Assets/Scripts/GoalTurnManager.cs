using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class GoalTurnManager : MonoBehaviour
{

    [SerializeField]
    public TextMeshProUGUI scoreTextP1;
    [SerializeField]
    public TextMeshProUGUI scoreTextP2;

    [SerializeField]
    private PortraitScript portraitP1;

    [SerializeField]
    private PortraitScript portraitP2;
    

    [SerializeField]
    private TextMeshPro winText;

    [SerializeField]
    private GameObject goal;
    public int score1=0;
    public int score2=0;
    public int currentPlayer=1;

    public bool turnInProgress;

    void Start(){


      scoreTextP1.text =  score1.ToString() ;
        scoreTextP2.text = score2.ToString() ;

        portraitP2.dimSprite();
            portraitP1.unDimSprite();

    }

    public void GameWon(int i){
        Debug.Log(name + " won!");
        if (i == 1){
            SceneManager.LoadScene(3);
        }else{
            SceneManager.LoadScene(4);
        }

        
        
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

        if (score1 == score2){
            portraitP1.setSprite(1);
            portraitP2.setSprite(1);
        } else if (score1 > score2){
            portraitP1.setSprite(0);
            portraitP2.setSprite(2); 
        } else {
            portraitP1.setSprite(2);
            portraitP2.setSprite(0); 
        }

    }
    public void beginTurn(){
        turnInProgress = true; 
    }
   public void endTurn(){
        turnInProgress = false;
        currentPlayer = (currentPlayer % 2) + 1;
        if (currentPlayer == 1){
            portraitP2.dimSprite();
            portraitP1.unDimSprite();
        } else {
            portraitP1.dimSprite();
            portraitP2.unDimSprite();
        }
   }
    
}
