using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float _speed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(Time.deltaTime * _speed,0, 0);
        Despawn();
    }
    void Despawn()
    {
        if (transform.position.y > 10 || transform.position.y < -10 || transform.position.x > 10 || transform.position.x < -10)
        {
            Destroy(gameObject);
        }
    }
}
