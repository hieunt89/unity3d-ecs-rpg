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
		var moveInputEntity = entities.SingleEntity ();
		var moveInput = moveInputEntity.moveInput;

		var selectedEntity = _pools.input.selectInput.entity;
		if (selectedEntity != null && selectedEntity.isMovable) {
			selectedEntity.ReplaceDestination (moveInput.x, moveInput.y, moveInput.z);
		}
    }
}
