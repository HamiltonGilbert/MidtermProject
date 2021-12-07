using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunUpgrade : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Q) && GameState.Instance._coins >= GameState.Instance._gunCost)
        {
            GameState.Instance._coins -= GameState.Instance._gunCost;
            GameState.Instance._gunDamage += 1;
            GameState.Instance._gunCost += 5;
            GameState.Instance.CoinUpdate("q");
        }
    }
}
