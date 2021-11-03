using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class GameState : MonoBehaviour
{
    [SerializeField] GameObject _text;

    [SerializeField] int _killsBeforeWin = 10;

    [SerializeField] GameObject _textInstructions;

    public bool _gameRunning = true;

    public int _enemiesKilled = 0;

    public static GameState Instance;
    // Start is called before the first frame update

    private void Awake()
    {
        Instance = this;
        _text.SetActive(false);
        _textInstructions.SetActive(false);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Submit") && ! _gameRunning)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void Win()
    {
        _gameRunning = false;
        _text.SetActive(true);
        _text.GetComponent<Text>().text = "Victory!";
        _textInstructions.SetActive(true);
        _textInstructions.GetComponent<Text>().text = "press \"return\" or \"enter\" to play again";
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
        if (_enemiesKilled >= _killsBeforeWin)
        {
            Win();
        }
    }
}
