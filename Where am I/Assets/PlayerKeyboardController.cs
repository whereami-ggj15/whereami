using UnityEngine;
using System.Collections;

public class PlayerKeyboardController : MonoBehaviour {

	public float speedMove = 5000.0f;
	public float speedRotate = 80.0f;
	
	void FixedUpdate(){
		
		float horizontal = Input.GetAxis("Horizontal");
		float vertical = Input.GetAxis("Vertical");

		//Debug.Log(new Vector2(horizontal, vertical));
		
		Quaternion rotation = transform.localRotation;
		rotation.y += horizontal;
		
		
		/*
		transform.Translate(Vector3.forward * Time.deltaTime * leftStick.y * speedMove);
		transform.Translate(Vector3.right * Time.deltaTime * leftStick.x * speedMove);

		*/
		transform.Rotate(Vector3.up * Time.deltaTime * horizontal * speedRotate);
		Quaternion.Lerp(transform.rotation, rotation, 10 * Time.deltaTime);

		Vector3 direction = transform.forward * vertical;

		//Debug.Log(rigidbody.velocity);
		//Vector3 force = new Vector3(leftStick.x, 0.0f, leftStick.y);
		rigidbody.AddForce(direction * speedMove * Time.deltaTime);
		


	}
}
