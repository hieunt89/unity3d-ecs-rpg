using Entitas;
using UnityEngine;
using System;

public class CharacterUpdateHitPointSystem : ISetPool, IReactiveSystem {

	Pool _pool;

	public void SetPool (Pool pool)
	{
		_pool = pool;
	}
	public TriggerOnEvent trigger {
		get {
			return CoreMatcher.Level.OnEntityAdded();
		}
	}

	public void Execute (System.Collections.Generic.List<Entity> entities)
	{
		foreach (var e in entities)
		{
			int hitPoint = e.baseHitPoint.amount;
			for (int levelIndex = 0; levelIndex < e.level.value; levelIndex++)
			{
				hitPoint = Mathf.FloorToInt (hitPoint * 1.1f);
			}
			e.ReplaceHitPoint (hitPoint);
		}
	}

}
