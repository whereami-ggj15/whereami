using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class PlaySoundOnEnter : MonoBehaviour {

	AudioSource source;

	void Start(){
		source = GetComponent<AudioSource>();
	}

	void OnTriggerEnter(Collider other){
		if(other.tag == "Player"){
			if(!source.isPlaying){
				source.Play();
			}
		}
	}
}
