using UnityEngine;
using System.Collections;

public class SpecialTerrainZone : MonoBehaviour {
	
	public AudioClip footstepsSound;

	private AudioClip previousFootstepsSound;
	private AudioSource playerFootstepsSource;

	// Use this for initialization
	void Start () {
		string playerObjectName = "player";
		playerFootstepsSource = GameObject.Find(playerObjectName).GetComponent<AudioSource>();
		previousFootstepsSound = playerFootstepsSource.clip;
		if(playerFootstepsSource == null){
			Debug.LogWarning(gameObject.name + " can't find player's footsteps audio source", this);
		}

		if(footstepsSound == null){
			Debug.LogWarning(gameObject.name + " does'nt have any audio clip set");
		}
	}

	void OnTriggerEnter(){

		playerFootstepsSource.clip = footstepsSound;
	}

	void OnTriggerExit(){
		playerFootstepsSource.clip = previousFootstepsSound;
	}
}
