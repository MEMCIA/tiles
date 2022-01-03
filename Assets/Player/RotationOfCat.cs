using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationOfCat : MonoBehaviour
{
    [SerializeField] Transform playerPos;
    [SerializeField] MovePlayer moveplayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StopAllCoroutines();
        StartCoroutine(Rotate());
        
    }
    IEnumerator Rotate()
    {
        transform.position = playerPos.position + moveplayer.offset;
        transform.rotation = new Quaternion(playerPos.rotation.x, playerPos.rotation.y, playerPos.rotation.z * 0.3f, playerPos.rotation.w);
        yield return new WaitForEndOfFrame();
    }
}