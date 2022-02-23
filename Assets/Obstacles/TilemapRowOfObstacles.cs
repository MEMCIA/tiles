using UnityEngine;
using UnityEngine.Tilemaps;
using System;

public class TilemapRowOfObstacles : MonoBehaviour
{
    [NonSerialized] public int heightOfLevelObstaclesTilemap;
    [NonSerialized] public Vector3Int endOfLevelObstaclesTilemap;
    [SerializeField] TileBase tileBase1;
    [SerializeField] Tilemap tileMapWithObstacles;
    [SerializeField] MainTilemap _mainTilemap;

    private void Awake()
    {
           
    }

    // Start is called before the first frame update
    void Start()
    {
        heightOfLevelObstaclesTilemap = tileMapWithObstacles.WorldToCell(_mainTilemap.endOfLevelWorldTPosition).y;
        endOfLevelObstaclesTilemap = tileMapWithObstacles.WorldToCell(_mainTilemap.endOfLevelWorldTPosition);
        CreateRowOfObstacles();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void CreateRowOfObstacles()
    {
        for (int i = 0; i < endOfLevelObstaclesTilemap.x + 1; i++)
        {
            tileMapWithObstacles.SetTile(new Vector3Int(i, endOfLevelObstaclesTilemap.y, 0), tileBase1);
        }

    }
}
