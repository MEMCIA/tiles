using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int Life = 7; 
    public List<GameObject> hearts = new List<GameObject>(7);
    public bool win = false;
    public bool dead = false;
    [SerializeField] Text text;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        LoseGame();
    }

    public void WinGame()
    {
        if (dead) return;
        text.color = Color.green;
        text.text = "W I N";
        win = true;
    }
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Eagle"))
        {
            Life--;
            if (Life < 0) return;
            hearts[Life].GetComponent<SpriteRenderer>().color = Color.black;
        }
    }

    void LoseGame()
    {
        if (Life <= 0)
        {
            if (win) return;
            text.text = "G A M E   O V E R";
            dead = true;
        }
    }
}
