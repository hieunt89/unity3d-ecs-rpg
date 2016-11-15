using Entitas;
using UnityEngine;

public class TickUpdateSystem : ISetPool, IInitializeSystem, IExecuteSystem 
{	
    Pool _pool;

    public void SetPool(Pool pool)
    {
    	  _pool = pool;
    }

    public void Initialize()
    {
        _pool.ReplaceTick (0f)
			.ReplaceTimeScale (1f)
            .ReplaceTotalTick (0f)
			;
    }

    public void Execute()
    {
        if (!_pool.isPause) {
            var e = _pool.tickEntity;
            e.ReplaceTick(Time.deltaTime)
			.ReplaceTotalTick (e.totalTick.amount + e.tick.currentTick)
            ;
        } 
    }
}
