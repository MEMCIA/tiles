using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Cookies : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    [SerializeField] Obstacle obstacle;
    [SerializeField] Ground ground;
    [SerializeField] Tilemap tilemap;
    [SerializeField] Grid grid;
    // Start is called before the first frame update
    void Start()
    {

        CreateCookies();
    }
    void CreateCookies()
    {
        float offset = GetComponent<CircleCollider2D>().radius+0.1f;
        float offset2 = GetComponent<CircleCollider2D>().radius + 0.1f+ grid.cellSize.x;
        DestroyGround destroyGround = ground.GetComponent<DestroyGround>();
        float x = obstacle.endOfObstaclesOnMapWithObstaclesWorld.x - offset;
        float y = destroyGround.endPlayerGameAreaY1 - offset;

        for (int i = 0; i < 5; i++)
        {
            float randomX = Random.Range(offset, x);
            float randomY = Random.Range(offset, y);
            Vector3 startPosSpaceForPlayerWorld = tilemap.CellToWorld(new Vector3Int(ground.startXSpaceForPlayer, ground.startYSpaceForPlayer, 0));
            Vector3 endPosForPlayerWorld = tilemap.CellToWorld(new Vector3Int(ground.endXSpaceForPlayer, ground.endYSpaceForPlayer,0));
            /// popraw zrób cellToworld + offset
            if (randomX >= startPosSpaceForPlayerWorld.x - offset && randomX <= endPosForPlayerWorld.x + offset)//zrobione
            {
                i--;
                continue;
            }
            if (randomY >= ground.startYSpaceForPlayer && randomY <= ground.endYSpaceForPlayer)
            {
                i--;
                continue;
            }
            Instantiate(prefab, new Vector3(randomX, randomY), prefab.transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
