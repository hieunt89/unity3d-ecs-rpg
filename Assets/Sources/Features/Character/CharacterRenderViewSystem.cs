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
		foreach (var e in entities) {
			var prefab = Resources.Load<GameObject> (e.name.value);
			GameObject go = null;
			try {
				go = GameObject.Instantiate (prefab);
			} catch (Exception) {
				Debug.Log ("Cannot instantiate " + prefab);
			}

			if (go != null) {
				go.transform.SetParent (_viewContainer, false);
				e.AddView (go);
				go.Link(e, _pool);

				if (e.hasPosition) {
					var position = e.position;
					go.transform.position = new Vector3(position.x, position.y, position.z);
				}
			}

		}
	}

}
