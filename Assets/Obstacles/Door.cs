using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
   [SerializeField] Obstacle obstacle;
    [SerializeField] GameObject prefab;
    
    // Start is called before the first frame update
    void Start()
    {
        Vector3 pos = new Vector3(obstacle.endOfObstaclesOnMapWithObstaclesWorld.x+3, obstacle.endOfObstaclesOnMapWithObstaclesWorld.y+3);
        Instantiate(prefab, pos, prefab.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
