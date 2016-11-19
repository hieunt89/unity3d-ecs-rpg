using Entitas;
using UnityEngine;
using UnityEngine.UI;
using System.Text;


public class GUISelectedLabel : MonoBehaviour, ISelectInputListener {
	Text mText;

	void Start () {
		mText = GetComponent <Text> ();
		Pools.sharedInstance.input.CreateEntity().AddSelectListener (this);
	}

	public void OnSelected ()
	{
		if (Pools.sharedInstance.input.selectInputEntity.selectInput.entity != null) {
			StringBuilder sb = new StringBuilder ();
			sb.Append("Name ").Append (Pools.sharedInstance.input.selectInputEntity.selectInput.entity.name.value).Append ("\n")
				.Append("Level ").Append (Pools.sharedInstance.input.selectInputEntity.selectInput.entity.currentLevel.value).Append ("\n")
				.Append("Exp ").Append (Pools.sharedInstance.input.selectInputEntity.selectInput.entity.currentExp.value).Append ("/").Append (Pools.sharedInstance.input.selectInputEntity.selectInput.entity.exp.value).Append ("\n")
				.Append("Hp ").Append (Pools.sharedInstance.input.selectInputEntity.selectInput.entity.currentHitPoint.amount).Append ("/").Append (Pools.sharedInstance.input.selectInputEntity.selectInput.entity.hitPoint.amount).Append ("\n")
			;

			mText.text = sb.ToString();
		}
	}
}
