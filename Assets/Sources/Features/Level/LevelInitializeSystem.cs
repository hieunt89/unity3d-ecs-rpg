using Entitas;
using UnityEngine;
using System;

public class LevelInitializeSystem : IReactiveSystem { //, IEnsureComponents {
	static int baseXP = 1000;
	public TriggerOnEvent trigger {
		get {
			return CoreMatcher.CurrentLevel.OnEntityAdded();
		}
	}

//	public IMatcher ensureComponents {
//		get {
//			return Matcher.AllOf (CoreMatcher.CurrentLevel, CoreMatcher.Exp);
//		}
//	}

	public void Execute (System.Collections.Generic.List<Entity> entities)
	{
		foreach (var e in entities) {
			var newValue = baseXP;
			if (e.currentLevel.value > 1) {
				for (int levelIndex = 1; levelIndex < e.currentLevel.value; levelIndex++)
				{
					newValue = baseXP * 2;
				}
			}
			
			e.ReplaceExp (newValue);
		}
	
	}

}
