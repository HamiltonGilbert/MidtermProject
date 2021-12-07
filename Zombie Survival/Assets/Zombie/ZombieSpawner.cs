using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ZombieSpawner : MonoBehaviour
{
    [SerializeField] GameObject _zombie;

    [SerializeField] float _spawnTime = 1;

    private bool _coroutineRunning;

    private int _counter = 0;

    //private float _zombieHealth = 1;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn(_spawnTime));
    }

    // Update is called once per frame
    void Update()
    {
        if (! GameState.Instance._gameRunning)
        {
            StopCoroutine("Spawn");
            _coroutineRunning = false;
            _counter = 0;
        }
        else if (! _coroutineRunning)
        {
            StartCoroutine(Spawn(_spawnTime));
        }
    }

    IEnumerator Spawn(float wait)
    {
        _coroutineRunning = true;
        yield return new WaitForSeconds(wait);
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
            StartCoroutine(Spawn(wait * .98f));

        if (_counter >= GameState.Instance._zombieUpgradeInterval)
        {
            _counter = 0;
            GameState.Instance._zombieHP++;
        }
        GameState.Instance._zombieSpeed += GameState.Instance._zombieSpeedIncrease;

        _counter++;
    }

}
