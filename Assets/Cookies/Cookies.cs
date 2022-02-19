using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Cookies : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    [SerializeField] Ground ground;
    [SerializeField] Tilemap tilemap;
    [SerializeField] Grid grid;
    [SerializeField] GameObject symbolOfCookiePrefab;
    [SerializeField] GameObject startShadowOfCookie;
    [SerializeField] DestroyGround destroyGround;
    public List<Vector3> shadowsOfCookieList = new List<Vector3>();
    int numberOfCookies = 5;
    // Start is called before the first frame update
    void Start()
    {
        shadowsOfCookieList.Add(startShadowOfCookie.transform.position);
        CreateSymbolOfObjectToFind();
        CreateCookies();
    }

    void CreateSymbolOfObjectToFind()
    {
        for (int i = 1; i < numberOfCookies; i++)
        {
            float distanceBetweenCookies = startShadowOfCookie.GetComponent<PolygonCollider2D>().bounds.extents.x * 3 - 1;
            Vector3 spawnPos = new Vector3(startShadowOfCookie.transform.position.x - distanceBetweenCookies * i, startShadowOfCookie.transform.position.y);
            shadowsOfCookieList.Add(spawnPos);
            Instantiate(symbolOfCookiePrefab, spawnPos, symbolOfCookiePrefab.transform.rotation);
        }
    }
    void CreateCookies()
    {
        var obj = Instantiate(prefab);
        float HalflengthOfCookie = obj.GetComponent<PolygonCollider2D>().bounds.extents.x;
        float offset3 = HalflengthOfCookie + 0.5f;

        for (int i = 0; i < numberOfCookies; i++)
        {
            Vector3 spawnPoint = FindSpawnPoint(i, HalflengthOfCookie);

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

    Vector3 FindSpawnPoint(int i, float HalflengthOfCookie)
    {
        float offset = HalflengthOfCookie + grid.cellSize.y + 0.5f;
        float offset2 = HalflengthOfCookie + grid.cellSize.x + 0.5f;
        float y = destroyGround.endPlayerGameAreaY1World - offset;
        float lengthOfCookieArea = ground.endOfLevelWorldV3.x / numberOfCookies;
        float randomY = Random.Range(offset2, y / 2);
        float randomX1 = lengthOfCookieArea * i;
        float randomX2 = lengthOfCookieArea * i + lengthOfCookieArea;
        float randomX;

        if (i == 0)
        {
            randomX = Random.Range(randomX1 + offset2, randomX2 - HalflengthOfCookie * 2);
        }
        else if (i == 4)
        {
            randomX = Random.Range(randomX1 + HalflengthOfCookie * 2, randomX2 - offset2);
        }
        else
        {
            randomX = Random.Range(randomX1 + HalflengthOfCookie * 2, randomX2 - HalflengthOfCookie * 2);
        }

        if (i % 2 == 0)
        {
            randomY = Random.Range(y / 2 + 1, y);
        }
        return new Vector3(randomX, randomY);
    }
}
