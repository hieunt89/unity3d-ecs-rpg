using Entitas;
using UnityEngine;
using System;

public class LevelUpSystem : ISetPool, IReactiveSystem {
	Pool _pool;
	Group levelUps;

	public void SetPool (Pool pool)
	{
		_pool = pool;
		levelUps = _pool.GetGroup (CoreMatcher.LevelUp);
	}
	public TriggerOnEvent trigger {
		get {
			return CoreMatcher.LevelUp.OnEntityAdded();
		}
	}

	public void Execute (System.Collections.Generic.List<Entity> entities)
	{
		if (levelUps.count <= 0) return;
		foreach (var e in levelUps.GetEntities ()) {
			e.ReplaceCurrentLevel (e.currentLevel.value + 1); 

			// update current exp - with remain exp
			e.ReplaceCurrentExp (e.levelUp.remainExp);

			e.RemoveLevelUp ();
		}
	}
}
