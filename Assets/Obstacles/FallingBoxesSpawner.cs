using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class FallingBoxesSpawner : MonoBehaviour
{
    [SerializeField] GameObject _prefab;
    [SerializeField] GameObject _prefab2;
    [SerializeField] Tilemap _tileMapWithObstacles;
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
        int x = 0;
        int length = Mathf.FloorToInt(_tilemapRowOfObstacles.EndOfLevelObstaclesTilemap.x / 3);
        List<Vector3> spawnPositions = new List<Vector3>();

        for (int i = 0; i < 3; i++)
        {
            Vector3Int vectorCell1 = new Vector3Int(Random.Range(x, x+length), _tilemapRowOfObstacles.HeightOfLevelObstaclesTilemap, 0);
            spawnPositions.Add(_tileMapWithObstacles.CellToWorld(vectorCell1));
            x += length;
        }
        return spawnPositions;
    }

    void SpawnFallingDownObstacles()
    {
        if (playerScript.win) return;
        if (playerScript.dead) return;
        List<Vector3> spawnPositions = CreateSpawnPositions();
        GameObject prefabToUse = _prefab;

        if (Random.Range(0, 2) == 1)
        {
            prefabToUse = _prefab2;
        }
        foreach (var item in spawnPositions)
        {
            Instantiate(prefabToUse, item, prefabToUse.transform.rotation);
        }
    }
}
