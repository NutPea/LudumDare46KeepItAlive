﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediPackController : MonoBehaviour
{
    public int healAmount;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D other) {
          if(other.gameObject.tag =="Player"){
            PlayerController phc = other.gameObject.GetComponent<PlayerController>();
            phc.currHealth += healAmount;
            Destroy(gameObject);
        }
    }
}
