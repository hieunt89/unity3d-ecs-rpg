using Entitas;
using UnityEngine;
using System;

public class LevelUpSystem : IReactiveSystem {
	
	public TriggerOnEvent trigger {
		get {
			return CoreMatcher.LevelUp.OnEntityAdded();
		}
	}

	public void Execute (System.Collections.Generic.List<Entity> entities)
	{
		var e = entities.SingleEntity ();
		e.ReplaceCurrentLevel (e.currentLevel.value + 1); 
		
		// update current exp - with remain exp
		e.ReplaceCurrentExp (e.levelUp.remainExp);

		e.RemoveLevelUp ();
	}

}
