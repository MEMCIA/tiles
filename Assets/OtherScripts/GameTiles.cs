using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GameTiles : MonoBehaviour
{
    public static GameTiles instance;
    public Tilemap Tilemap;
    public Dictionary<Vector3, WorldTile> tiles;

    private void Awake()
    {
        GetWorldTiles();
    }

    void GetWorldTiles()
    {
        tiles = new Dictionary<Vector3, WorldTile>();
        foreach (var pos in Tilemap.cellBounds.allPositionsWithin)
        {
            var localPlace = new Vector3Int(pos.x, pos.y, pos.z);
            if (!Tilemap.HasTile(localPlace)) continue;
            var tile = new WorldTile
            {
                LocalPlace = localPlace,
            WorldLocation = Tilemap.CellToWorld(localPlace),
            TileBase = Tilemap.GetTile(localPlace),
            TileMapMember = Tilemap,
            Name = localPlace.x + "," + localPlace.y,
            Cost = 1
            };
            tiles.Add(tile.WorldLocation, tile);
        }
    }
}
