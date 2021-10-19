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
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(Time.deltaTime * _speed, 0, 0);
        //Movement();
        Despawn();
    }

    void Movement()
    {
        Vector3 input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        rigidBody.MovePosition(transform.position + input * Time.deltaTime * _speed);
        // used code from unity documentation: https://docs.unity3d.com/ScriptReference/Rigidbody.MovePosition.html
    }

    void Despawn()
    {
        if (transform.position.y > 10 || transform.position.y < -10 || transform.position.x > 10 || transform.position.x < -10)
        {
            Destroy(gameObject);
        }
    }
}
