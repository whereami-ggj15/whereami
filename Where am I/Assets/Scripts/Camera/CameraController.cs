using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	
	public Transform target;
	public float smoothing = 5f;
	
	Vector3 offset; //distance between player/camera
	
	void Start(){
		transform.position = new Vector3(target.position.x, transform.position.y, target.position.z);
		offset = transform.position - target.position;
	}
	
	void FixedUpdate(){
		Vector3 targetCamPos = target.position + offset;
		transform.position = Vector3.Lerp (transform.position, targetCamPos, smoothing * Time.deltaTime);
	}
}