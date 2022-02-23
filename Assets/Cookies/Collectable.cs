using UnityEngine;

public class Collectable : MonoBehaviour
{
    public bool isCollectableFounded = false;

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
            isCollectableFounded = true;
            Destroy(this);
        }
    }
}
