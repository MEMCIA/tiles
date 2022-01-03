using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationOfCat : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] MovePlayer moveplayer;
   Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
       //rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        StopAllCoroutines();
        StartCoroutine(Rotate());
        
    }
    IEnumerator Rotate()
    {
        transform.position = player.transform.position + moveplayer.offset;
        transform.rotation = new Quaternion(player.transform.rotation.x, player.transform.rotation.y, player.transform.rotation.z * 0.3f, player.transform.rotation.w);
        yield return new WaitForEndOfFrame();
        Debug.Log(player.transform.rotation.z);
    }
    /* rb.AddRelativeForce(player.transform.position + moveplayer.offset);
        rb.AddTorque(player.transform.rotation.z * 0.3f);*/
}
