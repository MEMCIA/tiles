using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Destroy();
    }
   void  Destroy()
    {
        if (transform.position.y <= 0)
        {
            Destroy(gameObject);
        }
    }
}
