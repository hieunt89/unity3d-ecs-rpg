using System;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class HitPointRegenerationSystem : ISetPool, IReactiveSystem
{
	Pool _pool;
	Group _group;

	int count = 0;
	const int frequency = 3;
	const float step = 0.01f;

    public TriggerOnEvent trigger
    {
        get
        {
			return CoreMatcher.Tick.OnEntityAdded ();
        }
    }

    public void Execute(List<Entity> entities)
    {
//		Debug.Log ("regen");
		var characterEntity = _pool.characterEntity;

		if (count == 0) {
//			var newAmount = Mathf.Min (characterEntity.hitPoint.amount, characterEntity.currentHitPoint.amount + step);
//			characterEntity.ReplaceCurrentHitPoint (newAmount);
		}
		count = ((count + 1) % frequency);
		Debug.Log (count);
//		foreach (var e in _group.GetEntities ())
//		{
//			if (e.currentHitPoint.amount < e.hitPoint.amount) {
//				var newAmount = e.currentHitPoint.amount + (e.hitPoint.amount * e.hitPointRegenerationRate.value);
//				e.ReplaceCurrentHitPoint (Mathf.FloorToInt (newAmount));
//			}
//		}
    }

    public void SetPool(Pool pool)
    {
		_pool = pool;
		_group = _pool.GetGroup(CoreMatcher.CurrentHitPoint);
    }
}
