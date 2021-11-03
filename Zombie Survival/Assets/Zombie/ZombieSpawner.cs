using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ZombieSpawner : MonoBehaviour
{
    [SerializeField] GameObject _zombie;

    [SerializeField] float _spawnRate = 1;

    //private float _zombieHealth = 1;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn(_spawnRate));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Spawn(float wait)
    {
        yield return new WaitForSeconds(_spawnRate);
        float y = Random.Range(-10, 10);
        float x;
        if (y > 7 || y < -7)
        {
            x = Random.Range(-10, 10);
        }
        else
        {
            float temp = Mathf.Round(Random.value);
            if (temp == 1)
            {
                x = -10;
            }
            else
            {
                x = 10;
            }
        }

        Vector3 spawn = new Vector3(x, y, 0);
        Instantiate(_zombie, spawn, Quaternion.identity);
        if (GameState.Instance._gameRunning)
            StartCoroutine(Spawn(wait * .5f));
        
    }

}
