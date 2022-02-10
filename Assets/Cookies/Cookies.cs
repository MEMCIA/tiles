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
    [SerializeField] GameObject shadowOfCookiePrefab;
    [SerializeField] GameObject startShadowOfCookie;
    [SerializeField] DestroyGround destroyGround;
    public List<Vector3> shadowsOfCookieList = new List<Vector3>();
    float offset;
    float offset2;
    float offset3;
    float x;
    float y;
    int numberOfCookies = 5;
    // Start is called before the first frame update
    void Start()
    {
        shadowsOfCookieList.Add(startShadowOfCookie.transform.position);
        CreateShadowOfCookies();
        CreateCookies();
    }
    void CheckArea()
    {

    }
    void CreateShadowOfCookies()
    {
        for (int i = 1; i < numberOfCookies; i++)
        {
            float distanceBetweenCookies = startShadowOfCookie.GetComponent<PolygonCollider2D>().bounds.extents.x * 3-1;
            Vector3 spawnPos = new Vector3(startShadowOfCookie.transform.position.x - distanceBetweenCookies * i, startShadowOfCookie.transform.position.y);
            shadowsOfCookieList.Add(spawnPos);
            Instantiate(shadowOfCookiePrefab, spawnPos, shadowOfCookiePrefab.transform.rotation);

        }
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
        var obj = Instantiate(prefab);
        float HalflengthOfCookie = obj.GetComponent<PolygonCollider2D>().bounds.extents.x;
        offset2 = HalflengthOfCookie + grid.cellSize.x + 0.5f;
        offset = HalflengthOfCookie + grid.cellSize.y+ 0.5f;
        offset3 = HalflengthOfCookie + 0.5f;
       
        y = destroyGround.endPlayerGameAreaY1World - offset;

        float lengthOfCookieArea = ground.endOfLevelWorldV3.x / numberOfCookies;
        

        Debug.Log(" Cookies x " + x);
        Debug.Log("Cookies y" +y);
        Debug.Log("Cookies length" + HalflengthOfCookie);
        Debug.Log("Cookies cell"+ grid.cellSize.x);
        Debug.Log("Cookies offset" + offset);
        Debug.Log("Cookies offset2: " +offset2);
        Debug.Log("Cookies offset3: " + offset3);
        for (int i = 0; i < numberOfCookies; i++)
        {
           
            float randomX1 = lengthOfCookieArea * i;
            float randomX2 = lengthOfCookieArea * i + lengthOfCookieArea;
            float randomX;
            if (i==0)
            {
                randomX = Random.Range(randomX1 + offset2, randomX2 - HalflengthOfCookie * 2);
            }
            else if(i==4)
            {
                randomX = Random.Range(randomX1 + HalflengthOfCookie * 2, randomX2 - offset2);
            }
            else
            {
                randomX = Random.Range(randomX1 + HalflengthOfCookie * 2, randomX2 - HalflengthOfCookie * 2);
            }
            float randomY = Random.Range(offset2, y/2);
            if (i%2==0)
            {
                randomY = Random.Range(y / 2+1,y);
            }
            
            Vector3 startPosSpaceForPlayerWorld = tilemap.CellToWorld(new Vector3Int(ground.startXSpaceForPlayer, ground.startYSpaceForPlayer, 0));
            Vector3 endPosForPlayerWorld = tilemap.CellToWorld(new Vector3Int(ground.endXSpaceForPlayer, ground.endYSpaceForPlayer,0));
            bool isRandomXAcceptable = !(randomX >= startPosSpaceForPlayerWorld.x - offset3 && randomX <= endPosForPlayerWorld.x + offset3);
            bool isRandomYAcceptable = !(randomY >= startPosSpaceForPlayerWorld.y - offset3 && randomY <= endPosForPlayerWorld.y + offset3);
            if(!isRandomXAcceptable&&!isRandomYAcceptable)
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
