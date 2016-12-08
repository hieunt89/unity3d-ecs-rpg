using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public class _SelectObjectSystem : MonoBehaviour
{
	bool isSelecting = false;
	Vector3 startMousePosition;

	public GameObject selectionCirclePrefab;

	void Update ()
	{
		// If we press the left mouse button, begin selection and remember the location of the mouse
		if (Input.GetMouseButtonDown (0)) {
			isSelecting = true;
			startMousePosition = Input.mousePosition;

			foreach (var selectableObject in FindObjectsOfType<SelectableObjectComponent>()) {
				if (selectableObject.selectIndicator != null) {
					Destroy (selectableObject.selectIndicator.gameObject);
					selectableObject.selectIndicator = null;
				}
			}
		}
		// If we let go of the left mouse button, end selection
		if (Input.GetMouseButtonUp (0)) {
			var selectedObjects = new List<SelectableObjectComponent> ();
			foreach (var selectableObject in FindObjectsOfType<SelectableObjectComponent>()) {
				if (IsWithinSelectionBounds (selectableObject.gameObject)) {
					selectedObjects.Add (selectableObject);
				}
			}

//			var sb = new StringBuilder();
//			sb.AppendLine( string.Format( "Selecting [{0}] Units", selectedObjects.Count ) );
//			foreach( var selectedObject in selectedObjects )
//				sb.AppendLine( "-> " + selectedObject.gameObject.name );
//			Debug.Log( sb.ToString() );

			isSelecting = false;
		}

		// Highlight all objects within the selection box
		if (isSelecting) {
			foreach (var selectableObject in FindObjectsOfType<SelectableObjectComponent>()) {
				if (IsWithinSelectionBounds (selectableObject.gameObject)) {
					if (selectableObject.selectIndicator == null) {
						selectableObject.selectIndicator = Instantiate (selectionCirclePrefab);
						selectableObject.selectIndicator.transform.SetParent (selectableObject.transform, false);
						selectableObject.selectIndicator.transform.eulerAngles = new Vector3 (90, 0, 0);
					}
				} else {
					if (selectableObject.selectIndicator != null) {
						Destroy (selectableObject.selectIndicator.gameObject);
						selectableObject.selectIndicator = null;
					}
				}
			}
		}
	}

	public bool IsWithinSelectionBounds (GameObject gameObject)
	{
		if (!isSelecting)
			return false;

		var camera = Camera.main;
		var viewportBounds = GetViewportBounds (camera, startMousePosition, Input.mousePosition);
		return viewportBounds.Contains (camera.WorldToViewportPoint (gameObject.transform.position));
	}

	void OnGUI ()
	{
		if (isSelecting) {
			// Create a rect from both mouse positions
			var rect = GetScreenRect (startMousePosition, Input.mousePosition);
			DrawScreenRect (rect, new Color (0f, 255f, 0f, 0.25f));
			DrawScreenRectBorder (rect, 1, new Color (0f, 255f, 0f));
		}
	}

	Texture2D _whiteTexture;

	public Texture2D WhiteTexture {
		get {
			if (_whiteTexture == null) {
				_whiteTexture = new Texture2D (1, 1);
				_whiteTexture.SetPixel (0, 0, Color.white);
				_whiteTexture.Apply ();
			}
			return _whiteTexture;
		}
	}

	public Rect GetScreenRect (Vector3 _screenPosition1, Vector3 _screenPosition2)
	{
		// move origon from bottom left to top left
		_screenPosition1.y = Screen.height - _screenPosition1.y;
		_screenPosition2.y = Screen.height - _screenPosition2.y;

		// calculate the corners
		var topLeft = Vector3.Min (_screenPosition1, _screenPosition2);
		var bottomRight = Vector3.Max (_screenPosition1, _screenPosition2);

		// Create new rect
		return Rect.MinMaxRect (topLeft.x, topLeft.y, bottomRight.x, bottomRight.y);
	}

	public Bounds GetViewportBounds (Camera _camera, Vector3 _screenPosition1, Vector3 _screenPosition2)
	{
		var v1 = _camera.ScreenToViewportPoint (_screenPosition1);
		var v2 = _camera.ScreenToViewportPoint (_screenPosition2);
		var min = Vector3.Min (v1, v2);
		var max = Vector3.Max (v1, v2);
		min.z = _camera.nearClipPlane;
		max.z = _camera.farClipPlane;

		var bounds = new Bounds ();
		bounds.SetMinMax (min, max);
		return bounds;
	}

	public void DrawScreenRect (Rect _rect, Color _color)
	{
		GUI.color = _color;
		GUI.DrawTexture (_rect, WhiteTexture);
		GUI.color = Color.white;
	}

	public void DrawScreenRectBorder (Rect _rect, float _thickness, Color _color)
	{
		//TOP
		DrawScreenRect (new Rect (_rect.xMin, _rect.yMin, _rect.width, _thickness), _color);
		//LEFT
		DrawScreenRect (new Rect (_rect.xMin, _rect.yMin, _thickness, _rect.height), _color);
		//RIGHT
		DrawScreenRect (new Rect (_rect.xMax - _thickness, _rect.yMin, _thickness, _rect.height), _color);
		//BOTTOM
		DrawScreenRect (new Rect (_rect.xMin, _rect.yMax - _thickness, _rect.width, _thickness), _color);

	}
}
