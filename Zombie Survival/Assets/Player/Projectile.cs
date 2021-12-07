using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    [SerializeField] float _speed = 1f;

    private Rigidbody2D rigidBody;

    private int _leftRight = 1;

    // Start is called before the first frame update
    void Start()
    {
        Movement();
    }

    // Update is called once per frame
    void Update()
    {
        Despawn();
    }

    void Movement()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        rigidBody = GetComponent<Rigidbody2D>();

        
        Vector2 direction = mousePosition - transform.position;


        rigidBody.velocity = _leftRight * _speed * new Vector2(direction.x, direction.y).normalized;
        rigidBody.gravityScale = 0;
    }

    void Despawn()
    {
        if (transform.position.y > 10 || transform.position.y < -10 || transform.position.x > 10 || transform.position.x < -10)
        {
            Destroy(gameObject);
        }
    }

    public void LeftRight(int i)
    {
        _leftRight = i;
    }
}
