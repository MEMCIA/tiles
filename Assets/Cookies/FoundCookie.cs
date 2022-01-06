using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoundCookie : MonoBehaviour
{
    ParticleSystem ps;
    GameObject effects;
    // Start is called before the first frame update
    void Start()
    {
        effects = GameObject.Find("Particle System");
        ps = effects.GetComponent<ParticleSystem>();
        //GetComponent<Rigidbody2D>().isKinematic = true;
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("TilemapGround"))
        {
            Debug.Log("Founded");
            effects.transform.position = transform.position;
            ps.Play();
            //GetComponent<CircleCollider2D>().enabled = false;
            //Destroy(GetComponent<Rigidbody>());
            Destroy(this);
        }
    }
}
