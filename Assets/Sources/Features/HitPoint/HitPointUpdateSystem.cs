using Entitas;
using UnityEngine;

public class HitPointUpdateSystem : ISetPool, IEnsureComponents, IReactiveSystem {
	Pool _pool;
	Group _group;

	public void SetPool (Pool pool)
	{
		_pool = pool;
//		_group = _pool.GetGroup (Matcher.AllOf(CoreMatcher.CurrentHitPoint, CoreMatcher.HitPoint
	}

	public IMatcher ensureComponents {
		get {
			return Matcher.AllOf (CoreMatcher.HitPoint, CoreMatcher.CurrentHitPoint, CoreMatcher.Active);
		}
	}

	public void Execute (System.Collections.Generic.List<Entity> entities)
	{
		foreach (var e in entities) {
			if (e.currentHitPoint.amount < e.hitPoint.amount) {
				if (!e.isWound) {
					e.IsWound (true);
				}
			} else {
				e.IsWound (false);
			}

			if (e.currentHitPoint.amount <= 0) {
				// Do something
			}
		}
	}

	public TriggerOnEvent trigger {
		get {
			return CoreMatcher.CurrentHitPoint.OnEntityAdded ();
		}
	}
}
