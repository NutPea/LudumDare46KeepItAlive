using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MateUI : MonoBehaviour
{

    public Slider mateSlider;
    public MateController mate;
    public RecourceManager recourceManager;
    public TextMeshProUGUI recourcenText;
    public TextMeshProUGUI mediText;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mateSlider.value = (float)mate.currentHealth/mate.maxMateHealth;
        recourcenText.text = recourceManager.ressourceValue +"";
        mediText.text = recourceManager.mediValue + " /3";
    }
}
