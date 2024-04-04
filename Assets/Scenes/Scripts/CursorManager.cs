using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    [SerializeField] private Texture2D cursorTexture;

    private Vector2 cursorHotspot;

    void Start()
    {
        cursorHotspot = new Vector2(cursorHotspot.x / 2, cursorHotspot.y / 2);   
        Cursor.SetCursor(cursorTexture, cursorHotspot, CursorMode.Auto);
    }
}
