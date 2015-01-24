using UnityEngine;
using System.Collections;
using GamepadInput;

public class PlayerController : MonoBehaviour {

	public float speedMove = 5000.0f;
	public float speedRotate = 80.0f;

	private Rigidbody rigidbody;

	void Awake(){
		rigidbody = GetComponent<Rigidbody> ();
	}

	void FixedUpdate(){
		Vector2 leftStick = GamePad.GetAxis(GamePad.Axis.LeftStick, GamePad.Index.Any);
		Vector2 rightStick = GamePad.GetAxis(GamePad.Axis.RightStick, GamePad.Index.Any);

		Quaternion rotation = transform.localRotation;
		rotation.x += rightStick.x;
		rotation.y = rightStick.y;


		/*
		transform.Translate(Vector3.forward * Time.deltaTime * leftStick.y * speedMove);
		transform.Translate(Vector3.right * Time.deltaTime * leftStick.x * speedMove);

		*/
		transform.Rotate(Vector3.up * Time.deltaTime * rightStick.x * speedRotate);
		Vector3 direction = transform.worldToLocalMatrix.MultiplyVector(transform.forward);
		direction.x += leftStick.x;
		direction.z += leftStick.y;

		//Vector3 force = new Vector3(leftStick.x, 0.0f, leftStick.y);
		//rigidbody.AddForce(direction * speedMove * Time.deltaTime);

		Quaternion.Lerp(transform.rotation, rotation, 10 * Time.deltaTime);

		if (GamePad.GetButtonDown(GamePad.Button.A, GamePad.Index.Any))
			Debug.Log ("A");
	}
}