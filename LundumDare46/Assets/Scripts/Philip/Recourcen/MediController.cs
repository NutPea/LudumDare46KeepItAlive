using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediController : MonoBehaviour
{

    private  InteraktableController interaktableController;
    // Start is called before the first frame update
    void Start()
    {
        interaktableController = GetComponent<InteraktableController>();
    }

    // Update is called once per frame
    void Update()
    {
         if(interaktableController.getInterakted()){
        interaktableController.GetRecourceManager().mediValue += 1;
        Destroy(gameObject);
      }
    }
}
