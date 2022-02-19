using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    [SerializeField] Player player;
    public List<GameObject> ListLifesPictures = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        CreateSymbolsOfLife();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void CreateSymbolsOfLife()
    {
        ListLifesPictures.Add(gameObject);
        ListLifesPictures[0].transform.GetComponentInChildren<FishLife>().Number = 0;
        float sizeX = GetComponent<BoxCollider2D>().bounds.extents.x * 2;

        for (int i = 1; i < player.Life; i++)
        {
            Vector3 spawnPos = new Vector3(transform.position.x - sizeX * i, transform.position.y);
            GameObject l = Instantiate(prefab, spawnPos, prefab.transform.rotation);
            ListLifesPictures.Add(l);
            l.transform.GetComponentInChildren<FishLife>().Number = ListLifesPictures.Count - 1;
        }
    }
}
