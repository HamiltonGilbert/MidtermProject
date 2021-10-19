using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] float _speed;

    [SerializeField] GameObject _projectilePrefab;

    [SerializeField] float _topBoundary = 3.8f;
    [SerializeField] float _bottomBoundary = -4f;
    [SerializeField] float _leftBoundary = -8.5f;
    [SerializeField] float _rightBoundary = 8.5f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        if (Input.GetButtonDown("Fire1"))
            Fire();
    }

    void Fire()
    {
        Instantiate(_projectilePrefab, transform.position + new Vector3(1f, 0, 0), Quaternion.identity);
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
}