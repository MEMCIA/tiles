using System.Collections;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Warning : MonoBehaviour
{
    [SerializeField] Tilemap _tilemap;
    [SerializeField] MainTilemap _mainTilemap;
    [SerializeField] TileBase _tilebase;
    [SerializeField] FallingBoxesSpawner _fallingBoxesSpawner;
    bool _danger1Showed = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ShowWarning(); 
    }

    void ShowWarning()
    {
        if (_fallingBoxesSpawner.AreBoxesFalling)
        {
            if (_danger1Showed) return;
            StartCoroutine(MakeTilesRed(_mainTilemap.blueUpTiles, _mainTilemap.blue1));
            _danger1Showed = true;
        }
    }

    IEnumerator SetChangedColor(Color32 colorUp, Color32 colorDown)
    {
        yield return new WaitForSeconds(0.15f);
        for (int x = 0; x < _mainTilemap.width; x++)
        {
            for (int y = 0; y < _mainTilemap.height; y++)
            {
                if (!_tilemap.ContainsTile(_tilebase)) continue;
                _tilemap.SetColor(new Vector3Int(x, y, 0), FindColor(x, y, colorUp, colorDown));
            }
        }
    }

    IEnumerator MakeTilesRed(Color32 colorUp, Color32 colorDown)
    {
        byte g = 255;
        byte b = 255;

        while (g > 0)
        {
            for (int i = 0; i < _mainTilemap.height; i++)
            {
                for (int j = 0; j < _mainTilemap.width; j++)
                {
                    if (!_tilemap.ContainsTile(_tilebase)) continue;
                    _tilemap.SetColor(new Vector3Int(j, i, 0), new Color32(255, g, b, 255));
                }
            }
            g -= 5;
            b -= 5;
            yield return new WaitForSeconds(0.005f);
        }
        StartCoroutine(SetChangedColor(colorUp, colorDown));
    }

    Color32 FindColor(int x, int y, Color32 colorUp, Color32 colorDown)
    {
        Color32 originalColor = new Color32(255, 255, 255, 255);
        Color32 foundColor;

        if (y >= _mainTilemap.endOfLevelGroundTilemap.y)
        {
            foundColor = colorUp;
        }
        else
        {
            foundColor = colorDown;
        }
        if (y % 2 != 0)
        {
            if (x % 2 != 0)
            {
                foundColor = originalColor;
            }
        }
        else
        {
            if (x % 2 == 0)
            {
                foundColor = originalColor;
            }
        }
        return foundColor;
    }
}

