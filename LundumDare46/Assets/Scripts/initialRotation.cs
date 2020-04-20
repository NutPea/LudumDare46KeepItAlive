using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class initialRotation : MonoBehaviour
{

    public Enemy me;
    private Vector2 wishedPosition;
    Quaternion rotation;
    public float topDistanceToObject;

    void LateUpdate()
    {
        wishedPosition = new Vector2(me.transform.position.x, me.transform.position.y + topDistanceToObject);
        transform.position = wishedPosition;
        transform.rotation = rotation;
    }

    void Awake()
    {
        rotation = transform.rotation;
    }

}
