using ProjectContexts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
	[SerializeField] private float speed=3;
	[SerializeField] private float angleSpeed=200;
	private Vector2 direction;
	private float angle = 0;

    private CharacterController characterController;

	public InputControls inputControls;
	private void Awake()
	{
		characterController = GetComponent<CharacterController>();

		ProjectContext.InputManager.inputControls.Player.Move.performed += OnMove;
		ProjectContext.InputManager.inputControls.Player.Move.canceled += OnMoveStop;
	}

	private void OnDestroy()
	{
		ProjectContext.InputManager.inputControls.Player.Move.performed -= OnMove;
		ProjectContext.InputManager.inputControls.Player.Move.canceled -= OnMoveStop;
	}

	private void Update()
	{
		Move();
		Rotate();
	}

	private void Move()
	{
		//if (Keyboard.current.wKey.ReadValue() == 1)
		//{
		//	direction = 1;
		//}
		//else if (Keyboard.current.sKey.ReadValue() == 1)
		//{
		//	direction = -1;
		//}
		//else
		//{
		//	direction = 0;
		//}

		var velocity = transform.forward * direction.x * speed;
		characterController.SimpleMove(velocity);
	}

	private void Rotate()
	{
		//if (Keyboard.current.dKey.ReadValue() == 1)
		//{
		//	angle += angleSpeed * Time.deltaTime;
		//}
		//if (Keyboard.current.aKey.ReadValue() == 1)
		//{
		//	angle -= angleSpeed * Time.deltaTime;
		//}


		angle += direction.y * angleSpeed * Time.deltaTime;
		transform.rotation = Quaternion.AngleAxis(angle, Vector3.up);
	}

	private void OnMove(CallbackContext context)
	{
		var vec2 = context.ReadValue<Vector2>();
		direction = new Vector2(vec2.y, vec2.x);
	}

	private void OnMoveStop(CallbackContext context)
	{
		direction = Vector3.zero;
	}
}
