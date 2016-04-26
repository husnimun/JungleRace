using UnityEngine;
using System.Collections;

public class CoinPickup : MonoBehaviour {

	public Transform coinEffect;

	void Update(){
		
	}

	void OnTriggerEnter(Collider info){
		if (info.tag == "Player") {
            // Add player coins;
            Player player = info.gameObject.GetComponent<Player>();
            player.AddCoin();
			
            Transform effect = Instantiate (coinEffect,transform.position, transform.rotation) as Transform;
			Destroy (effect.gameObject, 3);
			Destroy (gameObject);
		}
	}
}
