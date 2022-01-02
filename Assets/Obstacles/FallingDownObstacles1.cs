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
            InvokeRepeating("SpawnFallingDownObstacles", 1, 0.3f);
            start = true;
        }
    }
    void SpawnFallingDownObstacles()
    {
        
        float offsetX = obstacle.endOfObstaclesOnMapWithObstaclesWorld.x - Mathf.FloorToInt(obstacle.endOfObstaclesOnMapWithObstaclesWorld.x +1);
        int randomX = Random.Range(0, Mathf.FloorToInt(obstacle.endOfObstaclesOnMapWithObstaclesWorld.x));
        Vector3 spawnPos = new Vector3(randomX+offsetX, obstacle.endOfObstaclesOnMapWithObstaclesWorld.y, 0);
        Instantiate(prefab, spawnPos, prefab.transform.rotation);
    }
    void AddCollider()
    {
        
    }
}
