using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishLife : MonoBehaviour
{
    GameObject fish;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GetComponent<CircleCollider2D>().enabled = false;
        Debug.Log("FISCH");
        fish = transform.parent.gameObject;
        GameObject paw = collision.gameObject.transform.parent.gameObject;
        Vector3 offset = fish.transform.position - paw.transform.position; 
        while (paw.GetComponent<Rigidbody2D>().rotation < 180) 
        {
            fish.transform.position = paw.transform.position + offset;  
        }

    }
}
