using Entitas;

public class ExpUpdateSystem : ISetPool, IExecuteSystem
{
  	Pool _pool;
	Group characters;
    public void SetPool(Pool pool)
    {
		  _pool = pool;
		characters = _pool.GetGroup (Matcher.AllOf (CoreMatcher.Active, CoreMatcher.Character, CoreMatcher.CurrentExp, CoreMatcher.Exp));
    }
    public void Execute()
    {
		foreach (var e in characters.GetEntities()) {
			if (e.currentExp.value >= e.exp.value) {
				var remainExp = e.currentExp.value - e.exp.value;
				e.AddLevelUp (remainExp);
			}
		}
    }
}
