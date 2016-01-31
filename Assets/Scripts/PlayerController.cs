using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{	
	const double DEAD_ZONE = 0.2;

	public float speed;
	
	void Start()
	{
	}
	
	void FixedUpdate ()
	{
		float horizontalInput = Input.GetAxisRaw("Horizontal");
		float verticalInput = Input.GetAxisRaw("Vertical");

		int moveHorizontal = ((horizontalInput > DEAD_ZONE) ? 1 :
			((horizontalInput < -DEAD_ZONE) ? -1 : 0));
		int moveVertical = ((verticalInput > DEAD_ZONE) ? 1 :
			((verticalInput < -DEAD_ZONE) ? -1 : 0));

		Vector3 movement = new Vector3(moveHorizontal * speed, 0.0f, moveVertical * speed);

		GetComponent<Rigidbody>().velocity = movement;
	}
}
