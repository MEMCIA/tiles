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
    [SerializeField] Player playerScript;
    public float endPlayerGameAreaY1World;
    int offsetY = -2;

    // Start is called before the first frame update
    void Start()
    {
        scriptGround = ground.GetComponent<Ground>();
        endPlayerGameAreaY1World = tilemap.CellToWorld(new Vector3Int(0, scriptGround.heightOfLevelGroundTilemap + offsetY, 0)).y;
        Debug.Log("DestroyGround heightOfLevelGroundTilemap: " + scriptGround.heightOfLevelGroundTilemap);
        tilemap = GetComponent<Tilemap>();
        rbPlayer = player.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        DestroyTile();
    }

    void DestroyTile()
    {
        if (playerScript.Life <= 0) return;
        GetDirectionOfPlayer();
        CircleCollider2D cc = player.GetComponent<CircleCollider2D>();
        float distance = cc.radius + 1.2f;
        Vector3 offset2 = rbPlayer.velocity.normalized * new Vector3(1.3f, 1.3f);
        Vector3 offset = new Vector3(direction.x * distance, direction.y * distance);
        Vector3Int checkPosition = tilemap.WorldToCell(player.transform.position + offset);
        Vector3Int checkPosition2 = tilemap.WorldToCell(player.transform.position + offset2);

        if (checkPosition.x == 0 || checkPosition.y == 0 || checkPosition.x == scriptGround.width - 1 || checkPosition.y >= scriptGround.heightOfLevelGroundTilemap + offsetY) return;
        tilemap.SetTile(new Vector3Int(Mathf.CeilToInt(checkPosition.x), Mathf.CeilToInt(checkPosition.y), 0), null);
        if (checkPosition2.x == 0 || checkPosition2.y == 0 || checkPosition2.x == scriptGround.width - 1 || checkPosition2.y >= scriptGround.heightOfLevelGroundTilemap + offsetY) return;
        tilemap.SetTile(new Vector3Int(Mathf.CeilToInt(checkPosition2.x), Mathf.CeilToInt(checkPosition2.y), 0), null);
    }

    void GetDirectionOfPlayer()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        direction = new Vector3Int(Mathf.CeilToInt(horizontal), Mathf.CeilToInt(vertical), 0);
    }



}
