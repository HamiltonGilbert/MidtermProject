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
        
        //if ((vector.z < 240 && vector.z > 120) || (vector.z > 300 || vector.z < 60))
        //{
            GameObject projectile = Instantiate(_projectilePrefab, transform.position, transform.rotation);
            Vector3 vector = projectile.transform.eulerAngles;
        //}
    }
}