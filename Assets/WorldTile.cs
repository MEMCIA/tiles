using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class WorldTile : MonoBehaviour
{
    public Vector3Int LocalPlace { get; set; }
    public Vector3 WorldLocation { get; set; }
    public TileBase TileBase { get; set; }
    public Tilemap TileMapMember { get; set; }
    public string Name { get; set; }


    public bool isExplored { get; set; }
    public WorldTile ExploredFrom{ get; set; }
    public int Cost { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
