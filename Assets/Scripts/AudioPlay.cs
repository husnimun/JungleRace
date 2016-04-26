using UnityEngine;
using System.Collections;

public class AudioPlay : MonoBehaviour {

    void Start() {
        AudioSource audio = GetComponent<AudioSource>();
        audio.Play();
    }
}
