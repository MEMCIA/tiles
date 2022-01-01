using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class KotyGround : MonoBehaviour
{
    public int width, height;
    [SerializeField] float smoothness;
    [SerializeField] float seed;
    [SerializeField] TileBase kot1,kot2,kot3,kot4;
    [SerializeField] Tilemap GroundTileMap, caveTileMap;
  
    [SerializeField] float modifier;
    public int[,] map;
    public List<int> listPerlinHeight = new List<int>();
    // Start is called before the first frame update
    void Start()
    {
        map = new int[width, height];
        TerrainGeneration();
        RenderMap();
        GroundTileMap.SetTile(new Vector3Int(0, 0, 0), null);
        GroundTileMap.SetTile(new Vector3Int(5, 2, 0), null);
        GroundTileMap.SetTile(new Vector3Int(5, 3, 0), null);
        GroundTileMap.SetTile(new Vector3Int(5, 4, 0), null);
        GroundTileMap.SetTile(new Vector3Int(6, 2, 0), null);
        GroundTileMap.SetTile(new Vector3Int(6, 3, 0), null);
        GroundTileMap.SetTile(new Vector3Int(6, 4, 0), null);


    }

    // Update is called once per frame
    void Update()
    {
        
    }
   void TerrainGeneration()
    {
        for (int x = 0; x < width; x++)
        {
            int perlinHeight;
            perlinHeight = Mathf.RoundToInt(Mathf.PerlinNoise(x / smoothness, seed) * height / 2);
            perlinHeight += height / 2;
            listPerlinHeight.Add(perlinHeight);
            for (int y = 0; y < perlinHeight; y++)
            {
                map[x, y] = 1;
            }
        }
        

    }
    void RenderMap()
    {
        
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                if (map[x, y] == 1)
                {
                   

                    GroundTileMap.SetTile(new Vector3Int(x, y, 0), FindTileBase(x,y));

                }
            }
        }
    }
    TileBase FindTileBase(int x, int y)
    {
        if(y%2==0)
        {
            if (x % 2 == 0)
            {
                return kot1;
            }
            else
            {
                return kot4;
            }
        }
        else
        {
            if (x % 2 == 0)
            {
                return kot4;
            }
            else
            {
                return kot1;
            }
        }
       
       
    }
}

