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

	[Header("Camera positions")]
	[SerializeField] private float radiusFromFocusPoint=10;
	[SerializeField] private float cameraHeight=10;
	[SerializeField] private float minRadius=1;
	[SerializeField] private float minHeight=1;
	[SerializeField] private float maxRadius=10;
	[SerializeField] private float maxHeight=10;

	[Header("Zoom")]
	[SerializeField] private int minZoom = 1;
	[SerializeField] private int maxZoom = 10;

	[Header("Rotation")]
	[SerializeField] private float rotateSpeed = 10;
	[SerializeField] private float rotateSensitivity = 0.2f;
	[SerializeField] private float smoothness = 0.2f;

    private Camera _camera;
	private float angleRotation = 0;
	private float angle = 0;
	private float zoomLevel = 10;
	private int zoomVal = 0;
	private float currentRadiusFromFocusPoint = 10;
	private float currentCameraHeight = 10;


	private void Awake()
	{
		_camera = GetComponent<Camera>();

		ProjectContext.InputManager.inputControls.Player.CameraMove.performed += OnRotateAround;
		ProjectContext.InputManager.inputControls.Player.CameraMove.canceled += OnRotateAroundStop;
		ProjectContext.InputManager.inputControls.Player.Zoom.performed += OnZoom;
	}

	private void OnDestroy()
	{
		ProjectContext.InputManager.inputControls.Player.CameraMove.performed -= OnRotateAround;
		ProjectContext.InputManager.inputControls.Player.CameraMove.canceled -= OnRotateAroundStop;
		ProjectContext.InputManager.inputControls.Player.Zoom.performed -= OnZoom;
	}

	private void Update()
	{

	}

	private void LateUpdate()
	{
		Follow();
		RotateAround();
		Zoom();
		LookAtTarget();
	}

	private void Follow()
	{
		var rad = angle * (float)Mathf.PI / 180f;
		var currentPosition = new Vector3((float)Mathf.Cos(rad) * currentRadiusFromFocusPoint, currentCameraHeight, (float)Mathf.Sin(rad) * currentRadiusFromFocusPoint)  + _focusTarget.position;
		transform.position = currentPosition;
		//transform.position = Vector3.Lerp(transform.position, currentPosition, smoothness);
	}

	private void LookAtTarget()
	{
		var relativePosition =  _focusTarget.position - transform.position;
		transform.rotation = Quaternion.LookRotation(relativePosition, Vector3.up);
		//transform.rotation = transform.rotation * Quaternion.AngleAxis(angle, Vector3.up);
	}

	private void RotateAround()
	{
		angle += angleRotation * rotateSensitivity;
	}

	private void Zoom()
	{
		if (zoomVal + zoomLevel<=maxZoom && zoomVal + zoomLevel >= minZoom)
		{
			zoomLevel += zoomVal;			
		}
		zoomVal = 0;

		var percent = (float)(zoomLevel -minZoom) / (float)(maxZoom - minZoom);
		radiusFromFocusPoint = Mathf.Lerp(minRadius, maxRadius, percent);
		cameraHeight = Mathf.Lerp(minHeight, maxHeight, percent);

		currentRadiusFromFocusPoint= Mathf.Lerp(currentRadiusFromFocusPoint, radiusFromFocusPoint, smoothness);
		currentCameraHeight= Mathf.Lerp(currentCameraHeight, cameraHeight, smoothness);
	}
	
	private void OnZoom(CallbackContext context)
	{
		zoomVal = -(int)context.ReadValue<Vector2>().normalized.y;
	}

	private void OnRotateAround(CallbackContext context)
	{
		angleRotation = context.ReadValue<Vector2>().x;
	}

	private void OnRotateAroundStop(CallbackContext context)
	{
		angleRotation = 0;
	}
}
