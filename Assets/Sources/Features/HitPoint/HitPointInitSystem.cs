using System;
using System.Collections.Generic;
using Entitas;
public class HitPointInitializeSystem : ISetPool, IReactiveSystem {
	Pool _pool;
    public TriggerOnEvent trigger
    {
        get
        {
            return CoreMatcher.BaseHitPoint.OnEntityAdded ();
        }
    }

    public void Execute(List<Entity> entities)
    {
		foreach (var e in entities)
		{
			e.AddHitPoint (e.baseHitPoint.amount);
			e.AddCurrentHitPoint (e.hitPoint.amount);
		}
    }

    public void SetPool(Pool pool)
    {
        _pool = pool;
    }
}
