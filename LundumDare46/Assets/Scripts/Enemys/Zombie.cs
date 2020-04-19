using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : Enemy
{
    public Vector3 homePosition;
    public Transform target;
    public float chaseRadius;
    public float attackRadius;

    // Start is called before the first frame update
    void Start()
    {
        homePosition = gameObject.transform.position;
        target = GameObject.FindWithTag("Player").transform;     
    }
    
    // Update is called once per frame
    void Update()
    {
        CheckDistance();
    }

    public virtual void CheckDistance()
    {
        if (Vector3.Distance(target.position, transform.position) <= chaseRadius && Vector3.Distance(target.position, transform.position) > attackRadius)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
        } else
        {
            transform.position = Vector3.MoveTowards(transform.position, homePosition, moveSpeed * Time.deltaTime);
        }
    }
}