using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //public GameObject hitEffekt;
    public int bulletDamage;


    void Start()
    {
        Destroy(gameObject, 3f);       
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag != "Player" && collision.gameObject.tag != "Enemy") {
            //GameObject effect = Instantiate(hitEffekt, transform.position, Quaternion.identity);
            //Destroy(effect, 5f);
            Destroy(gameObject);
        } 
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Enemy enemy = collision.GetComponent<Enemy>();
            if(enemy != null)
            {
                enemy.takeDamage(bulletDamage);
            }
            Destroy(gameObject);
        }    
    }
}
