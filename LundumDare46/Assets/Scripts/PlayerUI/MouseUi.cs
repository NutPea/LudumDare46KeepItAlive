using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseUi : MonoBehaviour
{
    public Texture2D currsorArrow;
    void Start()
    {
        Cursor.SetCursor(currsorArrow,Vector2.zero,CursorMode.ForceSoftware);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
