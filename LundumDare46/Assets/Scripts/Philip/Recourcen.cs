using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recourcen : MonoBehaviour
{

  private InteraktController interaktController;

  private void Start() {
      interaktController = GetComponent<InteraktController>();
  }

  private void Update() {
      if(interaktController.getInterakted()){
        interaktController.GetRecourceManager().addRecources(1);
        Destroy(gameObject);
      }
  }

}
