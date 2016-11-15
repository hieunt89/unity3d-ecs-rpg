using Entitas;

public class HitPointRegenSystem : ISetPool, IReactiveSystem
{
	Pool _pool;
	Group _group;

    public TriggerOnEvent trigger
    {
        get
        {
			return CoreMatcher.Tick.OnEntityAdded ();
        }
    }

    public void Execute(System.Collections.Generic.List<Entity> entities)
    {
		for (int i = 0; i < entities.Count; i++) {
			var e = entities [i];
			if (e.currentHitPoint.amount < e.hitPoint.amount) {

			}
		}
    }

    public void SetPool(Pool pool)
    {
		_pool = pool;
		_group = _pool.GetGroup(CoreMatcher.CurrentHitPoint);
    }
}
