using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Texture2D CursorDefaultReference;
    [SerializeField] private Texture2D CursorHitReference;

    public static Texture2D CursorTextureDefault;
    public static Texture2D CursorTextureHit;
    public static Vector2 CursorHotspot;

    void Start()
    {
        CursorTextureDefault = CursorDefaultReference;
        CursorTextureHit = CursorHitReference;
        CursorHotspot = new Vector2(CursorTextureDefault.width / 2, CursorTextureDefault.height / 2);
        Cursor.SetCursor(CursorTextureDefault, CursorHotspot, CursorMode.Auto);
    }

    // Update is called once per frame
    void Update()
    {
        
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
