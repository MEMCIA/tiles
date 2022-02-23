using UnityEngine;
using UnityEngine.Tilemaps;

public class ImageOnTopOfScene : MonoBehaviour
{
    [SerializeField] MainTilemap _mainTilemap;
    [SerializeField] Tilemap _tilemap;
    // Start is called before the first frame update
    void Start()
    {
        float width = _mainTilemap.width * _tilemap.cellSize.x;
        Debug.Log(width + "Width");
        GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, width);
        //GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical())

    }

    // Update is called once per frame
    void Update()
    {

    }
}
