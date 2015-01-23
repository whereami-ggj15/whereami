using UnityEngine;
using System.Collections;
using GamepadInput;

public class PlayerController : MonoBehaviour {

	public float speedMove = 10.0F;
	public float speedRotate = 80.0F;

	void Update(){
		Vector2 leftStick = GamePad.GetAxis(GamePad.Axis.LeftStick, GamePad.Index.Any);
		Vector2 rightStick = GamePad.GetAxis(GamePad.Axis.RightStick, GamePad.Index.Any);

		transform.Translate(Vector3.forward * Time.deltaTime * leftStick.y * speedMove);
		transform.Translate(Vector3.right * Time.deltaTime * leftStick.x * speedMove);
		transform.Rotate(Vector3.up * Time.deltaTime * rightStick.x * speedRotate);

		if (GamePad.GetButtonDown(GamePad.Button.A, GamePad.Index.Any))
			Debug.Log ("A");
	}
}