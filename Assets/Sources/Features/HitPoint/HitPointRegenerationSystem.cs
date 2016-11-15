using System;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class HitPointRegenerationSystem : ISetPool, IReactiveSystem
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

    public void Execute(List<Entity> entities)
    {
    }

    public void SetPool(Pool pool)
    {
		_pool = pool;
		_group = _pool.GetGroup(CoreMatcher.CurrentHitPoint);
    }
}
