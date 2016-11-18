using Entitas;
using UnityEngine;

public class NotifySelectListenerSystem : ISetPool, IReactiveSystem {
	Pool _pool;
	Group listeners;
	public void SetPool (Pool pool)
	{
		_pool = pool;
		listeners = _pool.GetGroup (InputMatcher.SelectListener);
	}

	public void Execute (System.Collections.Generic.List<Entity> entities)
	{
		foreach (var e in listeners.GetEntities ()) {
			e.selectListener.listener.OnSelected ();
		}
	}

	public TriggerOnEvent trigger {
		get {
			return InputMatcher.SelectInput.OnEntityAdded ();
		}
	}
}
