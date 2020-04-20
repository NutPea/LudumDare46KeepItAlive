using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : MonoBehaviour
{
    public int bulletDamage;

    void Start()
    {
        Destroy(gameObject, 3f);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerController player = collision.gameObject.GetComponent<PlayerController>();
            if (player != null)
            {
                player.takeDamage(bulletDamage);
            }
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag != "Enemy")
        {
            Destroy(gameObject);
        }
    }
}
