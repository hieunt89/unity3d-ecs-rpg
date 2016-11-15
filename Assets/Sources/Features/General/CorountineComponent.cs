using System.Collections;
using Entitas;

[Core]
public class CorountineComponent : IComponent {
	public IEnumerator task;
}
