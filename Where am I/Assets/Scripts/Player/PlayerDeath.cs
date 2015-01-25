using UnityEngine;
using System.Collections;

public class PlayerDeath : MonoBehaviour {
	

	void OnTriggerEnter (Collider other){
		if(other.tag == "Player"){
			other.SendMessage("FallDeath");
		}
	}
}
