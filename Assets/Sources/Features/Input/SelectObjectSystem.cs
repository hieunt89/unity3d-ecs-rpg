using Entitas;
using UnityEngine;

public class SelectObjectSystem : ISetPools, IInitializeSystem, ITearDownSystem {

	Pools _pools;
	Group selectedGroup;

	public void SetPools (Pools pools)
	{
		_pools = pools;
		selectedGroup = _pools.core.GetGroup (CoreMatcher.Selected);
	}

	public void Initialize ()
	{
		Messenger.AddListener <RaycastHit> (Events.Input.LeftMouseClick, OnLeftMouseClick);
	}

	void OnLeftMouseClick (RaycastHit _hit) {

		foreach (var selectedEntity in selectedGroup.GetEntities ()) {
			selectedEntity.IsSelected (false);
		}

		var entityLink = _hit.collider.gameObject.GetEntityLink ();
		if (entityLink != null) {
			if (entityLink.Entity.isSelectable) {
				Debug.Log (_hit.collider.name);
				entityLink.Entity.IsSelected (true);
			}
		}
	}

	public void TearDown ()
	{
		Messenger.RemoveListener <RaycastHit> (Events.Input.LeftMouseClick, OnLeftMouseClick);

	}
}
