using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : Enemy
{   
    private float timeBtwSpawn;
    public float startTimeBtwSpawn;
    public GameObject spawnPrefab;

    public override void Start()
    {
        wasHit = false;
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        timeBtwSpawn = startTimeBtwSpawn;
        homePosition = gameObject.transform.position;
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update() 
    {
        CheckDistance();
    }

    public void Spawn()
    {
        GameObject zombie = Instantiate(spawnPrefab, transform.position, Quaternion.identity);
    }
    
    private void CheckDistance()
    {
        if (Vector3.Distance(target.position, transform.position) <= attackRadius) //if enemy is in attackrange, attack him
        {
            RotateTowards(target.position);
            gameObject.GetComponent<EnemyShooting>().inRange = true;
            if (timeBtwSpawn <= 0)
            {
                Spawn();
                timeBtwSpawn = startTimeBtwSpawn;
            }
            else
            {
                timeBtwSpawn -= Time.deltaTime;
            }
        }
        else if (Vector3.Distance(target.position, transform.position) <= chaseRadius && Vector3.Distance(target.position, transform.position) > attackRadius || wasHit == true) //if enemy is in chaserange but not in attackrange, chase him
        {
            RotateTowards(target.position);
            gameObject.GetComponent<EnemyShooting>().inRange = false;
            transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
            if (timeBtwSpawn <= 0)
            {
                Spawn();
                timeBtwSpawn = startTimeBtwSpawn;
            }
            else
            {
                timeBtwSpawn -= Time.deltaTime;
            }
        }
        else if (Vector3.Distance(target.position, transform.position) > chaseRadius) //if enemy is not in chaserange, go back
        {
            RotateTowards(homePosition);
            gameObject.GetComponent<EnemyShooting>().inRange = false;
            transform.position = Vector3.MoveTowards(transform.position, homePosition, moveSpeed * Time.deltaTime);
        }
    }

     private void OnTriggerEnter2D(Collider2D other) {
         if(other.gameObject.tag == "Player"){
            other.gameObject.GetComponent<PlayerController>().takeDamage(baseAttack);
            other.gameObject.GetComponent<PlayerController>().knockBack(transform.position);
        }
    }

}
