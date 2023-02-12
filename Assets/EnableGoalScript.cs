using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableGoalScript : MonoBehaviour
{

    [SerializeField]
    private GameObject goalTop;

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
        
        goalTop.SetActive(enable);
        Debug.Log("Goal enabled: "+enable);

    }
}
