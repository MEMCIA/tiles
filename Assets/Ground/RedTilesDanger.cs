using System.Collections;
using UnityEngine;
using UnityEngine.Tilemaps;

public class RedTilesDanger : MonoBehaviour
{
    public Tilemap tilemap;
    public Ground ground;
    public TileBase tilebase;
    [SerializeField] FallingDownObstacles1 _fallingDownObstacles1Script;
    bool danger1Showed = false;

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
        if (_fallingDownObstacles1Script.AreBoxesFalling)
        {
            if (danger1Showed) return;
            StartCoroutine(MakeTilesRed(ground.blueUpTiles, ground.blue1));
            danger1Showed = true;
        }
    }

    IEnumerator SetChangedColor(Color32 colorUp, Color32 colorDown)
    {
        yield return new WaitForSeconds(0.15f);
        for (int x = 0; x < ground.width; x++)
        {
            for (int y = 0; y < ground.height; y++)
            {
                if (!tilemap.ContainsTile(tilebase)) continue;

                tilemap.SetColor(new Vector3Int(x, y, 0), FindColor(x, y, colorUp, colorDown));
            }
        }
    }

    IEnumerator MakeTilesRed(Color32 colorUp, Color32 colorDown)
    {
        byte g = 255;
        byte b = 255;
        while (g > 0)
        {
            for (int i = 0; i < ground.height; i++)
            {
                for (int j = 0; j < ground.width; j++)
                {
                    if (!tilemap.ContainsTile(tilebase)) continue;
                    tilemap.SetColor(new Vector3Int(j, i, 0), new Color32(255, g, b, 255));
                }
            }
            g -= 5;
            b -= 5;
            yield return new WaitForSeconds(0.005f);
        }
        StartCoroutine(SetChangedColor(colorUp, colorDown));
    }
    IEnumerator MakeOriginalColorOfTiles(Color32 colorUp, Color32 colorDown)
    {
        byte r = 255;
        byte g = 0;
        byte b = 0;
        bool wrongColor = true;
        bool wrongColorUp = true;
        bool wrongColorDown = true;

        while (wrongColor)
        {
            r -= 5;
            g += 5;
            b += 5;

            for (int i = 0; i < ground.height; i++)
            {
                for (int j = 0; j < ground.width; j++)
                {
                    if (!tilemap.ContainsTile(tilebase)) continue;
                    Color32 color = FindColor(j, i, colorUp, colorDown);
                    if (wrongColorUp) wrongColorUp = SetImprovedColor(color, r, g, b, j, i);
                    if (wrongColorDown) wrongColorDown = SetImprovedColor(color, r, g, b, j, i);
                }
            }
            if (!wrongColorUp && !wrongColorDown) wrongColor = false;

            yield return new WaitForSeconds(0.005f);
        }
    }
    Color32 FindColor(int x, int y, Color32 colorUp, Color32 colorDown)
    {
        Color32 originalColor = new Color32(255, 255, 255, 255);
        Color32 foundColor;

        if (y >= ground.endOfLevelGroundTilemap.y)
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
    bool SetImprovedColor(Color32 color, byte r, byte g, byte b, int x, int y)
    {
        Color32 colorCorrected = new Color32(r, g, b, 255);
        bool rightR = false;
        bool rightG = false;
        bool rightB = false;
        if (color.r >= r)
        {
            colorCorrected.r = color.r;
            rightR = true;
        }
        if (color.g <= g)
        {
            colorCorrected.g = color.g;
            rightG = true;
        }
        if (color.b <= b)
        {
            colorCorrected.b = color.b;
            rightB = true;
        }
        tilemap.SetColor(new Vector3Int(x, y, 0), colorCorrected);
        if (rightB && rightG && rightR)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

}

