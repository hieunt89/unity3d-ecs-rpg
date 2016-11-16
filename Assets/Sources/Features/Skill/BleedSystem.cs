using Entitas;
using UnityEngine;

public class BleedSystem : ISetPool, IReactiveSystem {
	Pool _pool;
	Group _group;
	public void SetPool (Pool pool)
	{
		_pool = pool;
		_group = _pool.GetGroup (SkillMatcher.Bleed);
	}

	public void Execute (System.Collections.Generic.List<Entity> entities)
	{
//		if (_group.count <= 0) return;
//
//		foreach (var e in _group.GetEntities()) {
//			var newAmount = e.currentHitPoint.amount - (e.hitPoint.amount * e.bleed.rate);
//			e.ReplaceCurrentHitPoint(Mathf.Clamp (Mathf.FloorToInt (newAmount), 0, e.hitPoint.amount));
//		}
	}

	public TriggerOnEvent trigger {
		get {
			return CoreMatcher.Tick.OnEntityAdded ();
			// TODO: need to fix error here :(
		}
	}
}
