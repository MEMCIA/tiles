using UnityEngine;

public class FallingBox : MonoBehaviour
{
    Player player;
    LifeSymbols lifeSymbols;
    Paws paws;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        lifeSymbols = GameObject.Find("SpriteLife").GetComponent<LifeSymbols>();
        paws = GameObject.Find("SpawnPaw").GetComponent<Paws>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            if (player.win) return;
            player.Life--;
            if (player.Life < 0) return;
            paws.SelectPawToMove();
            lifeSymbols.ChangeColorOfNextSymbol();
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
