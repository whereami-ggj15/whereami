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
	
	private float speedMove = 200.0f;
	private float speedRotate = 100.0f;
	private float joystickTolerance = 0.2F;
	private float detectionTrigger = 1.0F;
	private float throwRockForce = 1000.0F;
	private string groundName = "map";
	private float maxSpeed = 7.529F;
	private float currentSpeedRotate;

	public void gamePadShake(){
		//Gamepad.SetVibration(playerIndex, state.Triggers.left,state.Triggers.right);
	}

	public float getMove(){
		float value = rigidbody.velocity.magnitude / maxSpeed;
		if (value < 0.1F)
			value = 0.0F;
		if (value > 1.0F)
			value = 1.0F;
		return (value);
	}

	public float getRotate(){
		if (currentSpeedRotate < 0.0F)
			currentSpeedRotate = -currentSpeedRotate;
		float value = currentSpeedRotate / speedRotate;
		if (value < 0.1F)
			value = 0.0F;
		if (value > 1.0F)
			value = 1.0F;
		return (value);
	}

	private void FixedUpdate(){
		if (Input.GetJoystickNames().Length > 0){
			GamePadManager();
		}
		else{
			KeyboardManager();
		}
	}

	private void GamePadManager(){
		Vector2 leftStick = GamePad.GetAxis(GamePad.Axis.LeftStick, GamePad.Index.Any);
		Vector2 rightStick = GamePad.GetAxis(GamePad.Axis.RightStick, GamePad.Index.Any);

		if (GamePad.GetTrigger(GamePad.Trigger.RightTrigger, GamePad.Index.Any) >= detectionTrigger)
			rock.instanciateAndThrowRock(throwRockForce);
		
		if (leftStick.y > joystickTolerance || leftStick.y < -joystickTolerance)
			rigidbody.AddForce(transform.TransformDirection(Vector3.forward) * leftStick.y * speedMove);
		if (leftStick.x > joystickTolerance || leftStick.x < -joystickTolerance)
			rigidbody.AddForce(transform.TransformDirection(Vector3.right) * leftStick.x * speedMove);

		if (rightStick.x > joystickTolerance || rightStick.x < -joystickTolerance){
			transform.Rotate(Vector3.up * Time.deltaTime * rightStick.x * speedRotate);
			currentSpeedRotate = rightStick.x * speedRotate;
		}
		else
			currentSpeedRotate = 0.0F;
	}

	private void KeyboardManager(){
		float tmpSpeed;
		float tmpSpeedRotate;

		if (Input.GetKey (walkToggle)){
			tmpSpeed = speedMove / 2;
			tmpSpeedRotate = speedRotate / 2;
		}
		else{
			tmpSpeed = speedMove;
			tmpSpeedRotate = speedRotate;
		}

		if (Input.GetKey (throwRock))
			rock.instanciateAndThrowRock(throwRockForce);

		if (Input.GetKey (forward))
			rigidbody.AddForce(transform.TransformDirection(Vector3.forward) * tmpSpeed);
		if (Input.GetKey (back))
			rigidbody.AddForce(transform.TransformDirection(Vector3.back) * tmpSpeed);
		if (Input.GetKey (strafeLeft))
			rigidbody.AddForce(transform.TransformDirection(Vector3.left) * tmpSpeed);
		if (Input.GetKey (strafeRight))
			rigidbody.AddForce(transform.TransformDirection(Vector3.right) * tmpSpeed);

		if (Input.GetKey (turnLeft)){
			currentSpeedRotate = tmpSpeedRotate;
			transform.Rotate(Vector3.up * Time.deltaTime * -tmpSpeedRotate);
		}
		else if (Input.GetKey (turnRight)){
			currentSpeedRotate = tmpSpeedRotate;
			transform.Rotate(Vector3.up * Time.deltaTime * tmpSpeedRotate);
		}
		else
			currentSpeedRotate = 0.0F;
	}

	private void OnCollisionStay(Collision other){
		if (other.gameObject.name != groundName){
			Debug.Log ("Le joueur se frotte contre un mur");
		}
	}
}