using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeZombie : Enemy
{

    // Update is called once per frame
    void Update()
    {
        CheckDistance();
    }

    private void CheckDistance()
    {
        if (Vector3.Distance(target.position, transform.position) <= attackRadius) //if enemy is in attackrange, attack him
        {
            RotateTowards(target.position);
            gameObject.GetComponent<EnemyShooting>().inRange = true;
        }
        else if (Vector3.Distance(target.position, transform.position) <= chaseRadius &&
            Vector3.Distance(target.position, transform.position) > attackRadius || wasHit == true) //if enemy is in chaserange but not in attackrange, chase him
        {
            RotateTowards(target.position);
            gameObject.GetComponent<EnemyShooting>().inRange = false;
            transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
        }
        else if (Vector3.Distance(target.position, transform.position) > chaseRadius) //if enemy is not in chaserange, go back
        {
            RotateTowards(homePosition);
            gameObject.GetComponent<EnemyShooting>().inRange = false;
            transform.position = Vector3.MoveTowards(transform.position, homePosition, moveSpeed * Time.deltaTime);
        }
    }
}