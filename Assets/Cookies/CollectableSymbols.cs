using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableSymbols : MonoBehaviour
{
    [SerializeField] GameObject _startCollectableShadow;
    [SerializeField] GameObject _symbolOfCollectablePrefab;
    [SerializeField] CollectablesSpawner _collectablesSpawner;
    public List<Vector3> SymbolsOfCollectable = new List<Vector3>();

    // Start is called before the first frame update
    void Start()
    {
        SymbolsOfCollectable.Add(_startCollectableShadow.transform.position);
        CreateCollectableSymbols();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RemoveFirstCollectableFromList()
    {
        SymbolsOfCollectable.Remove(SymbolsOfCollectable[0]);
    }

    void CreateCollectableSymbols()
    {
        for (int i = 1; i < _collectablesSpawner.NumberOfCollectables; i++)
        {
            float distanceBetweenCookies = _startCollectableShadow.GetComponent<PolygonCollider2D>().bounds.extents.x * 3 - 1;
            Vector3 spawnPos = new Vector3(_startCollectableShadow.transform.position.x - distanceBetweenCookies * i, _startCollectableShadow.transform.position.y);
            SymbolsOfCollectable.Add(spawnPos);
            Instantiate(_symbolOfCollectablePrefab, spawnPos, _symbolOfCollectablePrefab.transform.rotation);
        }
    }
}
