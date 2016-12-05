using Entitas;
using UnityEngine;

public class ClickInputSystem : ISetPool, IExecuteSystem {
	Pool _pool;
	RaycastHit hit;
	Group selectedGroup;

	public void SetPool (Pool pool)
	{
		_pool = pool;
		selectedGroup = _pool.GetGroup (CoreMatcher.Selected);
	}

	public void Execute ()
	{
		if(Input.GetMouseButtonDown(0)) {
			Debug.Log ("click");
			// remove selected entities 
			foreach (var selectedEntity in selectedGroup.GetEntities()) {
				selectedEntity.IsSelected (false);
			}


			Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100);
			if (hit.collider != null) {
				var view = hit.collider.gameObject;

				if (view.GetComponent <EntityLink> ()) {
					var entity = view.GetComponent<EntityLink> ().Entity;
					if (entity != null && entity.isSelectable) {
						entity.IsSelected (true);
					}
				}
			} 
		}
	}
}
