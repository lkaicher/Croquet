using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goalTopScript : MonoBehaviour
{

    [SerializeField]
    private GoalTurnManager GoalManager;


    [SerializeField]
    public int goalID;
    bool P1TRIGGERED = false;
    bool P2TRIGGERED = false;

    

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
        Debug.Log(playerTag + "Triggered");
        if (playerTag == "Player"){
            if (P1TRIGGERED) return;
            P1TRIGGERED = true;
        } else if (playerTag == "Player2"){
            if (P2TRIGGERED) return;
            P2TRIGGERED = true;
        } else {
            return;
        }

        GoalManager.incrementScore(col.gameObject.tag );

    }
   
}
