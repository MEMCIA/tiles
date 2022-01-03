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
    public int[,] map;
    public List<int> listPerlinHeight = new List<int>();
   

    public int startXSpaceForPlayer = 5;
    public int endXSpaceForPlayer = 8;
    public int startYSpaceForPlayer = 2;
    public int endYSpaceForPlayer = 5;
    public List<Vector3> listSpaceForPlayerPositionsWorld = new List<Vector3>();
    private void Awake()
    {
        Generation();
        CreateSpaceForPlayer();
    }
    // Start is called before the first frame update
    void Start()
    {
       

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Generation();
        }
    }
    void CreateSpaceForPlayer()
    {
        
        for (int i = startXSpaceForPlayer; i < endXSpaceForPlayer; i++)
        {
            for (int j = startYSpaceForPlayer; j < endYSpaceForPlayer; j++)
            {
                GroundTileMap.SetTile(new Vector3Int(i, j, 0), null);
                listSpaceForPlayerPositionsWorld.Add(GroundTileMap.CellToWorld(new Vector3Int(i, j, 0)));
            }
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
                    ChangeColor(x, y);
                }
            }
        }
    }
    void clearMap()
    {
        GroundTileMap.ClearAllTiles();
        caveTileMap.ClearAllTiles();
    }
    public void ChangeColor(int x, int y)
    {
        if (y % 2 == 0)
        {
            if (x % 2 == 0)
            {
                GroundTileMap.SetColor(new Vector3Int(x,y,0), new Color32(177,248,248,255));
            }
           
        }
        else
        {
            if (x % 2 != 0)
            {
                GroundTileMap.SetColor(new Vector3Int(x, y, 0), new Color32(177, 248, 248, 255));
            }
           
        }


    }
}

