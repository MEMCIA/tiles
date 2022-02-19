using System.Collections;
using UnityEngine;

public class FishLife : MonoBehaviour
{
    GameObject fish;
    public int Number;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Number != collision.gameObject.transform.parent.gameObject.GetComponent<Paw>().Number) return;
        StartCoroutine(MoveFish(collision));
    }

    IEnumerator MoveFish(Collider2D collision)
    {
        fish = transform.parent.gameObject;
        GameObject paw = collision.gameObject;
        Vector3 offset = fish.transform.position - paw.transform.position;
        //int degrees = paw.GetComponentInParent<Paw>().Degrees;
        Paw pawScript = paw.GetComponentInParent<Paw>();

        while (!pawScript.MovementEnded)
        {
            Debug.Log("RRR");
            fish.transform.position = paw.transform.position + offset;
            yield return new WaitForEndOfFrame();
        }
        Debug.Log("RRX");
    }
}
