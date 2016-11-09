using Entitas;
using System.Collections.Generic;

public class NotifyPauseListenerSystem : ISetPool, IReactiveSystem {
	Group listeners;

	public void SetPool (Pool pool)
	{
		listeners = pool.GetGroup (Matcher.PauseListener);
	}

	public TriggerOnEvent trigger {
		get {
			return Matcher.Pause.OnEntityAddedOrRemoved ();
		}
	}

	public void Execute (List<Entity> entities)
	{
		var e = Pools.sharedInstance.pool.tickEntity;
		if (!e.isPause)
			e.ReplaceSpeed (0f);
		else 
			e.ReplaceSpeed (1f);

	}

}
