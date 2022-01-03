using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class FallingDownObstacles1 : MonoBehaviour
{
    [SerializeField] Obstacle obstacle;
    [SerializeField] GameObject prefab;
    [SerializeField] GameObject prefab2;
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
            InvokeRepeating("SpawnFallingDownObstacles", 1, 1f);
            start = true;
        }
    }
    void SpawnFallingDownObstacles()
    {
        
        int x1 = Mathf.FloorToInt(obstacle.endOfObstaclesOnMapWithObstaclesCell.x / 3);
        int x2 = x1 * 2;
        int x3 = obstacle.endOfObstaclesOnMapWithObstaclesCell.x;
       
        List<int> randomX = new List<int>();
        randomX.Add(Random.Range(0, x1));
        randomX.Add(Random.Range(x1, x2));
        randomX.Add(Random.Range(x2, x3));
        //Vector3 offsetX = new Vector3(obstacle.endOfObstaclesOnMapWithObstaclesWorld.x - Mathf.FloorToInt(obstacle.endOfObstaclesOnMapWithObstaclesWorld.x),0);
        Vector3 offsetX = new Vector3(2, 0, 0);
        GameObject prefabToUse = prefab;
        if (Random.Range(0,2)==1)
        {
            prefabToUse = prefab2;
        }
        foreach (var item in randomX)
        {
            Vector3 randomPos = tilemapWithObstacles.CellToWorld(new Vector3Int(item, obstacle.endOfObstaclesOnMapWithObstaclesCell.y, 0));
            Instantiate(prefabToUse, randomPos+offsetX, prefab.transform.rotation);
        }
        
        
       
    }
    void AddCollider()
    {
        
    }
}
