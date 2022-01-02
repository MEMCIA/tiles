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

    // Start is called before the first frame update
    void Start()
    {

        CreateCookies();
    }
    void CreateCookies()
    {
        float offset = 4;
        float x = obstacle.endOfObstaclesOnMapWithObstaclesWorld.x - offset;
        float y = obstacle.endOfObstaclesOnMapWithObstaclesWorld.y - offset;

        for (int i = 0; i < 3; i++)
        {
            float randomX = Random.Range(offset, x);
            float randomY = Random.Range(offset, y);
            /// popraw zrób cellToworld + offset
            if (randomX >= ground.startXSpaceForPlayer && randomX <= ground.endXSpaceForPlayer)
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
