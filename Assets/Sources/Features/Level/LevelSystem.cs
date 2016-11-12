using Entitas;
using UnityEngine;
using System;

public class LevelSystem : IReactiveSystem {
	static int baseXP = 1000;
	public TriggerOnEvent trigger {
		get {
			return CoreMatcher.CurrentLevel.OnEntityAdded();
		}
	}

	public void Execute (System.Collections.Generic.List<Entity> entities)
	{
		var characterEntity = entities.SingleEntity ();
		var exp = baseXP;
		if (characterEntity.currentLevel.value > 1) {
			for (int levelIndex = 1; levelIndex < characterEntity.currentLevel.value; levelIndex++)
			{
				exp = baseXP * 2;
			}
		}

		characterEntity.ReplaceExp (exp);
		Debug.Log (exp);
	}

}
