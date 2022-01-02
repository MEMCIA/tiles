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
    // Start is called before the first frame update
    void Start()
    {
        FindPositionOfPlayer();
    }
    

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }
    void FindPositionOfPlayer()
    {
        rb = GetComponent<Rigidbody2D>();
        Vector3 startPosOfPlayerSpace = tilemap.CellToWorld(new Vector3Int(ground.startXSpaceForPlayer, ground.startYSpaceForPlayer, 0));
        Vector3 endPosOfPlayerSpace = tilemap.CellToWorld(new Vector3Int(ground.endXSpaceForPlayer, ground.endYSpaceForPlayer, 0));
        startPlayerPos = endPosOfPlayerSpace - startPosOfPlayerSpace;
        startPlayerPos = new Vector3(startPlayerPos.x / 2, 0);
        startPlayerPos = startPosOfPlayerSpace + startPlayerPos;

        transform.position = startPlayerPos;
    }
    void Move()
    {
        if (playerScript.life <= 0) return; 
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        rb.AddForce(Vector3.right * horizontalInput * speed * Time.fixedDeltaTime);
        rb.AddForce(Vector3.up * verticalInput * speed * Time.fixedDeltaTime);
    }
}
