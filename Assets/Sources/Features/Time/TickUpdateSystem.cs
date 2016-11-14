using Entitas;

public class TickUpdateSystem : ISetPool, IInitializeSystem, IExecuteSystem
{	
    Pool _pool;

    public void SetPool(Pool pool)
    {
    	  _pool = pool;
    }

    public void Initialize()
    {
        _pool.ReplaceTick (0);
    }

    public void Execute()
    {
        if (!_pool.isPause)
            _pool.ReplaceTick(_pool.tick.currentTick + 1);
    }
}
