using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoundCookie : MonoBehaviour
{
   
    public bool isCookieFounded = false;
    // Start is called before the first frame update
    void Start()
    {
        
        //GetComponent<Rigidbody2D>().isKinematic = true;
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("TilemapGround"))
        {
            Debug.Log("Founded");
           
            
               
          
            isCookieFounded = true;
            //GetComponent<CircleCollider2D>().enabled = false;
            //Destroy(GetComponent<Rigidbody>());
            Destroy(this);
        }
    }
}
