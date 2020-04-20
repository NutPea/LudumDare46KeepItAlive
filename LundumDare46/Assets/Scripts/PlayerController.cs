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
    
    // Asthetic Shit
    public Rigidbody2D firePointRB;
    private Transform firePivotPoint;
    public Animator animator;
    public Transform WeaponSprite;
    public float localScaleOfWeaponSprite;
    private Transform WeaponSpriteTransform;

    private float timer;
    public float knockBackAmount;
    public GameObject playerHitParticle;


    private void Start()
    {
        currHealth = maxHealth;
        firePivotPoint = firePointRB.gameObject.GetComponent<Transform>();
        localScaleOfWeaponSprite = WeaponSprite.transform.localScale.y;
        WeaponSpriteTransform = animator.gameObject.GetComponent<Transform>();
    }
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);
        lookDir = mousePos - rb.position;
        angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        firePointRB.rotation = angle;
        HandleAnimation();
        if (firePivotPoint.transform.eulerAngles.z > 180f && firePivotPoint.transform.eulerAngles.z <= 360f)
        {
            WeaponSprite.transform.localScale = new Vector3(WeaponSprite.transform.localScale.x, localScaleOfWeaponSprite, WeaponSprite.transform.localScale.z);

        }
        else
        {
            WeaponSprite.transform.localScale = new Vector3(WeaponSprite.transform.localScale.x, -localScaleOfWeaponSprite, WeaponSprite.transform.localScale.z);
        }     
    }

    private void  HandleAnimation()
    {
        animator.SetBool("isRunning",movement.x != 0 || movement.y !=0);
        if (firePivotPoint.transform.eulerAngles.z > 135f && firePivotPoint.transform.eulerAngles.z <= 225f)
        {
            animator.SetFloat("Angle",0f);
            animator.SetFloat("Blend",-1f);
            WeaponSprite.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 1;
        }
        else if (firePivotPoint.transform.eulerAngles.z > 225f && firePivotPoint.transform.eulerAngles.z <= 315f)
        {
            animator.SetFloat("Angle",1f);
            animator.SetFloat("Blend",0f);
            WeaponSprite.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 1;

        }
        else if (firePivotPoint.transform.eulerAngles.z > 45f && firePivotPoint.transform.eulerAngles.z <= 135f)
        {
            animator.SetFloat("Angle",-1f);
            animator.SetFloat("Blend",0f);
            WeaponSprite.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 1;
        }
        else
        {
            animator.SetFloat("Angle",0f);
            animator.SetFloat("Blend",1f);
            WeaponSprite.gameObject.GetComponent<SpriteRenderer>().sortingOrder = -10;
        }
    }

    public void takeDamage(int damage)
    {
        currHealth -= damage;
        if (currHealth <= 0)
        {
            Debug.Log("Player " + gameObject.name + " destroyed!");
            
        }
    }

    public void knockBack(Vector3 damagePosition){
        Instantiate(playerHitParticle,transform.position,transform.rotation);
        Vector3 direction = (this.transform.position - damagePosition).normalized;
        rb.AddForce(direction * knockBackAmount *Time.deltaTime ,ForceMode2D.Force);
    }


}
