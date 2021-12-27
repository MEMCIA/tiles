using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EagleMove : MonoBehaviour
{
    [SerializeField] GameObject groundObject;
    Ground groundScript;
    [SerializeField] float speed = 100;
    int leftEdge = 0;
    int rightEdge;
    public bool isMiddlePointOfStart;
   
    int downEdge = 0;
    [SerializeField] int directionOfMovement = 1;
    bool flip = false;
    
    // Start is called before the first frame update
    void Start()
    {
        groundScript = groundObject.GetComponent<Ground>();
        rightEdge = groundScript.width;
        Debug.Log(rightEdge);
        
        switch (directionOfMovement)
        {
            case 1:
                if(isMiddlePointOfStart) transform.position = new Vector3((int)groundScript.width/2 - 2, transform.position.y);
                if (!isMiddlePointOfStart) transform.position = new Vector3(leftEdge + 2, transform.position.y);

                break;
            case -1:
                if (!isMiddlePointOfStart) transform.position = new Vector3(rightEdge - 2, transform.position.y);
                if (isMiddlePointOfStart) transform.position = new Vector3((int)groundScript.width / 2 + 2, transform.position.y);

                break;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(directionOfMovement ==1 && transform.position.x >= rightEdge)
        {
            SpriteRenderer sr = GetComponent<SpriteRenderer>();
            if (sr.flipX)
            {
                sr.flipX = false;
            }
            else
            {
                sr.flipX = true;
            }
        directionOfMovement = -1;
            
        }
        if (directionOfMovement == -1 && transform.position.x <= leftEdge)
        {
            SpriteRenderer sr = GetComponent<SpriteRenderer>();
            if (sr.flipX)
            {
                sr.flipX = false;
            }
            else
            {
                sr.flipX = true;
            }
        directionOfMovement = 1;

        }
        

        transform.Translate(Vector3.right * speed * Time.deltaTime*directionOfMovement);
        
    }
}
