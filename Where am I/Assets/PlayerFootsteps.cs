using UnityEngine;
using System.Collections;

public class PlayerFootsteps : MonoBehaviour {

	private AudioSource footstepsSource;
	public AudioClip footstepsSound;
	public AudioClip defaultFootstepsSound;
	public float minSpeed = 0.5f;

	void Start(){
	
		footstepsSource = GetComponent<AudioSource>();

	}

	void Update(){
		if(rigidbody.velocity.x > minSpeed){
			footstepsSource.Play();
		} else {
			footstepsSource.Stop();
		}
	}

}
