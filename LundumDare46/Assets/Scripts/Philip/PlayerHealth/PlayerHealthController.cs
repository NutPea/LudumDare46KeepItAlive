using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;

    public float currentHealthInProzent;


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        currentHealthInProzent = (float)currentHealth/maxHealth;
        if(currentHealth <= 0){
            Debug.Log("Player Is Dead");
        }
    }

    


}
