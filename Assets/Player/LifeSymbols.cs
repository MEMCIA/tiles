using System.Collections.Generic;
using UnityEngine;

public class LifeSymbols : MonoBehaviour
{
    [SerializeField] GameObject _prefab;
    [SerializeField] Player _player;
    List<GameObject> _lifePictures;
    Color32 _grey = new Color32(130, 129, 129, 255);

    // Start is called before the first frame update
    void Start()
    {
        CreateSymbolsOfLife();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public List<GameObject> GetLifePictures()
    {
        CreateSymbolsOfLife();
        return _lifePictures;
    }

    void CreateSymbolsOfLife()
    {
        if (_lifePictures != null) return;
        _lifePictures = new List<GameObject>();
        _lifePictures.Add(gameObject);
        _lifePictures[0].transform.GetComponentInChildren<LifeSymbol>().Number = 0;
        float sizeX = GetComponent<BoxCollider2D>().bounds.extents.x * 2;

        for (int i = 1; i < _player.Life; i++)
        {
            Vector3 spawnPos = new Vector3(transform.position.x - sizeX * i, transform.position.y);
            GameObject l = Instantiate(_prefab, spawnPos, _prefab.transform.rotation);
            _lifePictures.Add(l);
            l.transform.GetComponentInChildren<LifeSymbol>().Number = _lifePictures.Count - 1;
        }
    }

    public void ChangeColorOfNextSymbol()
    {
        _lifePictures[_player.Life].GetComponent<SpriteRenderer>().color = _grey;
    }
}
