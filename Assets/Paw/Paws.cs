using System;
using System.Collections.Generic;
using UnityEngine;

public class Paws : Paw
{
    [SerializeField] GameObject _paw;
    [NonSerialized] public List<GameObject> ListOfPaws = new List<GameObject>();
    [SerializeField] LifeSymbols _lifeSymbols;
    [NonSerialized] public int CounterOfCollisions;
    int _counterOfPaws;

    // Start is called before the first frame update
    void Start()
    {
        CreatePaws();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectPawToMove()
    {
        _counterOfPaws--;
        StartCoroutine(ListOfPaws[_counterOfPaws].GetComponent<Paw>().RotatePaw());
        CounterOfCollisions--;
    }

    void CreatePaws()
    {
        foreach (var life in _lifeSymbols.GetLifePictures())
        {
            Vector3 spawnPoint = new Vector3(life.transform.position.x, life.transform.position.y + 5f);
            GameObject p = Instantiate(_paw, spawnPoint, _paw.transform.rotation);
            ListOfPaws.Add(p);
            p.GetComponent<Paw>().Number = ListOfPaws.Count - 1;
        }
        _counterOfPaws = ListOfPaws.Count;
    }
}
