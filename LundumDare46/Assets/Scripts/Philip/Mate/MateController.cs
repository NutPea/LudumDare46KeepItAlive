using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MateController : MonoBehaviour
{

    private InteraktableController interaktController;
    public int maxMateHealth;
    public int currentHealth;
    public int loseLivePerTick;
    public float tickTimer ;
    private float currentTimer;


    void Start()
    {
       interaktController=GetComponent<InteraktableController>();
       currentHealth = maxMateHealth;
       currentTimer = tickTimer ;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentTimer <= 0){
            currentTimer = tickTimer;
            currentHealth -= loseLivePerTick;
            
        }else{
            currentTimer -= Time.deltaTime;
        }

        if(interaktController.getInterakted()){
            interaktController.setInterakted(false);
            int useAbleRecourceAmount = interaktController.GetRecourceManager().useRessource();
            if(useAbleRecourceAmount != 0){
                int brieflyCurrentHealth = currentHealth + 30 *useAbleRecourceAmount;
                if( brieflyCurrentHealth > maxMateHealth){
                    currentHealth = maxMateHealth;
                }
                else{
                    currentHealth = brieflyCurrentHealth;
                }
            }
            if(interaktController.GetRecourceManager().mediValue == 3){
                Debug.Log("U WOn");
            }
        }

        if(currentHealth <=0){
            Debug.Log("Mate Died");
        }

    }


    

}
