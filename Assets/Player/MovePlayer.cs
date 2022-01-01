using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    [SerializeField] Player playerScript;
    Rigidbody2D rb;
   [SerializeField] float speed = 100;
   public Vector3 startPlayerPos;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startPlayerPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    void Move()
    {
        if (playerScript.life <= 0) return; 
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        rb.AddForce(Vector3.right * horizontalInput * speed * Time.deltaTime);
        rb.AddForce(Vector3.up * verticalInput * speed * Time.deltaTime);
    }
}
