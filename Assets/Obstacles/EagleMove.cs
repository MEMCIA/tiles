using UnityEngine;
using UnityEngine.Tilemaps;

public class EagleMove : MonoBehaviour
{
    [SerializeField] GameObject groundObject;
    [SerializeField] float speed = 100;
    [SerializeField] bool isMiddlePointOfStart;
    [SerializeField] bool isPointOfStart3;
    [SerializeField] int directionOfMovement = 1;
    [SerializeField] Tilemap tilemap;
    Ground groundScript;
    SpriteRenderer spriteRenderer;
    int leftEdge = 0;
    float rightEdge;

    // Start is called before the first frame update
    void Start()
    {
        groundScript = groundObject.GetComponent<Ground>();
        rightEdge = tilemap.CellToWorld(new Vector3Int(groundScript.width, 0, 0)).x;
        spriteRenderer = GetComponent<SpriteRenderer>();
        FindStartPosition();
    }
    // Update is called once per frame
    void Update()
    {
        Flip();
        Move();
    }

    void Move()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime * directionOfMovement);
    }

    void FindStartPosition()
    {
        switch (directionOfMovement)
        {
            case 1:

                if (isMiddlePointOfStart)
                {
                    transform.position = new Vector3((int)rightEdge / 2 + 2, transform.position.y);
                }
                else if (isPointOfStart3)
                {
                    transform.position = new Vector3((int)rightEdge / 3 + 2, transform.position.y);
                }
                else
                {
                    transform.position = new Vector3(leftEdge + 2, transform.position.y);
                }

                break;
            case -1:

                if (isPointOfStart3)
                {
                    transform.position = new Vector3((int)rightEdge / 3 - 2, transform.position.y);
                }
                else if (isMiddlePointOfStart)
                {
                    transform.position = new Vector3((int)rightEdge / 2 - 2, transform.position.y);
                }
                else
                {
                    transform.position = new Vector3(rightEdge - 2, transform.position.y);
                }

                break;
        }
    }

    void Flip()
    {
        if (directionOfMovement == 1 && transform.position.x >= rightEdge)
        {
            spriteRenderer.flipX = !spriteRenderer.flipX;
            directionOfMovement = -1;
        }
        if (directionOfMovement == -1 && transform.position.x <= leftEdge)
        {
            spriteRenderer.flipX = !spriteRenderer.flipX;
            directionOfMovement = 1;
        }
    }
}

