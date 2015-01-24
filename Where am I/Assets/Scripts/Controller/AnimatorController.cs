using UnityEngine;
using System.Collections;

public class AnimatorController : MonoBehaviour {

	public float sensibility = 10.0f;
	public Transform camerasPosition; // represente le gameobject qui contient les deux caméras de rendu

	private float maxHeight = 80.0f;
	private float minHeight = 30.0f;

	void Awake(){
		sensibility += 1.0f;
	}

	// Update is called once per frame
	void Update () {
		ZoomHandler ();
		InputHandler ();
	}

	/**
	 * Gestion des clicks sur l'interface
	 */
	void InputHandler(){
		// gestion du zoom

	}

	/**
	 * Gestion du zoom de la caméra 
	 */
	void ZoomHandler(){
		float zooming = Input.mouseScrollDelta.y;
		if(zooming != 0){ // scroll up ou down
			float toY = camerasPosition.position.y + (zooming * sensibility) / 10f;
			
			if(toY >= maxHeight)
				toY = maxHeight;
			else if(toY <= minHeight)
				toY = minHeight;
			
			Vector3 toPosition = new Vector3(camerasPosition.position.x, toY, camerasPosition.position.z);
			camerasPosition.position = toPosition;
		}
	}
}
