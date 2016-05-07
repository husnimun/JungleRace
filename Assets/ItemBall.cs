using UnityEngine;
using System.Collections;

public class ItemBall : MonoBehaviour {

	Rigidbody rb;
	int rotationSpeed = 200;
	public bool isPut = false;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		rb.constraints = RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionX;
	}
	
	// Update is called once per frame
	void Update () {
		if (!isPut) {
			float rotation = rotationSpeed;
			rotation *= Time.deltaTime;
			rb.AddRelativeTorque (Vector3.right * rotation);
		}
	}
}
