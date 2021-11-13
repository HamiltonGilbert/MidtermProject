using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class GameState : MonoBehaviour
{
    [SerializeField] GameObject _text;

    [SerializeField] GameObject _textInstructions;

    [SerializeField] GameObject _upgradeMenu;

    [SerializeField] int _killsBeforeWin = 10;

    //[SerializeField] int _zombieIncrementor = 10;

    public bool _gameRunning = true;

    private int _enemiesKilled = 0;

    public int _coins = 0;

    public static GameState Instance;
    // Start is called before the first frame update

    private void Awake()
    {
        Instance = this;
        _textInstructions.GetComponent<Text>().text = "press \"return\" or \"enter\" to continue playing";
        _textInstructions.SetActive(false);
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
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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
        if (_enemiesKilled >= _killsBeforeWin)
        {
            //Win();
            WaveEnd();
        }
    }
}
