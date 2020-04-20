using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecourceManager : MonoBehaviour
{

    public int ressourceValue;
    public int mediValue;
    // Start is called before the first frame update

    public void addRecources(int addableRecources){
        ressourceValue += addableRecources;
    }

    public int useRessource(){
        int value = ressourceValue;
        ressourceValue = 0;
        return value;
    }
}
