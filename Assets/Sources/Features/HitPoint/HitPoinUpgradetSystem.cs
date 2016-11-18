using Entitas;
using UnityEngine;

public class HitPointUpgradeSystem : IReactiveSystem, IEnsureComponents {

	public IMatcher ensureComponents {
		get {
			return Matcher.AllOf(CoreMatcher.Active, CoreMatcher.BaseHitPoint, CoreMatcher.HitPoint, CoreMatcher.CurrentHitPoint);
		}
	}

	public TriggerOnEvent trigger {
		get {
			return CoreMatcher.CurrentLevel.OnEntityAdded();
		}
	}

	public void Execute (System.Collections.Generic.List<Entity> entities)
	{
		foreach (var e in entities) {
			//
			int newAmount = e.baseHitPoint.amount;
			for (int levelIndex = 1; e.currentLevel.value > 1 && levelIndex < e.currentLevel.value; levelIndex++)
			{
				newAmount = Mathf.FloorToInt (newAmount * 1.1f);
			}
			e.ReplaceHitPoint (newAmount);

			//
			e.ReplaceCurrentHitPoint (newAmount);
		}
	}

}
