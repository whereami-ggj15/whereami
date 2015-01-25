using UnityEngine;
using System.Collections;

public class BatTrigger : MonoBehaviour {
	
	public GameObject bat;

	AudioSource batSource;
	Animator animator;
	GameObject player;

	public int toTrigger = 1;

	void Awake(){
		player = GameObject.FindGameObjectWithTag ("Player");
		if (bat != null) {
			batSource = bat.GetComponent<AudioSource> ();
			animator = bat.GetComponent<Animator>();
		}
	}


	void OnTriggerEnter (Collider other) {
		toTrigger--;
		if (other.gameObject == player && toTrigger <= 0){
			animator.SetTrigger ("activate");
			batSource.Play();
		}
	}
}
