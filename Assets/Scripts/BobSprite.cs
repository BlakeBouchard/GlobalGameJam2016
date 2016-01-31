using UnityEngine;
using System.Collections;

public class BobSprite : MonoBehaviour {

	public GameObject sprite;
	public float height;
	public float tilt;
	//public float tiltAngle;
	public float cycleTime;

	private float progress;
	private Vector3 offset;
	//private Quaternion tiltOffset;
	private int tiltDirection;

	void Start () {
		progress = 0;
		offset = sprite.transform.localPosition;
		//tiltOffset = sprite.transform.localRotation;
		tiltDirection = 1;
	}

	private static float SimpleBounce(float x) {
		return Mathf.Abs(Mathf.Sin(3.14f*x));
	}

	void Update () {
		Vector3 movement = Vector3.zero;
		//Quaternion tiltRotation = Quaternion.identity;

		bool isMoving = GetComponent<Rigidbody> ().velocity.magnitude > 0;

		if (progress > 0 || isMoving) {
			progress += Time.deltaTime / cycleTime;

			float bounce = SimpleBounce(progress);
			movement.Set(tiltDirection * tilt * bounce, height * bounce, 0);

			if(progress >= 1) {
				progress = 0;
				tiltDirection *= -1;
			}
		}

		sprite.transform.localPosition = offset + movement;
		//sprite.transform.localRotation = tiltOffset * tiltRotation;
	}
}
