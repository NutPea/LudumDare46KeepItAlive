using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MateController : MonoBehaviour
{

    private InteraktController interaktController;
    public int maxMateHealth;
    private int currentHealth;
    void Start()
    {
       interaktController=GetComponent<InteraktController>();
       currentHealth = maxMateHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
