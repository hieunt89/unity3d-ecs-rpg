using Entitas;
using UnityEngine;

public sealed class MoveInputSystem : ISetPool, IExecuteSystem, ICleanupSystem {

    Pool _pool;
    Group moveInputs;

    public void SetPool(Pool pool) {
        _pool = pool;
		moveInputs = pool.GetGroup(InputMatcher.MoveInput);
    }

    public void Execute() {
        var input = Input.GetMouseButtonDown(1);

        if(input) {
			RaycastHit hit;
			Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100);
            if(hit.collider != null) {
				var pos = hit.point;
                _pool.CreateEntity()
					.AddMoveInput(pos.x, pos.y, pos.z);
            }
        }
    }

    public void Cleanup() {
		foreach(var e in moveInputs.GetEntities()) {
            _pool.DestroyEntity(e);
        }
    }
}
