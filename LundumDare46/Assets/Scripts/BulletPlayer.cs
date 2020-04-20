using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPlayer : MonoBehaviour
{
    public int bulletDamage;
    public GameObject EnemyParticle;
    public GameObject EnvirmonetParticle;

    void Start()
    {
        Destroy(gameObject, 1.5f);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            if (enemy != null)
            {
                Instantiate(EnemyParticle,transform.position,transform.rotation);
                enemy.takeDamage(bulletDamage);
            }
            Destroy(gameObject);
        } else if(collision.gameObject.tag != "Player")
        {
            Destroy(gameObject);
        }
        if(collision.gameObject.tag == "Enviroment"){
            Instantiate(EnvirmonetParticle,transform.position,transform.rotation);
            Destroy(gameObject);
        }
    }
}
