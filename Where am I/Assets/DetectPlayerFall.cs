using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider))]
public class DetectPlayerFall : MonoBehaviour {

	void OnTriggerEnter(Collider other){
		if(other.tag == "Player"){
			other.SendMessage("FallDeath");
		}
	}
}
