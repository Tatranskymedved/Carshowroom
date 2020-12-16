using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// This class is used for Events that have one Vector2 argument
/// </summary>
[CreateAssetMenu(menuName = "Events/Vector2 Event Channel")]
public class Vector2EventChannelSO : EventChannelBaseSO
{
	public UnityAction<Vector2> OnEventRaised;
	public void RaiseEvent(Vector2 value)
	{
		OnEventRaised.Invoke(value);
	}
}