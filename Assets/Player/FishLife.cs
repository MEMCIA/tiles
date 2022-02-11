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
    IEnumerator FindParent()
    {
        yield return new WaitForSeconds(0.5f);
        fish = transform.parent.gameObject;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("FISCH");
        GameObject paw = collision.gameObject;
        Vector3 offset = fish.transform.position - paw.transform.position;
        Vector3 pawPos = new Vector3(0, 0, 0);
        while (paw.transform.position!=pawPos)
        {
            fish.transform.position = paw.transform.position + offset;
            pawPos = paw.transform.position;
        }
    }
}
