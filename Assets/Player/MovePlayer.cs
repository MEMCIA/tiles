using UnityEngine;
using UnityEngine.Tilemaps;

public class MovePlayer : MonoBehaviour
{
    [SerializeField] Player playerScript;
    Rigidbody2D rb;
    [SerializeField] float speed = 100;

    // Start is called before the first frame update
    void Start()
    {     
        rb = GetComponent<Rigidbody2D>(); 
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }
   
    void Move()
    {
        if (playerScript.Life <= 0) return;
        if (playerScript.win) return;
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        rb.AddForce(Vector3.right * horizontalInput * speed * Time.fixedDeltaTime);
        rb.AddForce(Vector3.up * verticalInput * speed * Time.fixedDeltaTime);
    }
}
