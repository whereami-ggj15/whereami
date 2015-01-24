using UnityEngine;
using System.Collections;

public class AnimatorController : MonoBehaviour {

	public float zoomSensibility = 10.0f;
	public float dragSensibility = 10.0f;
	public Transform camerasPosition; // represente le gameobject qui contient les deux caméras de rendu
	public bool invertZoomButtons = false;
	public bool activateZoom = false;
	public bool activateDrag = false;
	public bool activateClick = true;

	private float maxHeight = 80.0f;
	private float minHeight = 30.0f;

	private bool isDragging = false;
	private Vector3 startPoint;

	void Awake(){
		zoomSensibility += 1.0f;
	}

	// Update is called once per frame
	void Update () {
		ZoomHandler ();
		InputHandler ();
	}

	/**
	 *
	 */
	void ClickHandler(){
		if (!activateClick)
			return;
	}

	/**
	 * Gestion du drag de l'interface
	 */
	void DragHandler(){
		if (!activateDrag)
			return;

		if (Input.GetMouseButtonDown (2)){ // clique centre
			if(!isDragging || startPoint == Vector3.zero)
				startPoint = Input.mousePosition;

			isDragging = true;
		}
		if(Input.GetMouseButtonUp(2)){
		    isDragging = false;
			startPoint = Vector3.zero;
		}

		if(isDragging){
			Vector3 distance = startPoint - Input.mousePosition;
			distance *= dragSensibility / 200f;

			Debug.Log("mouse : " + Input.mousePosition);
			camerasPosition.position = new Vector3(camerasPosition.position.x + distance.x, camerasPosition.position.y, camerasPosition.position.z + distance.y);
			startPoint = Input.mousePosition;
		}
	}

	/**
	 * Gestion du zoom de la caméra 
	 */
	void ZoomHandler(){
		if (!activateZoom)
			return;

		float zooming = Input.mouseScrollDelta.y;
		if(zooming != 0){ // scroll up ou down
			float toY = camerasPosition.position.y + (zooming * zoomSensibility) / 10f;
			
			if(toY >= maxHeight)
				toY = maxHeight;
			else if(toY <= minHeight)
				toY = minHeight;
			
			Vector3 toPosition = new Vector3(camerasPosition.position.x, toY, camerasPosition.position.z);
			camerasPosition.position = toPosition;
		}
	}
}
