using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TestTile : MonoBehaviour
{
    WorldTile tile;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var worlddPoint = new Vector3Int(Mathf.FloorToInt(point.x), Mathf.FloorToInt(point.y), Mathf.FloorToInt(point.z));
            var tiles = GameTiles.instance.tiles;
            if(tiles.TryGetValue(worlddPoint,out tile))
            {
                print("Tile " + tile.Name + " costs: " + tile.Cost);
                tile.TileMapMember.SetTileFlags(tile.LocalPlace, TileFlags.None);
                tile.TileMapMember.SetColor(tile.LocalPlace, Color.green);
            }
        }
    }
}
