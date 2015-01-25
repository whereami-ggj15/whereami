using UnityEngine;
using System.Collections;

public class NoiseZone : MonoBehaviour {

	BoxCollider collider;
	CameraEffects camEffects;
	CameraEffects camEffectsUI;
	AudioSource audioSource;

	// Use this for initialization
	void Start () {
		GetComponent<MeshRenderer> ().enabled = false;
		collider = GetComponent<BoxCollider> ();
		camEffects = Camera.main.GetComponent<CameraEffects>();
		camEffectsUI = GameObject.FindGameObjectWithTag("UICam").GetComponent<CameraEffects>();

		audioSource = GetComponent<AudioSource> ();
	}
	
	void OnTriggerEnter(Collider other){
		if(other.tag == "Player"){
			camEffects.ActivateNoise();
			camEffectsUI.ActivateNoise();
			if(!audioSource.isPlaying)
				audioSource.Play();
		}
	}

	void OnTriggerExit(Collider other){
		if(other.tag == "Player"){
			camEffects.DeactivateNoise();
			camEffectsUI.DeactivateNoise();
			audioSource.Stop ();
		}
	}
}
