using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Obstacle : MonoBehaviour
{
    [SerializeField] Transform start;
    [SerializeField] Transform end;
    [SerializeField] TileBase tileBase1;
    [SerializeField] Tilemap tileMapWithObstacles;
    [SerializeField] Tilemap tileMap;
    [SerializeField] Ground ground;
    public Vector3Int endOfObstaclesOnSecondMap;


    // Start is called before the first frame update
    void Start()
    {
        CreateObstacles();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void CreateObstacles()
    {
        // Vector3 startOfObstaclesOnFirstMap = tileMap.CellToWorld(new Vector3Int(0,Mathf.FloorToInt(ground.height/5),0));
        //Vector3Int startOfObstaclesOnSecondMap = tileMap.WorldToCell(startOfObstaclesOnFirstMap);
        Vector3 endOfObstaclesOnFirstMap = tileMap.CellToWorld(new Vector3Int(ground.width, Mathf.FloorToInt(ground.height / 5), 0));
        endOfObstaclesOnSecondMap = tileMapWithObstacles.WorldToCell(endOfObstaclesOnFirstMap);

        //int width = tileMapWithObstacles.WorldToCell(end.position).x;
        for (int i = 0; i < endOfObstaclesOnSecondMap.x + 1; i++)
        {
            tileMapWithObstacles.SetTile(new Vector3Int(i, endOfObstaclesOnSecondMap.y, 0), tileBase1);
        }
    }
}
