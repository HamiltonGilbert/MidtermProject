using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class GameState : MonoBehaviour
{
    [SerializeField] GameObject _coinCostGun;

    [SerializeField] GameObject _coinCostSpeed;

    [SerializeField] GameObject _gunText;

    [SerializeField] GameObject _speedText;

    [SerializeField] GameObject _coinText;

    [SerializeField] GameObject _text;

    [SerializeField] GameObject _textInstructions;

    [SerializeField] GameObject _upgradeMenu;

    [SerializeField] int _killsBeforeWin = 30;

    //[SerializeField] int _zombieIncrementor = 10;

    public bool _gameRunning = true;

    private int _enemiesKilled = 0;

    public int _coins = 0;

    public int _speedCost = 4;

    public int _gunCost = 10;

    public int _gunBought = 0;

    public int _speedBought = 0;

    public int _gunDamage = 1;

    public float _playerSpeed = 1f;

    public int _zombieHP = 1;

    public float _zombieSpeed = 2;

    public int _zombieUpgradeInterval = 1;

    public float _zombieSpeedIncrease = .03f;

    public static GameState Instance;
    // Start is called before the first frame update

    private void Awake()
    {
        _gunText.GetComponent<Text>().text = "Bought: 0";
        _speedText.GetComponent<Text>().text = "Bought: 0";
        _coinCostGun.GetComponent<Text>().text = _gunCost.ToString();
        _coinCostSpeed.GetComponent<Text>().text = _speedCost.ToString();
        CoinUpdate("");
        Instance = this;
        _textInstructions.GetComponent<Text>().text = "press \"return\" or \"enter\" to continue playing, Q to upgrade your gun, or E to upgrade your speed";
        _text.SetActive(false);
        _upgradeMenu.SetActive(false);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Submit") && ! _gameRunning)
        {
            _gameRunning = true;
            _upgradeMenu.SetActive(false);
            _zombieSpeed = 2;
            _zombieHP = 1;
            _enemiesKilled = 0;
        }
    }

    public void Win()
    {
        _gameRunning = false;
        _text.SetActive(true);
        _text.GetComponent<Text>().text = "Victory!";
        _textInstructions.SetActive(true);
    }

    public void WaveEnd()
    {
        _gameRunning = false;
        _upgradeMenu.SetActive(true);
        _textInstructions.SetActive(true);
    }

    public void Lose()
    {
        _gameRunning = false;
        _text.SetActive(true);
        _text.GetComponent<Text>().text = "You Lose";
        _textInstructions.SetActive(true);
        _textInstructions.GetComponent<Text>().text = "press \"return\" or \"enter\" to play again";
    }

    public void EnemyKilled()
    {
        _enemiesKilled++;
        _coins++;
        CoinUpdate("");
        if (_enemiesKilled >= _killsBeforeWin)
        {
            //Win();
            WaveEnd();
        }
    }

    public void CoinUpdate(string s)
    {
        if (s == "q")
        {
            _gunBought += 1;
            _gunText.GetComponent<Text>().text = "Bought: " + _gunBought;
            _coinCostGun.GetComponent<Text>().text = _gunCost.ToString();
        }
        if (s == "e")
        {
            _speedBought += 1;
            _speedText.GetComponent<Text>().text = "Bought: " + _speedBought;
            _coinCostSpeed.GetComponent<Text>().text = _speedCost.ToString();
        }
        _coinText.GetComponent<Text>().text = _coins.ToString();
    }
}
