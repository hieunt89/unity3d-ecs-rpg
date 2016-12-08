using Entitas;
using UnityEngine;
using System;

public class CharacterRenderSystem : ISetPool, IReactiveSystem, IEnsureComponents {

	Pool _pool;
	readonly Transform _viewContainer = new GameObject("Views").transform;

	public void SetPool (Pool pool)
	{
		_pool = pool;
	}

	public IMatcher ensureComponents {
		get {
			return Matcher.AllOf (CoreMatcher.Character, CoreMatcher.Name, CoreMatcher.Position);
		}
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
			GameObject view = null;
			try {
				view = GameObject.Instantiate (prefab);
			} catch (Exception) {
				Debug.Log ("Cannot instantiate " + prefab);
			}

			if (view != null) {
				view.transform.SetParent (_viewContainer, false);
				e.AddView (view);
				view.Link(e, _pool);

				var position = e.position;
				view.transform.position = new Vector3(position.x, position.y, position.z);
			}
		}
	}
}
