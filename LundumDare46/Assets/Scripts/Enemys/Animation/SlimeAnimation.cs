using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeAnimation : MonoBehaviour
{

    private Slime slime;
    // Start is called before the first frame update
    void Start()
    {
        slime = transform.parent.gameObject.transform.GetChild(0).GetComponent<Slime>();
    }

    // Update is called once per frame
    void Update()
    {
        if(slime.currentHealth <= 0){
            Destroy(transform.parent.gameObject);
        }
    }
}
