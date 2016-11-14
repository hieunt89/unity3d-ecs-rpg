using Entitas;
using UnityEngine;

public class TimeSystem : ISetPool, IInitializeSystem, IExecuteSystem
{
	Pool _pool;
    public void SetPool(Pool pool)
    {
			_pool =	pool;
    }
 
  	public void Execute ()
		{
				if(!_pool.isPause) {
						var secondEntity = _pool.secondEntity;
						secondEntity.ReplaceSecond (Time.time);
				}
		}

    public void Initialize()
    {
		_pool.SetSecond(0f)
		.AddTimeScale(1f)
		;
    }
}
