using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{	
	const double DEAD_ZONE = 0.2;

	public float speed;

	private Vector3 screenUp;
	private Vector3 screenRight;
	
	void Start()
	{
		screenUp = new Vector3 (1, 0, 1).normalized;
		screenRight = new Vector3 (1, 0, -1).normalized;
	}
	
	void FixedUpdate ()
	{
		float horizontalInput = Input.GetAxisRaw("Horizontal");
		float verticalInput = Input.GetAxisRaw("Vertical");

		int moveHorizontal = ((horizontalInput > DEAD_ZONE) ? 1 :
			((horizontalInput < -DEAD_ZONE) ? -1 : 0));
		int moveVertical = ((verticalInput > DEAD_ZONE) ? 1 :
			((verticalInput < -DEAD_ZONE) ? -1 : 0));

		Vector3 movement = ((screenUp * moveVertical) + (screenRight * moveHorizontal)).normalized * speed;

		// Transform to screen directions


        if(GetComponent<PlayerStateMachine>().CurrentState != PlayerStateMachine.PlayerState.InAwkwardConversation)
        {
            GetComponent<Rigidbody>().velocity = movement;
        }
        else
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
	}
}
