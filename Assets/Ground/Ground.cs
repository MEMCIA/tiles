using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Ground : MonoBehaviour
{
    public int width, height;
    [SerializeField] float smoothness;
    [SerializeField] float seed;
    [SerializeField] TileBase groundTile, upTile, backGroundTile;
    [SerializeField] Tilemap groundTileMap, obstaclesTilemap, backgroundTilemap;

    [SerializeField] float modifier;
    public int[,] map;
    public List<int> listPerlinHeight = new List<int>();

    [System.NonSerialized] public float heightOfLevelWorld;
    [System.NonSerialized] public int heightOfLevelGroundTilemap;
    [System.NonSerialized] public int heightOfLevelObstaclesTilemap;
    public Transform endOfLevelWorldT;
    [System.NonSerialized] public Vector3 endOfLevelWorldV3;
    [System.NonSerialized] public Vector3Int endOfLevelGroundTilemap;
    [System.NonSerialized] public Vector3Int endOfLevelObstaclesTilemap;


    [System.NonSerialized] public int startXSpaceForPlayer = 5;
    [System.NonSerialized] public int endXSpaceForPlayer = 8;
    [System.NonSerialized] public int startYSpaceForPlayer = 2;
    [System.NonSerialized] public int endYSpaceForPlayer = 5;
    [System.NonSerialized] public List<Vector3> listSpaceForPlayerPositionsWorld = new List<Vector3>();

    //colors
    [System.NonSerialized] public Color32 naturalColor = new Color32(255, 255, 255, 255);
    [System.NonSerialized] public Color32 blue1 = new Color32(177, 248, 248, 255);
    [System.NonSerialized] public Color32 blueUpTiles = new Color32(157, 188, 246, 255);
    [System.NonSerialized] public Color32 yellow2 = new Color32(255, 255, 255, 180);
   

    private void Awake()
    {
        Vector3 endOfLevelWorldTPosition = endOfLevelWorldT.position;
        heightOfLevelWorld = endOfLevelWorldTPosition.y;
        heightOfLevelGroundTilemap = groundTileMap.WorldToCell(endOfLevelWorldTPosition).y;
        heightOfLevelObstaclesTilemap = obstaclesTilemap.WorldToCell(endOfLevelWorldTPosition).y;

        endOfLevelGroundTilemap = groundTileMap.WorldToCell(endOfLevelWorldTPosition);
        endOfLevelObstaclesTilemap = obstaclesTilemap.WorldToCell(endOfLevelWorldTPosition);
        endOfLevelWorldV3 = endOfLevelWorldTPosition;

        Generation();
        CreateSpaceForPlayer();
        RenderBackgroundMap();


    }
    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {

    }
    void CreateSpaceForPlayer()
    {

        for (int i = startXSpaceForPlayer; i < endXSpaceForPlayer; i++)
        {
            for (int j = startYSpaceForPlayer; j < endYSpaceForPlayer; j++)
            {
                groundTileMap.SetTile(new Vector3Int(i, j, 0), null);
                listSpaceForPlayerPositionsWorld.Add(groundTileMap.CellToWorld(new Vector3Int(i, j, 0)));
            }
        }

    }

    void Generation()
    {
        //seed = Random.Range(-10000, 10000);
        //clearMap();
        groundTileMap.ClearAllTiles();
        map = GenerateArray(width, height, true);
        map = TerrainGeneration(map);
        RenderMap();
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
    void RenderMap()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                if (map[x, y] == 1)
                {
                    groundTileMap.SetTile(new Vector3Int(x, y, 0), groundTile);
                    if (y >= endOfLevelGroundTilemap.y)
                    {
                        groundTileMap.SetTile(new Vector3Int(x, y, 0), upTile);
                        groundTileMap.SetColor(new Vector3Int(x, y, 0), blueUpTiles);
                    }

                    ChangeColor(x, y, groundTileMap, blue1);
                }
            }
        }
    }
    void RenderBackgroundMap()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                if (map[x, y] == 1)
                {
                    backgroundTilemap.SetTile(new Vector3Int(x, y, 0), backGroundTile);
                    backgroundTilemap.SetColor(new Vector3Int(x, y, 0), yellow2);
                    ChangeColor(x, y, backgroundTilemap,naturalColor);
                   
                    //if (y >= endOfLevelGroundTilemap.y) GroundTileMap.SetTile(new Vector3Int(x, y, 0), upTile);

                    
                }
            }
        }
    }

    public void ChangeColor(int x, int y, Tilemap tilemap, Color32 color)
    {
        //if (y >= endOfLevelGroundTilemap.y) return;

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

