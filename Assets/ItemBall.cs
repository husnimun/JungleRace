using UnityEngine;
using System.Collections;

public class ItemBall : MonoBehaviour {

	Rigidbody rb;
	GameObject player;
	GameObject effect;
	public bool isPut = false;
	public GameObject effectIcon;
	bool isEffect = false;

	float time = 0;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		rb.constraints = RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionX;
        if (!isPut)
            rb.AddForce(transform.forward * 20, ForceMode.Impulse);
	}
	
	// Update is called once per frame
	void Update () {
		/*if (!isPut) {
			float rotation = rotationSpeed;
			rotation *= Time.deltaTime;
			rb.AddRelativeTorque (Vector3.right * rotation);
		}*/

		time += Time.deltaTime;
		if (isEffect) {
			// Put effect icon on top of player object
			effect.transform.position = player.transform.position + new Vector3(0, 3, 0);

			// Slowly fade the opcacity for 10 seconds
			Color temp = effect.GetComponent<SpriteRenderer>().color;
			temp.a = 1 - time / 5;
			effect.GetComponent<SpriteRenderer>().color = temp;
		}
	}

	void OnCollisionEnter(Collision other) {
		Debug.Log (other.gameObject.tag);
		if (other.gameObject.tag == "Player" && !isEffect) {
			Debug.Log("jancuk");
			player = other.gameObject;
			effect = Instantiate(effectIcon);
			StartCoroutine (startEffectItem (other));
		}
		if (other.gameObject.tag == "Stone") {
			Destroy (this.gameObject);
		}
	}

	IEnumerator startEffectItem(Collision other){
		isEffect = true;
		time = 0;
		gameObject.GetComponent<Rigidbody> ().isKinematic = true;
		gameObject.GetComponent<SphereCollider> ().enabled = false;
		gameObject.GetComponent<MeshRenderer> ().enabled = false;
		other.gameObject.GetComponent<Player>().isEffectItem = true;
		yield return new WaitForSeconds (5f);
		other.gameObject.GetComponent<Player>().isEffectItem = false;
		isEffect = false;
		time = 0;
		Destroy (this.gameObject);
	}
}
