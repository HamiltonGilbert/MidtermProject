using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    private GameObject _player;

    [SerializeField] float _speed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (GameState.Instance._gameRunning)
        {
            GetComponent<SpriteRenderer>().enabled = true;
            gameObject.SetActive(true);
            Movement();
        }
        else
        {
            GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    void Movement()
    {
        // Calculate direction vector.
        Vector3 dirction = transform.position - _player.transform.position;

        // Normalize resultant vector to unit Vector.
        dirction = -dirction.normalized;

        // Move in the direction of the direction vector every frame.
        transform.position += dirction * Time.deltaTime * _speed;
    }
}
