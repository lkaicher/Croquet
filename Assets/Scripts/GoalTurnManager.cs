using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class GoalTurnManager : MonoBehaviour 
{
    [SerializeField] TextMeshProUGUI scoreTextP1;
    [SerializeField] TextMeshProUGUI scoreTextP2;
    [SerializeField] PortraitScript portraitP1;
    [SerializeField] PortraitScript portraitP2;
    [SerializeField] int winningScore;

    public int score1=0;
    public int score2=0;
    public int currentPlayer=1;
    public bool turnInProgress;

    public bool p1WinningScoreReached;
    public bool p2WinningScoreReached;
    public string winner;
    bool loaded;

    Flamingo flamingo;
    ScenesManager sceneManager;

    public static GoalTurnManager instance { get; private set; }

    private void Awake()
    {
        if (instance != null && instance != this) Destroy(gameObject);
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        flamingo = FindObjectOfType<Flamingo>();
        sceneManager = FindObjectOfType<ScenesManager>();
    }
    void Start()
    {
        SetUpGame();
    }
    private void Update()
    {
        CheckWinningScore();
        CheckForGameOver();
    }
    private void SetUpGame()
    {
        scoreTextP1.text = score1.ToString();
        scoreTextP2.text = score2.ToString();
        portraitP2.dimSprite();
        portraitP1.unDimSprite();
    }
    public void IncrementScore(string playerTag)
    {
        if (playerTag == "Player"){
            score1++;
            scoreTextP1.text = score1.ToString() ;

        } else if (playerTag == "Player2" ){
            score2++;
            scoreTextP2.text = score2.ToString() ;

        } else return; 

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
    public void BeginTurn()
    {
        turnInProgress = true; 
    }
   public void EndTurn()
    {
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
    void CheckWinningScore()
    {
        if (score1 >= winningScore) p1WinningScoreReached = true;
        if (score2 >= winningScore) p2WinningScoreReached = true;
    }
    void CheckForGameOver()
    {
        if (turnInProgress) return;
        else if (flamingo.GetIsGameOver())
        {
            winner = flamingo.GetWinner();
            sceneManager.LoadGameOver();
        }
    }
}
