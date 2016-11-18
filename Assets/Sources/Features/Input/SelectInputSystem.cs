using Entitas;
using UnityEngine;

public class SelectInputSystem : ISetPool, IExecuteSystem, ICleanupSystem {

	Pool _pool;
	Group selectedInputs;

	public void SetPool(Pool pool) {
		_pool = pool;
		selectedInputs = pool.GetGroup(InputMatcher.SelectInput);
	}

	public void Execute() {
		var input = Input.GetMouseButtonDown(0);

		if(input) {
			RaycastHit hit;
			Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100);
			if(hit.collider != null) {
				var view = hit.collider.gameObject;
				Entity entity = null;
				if (view.GetComponent <EntityLink> ()) {
					entity = view.GetComponent<EntityLink> ().Entity;
				}
				if (view != null && entity != null) {
					_pool.CreateEntity()
						.AddSelectInput(view, entity);
				} else {
				}
			}
		}
	}

	public void Cleanup() {
		foreach(var e in selectedInputs.GetEntities()) {
			_pool.DestroyEntity(e);
		}
	}
}
