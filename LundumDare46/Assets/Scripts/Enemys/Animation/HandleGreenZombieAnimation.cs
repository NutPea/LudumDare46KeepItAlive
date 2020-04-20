using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleGreenZombieAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator animator;
    private Transform zombieBody;
    private Vector3 scale;
    private RangeZombie rangeZombie;
    // Start is called before the first frame update
    void Start()
    {
         zombieBody = transform.parent.gameObject.transform.GetChild(0).GetComponent<Transform>();
        scale = new Vector3(transform.localScale.x,transform.localScale.y,transform.localScale.z);
       rangeZombie = transform.parent.gameObject.transform.GetChild(0).GetComponent<RangeZombie>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(rangeZombie != null){
            if(zombieBody.transform.eulerAngles.z > 0 && zombieBody.transform.eulerAngles.z <= 180){
                transform.localScale = new Vector3(scale.x,scale.y,scale.z);
            }
            else{
                transform.localScale = new Vector3(-scale.x,scale.y,scale.z);
            }
            transform.position = zombieBody.transform.position;
        }

        if(rangeZombie.currentHealth <= 0){
            animator.SetBool("isRunning",false);
            animator.SetBool("isDead",true);
            Destroy(transform.parent.gameObject,1);
            
        }
         if(zombieBody != null &&  rangeZombie != null){
            if(Vector3.Distance(zombieBody.transform.position,rangeZombie.GetHomePosition())<= 0.5 ){
                animator.SetBool("isRunning",false);
            }else{
                animator.SetBool("isRunning",true);
            }
        }

    }
}
