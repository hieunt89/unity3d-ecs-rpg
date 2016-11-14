using Entitas;
using UnityEngine;
using System;

public class CharacterRenderViewSystem : ISetPool, IReactiveSystem {

	Pool _pool;
	readonly Transform _viewContainer = new GameObject("Views").transform;

	public void SetPool (Pool pool)
	{
		_pool = pool;
	}
	public TriggerOnEvent trigger {
		get {
			return CoreMatcher.Character.OnEntityAdded();
		}
	}

	public void Execute (System.Collections.Generic.List<Entity> entities)
	{
		var characterEntity = _pool.characterEntity;
		var prefab = Resources.Load<GameObject> (characterEntity.name.value);
		GameObject view = null;
		try {
			view = GameObject.Instantiate (prefab);
		} catch (Exception) {
			Debug.Log ("Cannot instantiate " + prefab);
		}

		if (view != null) {
			view.transform.SetParent (_viewContainer, false);
			characterEntity.AddView (view);
			view.Link(characterEntity, _pool);

			if (characterEntity.hasPosition) {
				var position = characterEntity.position;
				view.transform.position = new Vector3(position.x, position.y, position.z);
			}
		}
	}
}
