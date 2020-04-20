using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public string enemyName;
    public int maxHealth;
    public int currentHealth;
    public int baseAttack;
    public float moveSpeed;
    public HealthBar healthBar;

    public float chaseRadius;
    public float attackRadius;

    protected Vector3 homePosition;
    protected Transform target;
    protected bool wasHit;

    // Start is called before the first frame update
    public virtual void Start()
    {
        wasHit = false;
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        homePosition = gameObject.transform.position;
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void takeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        wasHit = true;
        if (currentHealth <= 0)
        {
            Debug.Log("Enemy " + gameObject.name + " destroyed!");
            Destroy(transform.parent.gameObject);
        }
    }

    public void RotateTowards(Vector2 target)
    {
        var offset = 90f;
        Vector2 direction = target - (Vector2)transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(Vector3.forward * (angle + offset));
    }
}