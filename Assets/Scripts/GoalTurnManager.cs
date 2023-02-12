using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class GoalTurnManager : MonoBehaviour
{

    [SerializeField]
    public TextMeshProUGUI scoreText;
    private int score1=0;
    private int score2=0;
    private int currentPlayer=1;

    void Start(){
      scoreText.text = score1 + " - " + score2;
    }
   private void OnTriggerEnter2D(Collider2D col){
    if(col.gameObject.tag =="Ball"){
        if(currentPlayer==1){
            score1++;
            scoreText.text = score1 + " - " + score2;
           
        }
        else{
            score2++;
            scoreText.text = score1 + " - " + score2;
         
        }
    }
   }
    
}
