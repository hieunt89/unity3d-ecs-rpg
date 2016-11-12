using Entitas;
using UnityEngine;
using System.Collections.Generic;

public class NavigationSystem : ISetPool, IReactiveSystem {
	Pool _pool;

	public void SetPool (Pool pool)
	{
		_pool = pool;

	}

	public void Execute (List<Entity> entities)
	{
		foreach (var e in entities) {
			var agent = e.view.gameObject.GetComponent <NavMeshAgent> ();
			if (agent == null) 
				agent = e.view.gameObject.AddComponent <NavMeshAgent> ();
			agent.SetDestination (new Vector3 (e.destination.x, e.destination.y, e.destination.z));
		}
	}

	public TriggerOnEvent trigger {
		get {
			return CoreMatcher.Destination.OnEntityAdded ();
		}
	}
}
