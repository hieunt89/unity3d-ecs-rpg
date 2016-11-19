using Entitas;
using UnityEngine;
public class CharacterInitializeSystem : ISetPool, IInitializeSystem {
	Pool _pool;

	public void SetPool (Pool pool)
	{
		_pool = pool;
	}

	public void Initialize ()
	{
		_pool.CreateEntity ()
			.IsActive (true)
			.IsCharacter(true)
			.AddName ("fdj")
			.AddCurrentLevel (1)
			.AddCurrentExp (50)
			.AddBaseHitPoint (100)
			.IsMovable (true)
			.AddPosition (5f, 0f, 5f)
			.AddDestination (5f, 0f, 5f)
			.AddMoveSpeed (10f)
			.AddTurnSpeed (500f)		
			;
		;
	}
}
