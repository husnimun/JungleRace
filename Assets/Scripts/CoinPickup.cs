using UnityEngine;
using System.Collections;

public class CoinPickup : MonoBehaviour {

	public Transform coinEffect;

	void Update(){
		if (transform.position.z < CoinGenerate.positionCoinLast)
			Destroy (gameObject);
	}

	void OnTriggerEnter(Collider info){
		if (info.tag == "Player") {
			Transform effect = Instantiate (coinEffect,transform.position, transform.rotation) as Transform;
			Destroy (effect.gameObject, 3);
			Destroy (gameObject);
		}
	}
}
