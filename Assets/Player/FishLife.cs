using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishLife : MonoBehaviour
{
    GameObject fish;
    public int Number;
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
        //GetComponent<CircleCollider2D>().enabled = false;
        Debug.Log("FISH");
        if (Number != collision.gameObject.transform.parent.gameObject.GetComponent<Paw>().Number) return;
        StartCoroutine(MoveFish(collision));
    }
    IEnumerator MoveFish(Collider2D collision)
    {
        fish = transform.parent.gameObject;
        GameObject paw = collision.gameObject;
        Vector3 offset = fish.transform.position - paw.transform.position;
        int degrees = paw.transform.parent.GetComponent<Paw>().Degrees;
        while(paw.transform.parent.transform.rotation.z> -degrees/2+5)
        {
            Debug.Log("RRR");
            fish.transform.position = paw.transform.position + offset;
            yield return new WaitForEndOfFrame();
        }
        Debug.Log("RRX");
    }
}
