using Entitas;
using UnityEngine;

public class BleedSystem : ISetPool, IReactiveSystem {
	Pool _pool;
	Group _group;
	public void SetPool (Pool pool)
	{
		_pool = pool;
		_group = _pool.GetGroup (Matcher.AllOf (CoreMatcher.Bleed, CoreMatcher.CurrentHitPoint, CoreMatcher.HitPoint));
	}

	public void Execute (System.Collections.Generic.List<Entity> entities)
	{
		if (_group.count <= 0) return;

		foreach (var e in _group.GetEntities()) {
			if (e.currentHitPoint.amount > 0) {
				if (e.bleed.elapse <= 0) {
					var newAmount = e.currentHitPoint.amount - (e.hitPoint.amount * e.bleed.rate);
					e.ReplaceCurrentHitPoint (Mathf.Clamp (Mathf.FloorToInt (newAmount), 0, e.hitPoint.amount));

					e.bleed.elapse = e.bleed.interval;
				} else {
					e.bleed.elapse -= entities.SingleEntity ().tick.currentTick;
				}
			}
		}
	}

	public TriggerOnEvent trigger {
		get {
			return CoreMatcher.Tick.OnEntityAdded ();
		}
	}
}
