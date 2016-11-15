using Entitas;
using UnityEngine;
using System;

public class LevelUpSystem : ISetPool, IReactiveSystem, ICleanupSystem {
	Pool _pool;
	Group _group;

	public void SetPool (Pool pool)
	{
		_pool = pool;
		_group = _pool.GetGroup (CoreMatcher.LevelUp);
	}
	public TriggerOnEvent trigger {
		get {
			return CoreMatcher.LevelUp.OnEntityAdded();
		}
	}

	public void Execute (System.Collections.Generic.List<Entity> entities)
	{
		for (int index = 0; index < entities.Count; index++) {
			var e = entities [index];
			e.ReplaceCurrentLevel (e.currentLevel.value + 1); 
			
			// update current exp - with remain exp
			e.ReplaceCurrentExp (e.levelUp.remainExp);
		}
	}
	public void Cleanup ()
	{
		foreach (var e in _group.GetEntities()) {
			_pool.DestroyEntity (e);
		}
	}
}
