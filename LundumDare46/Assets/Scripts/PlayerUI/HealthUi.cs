using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUi : MonoBehaviour
{


    public Slider slider;
    public PlayerController playerController;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    
    // Update is called once per frame
    void Update()
    {
        slider.value = (float)playerController.currHealth/playerController.maxHealth;
    }
}
