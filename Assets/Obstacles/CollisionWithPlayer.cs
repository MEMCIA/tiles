using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionWithPlayer : MonoBehaviour
{
    Player player;
    Life life;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        life = GameObject.Find("SpriteLife").GetComponent<Life>();
    }
   

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("collision");
        if (collision.collider.CompareTag("Player"))
        {
            if (player.win) return;
            player.life--;
            if (player.life < 0) return;
            life.ListLifesPictures[player.life].GetComponent<SpriteRenderer>().color = new Color32(130,129,129,255);
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
