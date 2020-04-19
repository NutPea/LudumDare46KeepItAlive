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

    public override void CheckDistance()
    {

        if (Vector3.Distance(target.position, transform.position) <= chaseRadius && Vector3.Distance(target.position, transform.position) > attackRadius)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
        }
        else if(Vector3.Distance(target.position, transform.position) > chaseRadius)
        {
            if (Vector3.Distance(transform.position, path[currentPoint].position) > roundingDistance)
            {
                transform.position = Vector3.MoveTowards(transform.position, path[currentPoint].position, moveSpeed * Time.deltaTime);
            }
            else
            {
                changeGoal();
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

}
