using Entitas;
using Entitas.CodeGenerator;

[Input, SingleEntity]
public sealed class MoveInputComponent : IComponent {
    public float x;
	public float y;
	public float z;

}
