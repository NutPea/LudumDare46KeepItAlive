using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : Shooting
{
    public Animator animator;
    public float fireRate = 0;
    private float timeToFire = 0;

    public AudioSource audioSource;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > timeToFire)
        {
            timeToFire = Time.time + 1 / fireRate;
            audioSource.Play();
            animator.SetTrigger("shoots");
            Shoot();
        }
    }
}