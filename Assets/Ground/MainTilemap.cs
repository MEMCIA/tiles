using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MainTilemap : MonoBehaviour
{
    public int width, height;
    [SerializeField] TileBase groundTile, upTile;
    [SerializeField] Tilemap groundTileMap;
    [System.NonSerialized] public int heightOfLevelGroundTilemap;
    [System.NonSerialized] public Vector3 endOfLevelWorldTPosition;
    public Transform endOfLevelWorldT;
    [System.NonSerialized] public Vector3 endOfLevelWorldV3;
    [System.NonSerialized] public Vector3Int endOfLevelGroundTilemap;

    //space for player
    [System.NonSerialized] public int startXSpaceForPlayer = 5;
    [System.NonSerialized] public int endXSpaceForPlayer = 8;
    [System.NonSerialized] public int startYSpaceForPlayer = 2;
    [System.NonSerialized] public int endYSpaceForPlayer = 5;
    [System.NonSerialized] public List<Vector3> listSpaceForPlayerPositionsWorld = new List<Vector3>();

    //game area Y up
    [System.NonSerialized] public float EndPlayerGameAreaYWorld;
    [System.NonSerialized] public int OffsetYGameAreaUp = -2;

    //colors
    [System.NonSerialized] public Color32 naturalColor = new Color32(255, 255, 255, 255);
    [System.NonSerialized] public Color32 blue1 = new Color32(177, 248, 248, 255);
    [System.NonSerialized] public Color32 blueUpTiles = new Color32(157, 188, 246, 255);

    private void Awake()
    {
        endOfLevelWorldTPosition = endOfLevelWorldT.position;
        heightOfLevelGroundTilemap = groundTileMap.WorldToCell(endOfLevelWorldTPosition).y;
        endOfLevelGroundTilemap = groundTileMap.WorldToCell(endOfLevelWorldTPosition);
        endOfLevelWorldV3 = endOfLevelWorldTPosition;
        EndPlayerGameAreaYWorld = groundTileMap.CellToWorld(new Vector3Int(0, heightOfLevelGroundTilemap + OffsetYGameAreaUp, 0)).y;
        CreateTilemap();
        CreateSpaceForPlayer();
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

    void CreateTilemap()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                groundTileMap.SetTile(new Vector3Int(x, y, 0), groundTile);
                if (y >= endOfLevelGroundTilemap.y)
                {
                    groundTileMap.SetTile(new Vector3Int(x, y, 0), upTile);
                    groundTileMap.SetColor(new Vector3Int(x, y, 0), blueUpTiles);
                }
                TilemapUtils.ChangeColor(x, y, groundTileMap, blue1);
            }
        }
    }
    
   
}

