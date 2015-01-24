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
	public KeyCode walkToggle = KeyCode.LeftShift;
	public KeyCode throwRock = KeyCode.Space;
	
	private float speedMove = 10.0f;
	private float speedRotate = 80.0f;
	private float joystickTolerance = 0.2F;
	private float detectionTrigger = 1.0F;
	private float throwRockForce = 1000.0F;

	void FixedUpdate(){
		GamePadManager();
		KeyboardManager();

		if (GamePad.GetButtonDown(GamePad.Button.A, GamePad.Index.Any))
			Debug.Log ("A");
	}

	private void GamePadManager(){
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
		if (GamePad.GetTrigger(GamePad.Trigger.RightTrigger, GamePad.Index.Any) >= detectionTrigger)
			rock.instanciateAndThrowRock(throwRockForce);
	}

	private void KeyboardManager(){
		float currSpeedMove;

		if (Input.GetKey (walkToggle))
			currSpeedMove = speedMove / 2;
		else
			currSpeedMove = speedMove;
		if (Input.GetKey (forward))
			transform.Translate(Vector3.forward * Time.deltaTime * currSpeedMove);
		if (Input.GetKey (back))
			transform.Translate(Vector3.back * Time.deltaTime * currSpeedMove);
		if (Input.GetKey (strafeLeft))
			transform.Translate(Vector3.left * Time.deltaTime * currSpeedMove);
		if (Input.GetKey (strafeRight))
			transform.Translate(Vector3.right * Time.deltaTime * currSpeedMove);
		if (Input.GetKey (turnLeft))
			transform.Rotate(Vector3.up * Time.deltaTime * -speedRotate);
		if (Input.GetKey (turnRight))
			transform.Rotate(Vector3.up * Time.deltaTime * speedRotate);
		if (Input.GetKey (throwRock))
			rock.instanciateAndThrowRock(throwRockForce);
	}
}