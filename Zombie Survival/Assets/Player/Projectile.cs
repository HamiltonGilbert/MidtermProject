using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    [SerializeField] float _speed = 1f;

    private Rigidbody2D rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        Movement();
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position += new Vector3(Time.deltaTime * _speed, 0, 0);
        //Movement();
        Despawn();
    }

    void Movement()
    {
        rigidBody = GetComponent<Rigidbody2D>();

        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mousePosition - transform.position;


        rigidBody.velocity = new Vector2(1, direction.y/direction.x) * _speed;
        rigidBody.gravityScale = 0;
    }

    void Despawn()
    {
        if (transform.position.y > 10 || transform.position.y < -10 || transform.position.x > 10 || transform.position.x < -10)
        {
            Destroy(gameObject);
        }
    }
}
