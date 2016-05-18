using UnityEngine;
using System.Collections;

public class PantulPlayer : MonoBehaviour {

	GameObject player;

	void OnTriggerEnter(Collider other){
		if (other.tag == "Player") {
			player = other.gameObject;
			player.GetComponent<Player>().GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, 300, -100));
		}
	}
}
