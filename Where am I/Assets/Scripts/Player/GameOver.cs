using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {
	AudioSource audio;
	public AudioClip fallSound;
	public AudioClip monsterDeath;

	PlayerController controls;

	void Start(){
		audio = GetComponent<AudioSource> ();
		controls = GetComponent<PlayerController> ();

	}

	// Use this for initialization
	/* pendant la chute */
	void FallDeath(){
		controls.enabled = false;
		audio.clip = fallSound;
		audio.Play ();
		StartCoroutine ("WaitForEndClip");
	}


	/** mort + goto end scene **/
	void MonsterDeath(){
		controls.enabled = false;
		audio.clip = monsterDeath;
		audio.Play ();
		StartCoroutine ("WaitForEndClip");
	}

	void GameFinished(){
		Debug.Log ("GAME FINISHED");
		Application.LoadLevel ("GameOver");
	}

	IEnumerator WaitForEndClip(){
		while(audio.isPlaying)
			yield return new WaitForSeconds(1);
		GameFinished();
	}
}
