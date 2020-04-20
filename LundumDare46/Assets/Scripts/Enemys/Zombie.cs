﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : Enemy
{
    
    // Update is called once per frame
    void Update()
    {
        CheckDistance();
    }

    public virtual void CheckDistance()
    {
        if (Vector3.Distance(target.position, transform.position) <= chaseRadius && Vector3.Distance(target.position, transform.position) > attackRadius || wasHit == true)
        {
            RotateTowards(target.position);
            transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
        } else
        {
            RotateTowards(homePosition);
            transform.position = Vector3.MoveTowards(transform.position, homePosition, moveSpeed * Time.deltaTime);
        }
    }
    
}