using Entitas;
using UnityEngine;
using System.Collections.Generic;

public class NavigationSystem : ISetPool, IReactiveSystem { //, IEnsureComponents {
	Pool _pool;
	Group characters;
	public void SetPool (Pool pool)
	{
		_pool = pool;
		characters = _pool.GetGroup (Matcher.AllOf (CoreMatcher.Active, CoreMatcher.Character, CoreMatcher.View, CoreMatcher.Movable, CoreMatcher.MoveSpeed, CoreMatcher.TurnSpeed));
	}

//	public IMatcher ensureComponents {
//		get {
//			return Matcher.AllOf (CoreMatcher.Active, CoreMatcher.Character, CoreMatcher.View, CoreMatcher.Movable, CoreMatcher.MoveSpeed, CoreMatcher.TurnSpeed);
//		}
//	}

	public void Execute (List<Entity> entities)
	{
		foreach (var e in characters.GetEntities()) {
			var agent = e.view.gameObject.GetComponent <NavMeshAgent> ();
			if (agent == null) 
				agent = e.view.gameObject.AddComponent <NavMeshAgent> ();

			if (!agent.enabled)
				agent.enabled = true;

			agent.speed = e.moveSpeed.value;
			agent.angularSpeed = e.turnSpeed.value;
				
			agent.SetDestination (new Vector3 (e.destination.x, e.destination.y, e.destination.z));
		}
	}

	public TriggerOnEvent trigger {
		get {
//			return CoreMatcher.Destination.OnEntityAdded ();
			return CoreMatcher.Tick.OnEntityAdded ();
		}
	}
}
