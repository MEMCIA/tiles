using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapUtils
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void ChangeColor(int x, int y, Tilemap tilemap, Color32 color)
    {
        if (y % 2 == 0)
        {
            if (x % 2 == 0)
            {
                tilemap.SetColor(new Vector3Int(x, y, 0), color);
            }
        }
        else
        {
            if (x % 2 != 0)
            {
                tilemap.SetColor(new Vector3Int(x, y, 0), color);
            }
        }
    }
}
