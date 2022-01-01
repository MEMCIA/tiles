using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int life = 3;
   [SerializeField] Text text;
    [SerializeField] List<GameObject> hearts = new List<GameObject>(3);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Dead();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Win"))
        {
            Debug.Log("Win");
            text.color = Color.green;
            text.text = "W I N";
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Eagle"))
        {
            life--;
            if (life < 0) return;
            hearts[life].GetComponent<SpriteRenderer>().color = Color.black;
        }


    }
    void Dead()
    {
        if (life <= 0)
        {
           
            
                text.text = "G A M E   O V E R";
           
        }
    }
    

   
       
}
