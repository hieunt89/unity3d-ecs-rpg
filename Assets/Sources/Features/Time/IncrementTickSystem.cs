using Entitas;
using UnityEngine;

public class IncrementTickSystem : ISetPool, IInitializeSystem, IExecuteSystem {
	Pool _pool;

 	public void SetPool (Pool pool)
	{
		_pool = pool;
	}

	public void Initialize ()
	{
		_pool.SetTick (0f)
			.AddSpeed (1f)
			;
	}

	public void Execute ()
	{
		var e = _pool.tickEntity;
		if (!e.isPause)
			e.ReplaceTick (e.tick.currenTick + e.speed.value);
	}
}
