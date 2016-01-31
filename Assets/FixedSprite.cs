using UnityEngine;
using System.Collections;

public class FixedSprite : MonoBehaviour {

	private Quaternion orientation;

	// Use this for initialization
	void Start () {
		orientation = transform.rotation;
	}
	
	// Update is called once per frame
	void LateUpdate () {
		transform.rotation = orientation;
	}
}
