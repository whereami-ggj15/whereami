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
	
	public float delayToPing = 0.50f; // seconds
	
	public GameObject pingObject;
	GameObject pingInstantiate = null;
	
	private float maxHeight = 80.0f; // zoom
	private float minHeight = 30.0f; // zoom
	private bool isDragging = false;
	private Vector3 startPoint; //dragging
	
	//private Camera cam;
	
	int floorMask;
	float camRayLenght = 1000f;
	
	void Awake(){
		zoomSensibility += 1.0f;
		floorMask = LayerMask.GetMask ("Ground");
	}
	
	// Update is called once per frame
	void Update () {
		ZoomHandler ();
		DragHandler ();
		ClickHandler ();
	}
	
	/**
	 *
	 */
	void ClickHandler(){
		if (!activateClick || pingInstantiate != null)
			return;
		
		if(Input.GetMouseButtonDown(0)){
			//Ray camRay = Ray(gameObject.transform.position, (gameObject.transform.position - Input.mousePosition).normalized);
			Ray camRay = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit floorHit;
			
			if (Physics.Raycast (camRay, out floorHit, camRayLenght, floorMask)){
				Vector3 clickPosition = floorHit.point - transform.position;
				clickPosition.y = 0f;
				
				pingInstantiate = (GameObject) Instantiate(pingObject, clickPosition, Quaternion.identity);
				Destroy(pingInstantiate, delayToPing);
			}
		}
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