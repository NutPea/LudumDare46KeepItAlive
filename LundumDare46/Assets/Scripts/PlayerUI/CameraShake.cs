using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{

    public float power = 0.7f;
    public float duration = 1f;
    // Start is called before the first frame update
    public float slowDownAmount;
    public bool shouldShake = false;
    public Transform Kamera;

    Vector3 startPosition;
    float initialDuration;

    void Start()
    {
        Kamera = Camera.main.transform;
        startPosition = Kamera.localPosition;
        initialDuration = duration;
    }

    // Update is called once per frame
    void Update()
    {
        if(shouldShake){
            startPosition = transform.position;
            if(duration >0){
                Kamera.localPosition = startPosition + Random.insideUnitSphere * power;
                duration -= Time.deltaTime * slowDownAmount;
            }
            else{
                shouldShake = false;
                duration = initialDuration;
                Kamera.localPosition = startPosition;
            }
        }

        if(Input.GetButton("Fire1")){
            shouldShake = true;
        }
        else{
            shouldShake = false;
        }
    }
}
