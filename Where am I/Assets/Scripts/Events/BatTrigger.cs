using UnityEngine;
using System.Collections;

public class BatTrigger : MonoBehaviour {
	
	public GameObject bat;
	public int contactsBeforeTrigger = 1;

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
		contactsBeforeTrigger--;
		if (other.gameObject == player && contactsBeforeTrigger <= 0){
			animator.SetTrigger ("activate");
			batSource.Play();
		}
	}
}
