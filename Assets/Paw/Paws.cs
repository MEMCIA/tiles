using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Paws : Paw
{
    [SerializeField] GameObject _paw;
    [NonSerialized] public List<GameObject> ListOfPaws = new List<GameObject>();
    [SerializeField] Life _life;
    [NonSerialized] public bool EnablePaw = false;
    int _counter;
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
        if(EnablePaw)
        {
            StartCoroutine(ListOfPaws[_counter - 1].GetComponent<Paw>().RotatePaw());
            _counter--;
            EnablePaw = false;
        }
    }

    void CreatePaws()
    {
        foreach (var life in _life.ListLifesPictures)
        {
            Vector3 spawnPoint = new Vector3(life.transform.position.x, life.transform.position.y + 5f);
           ListOfPaws.Add( Instantiate(_paw, spawnPoint, _paw.transform.rotation));
            _counter = ListOfPaws.Count;
        }
        //ListOfPaws[0].transform.eulerAngles = new Vector3(0,0,90);

    }
}
