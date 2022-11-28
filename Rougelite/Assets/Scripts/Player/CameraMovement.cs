using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using ProjectContexts;
using static UnityEngine.InputSystem.InputAction;

public class CameraMovement : MonoBehaviour
{
	[SerializeField] private Transform _focusTarget;
	[SerializeField] private AnimationCurve _zoomDistance;
	[SerializeField] private float rotateSpeed = 10;

    private Camera _camera;

	private void Awake()
	{
		_camera = GetComponent<Camera>();

		ProjectContext.InputManager.inputControls.Player.CameraMove.performed += OnRotateAround;
		//ProjectContext.InputManager.inputControls.Player.CameraMove.canceled += OnMoveStop;
	}

	private void OnDestroy()
	{
		ProjectContext.InputManager.inputControls.Player.CameraMove.performed -= OnRotateAround;
		//ProjectContext.InputManager.inputControls.Player.CameraMove.canceled -= OnMoveStop;
	}

	private void LateUpdate()
	{
		Follow();
		LookAtTarget();
	}

	private void Follow()
	{
		//var currentPosition=

		//transform.position = currentPosition;
	}

	private void LookAtTarget()
	{
		var relativePosition =  _focusTarget.position - transform.position;
		transform.rotation = Quaternion.LookRotation(relativePosition, Vector3.up);
	}

	private void Zoom()
	{

	}

	private void OnRotateAround(CallbackContext context)
	{

	}
}
