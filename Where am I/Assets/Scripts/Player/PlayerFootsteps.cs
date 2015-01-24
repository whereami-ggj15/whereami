using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class PlayerFootsteps : MonoBehaviour {

	private GameObject player;
	private PlayerController playerCtrl;
	private AudioSource footstepsSource;
	private bool isPlaying = false;
	public AudioClip defaultFootstepsSound;
	public float minSpeed = 0.05f;

	void Start(){
		player = transform.parent.gameObject;
		if(player == null){
			Debug.LogWarning(gameObject.name + " can't find player");
		} else {
			playerCtrl = player.GetComponent<PlayerController>();
		}

		footstepsSource = GetComponent<AudioSource>();
		if(defaultFootstepsSound != null){
			footstepsSource.clip = defaultFootstepsSound;
		} else {
			Debug.LogWarning("Default footsteps sound not set!");
		}

	}

	void Update(){
		//Debug.Log(player.rigidbody.velocity + " min: " + minSpeed);
		if(playerCtrl.getMove() > minSpeed || playerCtrl.getRotate() > minSpeed){
			if(!isPlaying){
				PlaySound();
			}
		} else if(isPlaying){
			StopSound();
		}
	}

	private void StopSound(){
		footstepsSource.Stop();
		isPlaying = false;
	}

	private void PlaySound(){
		footstepsSource.Play();
		isPlaying = true;
	}

	public void SetFootstepsSound(AudioClip newSound){
		StopSound();
		footstepsSource.clip = newSound;
	}

	public void ResetToDefault(){
		StopSound();
		footstepsSource.clip = defaultFootstepsSound;
	}

}
