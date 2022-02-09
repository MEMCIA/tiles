using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MovePlayer : MonoBehaviour
{
    [SerializeField] Player playerScript;
    Rigidbody2D rb;
   [SerializeField] float speed = 100;
   public Vector3 startPlayerPos;
    [SerializeField]  Ground ground;
    [SerializeField]  Tilemap tilemap;
    [SerializeField] Transform catSpritePos;
    public Vector3 offset;
    Vector3 startPosOfCirlce;
    Vector3 startPosOfCatSprite;
   
    // Start is called before the first frame update
    void Start()
    { startPosOfCirlce = transform.position;
        startPosOfCatSprite = catSpritePos.position;
        offset = startPosOfCatSprite - startPosOfCirlce;
        SetStartPositionOfPlayer();


    }
    

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }
    void SetStartPositionOfPlayer()
    {
        rb = GetComponent<Rigidbody2D>();
        CircleCollider2D cc = GetComponent<CircleCollider2D>();
        float offsetF = cc.radius +0.1f;
        Vector3 offsetV = new Vector3(0, offsetF, 0);
        Vector3 startPosOfPlayerSpace = tilemap.CellToWorld(new Vector3Int(ground.startXSpaceForPlayer, ground.startYSpaceForPlayer, 0));
        Vector3 endPosOfPlayerSpace = tilemap.CellToWorld(new Vector3Int(ground.endXSpaceForPlayer, ground.endYSpaceForPlayer, 0));
        startPlayerPos = endPosOfPlayerSpace - startPosOfPlayerSpace;
        startPlayerPos = new Vector3(startPlayerPos.x / 2, 0);
        startPlayerPos = startPosOfPlayerSpace + startPlayerPos + offsetV;

        transform.position = startPlayerPos;
    }
    void Move()
    {
        if (playerScript.life <= 0) return;
        if (playerScript.win) return;
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        rb.AddForce(Vector3.right * horizontalInput * speed * Time.fixedDeltaTime);
        rb.AddForce(Vector3.up * verticalInput * speed * Time.fixedDeltaTime);
    }
}
