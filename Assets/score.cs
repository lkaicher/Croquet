using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class score : MonoBehaviour
{
    public List<GameObject> targets;
    public TextMeshProUGUI scoreText;
    private int score1;
    private int score2;
    // Start is called before the first frame update
    void Start()
    {
    score1= 0;
    score2=0;
    scoreText.text = "Score: \n" + score1+ " - " + score2;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void UpdateScoreP1(){
         score1++;
         scoreText.text = "Score: \n" + score1+ " - " + score2;
    }
    void UpdateScoreP2(){
        score2++;
        scoreText.text = "Score: \n" + score1+ " - " + score2;
    }
}
