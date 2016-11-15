using Entitas;
using UnityEngine;

public class HitPointUpdateSystem : IReactiveSystem, IEnsureComponents {

	public IMatcher ensureComponents {
		get {
			return CoreMatcher.BaseHitPoint;
		}
	}

	public TriggerOnEvent trigger {
		get {
			return CoreMatcher.CurrentLevel.OnEntityAdded();
		}
	}

	public void Execute (System.Collections.Generic.List<Entity> entities)
	{
		var characterEntity = entities.SingleEntity ();
		//
		int hitPoint = characterEntity.baseHitPoint.amount;
		for (int levelIndex = 1; characterEntity.currentLevel.value > 1 && levelIndex < characterEntity.currentLevel.value; levelIndex++)
		{
			hitPoint = Mathf.FloorToInt (hitPoint * 1.1f);
		}
		characterEntity.ReplaceHitPoint (hitPoint);

		//
		characterEntity.ReplaceCurrentHitPoint (hitPoint);
	}

}
