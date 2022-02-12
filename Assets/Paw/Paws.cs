using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Paws : Paw
{
    [SerializeField] GameObject _paw;
    [NonSerialized] public List<GameObject> ListOfPaws = new List<GameObject>();
    [SerializeField] Life _life;
    [NonSerialized] public int CounterOfCollisions;
    int _counterOfPaws;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("CreatePaws",0.2f);
        
    }

    // Update is called once per frame
    void Update()
    {
        MovePaw();
    }

    void MovePaw()
    {
        for (int i = 0; i < CounterOfCollisions; i++)
       {
            _counterOfPaws--;
            StartCoroutine(ListOfPaws[_counterOfPaws].GetComponent<Paw>().RotatePaw());
            Debug.Log("QQQ");
            CounterOfCollisions--;
        }
    }

    void CreatePaws()
    {
        foreach (var life in _life.ListLifesPictures)
        {
            Vector3 spawnPoint = new Vector3(life.transform.position.x, life.transform.position.y + 5f);
            GameObject p = Instantiate(_paw, spawnPoint, _paw.transform.rotation);
           ListOfPaws.Add(p );
            p.GetComponent<Paw>().Number = ListOfPaws.Count - 1;
        }
        _counterOfPaws = ListOfPaws.Count;
        //_counter = ListOfPaws.Count;
        //ListOfPaws[0].transform.eulerAngles = new Vector3(0,0,90);

    }
}
