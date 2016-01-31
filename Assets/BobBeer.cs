using UnityEngine;
using System.Collections;

public class BobBeer : MonoBehaviour {
	
	public float height;
	public float cycleTime;
	
	private Vector3 offset;

	void Start () {
		offset = transform.localPosition;
	}
	
	private static float SimpleBob(float x) {
		return Mathf.Sin (3.14f * x);
	}
	
	void Update () {
		transform.localPosition = offset + Vector3.up * (SimpleBob (Time.time / cycleTime) * height);
	}
}
