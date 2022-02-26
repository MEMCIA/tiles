using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CollectablesSpawner : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    [SerializeField] MainTilemap _mainTilemap;
    [SerializeField] Tilemap tilemap;
    [SerializeField] Grid grid;
    [SerializeField] DestroyTiles _destroyTiles;
    public int NumberOfCollectables = 5;

    // Start is called before the first frame update
    void Start()
    {
        CreateCollectables();
    }

    void CreateCollectables()
    {
        var obj = Instantiate(prefab);
        float HalflengthOfCollectable = obj.GetComponent<PolygonCollider2D>().bounds.extents.x;
        float offset3 = HalflengthOfCollectable + 0.5f;

        for (int i = 0; i < NumberOfCollectables; i++)
        {
            Vector3 spawnPoint = FindSpawnPoint(i, HalflengthOfCollectable);

            if (CheckIfSpawnPositionIsUnacceptable(spawnPoint, offset3))
            {
                i--;
                continue;
            }
            Instantiate(prefab, spawnPoint, prefab.transform.rotation);
        }
    }

    bool CheckIfSpawnPositionIsUnacceptable(Vector3 spawnPoint, float offset3)
    {
        Vector3 startPosSpaceForPlayerWorld = tilemap.CellToWorld(new Vector3Int(_mainTilemap.startXSpaceForPlayer, _mainTilemap.startYSpaceForPlayer, 0));
        Vector3 endPosForPlayerWorld = tilemap.CellToWorld(new Vector3Int(_mainTilemap.endXSpaceForPlayer, _mainTilemap.endYSpaceForPlayer, 0));
        bool isRandomXUnacceptable = ((spawnPoint.x >= startPosSpaceForPlayerWorld.x - offset3) && (spawnPoint.x <= endPosForPlayerWorld.x + offset3));
        bool isRandomYUnacceptable = ((spawnPoint.y >= startPosSpaceForPlayerWorld.y - offset3) && (spawnPoint.y <= endPosForPlayerWorld.y + offset3));
        return isRandomXUnacceptable && isRandomYUnacceptable;
    }

    Vector3 FindSpawnPoint(int i, float HalflengthOfCollectable)
    {
        float offsetX = HalflengthOfCollectable + grid.cellSize.x + 0.5f;
        float lengthX = (_mainTilemap.endOfLevelWorldV3.x - 2*offsetX)/ NumberOfCollectables;
        float x = offsetX + lengthX*i;
        float randomX = Random.Range(x + HalflengthOfCollectable * 2, x+lengthX - HalflengthOfCollectable * 2);

        float offsetY = HalflengthOfCollectable + grid.cellSize.y + 0.5f;
        float lengthY = (_mainTilemap.EndPlayerGameAreaYWorld - offsetY*2)/2;
        float randomY;

        if (i % 2 == 0)
        {
            randomY = Random.Range(lengthY + offsetY + HalflengthOfCollectable, offsetY + 2 * lengthY);
        }
        else
        {
            randomY = Random.Range(offsetY, lengthY + offsetY - HalflengthOfCollectable);
        }
        return new Vector3(randomX, randomY);
    }
}
