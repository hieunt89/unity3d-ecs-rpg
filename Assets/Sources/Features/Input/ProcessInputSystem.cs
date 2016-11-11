using System.Collections.Generic;
using Entitas;
using System.Linq;
using UnityEngine;

public sealed class ProcessMoveInputSystem : ISetPools, IReactiveSystem {

    public TriggerOnEvent trigger { get { return InputMatcher.Input.OnEntityAdded(); } }

	Pools _pools;

	public void SetPools (Pools pools)
	{
		_pools = pools;
	}

    public void Execute(List<Entity> entities) {
        var inputEntity = entities.SingleEntity();
        var input = inputEntity.input;

		_pools.core.characterEntity.ReplaceDestination (input.x, input.y, input.z);
    }
}
