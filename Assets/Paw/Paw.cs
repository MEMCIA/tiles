using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paw : MonoBehaviour
{
    public int Degrees = 260;
    public int Number;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public IEnumerator RotatePaw()
    {
        float z = 0;
        while (z < Degrees)
        {
            z += 170f*Time.deltaTime;
            transform.eulerAngles = new Vector3(0, 0, z);
            yield return new WaitForEndOfFrame();
        }

    }
}
