using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{	
	public float speed;
	
	void Start()
	{
	}
	
	void FixedUpdate ()
	{
		float horizontalInput = Input.GetAxis("Horizontal");
		float verticalInput = Input.GetAxis("Vertical");

		int moveHorizontal = ((horizontalInput > 0) ? 1 :
			((horizontalInput < 0) ? -1 : 0));
		int moveVertical = ((verticalInput > 0) ? 1 :
			((verticalInput < 0) ? -1 : 0));

		Vector3 movement = new Vector3(moveHorizontal * speed, 0.0f, moveVertical * speed);

		GetComponent<Rigidbody>().velocity = movement;
	}
}
