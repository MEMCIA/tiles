using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class FallingDownObstacles1 : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    [SerializeField] GameObject prefab2;
    [SerializeField] Tilemap tilemapWithObstacles;
    [SerializeField] GameObject player;
    [SerializeField] MainTilemap _mainTilemap;
    [SerializeField] TilemapRowOfObstacles _tilemapRowOfObstacles;
    MovePlayer movePlayer;
    Player playerScript;
    public bool AreBoxesFalling = false;
    // Start is called before the first frame update
    void Start()
    {
        movePlayer = player.GetComponent<MovePlayer>();
        playerScript = player.GetComponent<Player>(); 
    }

    // Update is called once per frame
    void Update()
    {
        StartSpawn();
    }

    void StartSpawn()
    {
        if (player.transform.position == playerScript.StartPlayerPos) return;
        if (AreBoxesFalling) return;
        InvokeRepeating("SpawnFallingDownObstacles", 1, 1.5f);
        AreBoxesFalling = true;
    }

    List<Vector3> CreateSpawnPositions()
    {
        int x1 = Mathf.FloorToInt(_tilemapRowOfObstacles.endOfLevelObstaclesTilemap.x / 3);
        int x2 = x1 * 2;
        int x3 = _tilemapRowOfObstacles.endOfLevelObstaclesTilemap.x;
        List<Vector3> spawnPositions = new List<Vector3>();
        Vector3Int vectorCell1 = new Vector3Int(Random.Range(0, x1), _tilemapRowOfObstacles.heightOfLevelObstaclesTilemap,0);
        Vector3Int vectorCell2 = new Vector3Int(Random.Range(x1, x2), _tilemapRowOfObstacles.heightOfLevelObstaclesTilemap, 0);
        Vector3Int vectorCell3 = new Vector3Int(Random.Range(x2, x3), _tilemapRowOfObstacles.heightOfLevelObstaclesTilemap, 0);
        spawnPositions.Add(tilemapWithObstacles.CellToWorld(vectorCell1));   
        spawnPositions.Add(tilemapWithObstacles.CellToWorld(vectorCell2));  
        spawnPositions.Add(tilemapWithObstacles.CellToWorld(vectorCell3));
        return spawnPositions;
    }

    void SpawnFallingDownObstacles()
    {
        if (playerScript.win) return;
        if (playerScript.dead) return;
        List<Vector3> spawnPositions = CreateSpawnPositions();
        GameObject prefabToUse = prefab;

        if (Random.Range(0, 2) == 1)
        {
            prefabToUse = prefab2;
        }
        foreach (var item in spawnPositions)
        {
            Instantiate(prefabToUse, item, prefab.transform.rotation);
        }

    }

}
