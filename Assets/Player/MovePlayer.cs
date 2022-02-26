using UnityEngine;
using UnityEngine.Tilemaps;

public class MovePlayer : MonoBehaviour
{
    [SerializeField] Player playerScript;
    Rigidbody2D rb;
    [SerializeField] float speed = 100;
    float horizontalInput;
    float verticalInput;

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
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        rb.AddForce(Vector3.right * horizontalInput * speed * Time.fixedDeltaTime);
        rb.AddForce(Vector3.up * verticalInput * speed * Time.fixedDeltaTime);
    }

    public Vector3Int GetDirectionOfPlayer()
    {
        return new Vector3Int(Mathf.CeilToInt(horizontalInput), Mathf.CeilToInt(verticalInput), 0);
    }
}
