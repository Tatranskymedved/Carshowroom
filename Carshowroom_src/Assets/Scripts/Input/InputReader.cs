using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "InputReader", menuName = "Game/Input Reader")]
public class InputReader : ScriptableObject//,  ShowroomInput.I
{
    // Gameplay
    public event UnityAction<Vector2> moveEvent;
    public event UnityAction<Vector2> cameraMoveEvent;
    public event UnityAction pauseEvent;
    public event UnityAction interactEvent;

    // Menu & Dialogue
    public event UnityAction onMoveSelectionEvent = delegate { };
    public event UnityAction onConfirmSelectionEvent = delegate { };
    public event UnityAction onCancelSelectionEvent = delegate { };

    //private GameInput gameInput;

    private void OnEnable()
    {
        //if (gameInput == null)
        //{
        //    gameInput = new GameInput();
        //    gameInput.Gameplay.SetCallbacks(this);
        //    gameInput.Dialogue.SetCallbacks(this);
        //    gameInput.Menu.SetCallbacks(this);
        //}
        EnableBasicInput();
    }

    private void OnDisable()
    {
        DisableAllInput();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveEvent?.Invoke(context.ReadValue<Vector2>());
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        cameraMoveEvent?.Invoke(context.ReadValue<Vector2>());
    }

    public void OnPause(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
            pauseEvent?.Invoke();
    }

    public void OnMoveSelection(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
            onMoveSelectionEvent?.Invoke();
    }

    public void OnConfirm(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
            onConfirmSelectionEvent?.Invoke();
    }

    public void OnCancel(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
            onCancelSelectionEvent?.Invoke();
    }

    public void EnableBasicInput()
    {
        //gameInput.Basic.Disable();
    }

    public void DisableAllInput()
    {
        //gameInput.Basic.Disable();
    }
}
