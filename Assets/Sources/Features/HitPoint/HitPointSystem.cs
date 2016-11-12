using Entitas;
using UnityEngine;
using System;

public class HitPointSystem : IReactiveSystem {
	
	public TriggerOnEvent trigger {
		get {
			return Matcher.AllOf(CoreMatcher.CurrentLevel, CoreMatcher.BaseHitPoint).OnEntityAdded();
		}
	}

	public void Execute (System.Collections.Generic.List<Entity> entities)
	{
		var characterEntity = entities.SingleEntity ();
		//
		int hitPoint = characterEntity.baseHitPoint.amount;
		if (characterEntity.currentLevel.value > 1){
			for (int levelIndex = 1; levelIndex < characterEntity.currentLevel.value; levelIndex++)
			{
				hitPoint = Mathf.FloorToInt (hitPoint * 1.1f);
			}
		}
		characterEntity.ReplaceHitPoint (hitPoint);

		//
		characterEntity.ReplaceCurrentHitPoint (hitPoint);
	}

}
