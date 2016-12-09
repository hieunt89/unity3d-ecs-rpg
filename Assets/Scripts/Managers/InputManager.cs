using UnityEngine;
using System.Collections;
using UnityEngine.InputNew;
using Entitas;

namespace RPG {
	public class InputManager : MonoBehaviour {
		MyInputs mInput;
		PlayerInput playerInput;

		Vector3 startMousePosition;
		bool isSelecting;

		Group selectableGroup;

		void Start () {
			playerInput = GameObject.FindObjectOfType <PlayerInput> ();
			if (playerInput) 
				mInput = playerInput.GetActions <MyInputs> ();

			selectableGroup = Pools.sharedInstance.core.GetGroup (CoreMatcher.Selectable);

		}
		
		// Update is called once per frame
		void Update () {

			var leftMouseDown = mInput.leftClick.wasJustPressed;
			if (leftMouseDown) {
				isSelecting = true;
				startMousePosition = Mouse.current.position;
			}

			var leftMouseUp = mInput.leftClick.wasJustReleased;
			if (leftMouseUp) {
				isSelecting = false;
			}

			if (isSelecting) {
				foreach (var e in selectableGroup.GetEntities()) {
					if (IsWithinSelectionBounds (e.view.gameObject)) {
						if (!e.hasIndicator) {
						}
					}
				}
			}
		}

		void OnGUI () {
			if (isSelecting) {
				var rect = GetScreenRect (startMousePosition, Input.mousePosition);
				DrawScreenRect (rect, new Color (0f, 255f, 0f, 0.25f));
				DrawScreenRectBorder (rect, 1, new Color (0f, 255f, 0f));
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
}