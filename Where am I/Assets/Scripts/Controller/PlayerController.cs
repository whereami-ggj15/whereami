using UnityEngine;
using System.Collections;
using GamepadInput;
using System;
using XInputDotNetPure; 

public class PlayerController : MonoBehaviour {
	public KeyCode forward = KeyCode.Z;
	public KeyCode back = KeyCode.S;
	public KeyCode turnRight = KeyCode.D;
	public KeyCode turnLeft = KeyCode.Q;
	public KeyCode strafeRight = KeyCode.E;
	public KeyCode strafeLeft = KeyCode.A;
	public KeyCode walkToggle = KeyCode.LeftShift;
	public KeyCode rotate45Left = KeyCode.W;
	public KeyCode rotate45Right = KeyCode.C;
	public KeyCode throwRock = KeyCode.Space;
	public KeyCode placeBackWall = KeyCode.LeftControl;
	public AudioSource communication;
	public AudioSource noiseCommunication;

	private float incrementationVolume = 0.1F; //niveau d'inc/déc pour changer le volume de la radio
	private float speedMove = 150.0f; //vitesse de déplacement du joueur
	private float speedRotate = 100.0f; //vitesse de rotation du joueur
	private float joystickTolerance = 0.2F; //tolérence à la détection d'un mouvement sur les joysticks du gamepad
	private float detectionTrigger = 1.0F; //niveau de détection des gachettes du gamepad
	private float throwRockForce = 1000.0F; //force de lancer d'une pierre
	private float maxSpeed = 7.529F; //vitesse (vélocité maximal), sert à déduire un rapport de vitesse entre la vitesse actuelle et la vitesse max
	private float cranRotate = 45.0F; //degres absolu (1 = 360°) de cran ou le joueur tourne en utilisant Rb ou Lb
	
	private float currentSpeedRotate;

	public void gamePadShake(float forceRight, float forceLeft){
		XInputDotNetPure.GamePad.SetVibration(XInputDotNetPure.PlayerIndex.One, forceRight, forceLeft);
		XInputDotNetPure.GamePad.SetVibration(XInputDotNetPure.PlayerIndex.Two, forceRight, forceLeft);
		XInputDotNetPure.GamePad.SetVibration(XInputDotNetPure.PlayerIndex.Three, forceRight, forceLeft);
		XInputDotNetPure.GamePad.SetVibration(XInputDotNetPure.PlayerIndex.Four, forceRight, forceLeft);
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

	private void OnApplicationQuit(){
		gamePadShake(0.0F, 0.0F);
	}
	
	private void GamePadManager(){
		Vector2 leftStick = GamepadInput.GamePad.GetAxis(GamepadInput.GamePad.Axis.LeftStick, GamepadInput.GamePad.Index.Any);
		Vector2 rightStick = GamepadInput.GamePad.GetAxis(GamepadInput.GamePad.Axis.RightStick, GamepadInput.GamePad.Index.Any);

		if (GamepadInput.GamePad.GetTrigger(GamepadInput.GamePad.Trigger.RightTrigger, GamepadInput.GamePad.Index.Any) >= detectionTrigger)
			rock.instanciateAndThrowRock(throwRockForce);
		if (GamepadInput.GamePad.GetTrigger(GamepadInput.GamePad.Trigger.LeftTrigger, GamepadInput.GamePad.Index.Any) >= detectionTrigger)
			bodyLR.placeBackWall();
		if (GamepadInput.GamePad.GetButtonDown(GamepadInput.GamePad.Button.RightShoulder, GamepadInput.GamePad.Index.Any))
			transform.Rotate(0, cranRotate, 0);
		if (GamepadInput.GamePad.GetButtonDown(GamepadInput.GamePad.Button.LeftShoulder, GamepadInput.GamePad.Index.Any))
			transform.Rotate(0, -cranRotate, 0);
		if (GamepadInput.GamePad.GetButtonDown(GamepadInput.GamePad.Button.Y, GamepadInput.GamePad.Index.Any)){
			noiseCommunication.volume += incrementationVolume;
			communication.volume += incrementationVolume;
		}
		if (GamepadInput.GamePad.GetButtonDown(GamepadInput.GamePad.Button.A, GamepadInput.GamePad.Index.Any) && communication.volume > 0.1F){
			noiseCommunication.volume -= incrementationVolume;
			communication.volume -= incrementationVolume;
		}
		
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

		if (Input.GetKeyDown (throwRock))
			rock.instanciateAndThrowRock(throwRockForce);
		if (Input.GetKeyDown (placeBackWall))
			bodyLR.placeBackWall();
		if (Input.GetKeyDown (rotate45Left))
			transform.Rotate(0, -cranRotate, 0);
		if (Input.GetKeyDown(rotate45Right))
			transform.Rotate(0, cranRotate, 0);

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
}
