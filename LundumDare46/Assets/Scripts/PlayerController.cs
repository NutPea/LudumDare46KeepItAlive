using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //private Movement attributes
    private Vector2 lookDir;
    private Vector2 movement;
    private Vector2 mousePos;  
    private float angle; //rotation-angle to x axis
    
    //public Movement attributes
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Camera cam;

    //statisic attributes
    public int maxHealth;
    public int currHealth;

    private void Start()
    {
        currHealth = maxHealth;
    }
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        lookDir = mousePos - rb.position;
        angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }
}
