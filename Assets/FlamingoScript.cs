using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlamingoScript : MonoBehaviour
{

    [SerializeField]
    private GoalTurnManager GoalManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col){
        string playerTag = col.gameObject.tag;
        Debug.Log(playerTag + "hit flamingo");
        if (playerTag == "Player"){
            if (GoalManager.score1 == 6){
                GoalManager.GameWon(1);
            }
            
        } else if (playerTag == "Player2"){
            if (GoalManager.score1 == 6){
                GoalManager.GameWon(1);
            }
        } else {
            return;
        }


    }
}
