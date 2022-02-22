using System.Collections.Generic;
using UnityEngine;

public class LifeSymbols : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    [SerializeField] Player player;
    public List<GameObject> ListLifesPictures;

    // Start is called before the first frame update
    void Start()
    {
        CreateSymbolsOfLife();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public List<GameObject> GetLifePictures()
    {
        CreateSymbolsOfLife();
        return ListLifesPictures;
    }

    void CreateSymbolsOfLife()
    {
        if (ListLifesPictures != null) return;
        ListLifesPictures.Add(gameObject);
        ListLifesPictures[0].transform.GetComponentInChildren<LifeSymbol>().Number = 0;
        float sizeX = GetComponent<BoxCollider2D>().bounds.extents.x * 2;

        for (int i = 1; i < player.Life; i++)
        {
            Vector3 spawnPos = new Vector3(transform.position.x - sizeX * i, transform.position.y);
            GameObject l = Instantiate(prefab, spawnPos, prefab.transform.rotation);
            ListLifesPictures.Add(l);
            l.transform.GetComponentInChildren<LifeSymbol>().Number = ListLifesPictures.Count - 1;
        }
    }

    public void ChangeColorOfNextSymbol()
    {
        ListLifesPictures[player.Life].GetComponent<SpriteRenderer>().color = new Color32(130, 129, 129, 255);
    }
}
