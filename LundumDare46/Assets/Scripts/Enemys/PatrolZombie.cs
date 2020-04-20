using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class PatrolZombie : Zombie
{
    public Transform[] path;
    public Transform currentGoal; 
    public int currentPoint;
    public float roundingDistance;

    private void Awake() {
        currentMovementSpeed = moveSpeed;
        currentTimer = timer;
    }

    public override void CheckDistance()
    {

        if (Vector3.Distance(target.position, transform.position) <= attackRadius) //if player is in attackrange, attack him
        {
            RotateTowards(target.position);
        }
        else if (Vector3.Distance(target.position, transform.position) <= chaseRadius &&
            Vector3.Distance(target.position, transform.position) > attackRadius || wasHit == true) //if player is in chaserange but not in attackrange, chase him
        {
            RotateTowards(target.position);
            transform.position = Vector3.MoveTowards(transform.position, target.position,  currentMovementSpeed * Time.deltaTime);
        }
        else if(Vector3.Distance(target.position, transform.position) > chaseRadius) //if player is not in chaserange go back to patrolpath
        {
            if (Vector3.Distance(transform.position, path[currentPoint].position) > roundingDistance)
            {
                RotateTowards(path[currentPoint].position);
                transform.position = Vector3.MoveTowards(transform.position, path[currentPoint].position,  currentMovementSpeed * Time.deltaTime);
            }
            else
            {
                changeGoal();
            }
        }

        if(waitTimer == true){

            currentMovementSpeed = 0f;
            if(currentTimer <= 0){
                currentMovementSpeed = moveSpeed;
                currentTimer = timer;
                waitTimer = false;
            }
            else{
                currentTimer -= Time.deltaTime;
            }
        }
        
    }

    private void changeGoal()
    {
        if(currentPoint == path.Length -1)
        {
            currentPoint = 0;
            currentGoal = path[0];
        } 
        else
        {
            currentPoint++;
            currentGoal = path[currentPoint];
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
         if(other.gameObject.tag == "Player" && waitTimer == false){
            waitTimer = true;
            other.gameObject.GetComponent<PlayerController>().takeDamage(baseAttack);
            other.gameObject.GetComponent<PlayerController>().knockBack(transform.position);
        }
    }
}
