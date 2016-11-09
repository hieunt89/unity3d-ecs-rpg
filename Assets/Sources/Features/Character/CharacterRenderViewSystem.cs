using Entitas;
using UnityEngine;
using System.Collections.Generic;

public class CharacterRenderViewSystem : ISetPool, IReactiveSystem {
	Pool _pool;

	public void SetPool (Pool pool)
	{
		_pool = pool;
	}

	public void Execute (List<Entity> entities)
	{
//		Debug.Log ("render system");
		// load model from resource
		foreach (var e in entities) {
			new GameObject(e.name.text);
		}
	}

	public TriggerOnEvent trigger {
		get {
			return Matcher.Name.OnEntityAdded ();
		}
	}

}
