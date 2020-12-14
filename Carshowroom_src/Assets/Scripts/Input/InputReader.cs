using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "InputReader", menuName = "Game/Input Reader")]
public class InputReader : ScriptableObject, ShowroomInput.IShowroomControlActions
{
    // Gameplay
    public event UnityAction<Vector2> cameraMoveEvent;
    public FloatEventChannelSO cameraZoomEvent;
    public BoolStateSO cameraAutoRotateStateSO;

    private ShowroomInput showroomInput;

    private void OnEnable()
    {
        if (showroomInput == null)
        {
            showroomInput = new ShowroomInput();
            showroomInput.ShowroomControl.SetCallbacks(this);
        }
        EnableBasicInput();
    }

    private void OnDisable()
    {
        DisableAllInput();
    }

    public void OnLook(InputAction.CallbackContext context)
    {
    }

    public void EnableBasicInput()
    {
        showroomInput.Enable();
    }

    public void DisableAllInput()
    {
        showroomInput.Disable();
    }

    public void OnRotate(InputAction.CallbackContext context)
    {
        cameraMoveEvent?.Invoke(context.ReadValue<Vector2>());
    }

    public void OnNewaction(InputAction.CallbackContext context)
    {
    }

    public void OnAutoRotate(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Performed)
        {
            cameraAutoRotateStateSO?.Change();
        }
    }

    public void OnZoom(InputAction.CallbackContext context)
    {
        if(cameraZoomEvent != null && context.phase == InputActionPhase.Performed)
        {
            var vec = context.ReadValue<Vector2>();
            cameraZoomEvent.RaiseEvent(vec.y);
        }
    }
}
