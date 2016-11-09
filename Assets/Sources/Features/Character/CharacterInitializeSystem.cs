using Entitas;

public class CharacterInitializeSystem : ISetPool, IInitializeSystem {
	Pool _pool;

	public void SetPool (Pool pool)
	{
		_pool = pool;
	}

	public void Initialize ()
	{
		_pool.CreateEntity ()
			.IsCharacter(true)
			.AddName ("fdj")
			.AddPosition (1, 0 ,1);
		;
	}
}
