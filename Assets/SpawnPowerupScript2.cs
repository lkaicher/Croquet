using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPowerupScript2 : MonoBehaviour
{

    [SerializeField]

    private GameObject powerup;


    [SerializeField]
    private float spawnRate = 2;

    [SerializeField]
    private int minX = 0;
     [SerializeField]
    private int minY = 0;
     [SerializeField]
    private int maxX = 1920;
     [SerializeField]
    private int maxY = 1080;

    private float timer = 0; 




    void spawnPowerup() {

        Vector3 spawnPoint = new Vector3(Random.Range(minX,maxX),Random.Range(minY,maxY), 0);
        Instantiate(powerup, spawnPoint,transform.rotation);
    }
    // Start is called before the first frame update
    void Start()
    {
        spawnPowerup();   
    }

    // Update is called once per frame
    void Update()
    {
        
        if (timer < spawnRate){
            timer += Time.deltaTime;
        } else {
            spawnPowerup();
            timer = 0;
        }
    }
}
