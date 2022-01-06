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
    [SerializeField] DestroyGround destroyGround;
    float offset;
    float offset2;
    float x;
    float y;
    // Start is called before the first frame update
    void Start()
    {

        CreateCookies();
    }
    void CheckArea()
    {

    }
    void CreateCookies()
    {
        Vector3 tr = prefab.transform.localScale;
        CircleCollider2D[] colliders = prefab.GetComponents<CircleCollider2D>();
        float x1 = colliders[0].bounds.center.x;
        float x2 = colliders[1].bounds.center.x;
        float difference =Mathf.Abs(x1-x2);
        float radius = colliders[0].bounds.center.x/2;
        Debug.Log(radius);
        offset = prefab.GetComponent<CircleCollider2D>().radius+0.1f+difference;
        
       offset2 = prefab.GetComponent<CircleCollider2D>().radius*prefab.transform.localScale.x + 0.1f+ grid.cellSize.x +difference;// offset on the right/left/down of map
        Debug.Log("Length"+colliders.Length);
        Debug.Log("x1" +x1);
        Debug.Log("x2" + x2);
        Debug.Log("offset"+offset2);
        Debug.Log("radius"+ prefab.GetComponent<CircleCollider2D>().radius*prefab.transform.localScale.x);
        Debug.Log("cell"+ grid.cellSize.x);
        Debug.Log("difference" + difference);
        x = obstacle.endOfObstaclesOnMapWorld.x - offset2;
        y = destroyGround.endPlayerGameAreaY1 - offset2;

        for (int i = 0; i < 5; i++)
        {
            float randomX = Random.Range(offset2, x);
            float randomY = Random.Range(offset2, y);
            Vector3 startPosSpaceForPlayerWorld = tilemap.CellToWorld(new Vector3Int(ground.startXSpaceForPlayer, ground.startYSpaceForPlayer, 0));
            Vector3 endPosForPlayerWorld = tilemap.CellToWorld(new Vector3Int(ground.endXSpaceForPlayer, ground.endYSpaceForPlayer,0));
            /// popraw zrób cellToworld + offset
            if (randomX >= startPosSpaceForPlayerWorld.x - offset && randomX <= endPosForPlayerWorld.x + offset)//zrobione
            {
                i--;
                continue;
            }
            if (randomY >= startPosSpaceForPlayerWorld.y-offset && randomY <= endPosForPlayerWorld.y+offset)
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
