using UnityEngine;
using System.Collections;

public class bodyLR : MonoBehaviour {

	PlayerController controller;

	private void Start(){
		controller = GetComponentInParent<PlayerController>();
	}

	private void OnTriggerStay(Collider other){
		if (other.gameObject.tag == "Walls"){
			if (this.tag == "bodyLeft"){
				Debug.Log ("Le joueur se frotte contre un mur left");
				controller.gamePadShake(10.0F, 0.0F);
			}
			if (this.tag == "bodyRight"){
				Debug.Log ("Le joueur se frotte contre un mur right");
				controller.gamePadShake(0.0F, 10.0F);
			}
			if (this.tag == "bodyFront"){
				Debug.Log ("Le joueur se frotte contre un mur devant");
				controller.gamePadShake(10.0F, 10.0F);
			}
			if (this.tag == "bodyBack"){
				Debug.Log ("Le joueur se frotte contre un mur derriere");
				controller.gamePadShake(10.0F, 10.0F);
			}
		}
	}
}
