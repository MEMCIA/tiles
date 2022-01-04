using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Obstacle : MonoBehaviour
{
    [SerializeField] TileBase tileBase1;
    [SerializeField] Tilemap tileMapWithObstacles;
    [SerializeField] Tilemap tileMap;
    [SerializeField] Ground ground;
    public Vector3Int endOfObstaclesOnMapWithObstaclesCell;
    public Vector3 endOfObstaclesOnMapWorld;
    // height of ground / heightOfObstacleAsPartOfGround = heightOfObstacleInCells
    public float heightOfObstacleAsPartOfGround = 6;
    private void Awake()
    {
        CreateObstacles();
    }
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

    }
    void CreateObstacles()
    {
        // Vector3 startOfObstaclesOnFirstMap = tileMap.CellToWorld(new Vector3Int(0,Mathf.FloorToInt(ground.height/5),0));
        //Vector3Int startOfObstaclesOnSecondMap = tileMap.WorldToCell(startOfObstaclesOnFirstMap);
        Vector3 endOfObstaclesOnFirstMapWorld = tileMap.CellToWorld(new Vector3Int(ground.width, Mathf.FloorToInt(ground.height / heightOfObstacleAsPartOfGround), 0));
        endOfObstaclesOnMapWithObstaclesCell = tileMapWithObstacles.WorldToCell(endOfObstaclesOnFirstMapWorld);
        //endOfObstaclesOnMapWithObstaclesCell = new Vector3Int(endOfObstaclesOnMapWithObstaclesCell.x, endOfObstaclesOnMapWithObstaclesCell.y,0);
        //endOfObstaclesOnMapWithObstaclesWorld = tileMapWithObstacles.CellToWorld(endOfObstaclesOnMapWithObstaclesCell);
        //int width = tileMapWithObstacles.WorldToCell(end.position).x;
        for (int i = 0; i < endOfObstaclesOnMapWithObstaclesCell.x+1; i++)
        {
            tileMapWithObstacles.SetTile(new Vector3Int(i, endOfObstaclesOnMapWithObstaclesCell.y, 0), tileBase1);
           
        }
        
    }
}
