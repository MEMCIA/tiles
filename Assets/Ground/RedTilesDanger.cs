using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class RedTilesDanger : MonoBehaviour
{
    public Tilemap tilemap;
    public Ground ground;
    public TileBase tilebase;
    [SerializeField] GameObject player;
    [SerializeField] Obstacle obstacleScript;
    bool danger1Showed = false;
    int heightOfObstacle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player.transform.position!=player.GetComponent<MovePlayer>().startPlayerPos)
        {
            if (danger1Showed) return;
            ShowDanger();
            danger1Showed = true;
        }
        
    }
    void ShowDanger()
    {
        heightOfObstacle = Mathf.FloorToInt(ground.height / obstacleScript.heightOfObstacleAsPartOfGround);
        StopAllCoroutines();
        StartCoroutine(MakeTilesRed());
       


    }
    void SetChangedColor()
    {
        for (int x = 0; x < ground.width; x++)
        {
            for (int y = 0; y < heightOfObstacle; y++)
            {
                if (!tilemap.ContainsTile(tilebase)) continue;

                ground.ChangeColor(x, y);
               
            }
        }
    }

    //tile.TileMapMember.SetColor(tile.LocalPlace, Color.green);

    IEnumerator MakeTilesRed( )
{
       
        //tilemap.SetColor
        byte g = 255;
        byte b = 255;
        while(g>0)
        {
            for (int i = 0; i < heightOfObstacle; i++)
            {
                for (int j = 0; j < ground.width; j++)
                {
                    if (!tilemap.ContainsTile(tilebase)) continue;
                    
                    tilemap.SetColor(new Vector3Int(j, i, 0), new Color32(255, g, b, 255));
                   
                }
               
            }
            g -= 5;
            b -= 5;
            yield return new WaitForSeconds(0.005f);
          
        }
        StopAllCoroutines();
        StartCoroutine(MakeOriginalColorOfTiles());




    }
    IEnumerator MakeOriginalColorOfTiles()
    {
       
        int heightOfObstacle = Mathf.FloorToInt(ground.height / obstacleScript.heightOfObstacleAsPartOfGround);
        byte g = 0;
        byte b = 0;
        while(g<255)
        {
            for (int i = 0; i < heightOfObstacle; i++)
            {
                for (int j = 0; j < ground.width; j++)
                {
                    if (!tilemap.ContainsTile(tilebase)) continue;
                    tilemap.SetColor(new Vector3Int(j, i, 0), new Color32(255, g, b, 255));
                }
            }
            g += 5;
            b += 5;
            yield return new WaitForSeconds(0.005f);
        }
        SetChangedColor();
    }
}

