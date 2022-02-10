using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int life = 7;
    [SerializeField] Text text;
    public List<GameObject> hearts = new List<GameObject>(7);
    public bool win = false;
    public bool dead = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Dead();
    }
    public void Win()
    {
        if (dead) return;
        text.color = Color.green;
        text.text = "W I N";
        win = true;
    }
    /*
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Win"))
        {
            Debug.Log("Win");
            text.color = Color.green;
            text.text = "W I N";
        }
        
    }
    */
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

            if (win) return;
            text.text = "G A M E   O V E R";
            dead = true;
        }
    }




}
