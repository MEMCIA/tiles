using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cookies : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    [SerializeField] Obstacle obstacle;
    // Start is called before the first frame update
    void Start()
    {
        float x = obstacle.endOfObstaclesOnMapWithObstaclesWorld.x - 3;
        float y = obstacle.endOfObstaclesOnMapWithObstaclesWorld.y - 3;
       for (int i = 0; i < 3; i++)
        {
            float randomX = Random.Range(1, x);
            float randomY = Random.Range(1, y);
            Instantiate(prefab, new Vector3(randomX, randomY), prefab.transform.rotation);
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
