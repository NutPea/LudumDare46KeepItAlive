using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : Enemy
{

    
    public float currentMovementSpeed;
    public bool waitTimer;
    public float timer;
    public float currentTimer;

     public new void Start() {

        wasHit = false;
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        homePosition = gameObject.transform.position;
        target = GameObject.FindGameObjectWithTag("Player").transform;

        currentMovementSpeed = moveSpeed;
        currentTimer = timer;

    }

    // Update is called once per frame
    void Update()
    {
        CheckDistance();
    }

    public virtual void CheckDistance()
    {
        if (Vector3.Distance(target.position, transform.position) <= attackRadius) //if enemy is in attackrange, attack him
        {
            RotateTowards(target.position);
        }
        else if (Vector3.Distance(target.position, transform.position) <= chaseRadius &&
            Vector3.Distance(target.position, transform.position) > attackRadius || wasHit == true) //if enemy is in chaserange but not in attackrange, chase him
        {
            RotateTowards(target.position);
            transform.position = Vector3.MoveTowards(transform.position, target.position, currentMovementSpeed * Time.deltaTime);
        }
        else if (Vector3.Distance(target.position, transform.position) > chaseRadius) //if enemy is not in chaserange, go back
        {
            RotateTowards(homePosition);
            transform.position = Vector3.MoveTowards(transform.position, homePosition, currentMovementSpeed * Time.deltaTime);
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

    private void OnTriggerEnter2D(Collider2D other) {
         if(other.gameObject.tag == "Player" && waitTimer == false){
            waitTimer = true;
            other.gameObject.GetComponent<PlayerController>().takeDamage(baseAttack);
            other.gameObject.GetComponent<PlayerController>().knockBack(transform.position);
        }
    }

    public Vector3 GetHomePosition(){
        return homePosition;
    }
}