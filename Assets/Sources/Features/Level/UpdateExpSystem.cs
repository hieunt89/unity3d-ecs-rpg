using Entitas;

public class UpdateExpSystem : ISetPool, IExecuteSystem
{
	  Pool _pool;
    public void SetPool(Pool pool)
    {
		  _pool = pool;
    }
    public void Execute()
    {
	  	var characterEntity = _pool.characterEntity;
      if (characterEntity.currentExp.value >= characterEntity.exp.value) {
        var remainExp = characterEntity.currentExp.value - characterEntity.exp.value;
        characterEntity.AddLevelUp (remainExp);
      }
    }
}
