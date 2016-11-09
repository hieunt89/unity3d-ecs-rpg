using Entitas;
using UnityEngine;

public class ProduceManaSystem : ISetPool, IInitializeSystem, IReactiveSystem {
	Pool _pool;

	public void SetPool (Pool pool)
	{
		_pool = pool;
	}

	public void Initialize ()
	{
		_pool.SetMana (0);
	}

	public TriggerOnEvent trigger {
		get {
			return Matcher.Tick.OnEntityAdded ();
		}
	}

	public void Execute (System.Collections.Generic.List<Entity> entities)
	{
		// tick change 1 second per frame .... sai roi
		Debug.Log ("tick changed");
		_pool.ReplaceMana (_pool.mana.amount + 1);
	}

}
