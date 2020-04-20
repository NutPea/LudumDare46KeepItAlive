using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogeTrigger : MonoBehaviour
{

public Dialoge dialoge;


private void Start() {
    FindObjectOfType<DialogeManager>().StartDialoge(dialoge);
}
  
}
