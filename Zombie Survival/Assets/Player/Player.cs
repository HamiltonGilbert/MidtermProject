using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    [SerializeField] GameObject _weapon;

    [SerializeField] GameObject _projectilePrefab;

    [SerializeField] float _topBoundary = 3.8f;
    [SerializeField] float _bottomBoundary = -4f;
    [SerializeField] float _leftBoundary = -8.5f;
    [SerializeField] float _rightBoundary = 8.5f;

    private float _speed;

    private void Awake()
    {
        SpeedUpdate();
    }
    // Start is called before the first frame update

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GameState.Instance._gameRunning)
        {
            GetComponent<SpriteRenderer>().enabled = true;
            _weapon.GetComponent<SpriteRenderer>().enabled = true;
            Movement();
            Rotation();
            if (Input.GetButtonDown("Fire1"))
                Fire();
        }
        else
        {
            GetComponent<SpriteRenderer>().enabled = false;
            _weapon.GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    void SpeedUpdate()
    {
        _speed = GameState.Instance._playerSpeed;
    }

    void Rotation()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mousePosition - transform.position;
        float angle = Vector2.SignedAngle(Vector2.right, direction);
        transform.eulerAngles = new Vector3(0, 0, angle);
        // used some code from this article: https://gamedevbeginner.com/make-an-object-follow-the-mouse-in-unity-in-2d/#look_at_mouse_2Ds
    }

    void Fire()
    {
        
        Transform spawnPoint = transform.GetChild(0).GetChild(0);

        Instantiate(_projectilePrefab, spawnPoint.position, transform.rotation);
        
    }

    void Movement()
    {
        float xMove = transform.position.x + Input.GetAxisRaw("Horizontal") * .1f * _speed;
        float yMove = transform.position.y + Input.GetAxisRaw("Vertical") * .1f * _speed;
        transform.position = new Vector3(xMove, yMove, 0);

        if (transform.position.y >= _topBoundary)
        {
            transform.position = new Vector3(transform.position.x, _topBoundary, 0);
        }
        if (transform.position.x >= _rightBoundary)
        {
            transform.position = new Vector3(_rightBoundary, transform.position.y, 0);
        }
        if (transform.position.y <= _bottomBoundary)
        {
            transform.position = new Vector3(transform.position.x, _bottomBoundary, 0);
        }
        if (transform.position.x <= _leftBoundary)
        {
            transform.position = new Vector3(_leftBoundary, transform.position.y, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Zombie")
        {
            GameState.Instance.WaveEnd();
        }

    }
}