using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseUi : MonoBehaviour
{
    public Transform MouseCursor;
    
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        MouseCursor.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
