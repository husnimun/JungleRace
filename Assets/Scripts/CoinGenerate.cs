﻿using UnityEngine;
using System.Collections;

public class CoinGenerate : MonoBehaviour {

	public GameObject coin;
	public GameObject stone;
	public GameObject grass;
	public GameObject mud;
	public GameObject collectables;

	float positionCoinLast;
	float timeElapsed = 0;
	float spawnCycle = 2f;


	// Use this for initialization
	void Start () {
		float positionCoinAwake;
		float eventStone = 0;
		for (positionCoinAwake = 4; positionCoinAwake <= 150;) {
			float posX = generateRandomPosition();
			for (int i = 0; i < 3; ++i) {
				if (positionCoinAwake == 4 || positionCoinAwake == 8 || positionCoinAwake == 12)
					posX = 0;
				GameObject temp = Instantiate(coin) as GameObject;
				Vector3 pos = temp.transform.position;
				temp.transform.position = new Vector3 (posX,pos.y,positionCoinAwake);
				if (i == 1 && eventStone % 2 == 0 && positionCoinAwake > 30) {
					float posStone1 = generateRandomStonePosition (posX);
					// instantiate stone 1
					GameObject temp1 = generateRandomObstacle();
					Vector3 pos1 = temp1.transform.position;
					temp1.transform.position = new Vector3 (posStone1,pos1.y,positionCoinAwake);
					if (temp1.tag == "Stone") {
						GameObject collectable1 = Instantiate (collectables) as GameObject;
						pos1 = temp1.transform.position;
						collectable1.transform.position = new Vector3 (pos1.x, pos1.y + 3, pos1.z);
					}
				}
				positionCoinAwake += 2;
				if (positionCoinAwake > 165)
					break;
			}
			float posStone2 = generateRandomPosition ();

			// instantiate stone 2
			GameObject temp2 = generateRandomObstacle();
			Vector3 pos2 = temp2.transform.position;
			temp2.transform.position = new Vector3 (posStone2,pos2.y,positionCoinAwake + 5);
			if (temp2.tag == "Stone") {
				GameObject collectable1 = Instantiate (collectables) as GameObject;
				pos2 = temp2.transform.position;
				collectable1.transform.position = new Vector3 (pos2.x, pos2.y + 3, pos2.z);
			}
			eventStone++;
			positionCoinAwake += 10;
		}

	}
	
	// Update is called once per frame
	void Update () {

	}

	float generateRandomPosition(){
		float val = Random.Range(-3,3);
		if(val < -1) return -3;
		else if(val <= 1) return 0;
		else return 3;
	}

	float generateRandomStonePosition(float pos1){
		float pos2 = generateRandomPosition ();
		while (pos1 == pos2) {
			pos2 = generateRandomPosition ();
		}
		return pos2;
	}

	GameObject generateRandomObstacle(){
		float val = generateRandomPosition ();
		GameObject temp;
		if (val == -3)
			temp = Instantiate (stone) as GameObject;
		else if (val == 0)
			temp = Instantiate (grass) as GameObject;
		else
			temp = Instantiate (mud) as GameObject;
		return temp;
	}
}
