using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteraktableSprite : MonoBehaviour
{

    public float interaktAmount;
    public SpriteRenderer spriteRenderer;
    public Sprite[] loadSprite;
    private Sprite currentUsedSprite;
    // Start is called before the first frame update
    void Start()
    {
        currentUsedSprite = loadSprite[0];
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(interaktAmount >= 0 && interaktAmount <0.125 ){
            currentUsedSprite = loadSprite[0];
        }
        else if(interaktAmount >= 0.125 && interaktAmount <0.25){
            currentUsedSprite = loadSprite[1];
        }
        else if(interaktAmount >= 0.25 && interaktAmount <0.375){
            currentUsedSprite = loadSprite[2];
        }
        else if(interaktAmount >= 0.375 && interaktAmount <0.50){
            currentUsedSprite = loadSprite[3];
        }
        else if(interaktAmount >= 0.50 && interaktAmount <0.625){
            currentUsedSprite = loadSprite[4];
        }
        else if(interaktAmount >= 0.625 && interaktAmount <0.75){
            currentUsedSprite = loadSprite[5];
        }
        else if(interaktAmount >= 0.75 && interaktAmount <0.875){
            currentUsedSprite = loadSprite[6];
        }
        else if(interaktAmount >= 0.875 && interaktAmount <1.0){
            currentUsedSprite = loadSprite[7];
        }
        else{
            currentUsedSprite = loadSprite[8];
        }
        spriteRenderer.sprite = currentUsedSprite;

    }

    public void setInteraktAmount( float interaktAmount){
        this.interaktAmount = interaktAmount;
    }
}
