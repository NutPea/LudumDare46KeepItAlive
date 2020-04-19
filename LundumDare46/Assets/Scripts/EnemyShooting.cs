using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : Shooting
{
    private float timeBtwShots;
    public float startTimeBtwShots;
    public bool inRange;

    // Start is called before the first frame update
    void Start()
    {
        timeBtwShots = startTimeBtwShots;   
    }

    // Update is called once per frame
    void Update()
    {
        if (timeBtwShots <= 0)
        {
            if (inRange == true)
            {
                Shoot();
                timeBtwShots = startTimeBtwShots;
            }
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }
}
