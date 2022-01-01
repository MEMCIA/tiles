using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class FallingDownObstacles1 : MonoBehaviour
{
    [SerializeField] Obstacle obstacle;
    [SerializeField] GameObject prefab;
    [SerializeField] Tilemap tilemapWithObstacles;
    [SerializeField] GameObject player;
    bool start = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.x != player.GetComponent<MovePlayer>().startPlayerPos.x)
        {
            if (start) return;
            InvokeRepeating("SpawnFallingDownObstacles", 1, 0.5f);
            start = true;
        }
    }
    void SpawnFallingDownObstacles()
    {
        Vector3 endOfObstacleToWorld = tilemapWithObstacles.CellToWorld(obstacle.endOfObstaclesOnSecondMap);
        float offsetX = endOfObstacleToWorld.x - Mathf.FloorToInt(endOfObstacleToWorld.x +1);
        int randomX = Random.Range(0, Mathf.FloorToInt(endOfObstacleToWorld.x));
        Vector3 spawnPos = new Vector3(randomX+offsetX, endOfObstacleToWorld.y, 0);
        Instantiate(prefab, spawnPos, prefab.transform.rotation);
    }
    void AddCollider()
    {
        
    }
}
