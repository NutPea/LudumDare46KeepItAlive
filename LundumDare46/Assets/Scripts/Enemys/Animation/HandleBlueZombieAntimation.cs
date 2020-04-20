using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleBlueZombieAntimation : MonoBehaviour
{

    private Animator animator;
    private Transform zombieBody;
    private Vector3 scale;
    private PatrolZombie patrolZombie;
    // Start is called before the first frame update
    void Start()
    {
        zombieBody = transform.parent.gameObject.transform.GetChild(0).GetComponent<Transform>();
        scale = new Vector3(transform.localScale.x,transform.localScale.y,transform.localScale.z);
        patrolZombie = transform.parent.gameObject.transform.GetChild(0).GetComponent<PatrolZombie>();
        animator = GetComponent<Animator>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if(patrolZombie != null){
            if(zombieBody.transform.eulerAngles.z > 0 && zombieBody.transform.eulerAngles.z <= 180){
                transform.localScale = new Vector3(scale.x,scale.y,scale.z);
            }
            else{
                transform.localScale = new Vector3(-scale.x,scale.y,scale.z);
            }
            transform.position = zombieBody.transform.position;
        }

        if(patrolZombie.currentHealth <= 0){
            animator.SetTrigger("Dead");
            Destroy(transform.parent.gameObject,1);
            
        }
        
    }
}
