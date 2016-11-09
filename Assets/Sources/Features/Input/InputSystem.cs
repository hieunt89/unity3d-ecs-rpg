using Entitas;
using UnityEngine;

public sealed class InputSystem : ISetPool, IExecuteSystem, ICleanupSystem {

    Pool _pool;
    Group _inputs;

    public void SetPool(Pool pool) {
        _pool = pool;
		_inputs = pool.GetGroup(InputMatcher.Input);
    }

    public void Execute() {
        var input = Input.GetMouseButtonDown(0);

        if(input) {
			RaycastHit hit;
			Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100);
            if(hit.collider != null) {
				var pos = hit.point;

                _pool.CreateEntity()
					.AddInput((int)pos.x, (int)pos.y, (int)pos.z);
            }
        }
    }

    public void Cleanup() {
        foreach(var e in _inputs.GetEntities()) {
            _pool.DestroyEntity(e);
        }
    }
}
