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
		var inputEntity = entities.SingleEntity();
		var input = inputEntity.input;
		Debug.Log ("Process Input " + input.x + "/" + input.y + "/" + input.z);
	}

	public TriggerOnEvent trigger {
		get {
			return Matcher.Input.OnEntityAdded ();
		}
	}
}
