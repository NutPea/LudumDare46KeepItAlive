﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteraktableController : MonoBehaviour
{
   
    private FindPlayerInRadius findPlayerInRadius;
    private bool once;
    public float interaktAmount;
    public float interaktAmountTime;
    private GameObject Player;
    private RecourceManager recourceManager;
    private GameObject interaktableGameObject;
    private InteraktableSprite interaktableSprite;
    public bool interakted = false;

    // Start is called before the first frame update
    void Start()
    {
        findPlayerInRadius = GetComponent<FindPlayerInRadius>();
    }
    // Update is called once per frame
    void Update()
    {
        Initialise();
        Interakting();

    }

    private void Initialise()
    {
        if (Player == null)
        {
            Player = findPlayerInRadius.getPlayer();
        }
        if (Player != null && once == false)
        {
            recourceManager = Player.GetComponent<RecourceManager>();
            interaktableGameObject = Player.transform.GetChild(1).gameObject;
            interaktableSprite = interaktableGameObject.transform.GetChild(0).GetComponent<InteraktableSprite>();
            once = true;
        }
    }

    private void Interakting()
    {
        if (Player != null && !interakted )
        {
            if (findPlayerInRadius.getInRange())
            {
                interaktableGameObject.SetActive(true);
                if (Input.GetKey(KeyCode.E) && interaktAmount < 1)
                {
                    interaktableGameObject.SetActive(true);
                    interaktAmount += Time.deltaTime / interaktAmountTime;
                    interaktableSprite.setInteraktAmount(interaktAmount);
                    if (interaktAmount >= 1)
                    {
                        interakted = true;
                        interaktableSprite.setInteraktAmount(0);
                        interaktableGameObject.SetActive(false);
                    }
                }
                else
                {
                    interaktAmount = 0;
                    interaktableSprite.setInteraktAmount(interaktAmount);
                    interaktableGameObject.SetActive(false);
                }
            }
        }
    }

    public bool getInterakted(){
        return interakted;
    }

    public void setInterakted(bool interakted){
        this.interakted = interakted; 
    }

    public RecourceManager GetRecourceManager(){
        return recourceManager;
    }
}
