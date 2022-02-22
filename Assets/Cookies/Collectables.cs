using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Collectables : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    [SerializeField] Ground ground;
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
        Vector3 startPosSpaceForPlayerWorld = tilemap.CellToWorld(new Vector3Int(ground.startXSpaceForPlayer, ground.startYSpaceForPlayer, 0));
        Vector3 endPosForPlayerWorld = tilemap.CellToWorld(new Vector3Int(ground.endXSpaceForPlayer, ground.endYSpaceForPlayer, 0));
        bool isRandomXUnacceptable = ((spawnPoint.x >= startPosSpaceForPlayerWorld.x - offset3) && (spawnPoint.x <= endPosForPlayerWorld.x + offset3));
        bool isRandomYUnacceptable = ((spawnPoint.y >= startPosSpaceForPlayerWorld.y - offset3) && (spawnPoint.y <= endPosForPlayerWorld.y + offset3));
        return isRandomXUnacceptable && isRandomYUnacceptable;
    }

    Vector3 FindSpawnPoint(int i, float HalflengthOfCollectable)
    {
        float offset = HalflengthOfCollectable + grid.cellSize.y + 0.5f;
        float offset2 = HalflengthOfCollectable + grid.cellSize.x + 0.5f;
        float y = _destroyTiles.endPlayerGameAreaY1World - offset;
        float lengthOfCookieArea = ground.endOfLevelWorldV3.x / NumberOfCollectables;
        float randomY = Random.Range(offset2, y / 2);
        float randomX1 = lengthOfCookieArea * i;
        float randomX2 = lengthOfCookieArea * i + lengthOfCookieArea;
        float randomX;

        if (i == 0)
        {
            randomX = Random.Range(randomX1 + offset2, randomX2 - HalflengthOfCollectable * 2);
        }
        else if (i == 4)
        {
            randomX = Random.Range(randomX1 + HalflengthOfCollectable * 2, randomX2 - offset2);
        }
        else
        {
            randomX = Random.Range(randomX1 + HalflengthOfCollectable * 2, randomX2 - HalflengthOfCollectable * 2);
        }

        if (i % 2 == 0)
        {
            randomY = Random.Range(y / 2 + 1, y);
        }
        return new Vector3(randomX, randomY);
    }
}
