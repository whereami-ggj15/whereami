using UnityEngine;
using System.Collections;

public class WinGame : MonoBehaviour {

	// Update is called once per frame
	void OnTriggerEnter (Collider other) {
		if(other.tag != "Player")
			return;

		Debug.Log ("GAME FINISHED");
		Application.LoadLevel ("GameWin");
	}
}
