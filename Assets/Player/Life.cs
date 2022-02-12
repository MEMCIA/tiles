using System.Collections;
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
        ListLifesPictures.Add(gameObject);
        ListLifesPictures[0].transform.GetChild(0).gameObject.GetComponent<FishLife>().Number = 0;
       float sizeX = GetComponent<BoxCollider2D>().bounds.extents.x *2;
        //float spaceBetweenPrefabs = sizeX / 7;
        //Debug.Log(spaceBetweenPrefabs + "space between prefabs");
        for (int i = 1; i < player.life; i++)
        {
            Vector3 spawnPos = new Vector3(transform.position.x-sizeX*i,transform.position.y);
            GameObject l = Instantiate(prefab, spawnPos, prefab.transform.rotation);
            ListLifesPictures.Add(l);
            l.transform.GetChild(0).gameObject.GetComponent<FishLife>().Number = ListLifesPictures.Count - 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
