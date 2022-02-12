using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DestroyGround : MonoBehaviour
{
    [SerializeField] Tilemap tilemap;
    [SerializeField] GameObject player;
    Rigidbody2D rbPlayer;
    [SerializeField] GameObject ground;
    Ground scriptGround;
    Vector3Int direction;
    Vector3Int checkPosition;
    bool playerOverGround = false;
    [SerializeField] Player playerScript;
    [SerializeField] Obstacle obstacleScript;
    public float endPlayerGameAreaY1World;
    int offsetY = -2;
    
    // Start is called before the first frame update
    void Start()
    {
        scriptGround = ground.GetComponent<Ground>();
        endPlayerGameAreaY1World = tilemap.CellToWorld(new Vector3Int(0,scriptGround.heightOfLevelGroundTilemap +offsetY,0)).y;
        Debug.Log("DestroyGround heightOfLevelGroundTilemap: "+ scriptGround.heightOfLevelGroundTilemap);
        tilemap = GetComponent<Tilemap>();
        rbPlayer = player.GetComponent<Rigidbody2D>();
       
        
    }

    // Update is called once per frame
    void Update()
    {

        DestroyTile();
        PlayerOverGround();

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
       
        
    }
    void DestroyTile()
    {
        if (playerOverGround) return;
        if (playerScript.life <= 0) return;
        GetDirection();
        CircleCollider2D cc = player.GetComponent<CircleCollider2D>();
        float distance = cc.radius+1.2f;
        //Vector3 velocity = rbPlayer.velocity;
        Vector3 offset2 = rbPlayer.velocity.normalized* new Vector3(1.3f,1.3f);
        Vector3 offset = new Vector3(direction.x * distance, direction.y * distance); // mno�ysz wektor o d�ugo��i 1, �eby mia� teraz d�ugo�� "distance" - tak policzy�a� zielony wektor z rysunku
        checkPosition = tilemap.WorldToCell(player.transform.position + offset);
        Vector3Int checkPosition2 = tilemap.WorldToCell(player.transform.position + offset2);

        //Debug.Log(checkPosition.x + " " + checkPosition.y);

        //Vector3  offsetAndDirection= new Vector3(Mathf.CeilToInt(velocity.x)*offset*1.01f, Mathf.CeilToInt(velocity.y) * offset * 1.01f, Mathf.CeilToInt(velocity.z) * offset * 1.01f);
        //Vector3 tileToDestroy =tilemap.WorldToCell(player.transform.position +offsetAndDirection);

        //Vector3Int tileToDestroyInt = new Vector3Int(Mathf.CeilToInt(tileToDestroy.x), Mathf.CeilToInt(tileToDestroy.y), Mathf.CeilToInt(tileToDestroy.z));
        //Debug.Log(tileToDestroyInt.ToString()+"/"+player.transform.position+ "/"+ velocity * Time.deltaTime);
        //Debug.Log("x:" + (velocity * Time.deltaTime).x + "y:" + (velocity * Time.deltaTime).y);
        if (scriptGround.map[checkPosition.x, checkPosition.y]==1)
        {
            if (checkPosition.x == 0 || checkPosition.y == 0 || checkPosition.x == scriptGround.width - 1||checkPosition.y>= scriptGround.heightOfLevelGroundTilemap+offsetY) return;
            tilemap.SetTile(new Vector3Int(Mathf.CeilToInt(checkPosition.x), Mathf.CeilToInt(checkPosition.y),0), null);
        }
        if (scriptGround.map[checkPosition2.x, checkPosition2.y] == 1)
        {
            if (checkPosition2.x == 0 || checkPosition2.y == 0 || checkPosition2.x == scriptGround.width - 1 || checkPosition2.y >= scriptGround.heightOfLevelGroundTilemap + offsetY) return;
            tilemap.SetTile(new Vector3Int(Mathf.CeilToInt(checkPosition2.x), Mathf.CeilToInt(checkPosition2.y), 0), null);
        }



    }

    void GetDirection()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        direction = new Vector3Int (Mathf.CeilToInt(horizontal), Mathf.CeilToInt(vertical),0);
        //Debug.Log(direction);

    }

    void PlayerOverGround()
    {
        if(scriptGround.listPerlinHeight[checkPosition.x]==checkPosition.y)
        {
            rbPlayer.AddForce(new Vector3(0, 5, 0));
            rbPlayer.gravityScale = 5;
            playerOverGround = true;
        }
      
       


        //var playerPos = checkPosition;

        // if(playerPos.x!=Mathf.CeilToInt(player.transform.position.x)) rbPlayer.gravityScale = 1;






    }

}
