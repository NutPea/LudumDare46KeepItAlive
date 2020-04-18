using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecourceController : MonoBehaviour
{
    // Start is called before the first frame update  private InteraktController interaktController;
    private  InteraktableController interaktableController;
  private void Start() {
      interaktableController = GetComponent<InteraktableController>();
  }

  private void Update() {
      if(interaktableController.getInterakted()){
        interaktableController.GetRecourceManager().addRecources(1);
        Destroy(gameObject);
      }
  }
}
