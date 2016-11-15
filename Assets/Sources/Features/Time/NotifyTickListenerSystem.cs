using Entitas;

public class NotifyTickListenersSystem : IReactiveSystem, ISetPool
{
	Pool _pool;
	Group listeners;

	public void Execute(System.Collections.Generic.List<Entity> entities)
	{
		foreach (var entity in listeners.GetEntities()) {
			entity.tickListener.listener.TickChanged();
		}
	}

	public TriggerOnEvent trigger { get { return CoreMatcher.Tick.OnEntityAddedOrRemoved();}}

	public void SetPool(Pool pool){
		_pool = pool;
		listeners = _pool.GetGroup(CoreMatcher.TickListener);
	}
}