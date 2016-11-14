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
           return CoreMatcher.Second.OnEntityAdded ();
        }
    }

    public void Execute(List<Entity> entities)
    {
		Debug.Log ("regen");
		foreach (var e in _group.GetEntities ())
		{
			if (e.currentHitPoint.amount < e.hitPoint.amount) {
				var newAmount = e.currentHitPoint.amount + (e.hitPoint.amount * e.hitPointRegenerationRate.value);
				e.ReplaceCurrentHitPoint (Mathf.FloorToInt (newAmount));
			}
		}
    }

    public void SetPool(Pool pool)
    {
		_pool = pool;
		_group = _pool.GetGroup(CoreMatcher.CurrentHitPoint);
    }
}
