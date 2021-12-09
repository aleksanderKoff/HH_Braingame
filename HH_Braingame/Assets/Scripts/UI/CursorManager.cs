using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    
    public static Texture2D CursorTextureDefault;
    public static Texture2D CursorTextureHit;
    public static Vector2 CursorHotspot;

    void Start()
    {
        CursorTextureDefault = Resources.Load<Texture2D>("Cursor/Cursor");
        CursorTextureHit = Resources.Load<Texture2D>("Cursor/CursorRed");
        CursorHotspot = new Vector2(CursorTextureDefault.width / 2, CursorTextureDefault.height / 2);
        Cursor.SetCursor(CursorTextureDefault, CursorHotspot, CursorMode.Auto);
    }
    public static void ChangeCursorColorHit()
    {
        Cursor.SetCursor(CursorTextureHit, CursorHotspot, CursorMode.Auto);
    }

    public static void ChangeCursorColorDefault()
    {
        Cursor.SetCursor(CursorTextureDefault, CursorHotspot, CursorMode.Auto);
    }
}
