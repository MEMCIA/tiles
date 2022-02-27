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
    CircleCollider2D _circleCollider;
    [SerializeField] MovePlayer _movePlayer;

    // Start is called before the first frame update
    void Start()
    {
        _mainTilemap = ground.GetComponent<MainTilemap>();   
        tilemap = GetComponent<Tilemap>();
        rbPlayer = player.GetComponent<Rigidbody2D>();
        _circleCollider = player.GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Destroy();
    }

    void Destroy()
    {
        if (playerScript.Dead) return;
        DestroyTileWhenVelocityIsMoreThan0();
        DestroyTileWhenVelocityIs0();
    }

    void DestroyTile(Vector3 offset)
    {
        Vector3Int checkPosition = tilemap.WorldToCell(player.transform.position + offset);
        if(!IsTilePositionValid(checkPosition))return;
        tilemap.SetTile(new Vector3Int(Mathf.CeilToInt(checkPosition.x), Mathf.CeilToInt(checkPosition.y), 0), null);
    }

    bool IsTilePositionValid(Vector3Int checkPosition)
    {
        if (checkPosition.x == 0) return false;
        if(checkPosition.y == 0) return false;
        if (checkPosition.x == _mainTilemap.width - 1) return false;
        if (checkPosition.y >= _mainTilemap.heightOfLevelGroundTilemap + _mainTilemap.OffsetYGameAreaUp) return false;
        return true;
    }

    void DestroyTileWhenVelocityIsMoreThan0()
    {
        Vector3 offset = rbPlayer.velocity.normalized * new Vector3(1.3f, 1.3f);
        DestroyTile(offset);
    }

    void DestroyTileWhenVelocityIs0()
    {
        direction = _movePlayer.GetDirectionOfPlayer();
        float distance = _circleCollider.radius + 1.2f;
        Vector3 offset = new Vector3(direction.x * distance, direction.y * distance);
        DestroyTile(offset);
    }
}
