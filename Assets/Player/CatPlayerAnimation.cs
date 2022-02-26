using System.Collections;
using UnityEngine;

public class CatPlayerAnimation : MonoBehaviour
{
    [SerializeField] GameObject player;
    public Vector3 offsetBetweenCatAndCirlce;

    // Start is called before the first frame update
    void Start()
    {
        offsetBetweenCatAndCirlce = transform.position - player.GetComponent<Player>().StartPosOfCirlce;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        StartCoroutine(Rotate());
    }

    IEnumerator Rotate()
    {
        transform.position = player.transform.position + offsetBetweenCatAndCirlce;
        transform.rotation = new Quaternion(player.transform.rotation.x, player.transform.rotation.y, player.transform.rotation.z * 0.5f, player.transform.rotation.w);
        yield return new WaitForEndOfFrame();
    }
}
