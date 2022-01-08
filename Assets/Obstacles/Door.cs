using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
   [SerializeField] Obstacle obstacle;
    [SerializeField] GameObject prefab;
    [SerializeField] Ground ground;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 pos = new Vector3(ground.endOfLevelWorldV3.x+3, ground.endOfLevelWorldV3.y+3);
        Instantiate(prefab, pos, prefab.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
