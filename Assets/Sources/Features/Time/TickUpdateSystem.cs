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
        _pool.SetTick(0f)
        .AddTickSpeed (1f)
        ;
    }

    public void Execute()
    {
        if (!_pool.isPause) {
        }
    }


   
}
