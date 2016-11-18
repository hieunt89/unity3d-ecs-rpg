using Entitas;
using UnityEngine;

public class SelectInputSystem : ISetPool, IInitializeSystem, IExecuteSystem {

	Pool _pool;

	public void SetPool(Pool pool) {
		_pool = pool;
	}

	public void Initialize ()
	{
		_pool.CreateEntity ().AddSelectInput (null, null);
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
					_pool.selectInputEntity.ReplaceSelectInput (view, entity);
				}
			}
		}
	}
}
