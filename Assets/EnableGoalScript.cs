using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableGoalScript : MonoBehaviour
{

    [SerializeField]
    public GameObject goalTop;


  


    [SerializeField]
    bool enable = true;


 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    private void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag == "Player" || col.gameObject.tag == "Player2"){
            //if (!goalScript.getRecentlyEnabled()){
                goalTop.SetActive(enable);
               // goalScript.setRecentlyEnabled(true);
                Debug.Log("Goal enabled: "+enable);
            //}
        }

    }
}
