using UnityEngine;
using UnityEngine.InputNew;

// GENERATED FILE - DO NOT EDIT MANUALLY
public class MyInputs : ActionMapInput {
	public MyInputs (ActionMap actionMap) : base (actionMap) { }
	
	public ButtonInputControl @leftClick { get { return (ButtonInputControl)this[0]; } }
	public ButtonInputControl @rightClick { get { return (ButtonInputControl)this[1]; } }
	public ButtonInputControl @middleClick { get { return (ButtonInputControl)this[2]; } }
}
