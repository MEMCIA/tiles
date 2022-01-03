using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class EagleMove : MonoBehaviour
{
    [SerializeField] GameObject groundObject;
    Ground groundScript;
    [SerializeField] float speed = 100;
    int leftEdge = 0;
    float rightEdge;
    [SerializeField] bool isMiddlePointOfStart;
    [SerializeField] bool isPointOfStart3;
    int downEdge = 0;
    [SerializeField] int directionOfMovement = 1;
    bool flip = false;
    [SerializeField] Tilemap tilemap;

    // Start is called before the first frame update
    void Start()
    {
        groundScript = groundObject.GetComponent<Ground>();
        rightEdge = tilemap.CellToWorld(new Vector3Int(groundScript.width,0,0)).x;
        FindStartPosition();

    }
    // Update is called once per frame
    void Update()
    {
        Flip();
        transform.Translate(Vector3.right * speed * Time.deltaTime*directionOfMovement);
        
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
            SpriteRenderer sr = GetComponent<SpriteRenderer>();
            sr.flipX = !sr.flipX;

          
            directionOfMovement = -1;

        }
        if (directionOfMovement == -1 && transform.position.x <= leftEdge)
        {
            SpriteRenderer sr = GetComponent<SpriteRenderer>();
            sr.flipX = !sr.flipX;
            directionOfMovement = 1;

        }
    }
    }

