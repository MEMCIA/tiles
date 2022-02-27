using UnityEngine;

public class Collectable : MonoBehaviour
{
    public bool isCollectableFound = false;

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
            isCollectableFound = true;
            Destroy(this);
        }
    }
}
