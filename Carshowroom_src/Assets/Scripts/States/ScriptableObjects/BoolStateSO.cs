using UnityEngine.Events;
using UnityEngine;

/// <summary>
/// This class is used for Events that have one bool argument.
/// </summary>

[CreateAssetMenu(menuName = "States/Bool State")]
public class BoolStateSO : StateBaseSO
{
    public UnityAction<bool> OnEventRaised;

    private bool isOn;
    public bool IsOn
    {
        get { return isOn; }
        set
        {
            if (isOn != value)
                RaiseEvent(isOn);
        }
    }

    public void RaiseEvent(bool value)
    {
        isOn = value;
        OnEventRaised?.Invoke(value);
    }

    public void Change()
    {
        this.RaiseEvent(!IsOn);
    }
}
