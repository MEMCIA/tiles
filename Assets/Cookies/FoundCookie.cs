using UnityEngine;

public class FoundCookie : MonoBehaviour
{
    public bool isCookieFounded = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("TilemapGround"))
        {
            isCookieFounded = true;
            Destroy(this);
        }
    }
}
