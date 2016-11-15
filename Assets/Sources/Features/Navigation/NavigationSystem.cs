using Entitas;
using UnityEngine;
using System.Collections.Generic;

public class NavigationSystem : ISetPool, IReactiveSystem { //, IEnsureComponents {
	Pool _pool;

	public void SetPool (Pool pool)
	{
		_pool = pool;
	}

//	public IMatcher ensureComponents {
//		get {
//			return CoreMatcher.Destination;
//		}
//	}

	public void Execute (List<Entity> entities)
	{
		Debug.Log ("tick");
		var characterEntity = _pool.characterEntity;
		var agent = characterEntity.view.gameObject.GetComponent <NavMeshAgent> ();
		if (agent == null) 
			agent = characterEntity.view.gameObject.AddComponent <NavMeshAgent> ();

		if (!agent.enabled)
			agent.enabled = true;

		agent.speed = characterEntity.moveSpeed.value;
		agent.angularSpeed = characterEntity.turnSpeed.value;
			
		agent.SetDestination (new Vector3 (characterEntity.destination.x, characterEntity.destination.y, characterEntity.destination.z));
	}

	public TriggerOnEvent trigger {
		get {
//			return CoreMatcher.Destination.OnEntityAdded ();
			return CoreMatcher.Tick.OnEntityAdded ();
		}
	}
}
