using Entitas;
using UnityEngine;

public class MovementSystem : ISetPool, IReactiveSystem {

	Pool _pool;

	public void SetPool (Pool pool)
	{
		_pool = pool;
	}

	public void Execute (System.Collections.Generic.List<Entity> entities)
	{
		Debug.Log ("tick");
	}

	public TriggerOnEvent trigger {
		get {
			return CoreMatcher.Tick.OnEntityAdded ();
		}
	}
}
