using System.Collections.Generic;
using Entitas;
public class PauseUpdateSystem : ISetPool, IReactiveSystem {
	Pool _pool;

    public TriggerOnEvent trigger
    {
        get
        {
			return CoreMatcher.Pause.OnEntityAddedOrRemoved ();
        }
    }

    public void Execute(List<Entity> entities)
    {
		_pool.tickEntity.ReplaceTimeScale (_pool.isPause ? 0f : 1f);
    }

    public void SetPool(Pool pool)
    {
        _pool = pool;
    }
}
