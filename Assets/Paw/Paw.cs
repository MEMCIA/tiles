using System.Collections;
using UnityEngine;

public class Paw : MonoBehaviour
{
    public int Number;
    public bool MovementEnded = false;

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
        int rotation = 230;
        float z = 0;
        int degreesAdded = 170;

        while (z < rotation)
        {
            z += degreesAdded * Time.deltaTime;
            transform.eulerAngles = new Vector3(0, 0, z);
            yield return new WaitForEndOfFrame();
        }
        MovementEnded = true;
    }
}
