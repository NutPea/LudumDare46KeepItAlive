using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //public GameObject hitEffekt;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //GameObject effect = Instantiate(hitEffekt, transform.position, Quaternion.identity);
        //Destroy(effect, 5f);
        Destroy(gameObject);
    }
}
