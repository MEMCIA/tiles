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
    bool danger1Showed = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player.transform.position.x!=player.GetComponent<MovePlayer>().startPlayerPos.x)
        {
            if (danger1Showed) return;
            ShowDanger();
            danger1Showed = true;
        }
        
    }
    void ShowDanger()
    {
        StopAllCoroutines();
        StartCoroutine(MakeTilesRed());
    }

    //tile.TileMapMember.SetColor(tile.LocalPlace, Color.green);

    IEnumerator MakeTilesRed( )
{
        int heightOfObstacle = Mathf.FloorToInt(ground.height / 5);
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
        Debug.Log("Korutynka");
        int heightOfObstacle = Mathf.FloorToInt(ground.height / 5);
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
    }
}

