using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParts : MonoBehaviour
{
	[SerializeField] GameObject _projectile;
	[SerializeField] float _projectileSpeed;
	// Start is called before the first frame update
	void Start()
    {
        
    }

	// Update is called once per frame
	void Update()
	{

		//Grab our mouse position in relation to it's location of the camera/world combination. Great sensation!
		Vector3 mousePos_world = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		Vector3 mousePos = new Vector3(mousePos_world.x, mousePos_world.y, transform.position.z);

		//Determine the direction we are looking at
		Vector3 direction = mousePos - transform.position;

		//Rotate our object to look at the rotation.
		//Note: Try messing around with the "Pivot" point of your sprite to have different effects.
		//For a gun, the "bottom" pivot or near the bottom of the sprite might be best
		//Basically your pivot point should near the "stock" of the gun
		transform.rotation = Quaternion.LookRotation(transform.forward, direction);

		if (Input.GetButtonDown("Fire1"))
		{
			//Instantiate my bullet. My bullet has 0 on gravity scale and set to Fixed Angle
			GameObject tempMyBullet = Instantiate(_projectile, transform.position, Quaternion.Euler(0, 0, transform.eulerAngles.z + Random.Range(0, 90))) as GameObject;

			//Determine the velocity/direction we want to give our bullet
			Vector3 velocity = tempMyBullet.transform.rotation * Vector3.right;

			Rigidbody2D rigidBody = tempMyBullet.GetComponent<Rigidbody2D>();
			rigidBody.AddForce(velocity * _projectileSpeed);
		}

	}
}
