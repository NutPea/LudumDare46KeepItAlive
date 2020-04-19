using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Enemy
{
    public Vector3 homePosition;
    public float attackRange;
    public float chaseRadius;

    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        homePosition = gameObject.transform.position;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(player.position, transform.position) <= attackRange)
        {
            RotateTowards(player.position);
            gameObject.GetComponent<ShootingEnemy>().inRange = true;
        }
        else if(Vector3.Distance(player.position, transform.position) > chaseRadius)
        {
            RotateTowards(homePosition);
            gameObject.GetComponent<ShootingEnemy>().inRange = false;
            transform.position = Vector3.MoveTowards(transform.position, homePosition, moveSpeed * Time.deltaTime);
        } 
        else if(Vector3.Distance(player.position, transform.position) < chaseRadius)
        {

            transform.position = Vector3.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
        }

    }
}
