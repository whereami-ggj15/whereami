using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PlayerController))]
[RequireComponent(typeof(AudioSource))]
public class PlayerGameOver : MonoBehaviour {

	public AudioClip fallSound;

	private AudioSource fallSoundSource;
	private PlayerController playerCtrl;

	void Start(){
		playerCtrl = GetComponent<PlayerController>();
		fallSoundSource = GetComponent<AudioSource>();
		fallSoundSource.clip = fallSound;
	}

	void FallDeath(){

		if(fallSoundSource != null && !fallSoundSource.isPlaying){
			fallSoundSource.Play();
		}
		GameOver();
	}

	void GameOver(){
		playerCtrl.enabled = false;
	}
}
