using Entitas;
using UnityEngine;

public class ProcessInputSystem : ISetPool, IReactiveSystem {

	Pool _pool;

	public void SetPool (Pool pool)
	{
		_pool = pool;
	}

	public void Execute (System.Collections.Generic.List<Entity> entities)
	{
		Debug.Log ("Process Input");
		var e = entities.SingleEntity();
	}

	public TriggerOnEvent trigger {
		get {
			return Matcher.Input.OnEntityAdded ();
		}
	}
}
