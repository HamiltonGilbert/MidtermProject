using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawn : MonoBehaviour
{

    [SerializeField] GameObject _projectilePrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
            Fire();
    }

    void Fire()
    {
        Instantiate(_projectilePrefab, transform.position, transform.rotation);
    }
}
