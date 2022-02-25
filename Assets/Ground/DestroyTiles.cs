using UnityEngine;
using UnityEngine.Tilemaps;

public class DestroyTiles : MonoBehaviour
{
    [SerializeField] Tilemap tilemap;
    [SerializeField] GameObject player;
    Rigidbody2D rbPlayer;
    [SerializeField] GameObject ground;
    MainTilemap _mainTilemap;
    Vector3Int direction;
    [SerializeField] Player playerScript;

    // Start is called before the first frame update
    void Start()
    {
        _mainTilemap = ground.GetComponent<MainTilemap>();   
        tilemap = GetComponent<Tilemap>();
        rbPlayer = player.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Destroy();
    }

    void Destroy()
    {
        if (playerScript.Life <= 0) return;
        DestroyTileWhenVelocityIsMoreThan0();
        DestroyTileWhenVelocityIs0();
    }

    void DestroyTile(Vector3 offset)
    {
        Vector3Int checkPosition = tilemap.WorldToCell(player.transform.position + offset);

        if (checkPosition.x == 0 || checkPosition.y == 0 || checkPosition.x == _mainTilemap.width - 1 || checkPosition.y >= _mainTilemap.heightOfLevelGroundTilemap + _mainTilemap.OffsetYGameAreaUp) return;
        tilemap.SetTile(new Vector3Int(Mathf.CeilToInt(checkPosition.x), Mathf.CeilToInt(checkPosition.y), 0), null);
    }

    void DestroyTileWhenVelocityIsMoreThan0()
    {
        Vector3 offset = rbPlayer.velocity.normalized * new Vector3(1.3f, 1.3f);
        DestroyTile(offset);
    }

    void DestroyTileWhenVelocityIs0()
    {
        GetDirectionOfPlayer();
        CircleCollider2D cc = player.GetComponent<CircleCollider2D>();
        float distance = cc.radius + 1.2f;
        Vector3 offset = new Vector3(direction.x * distance, direction.y * distance);
        DestroyTile(offset);
    }

    void GetDirectionOfPlayer()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        direction = new Vector3Int(Mathf.CeilToInt(horizontal), Mathf.CeilToInt(vertical), 0);
    }
}
