using Entitas;
using UnityEngine;

// xu ly input system
// touch input
// mouse click input
public class InputSystem : ISetPool, IExecuteSystem, ICleanupSystem {

	Pool _pool;
	Group _inputs;

	public void SetPool (Pool pool)
	{
		_pool = pool;
		_inputs = pool.GetGroup (Matcher.Input);
	}

	public void Execute ()
	{
		// left click
		var input = Input.GetMouseButtonDown (1);

		if (input) {
			RaycastHit hit;
			Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100f);
			if (hit.collider != null) {
				_pool.CreateEntity().AddInput (hit.point.x, hit.point.y, hit.point.z);
			}
		}
	}

	// sao khong thay no execute ?
	public void Cleanup ()
	{
		Debug.Log ("clean up");
		foreach (var e in _inputs.GetEntities()) {
			_pool.DestroyEntity(e);
		}
	}
}
