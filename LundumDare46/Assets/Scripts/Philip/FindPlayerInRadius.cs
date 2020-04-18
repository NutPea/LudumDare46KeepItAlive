using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindPlayerInRadius : MonoBehaviour
{

    private bool once ;
    private GameObject Player;

    private bool inRange;
    [SerializeField] private float range;
    // Start is called before the first frame update
    private void Awake() {
        once = false; 
    }

    // Update is called once per frame
    void Update()
    {
        if(Player != null){
            if(Vector2.Distance(this.gameObject.transform.position,Player.transform.position) < range){
                inRange = true;
            }
            else{
                inRange = false;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D other) {
            if(other.gameObject.tag == "Player" && !once){
                Player= other.gameObject;
                once = true;
            }
    }


    public bool getInRange(){
        return inRange;
    }

    public GameObject getPlayer(){
        return Player;
    }

}
