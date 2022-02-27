using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapBackground : MonoBehaviour
{
    [SerializeField] Tilemap _backgroundTilemap;
    Color32 _yellow2 = new Color32(255, 255, 255, 180);
    Color32 _naturalColor = new Color32(255, 255, 255, 255);
    [SerializeField] TileBase _backGroundTile;
    [SerializeField] MainTilemap _mainTilemap;

    // Start is called before the first frame update
    void Start()
    {
        CreateBackgroundMap();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CreateBackgroundMap()
    {
        for (int x = 0; x < _mainTilemap.width; x++)
        {
            for (int y = 0; y < _mainTilemap.height; y++)
            {
                _backgroundTilemap.SetTile(new Vector3Int(x, y, 0), _backGroundTile);
                _backgroundTilemap.SetColor(new Vector3Int(x, y, 0), _yellow2);
                TilemapUtils.ChangeColor(x, y, _backgroundTilemap, _naturalColor);
            }
        }
    }

}
