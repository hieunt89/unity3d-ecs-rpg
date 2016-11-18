using Entitas;

public class SlowMovementSystem : ISetPool, IReactiveSystem {
	Pool _pool;
	Group _group;

	public void SetPool (Pool pool)
	{
		_pool = pool;
		_group = _pool.GetGroup (Matcher.AllOf (CoreMatcher.MoveSpeed, CoreMatcher.SlowMovement));
	}

	public void Execute (System.Collections.Generic.List<Entity> entities)
	{
		if (_group.count <= 0)
			return;
		foreach (var e in _group.GetEntities()) {
			if (e.slowMovement.elapse <= 0) {

			} else {
				e.slowMovement.elapse -= entities.SingleEntity ().tick.currentTick;
			}
		}
	}

	public TriggerOnEvent trigger {
		get {
			return CoreMatcher.Tick.OnEntityAdded ();
		}
	}
}
