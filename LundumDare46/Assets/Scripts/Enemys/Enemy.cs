using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public string enemyName;
    public int maxHealth;
    public int currHealth;
    public int baseAttack;
    public float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
           
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void takeDamage(int damage)
    {
        currHealth -= damage;
        if (currHealth <= 0)
        {
            Debug.Log("Enemy " + gameObject.name + " destroyed!");
            Destroy(gameObject);
        }
    }
}