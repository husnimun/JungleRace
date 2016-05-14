using UnityEngine;
using System.Collections;

public class CoinPickup : MonoBehaviour {

	public Transform coinEffect;
	public Collider col;

	void Start(){
		col = GetComponent<Collider> ();
	}

	void Update(){
		
	}

	void OnTriggerEnter(Collider info){
		if (info.tag == "Player") {
			if (col.tag == "Coin") {
				Debug.Log ("Coin");
				// Add player coins;
				Player player = info.gameObject.GetComponent<Player>();
				player.AddCoin();
			} else {
				Debug.Log ("Collectable");
				Player player = info.gameObject.GetComponent<Player>();
				player.setSkill();
			}
            
			
            Transform effect = Instantiate (coinEffect,transform.position, transform.rotation) as Transform;
			Destroy (effect.gameObject, 3);
			Destroy (gameObject);
		}
	}
}
