using UnityEngine;
using System.Collections;

public class BatTrigger : MonoBehaviour {
	
	public GameObject bat;

	AudioSource batSource;
	Animator animator;
	GameObject player;

	void Awake(){
		player = GameObject.FindGameObjectWithTag ("Player");
		if (bat != null) {
			batSource = bat.GetComponent<AudioSource> ();
			animator = bat.GetComponent<Animator>();
		}
	}


	void OnTriggerEnter (Collider other) {
		if (other.gameObject == player){
			animator.SetTrigger ("activate");
			batSource.Play();
		}
	}
}
