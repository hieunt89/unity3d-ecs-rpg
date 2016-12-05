using System;
using System.Collections.Generic;
using Entitas;
public class HitPointInitializeSystem : IReactiveSystem {
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
}
