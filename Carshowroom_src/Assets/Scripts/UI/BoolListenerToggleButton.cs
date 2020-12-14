using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoolListenerToggleButton : MonoBehaviour
{
	[SerializeField] private BoolStateSO state = default;
	[Tooltip("Should the value be applied to toggle button right after enabling behaviour")]
	[SerializeField] private bool InitChangeOnEnable = true;

	private void OnEnable()
	{
		if (state != null)
		{
			state.OnEventRaised += Respond;
			if(InitChangeOnEnable)
				Respond(state.IsOn);
		}
	}

	private void OnDisable()
	{
		if (state != null)
			state.OnEventRaised -= Respond;
	}

	private void Respond(bool value)
	{
		var tb = this.GetComponent<Toggle>();
		if(tb != null)
			tb.isOn = value;
	}
}
