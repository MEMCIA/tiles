using UnityEngine;
using UnityEngine.Tilemaps;

public class ImageOnTopOfScene : MonoBehaviour
{
    [SerializeField] Ground ground;
    [SerializeField] Tilemap tilemap;
    // Start is called before the first frame update
    void Start()
    {
        float width = ground.width * tilemap.cellSize.x;
        Debug.Log(width + "Width");
        GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, width);
        //GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical())

    }

    // Update is called once per frame
    void Update()
    {

    }
}
