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
    float offset3;
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
        /*
        Vector3 tr = prefab.transform.localScale;
        CircleCollider2D[] colliders = prefab.GetComponents<CircleCollider2D>();
        float startX = Mathf.Min(colliders[0].bounds.min.x,colliders[1].bounds.min.x);
        float endX = Mathf.Max(colliders[0].bounds.max.x, colliders[1].bounds.max.x);
        float length = endX - startX;
        Debug.Log("minx0: " + colliders[0].bounds.min.x);
        Debug.Log("minx1: " + colliders[1].bounds.min.x);
        Debug.Log("length of colliders: "+length);
        Debug.Log("startX " + startX);
        Debug.Log("endX " + endX);
        float x1 = colliders[0].bounds.center.x;
        float x2 = colliders[1].bounds.center.x;
        float difference =Mathf.Abs(x1-x2);
        float radius = colliders[0].bounds.center.x/2;
        float x11 = Mathf.Min(colliders[0].bounds.min.x, colliders[1].bounds.min.x);
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
        */
        float lengthOfCookie = prefab.GetComponent<PolygonCollider2D>().bounds.extents.x;
        offset2 = lengthOfCookie + grid.cellSize.x + 0.5f;
        offset = lengthOfCookie + grid.cellSize.x*2 + 0.5f;
        offset3 = lengthOfCookie + 0.5f;
        x = ground.endOfLevelWorldV3.x - offset2;
        y = destroyGround.endPlayerGameAreaY1World - offset;

        Debug.Log(" Cookies x " + x);
        Debug.Log("Cookies y" +y);
        Debug.Log("Cookies length" + lengthOfCookie);
        Debug.Log("Cookies cell"+ grid.cellSize.x);
        Debug.Log("Cookies offset" + offset);
        Debug.Log("Cookies offset2: " +offset2);
        Debug.Log("Cookies offset3: " + offset3);
        for (int i = 0; i < 5; i++)
        {
            float randomX = Random.Range(offset2, x);
            float randomY = Random.Range(offset2, y);
            Vector3 startPosSpaceForPlayerWorld = tilemap.CellToWorld(new Vector3Int(ground.startXSpaceForPlayer, ground.startYSpaceForPlayer, 0));
            Vector3 endPosForPlayerWorld = tilemap.CellToWorld(new Vector3Int(ground.endXSpaceForPlayer, ground.endYSpaceForPlayer,0));
            /// popraw zrób cellToworld + offset
            /// 
            /*
            if (randomX >= startPosSpaceForPlayerWorld.x - offset3 && randomX <= endPosForPlayerWorld.x + offset3)//zrobione
            {
                i--;
                continue;
            }
            if (randomY >= startPosSpaceForPlayerWorld.y-offset3 && randomY <= endPosForPlayerWorld.y+offset3)
            {
                i--;
                continue;
            }
            */
            Instantiate(prefab, new Vector3(randomX, randomY), prefab.transform.rotation);
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
