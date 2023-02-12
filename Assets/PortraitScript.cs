using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortraitScript : MonoBehaviour
{

   // [SerializeField]
    //GoalTurnManager goalManager;

    [SerializeField]
    private Sprite[] portraitSprites;

    SpriteRenderer SR;
    [SerializeField]
    SpriteRenderer Shade;

    Color dim = new Color(0,0,0,0.35f);
    Color unDim = new Color(0,0,0,0);

    public void setSprite(int index){
        SR.sprite = portraitSprites[index];
        Shade.sprite = SR.sprite;
    }

    public void dimSprite(){
        Shade.color = dim;
    }

    public void unDimSprite(){
        Shade.color = unDim;

    }
    
    // Start is called before the first frame update
    void Start()
    {
        SR = this.GetComponent<SpriteRenderer>();
        //unDimSprite();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
