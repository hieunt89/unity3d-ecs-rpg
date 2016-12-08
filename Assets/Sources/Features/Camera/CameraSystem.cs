using Entitas;
using UnityEngine;

public class CameraSystem : IInitializeSystem, IExecuteSystem
{
	const string INPUT_MOUSE_SCROLLWHEEL = "Mouse ScrollWheel";
	const string INPUT_MOUSE_X = "Mouse X";
	const string INPUT_MOUSE_Y = "Mouse Y";
//	const float MIN_CAM_DISTANCE = 10f;
//	const float MAX_CAM_DISTANCE = 40f;

	public float movementSpeed = .5f;
	public float rotationSpeed = 2f;
	public float smoothess = 0.85f;

	// how fast the camera zooms in and out
//	[Range(.3f,2f)]
//	public float zoomSpeed = .8f;

	// the current distance from pivot point (locked to Vector3.zero)
//	float distance = 0f;

	Camera mainCamera;
	Vector3 targetPosition;
	public Quaternion targetRotation;
	float targetRotationX;
	float targetRotationY;

	public void Initialize ()
	{
		mainCamera = Camera.main;
		targetPosition = mainCamera.transform.position;
		targetRotation = mainCamera.transform.rotation;
		targetRotationX = mainCamera.transform.localRotation.eulerAngles.x;
		targetRotationX = mainCamera.transform.localRotation.eulerAngles.x;
	}

	public void Execute ()
	{


		if (Input.GetKey (KeyCode.W)) {
			targetPosition += mainCamera.transform.forward * movementSpeed;
		}
		if (Input.GetKey (KeyCode.S)) {
			targetPosition -= mainCamera.transform.forward * movementSpeed;
		}

		if (Input.GetKey (KeyCode.A)) {
			targetPosition -= mainCamera.transform.right * movementSpeed;
		}
		if (Input.GetKey (KeyCode.D)) {
			targetPosition += mainCamera.transform.right * movementSpeed;
		}

		//		if (Input.GetKey (KeyCode.Q)) {
		//			targetPosition -= mainCamera.transform.up * movementSpeed;
		//		}
		//		if (Input.GetKey (KeyCode.E)) {
		//			targetPosition += mainCamera.transform.up * movementSpeed;
		//		}

		//		if( Input.GetAxis(INPUT_MOUSE_SCROLLWHEEL) != 0f )
		//		{
		//			float delta = Input.GetAxis(INPUT_MOUSE_SCROLLWHEEL);
		//
		//			distance -= delta * (distance/MAX_CAM_DISTANCE) * (zoomSpeed * 1000) * Time.deltaTime;
		//			distance = Mathf.Clamp(distance, MIN_CAM_DISTANCE, MAX_CAM_DISTANCE);
		//			mainCamera.transform.position = mainCamera.transform.localRotation * (Vector3.forward * -distance);
		//		}

		if (Input.GetMouseButton (1)) {
			Cursor.visible = false;
			targetRotationX -= Input.GetAxis (INPUT_MOUSE_Y) * rotationSpeed;
			targetRotationY += Input.GetAxis (INPUT_MOUSE_X) * rotationSpeed;
			targetRotation = Quaternion.Euler (targetRotationX, targetRotationY, 0.0f);
		} else {
			Cursor.visible = true;
		}

		mainCamera.transform.position = Vector3.Lerp (mainCamera.transform.position, targetPosition, (1.0f - smoothess));
		mainCamera.transform.rotation = Quaternion.Lerp (mainCamera.transform.rotation, targetRotation, (1.0f - smoothess));

	}
}
