using UnityEngine;
using System.Collections;

public class BatasAtas : MonoBehaviour {

    void OnTriggerEnter(Collider other){
        if (other.tag == "Player")
        {
            other.gameObject.GetComponent<Player>().isBatasAtas = true;
        }
    }

    void OnTriggerExit(Collider other){
        if (other.tag == "Player")
        {
            other.gameObject.GetComponent<Player>().isBatasAtas = false;
        }
    }
}
