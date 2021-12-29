using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GroundOnCollision : MonoBehaviour
{
    [SerializeField] Tilemap tilemap;
    [SerializeField] GameObject player;
    Rigidbody2D rbPlayer;
    [SerializeField] GameObject ground;
    Ground scriptGround;
    // Start is called before the first frame update
    void Start()
    {
        tilemap = GetComponent<Tilemap>();
        rbPlayer = player.GetComponent<Rigidbody2D>();
        scriptGround = ground.GetComponent<Ground>();
    }

    // Update is called once per frame
    void Update()
    {
        DestroyTile();

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
       
        
    }
    void DestroyTile()
    {
        Vector3 velocity = rbPlayer.velocity;
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 tileToDestroy = tilemap.WorldToCell(player.transform.position + velocity*Time.deltaTime);
        Debug.Log("Vel"+(velocity * Time.deltaTime * horizontalInput).ToString());
        Vector3Int tileToDestroyInt = new Vector3Int(Mathf.CeilToInt(tileToDestroy.x), Mathf.CeilToInt(tileToDestroy.y), Mathf.CeilToInt(tileToDestroy.z));
        //Debug.Log(tileToDestroyInt.ToString()+"/"+player.transform.position+ "/"+ velocity * Time.deltaTime);
        Debug.Log("x:" + (velocity * Time.deltaTime).x + "y:" + (velocity * Time.deltaTime).y);
        if(scriptGround.map[tileToDestroyInt.x, tileToDestroyInt.y]==1)
        {
            tilemap.SetTile(tileToDestroyInt, null);
        }
       
        
        
    }

}
