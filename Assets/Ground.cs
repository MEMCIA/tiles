using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Ground : MonoBehaviour
{
   public int width, height;
    [SerializeField] float smoothness;
    [SerializeField] float seed;
    [SerializeField] TileBase groundTile, caveTile;
    [SerializeField] Tilemap GroundTileMap, caveTileMap;
    [Header("Caves")]
    [SerializeField] float modifier;
    int[,] map;
    public List<int> listPerlinHeight = new List<int>();

    // Start is called before the first frame update
    void Start()
    {
        Generation();
        GroundTileMap.SetTile(new Vector3Int(0, 0, 0), null);
        GroundTileMap.SetTile(new Vector3Int(5, 2, 0), null);
        GroundTileMap.SetTile(new Vector3Int(5, 3, 0), null);
        GroundTileMap.SetTile(new Vector3Int(5, 4, 0), null);
        GroundTileMap.SetTile(new Vector3Int(6, 2, 0), null);
        GroundTileMap.SetTile(new Vector3Int(6, 3, 0), null);
        GroundTileMap.SetTile(new Vector3Int(6, 4, 0), null);
       // gameObject.AddComponent<TilemapCollider2D>();


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Generation();
        }
    }
    void Generation()
    {
        //seed = Random.Range(-10000, 10000);
        //clearMap();
        GroundTileMap.ClearAllTiles();
        map = GenerateArray(width, height, true);
        map = TerrainGeneration(map);
        RenderMap(map, GroundTileMap, groundTile);
    }
    public int[,] GenerateArray(int width, int height, bool empty)
    {
        int[,] map = new int[width, height];
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                map[x, y] = (empty) ? 0 : 1;
            }
        }
        return map;
    }
    public int[,] TerrainGeneration(int[,] map)
    {
        for (int x = 0; x < width; x++)
        {
            int perlinHeight;
            perlinHeight = Mathf.RoundToInt(Mathf.PerlinNoise(x / smoothness, seed) * height / 2);
            perlinHeight += height / 2;
            listPerlinHeight.Add(perlinHeight);
            for (int y = 0; y < perlinHeight; y++)
            {
                map[x, y] = 1;
            }
        }
        return map;

    }
    void RenderMap(int[,] map, Tilemap groundTileMap, TileBase groundTilebase)
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                if (map[x, y] == 1)
                {
                    GroundTileMap.SetTile(new Vector3Int(x, y, 0), groundTilebase);
                    //GroundTileMap.SetColliderType(new Vector3Int(x, y, 0), Tile.ColliderType.Grid);
                }
            }
        }
    }
    void clearMap()
    {
        GroundTileMap.ClearAllTiles();
        caveTileMap.ClearAllTiles();
    }
}

