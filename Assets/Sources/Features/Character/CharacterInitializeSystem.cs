using Entitas;

public class CharacterInitializeSystem : ISetPool, IInitializeSystem {
	Pool _pool;
	public void SetPool (Pool pool)
	{
		_pool = pool;
	}

	public void Initialize ()
	{
		_pool.CreateEntity ().AddName ("fdj");
	}
}
