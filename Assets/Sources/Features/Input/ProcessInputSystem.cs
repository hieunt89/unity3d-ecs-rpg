using System.Collections.Generic;
using Entitas;
using System.Linq;
using UnityEngine;

public sealed class ProcessMoveInputSystem : ISetPools, IReactiveSystem {

    public TriggerOnEvent trigger { get { return InputMatcher.MoveInput.OnEntityAdded(); } }

	Pools _pools;

	public void SetPools (Pools pools)
	{
		_pools = pools;
	}

    public void Execute(List<Entity> entities) {
        var inputEntity = entities.SingleEntity();
		var moveInput = inputEntity.moveInput;

		_pools.core.characterEntity.ReplaceDestination (moveInput.x, moveInput.y, moveInput.z);
    }
}
