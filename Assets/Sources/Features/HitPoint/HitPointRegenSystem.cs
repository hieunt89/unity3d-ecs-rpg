using Entitas;
using UnityEngine;

public class HitPointRegenSystem : ISetPool, IReactiveSystem
{
	Pool _pool;
	Group _group;

    public TriggerOnEvent trigger
    {
        get
        {
			return CoreMatcher.Tick.OnEntityAdded ();
        }
    }

    public void Execute(System.Collections.Generic.List<Entity> entities)
    {
		if (_group.count <= 0)
			return;
		
		foreach (var e in _group.GetEntities()) {
			if (e.hitPointRegen.duration <= 0) {
				var newAmount = e.currentHitPoint.amount + (e.hitPoint.amount * Mathf.Clamp01 (e.hitPointRegen.rate));
				e.ReplaceCurrentHitPoint (Mathf.Clamp (Mathf.FloorToInt (newAmount), 0, e.hitPoint.amount));

				e.hitPointRegen.duration = e.hitPointRegen.interval;
			} else {
				e.hitPointRegen.duration -= entities.SingleEntity().tick.currentTick;
			}
		} 
    }

    public void SetPool(Pool pool)
    {
		_pool = pool;
		_group = _pool.GetGroup(Matcher.AllOf (CoreMatcher.CurrentHitPoint, CoreMatcher.Wound));
    }
}
