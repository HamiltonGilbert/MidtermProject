using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    private GameObject _player;

    public int _HP;

    [SerializeField] float _speed;

    void Awake()
    {
        _HP = GameState.Instance._zombieHP;

        _speed = GameState.Instance._zombieSpeed;
    }

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
            //GetComponent<SpriteRenderer>().enabled = true;
            gameObject.SetActive(true);
            Movement();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Projectile")
        {
            _HP -= GameState.Instance._gunDamage;

            if (_HP <= 0)
            {
                GameState.Instance.EnemyKilled();
                Destroy(gameObject);
            }
            Destroy(collision.gameObject);
        }

    }

    void Movement()
    {
        // Calculate direction vector.
        Vector3 direction = transform.position - _player.transform.position;

        // Normalize resultant vector to unit Vector.
        direction = -direction.normalized;

        // Move in the direction of the direction vector every frame.
        transform.position += direction * Time.deltaTime * _speed;
    }
}
