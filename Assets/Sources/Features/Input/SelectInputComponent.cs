using Entitas;
using UnityEngine;
using Entitas.CodeGenerator;

[Input, SingleEntity]
public class SelectInputComponent : IComponent {
	public GameObject view;
	public Entity entity;
}
