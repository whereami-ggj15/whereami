using UnityEngine;
using System.Collections;
using GamepadInput;

public class PlayerController : MonoBehaviour {

	public KeyCode forward = KeyCode.Z;
	public KeyCode back = KeyCode.S;
	public KeyCode turnRight = KeyCode.D;
	public KeyCode turnLeft = KeyCode.Q;
	public KeyCode strafeRight = KeyCode.E;
	public KeyCode strafeLeft = KeyCode.A;
	public float speedMove = 5000.0f;
	public float speedRotate = 80.0f;
	public float joystickTolerance = 0.2F;

	void FixedUpdate(){
		JoysticksManager();
		KeyboardManager();

		if (GamePad.GetButtonDown(GamePad.Button.A, GamePad.Index.Any))
			Debug.Log ("A");
	}

	private void JoysticksManager(){
		float tolerence = joystickTolerance;
		Vector2 leftStick = GamePad.GetAxis(GamePad.Axis.LeftStick, GamePad.Index.Any);
		Vector2 rightStick = GamePad.GetAxis(GamePad.Axis.RightStick, GamePad.Index.Any);
		
		if (leftStick.y > joystickTolerance || leftStick.y < -joystickTolerance){
			if (leftStick.y < 0)
				tolerence = -tolerence;
			transform.Translate(Vector3.forward * Time.deltaTime * (leftStick.y - tolerence) * speedMove);
		}
		if (leftStick.x > joystickTolerance || leftStick.x < -joystickTolerance){
			if (leftStick.x < 0)
				tolerence = -tolerence;
			transform.Translate(Vector3.right * Time.deltaTime * (leftStick.x - tolerence) * speedMove);
		}
		if (rightStick.x > joystickTolerance || rightStick.x < -joystickTolerance){
			if (rightStick.x < 0)
				tolerence = -tolerence;
			transform.Rotate(Vector3.up * Time.deltaTime * (rightStick.x - tolerence) * speedRotate);
		}
	}

	private void KeyboardManager(){
		if (Input.GetKey (forward))
			transform.Translate(Vector3.forward * Time.deltaTime * speedMove);
		if (Input.GetKey (back))
			transform.Translate(Vector3.back * Time.deltaTime * speedMove);
		if (Input.GetKey (strafeLeft))
			transform.Translate(Vector3.left * Time.deltaTime * speedMove);
		if (Input.GetKey (strafeRight))
			transform.Translate(Vector3.right * Time.deltaTime * speedMove);
		if (Input.GetKey (turnLeft))
			transform.Rotate(Vector3.up * Time.deltaTime * -speedRotate);
		if (Input.GetKey (turnRight))
			transform.Rotate(Vector3.up * Time.deltaTime * speedRotate);
	}
}