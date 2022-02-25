using UnityEngine;
using UnityEngine.Tilemaps;
using System;

public class TilemapRowOfObstacles : MonoBehaviour
{
    [NonSerialized] public int HeightOfLevelObstaclesTilemap;
    [NonSerialized] public Vector3Int EndOfLevelObstaclesTilemap;
    [SerializeField] TileBase _tileBase;
    [SerializeField] Tilemap _tileMapWithObstacles;
    [SerializeField] MainTilemap _mainTilemap;

    private void Awake()
    {
           
    }

    // Start is called before the first frame update
    void Start()
    {
        HeightOfLevelObstaclesTilemap = _tileMapWithObstacles.WorldToCell(_mainTilemap.endOfLevelWorldTPosition).y;
        EndOfLevelObstaclesTilemap = _tileMapWithObstacles.WorldToCell(_mainTilemap.endOfLevelWorldTPosition);
        CreateRowOfObstacles();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void CreateRowOfObstacles()
    {
        for (int i = 0; i < EndOfLevelObstaclesTilemap.x + 1; i++)
        {
            _tileMapWithObstacles.SetTile(new Vector3Int(i, EndOfLevelObstaclesTilemap.y, 0), _tileBase);
        }

    }
}
