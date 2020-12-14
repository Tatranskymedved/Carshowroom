using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class FloatEvent : UnityEvent<float>
{
}

/// <summary>
/// A flexible handler for float events in the form of a MonoBehaviour.
/// </summary>
public class IntEventListener : MonoBehaviour
{
	[SerializeField] private FloatEventChannelSO _channel = default;

	public FloatEvent OnEventRaised;

	private void OnEnable()
	{
		if (_channel != null)
			_channel.OnEventRaised += Respond;
	}

	private void OnDisable()
	{
		if (_channel != null)
			_channel.OnEventRaised -= Respond;
	}

	private void Respond(float value)
	{
		if (OnEventRaised != null)
			OnEventRaised.Invoke(value);
	}
}
