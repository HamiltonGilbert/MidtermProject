using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpeedUpgrade : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.E) && GameState.Instance._coins >= GameState.Instance._speedCost)
        {
            GameState.Instance._coins -= GameState.Instance._speedCost;
            GameState.Instance._playerSpeed *= 1.1f;
            GameState.Instance._speedCost += 1;
            GameState.Instance.CoinUpdate("e");
        }
    }

}
