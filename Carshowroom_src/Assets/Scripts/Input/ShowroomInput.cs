// GENERATED AUTOMATICALLY FROM 'Assets/Settings/Input/ShowroomInput.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @ShowroomInput : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @ShowroomInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""ShowroomInput"",
    ""maps"": [
        {
            ""name"": ""ShowroomControl"",
            ""id"": ""503d0458-b1c4-4696-8be5-634303866c03"",
            ""actions"": [
                {
                    ""name"": ""Rotate"",
                    ""type"": ""Value"",
                    ""id"": ""eda02587-628c-4345-b16d-704ab3ea7b7f"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""New action"",
                    ""type"": ""PassThrough"",
                    ""id"": ""de22bc45-5378-482c-9583-04e44922ee84"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""37497549-b639-4299-9af3-7c47c96de673"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""New action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // ShowroomControl
        m_ShowroomControl = asset.FindActionMap("ShowroomControl", throwIfNotFound: true);
        m_ShowroomControl_Rotate = m_ShowroomControl.FindAction("Rotate", throwIfNotFound: true);
        m_ShowroomControl_Newaction = m_ShowroomControl.FindAction("New action", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // ShowroomControl
    private readonly InputActionMap m_ShowroomControl;
    private IShowroomControlActions m_ShowroomControlActionsCallbackInterface;
    private readonly InputAction m_ShowroomControl_Rotate;
    private readonly InputAction m_ShowroomControl_Newaction;
    public struct ShowroomControlActions
    {
        private @ShowroomInput m_Wrapper;
        public ShowroomControlActions(@ShowroomInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Rotate => m_Wrapper.m_ShowroomControl_Rotate;
        public InputAction @Newaction => m_Wrapper.m_ShowroomControl_Newaction;
        public InputActionMap Get() { return m_Wrapper.m_ShowroomControl; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ShowroomControlActions set) { return set.Get(); }
        public void SetCallbacks(IShowroomControlActions instance)
        {
            if (m_Wrapper.m_ShowroomControlActionsCallbackInterface != null)
            {
                @Rotate.started -= m_Wrapper.m_ShowroomControlActionsCallbackInterface.OnRotate;
                @Rotate.performed -= m_Wrapper.m_ShowroomControlActionsCallbackInterface.OnRotate;
                @Rotate.canceled -= m_Wrapper.m_ShowroomControlActionsCallbackInterface.OnRotate;
                @Newaction.started -= m_Wrapper.m_ShowroomControlActionsCallbackInterface.OnNewaction;
                @Newaction.performed -= m_Wrapper.m_ShowroomControlActionsCallbackInterface.OnNewaction;
                @Newaction.canceled -= m_Wrapper.m_ShowroomControlActionsCallbackInterface.OnNewaction;
            }
            m_Wrapper.m_ShowroomControlActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Rotate.started += instance.OnRotate;
                @Rotate.performed += instance.OnRotate;
                @Rotate.canceled += instance.OnRotate;
                @Newaction.started += instance.OnNewaction;
                @Newaction.performed += instance.OnNewaction;
                @Newaction.canceled += instance.OnNewaction;
            }
        }
    }
    public ShowroomControlActions @ShowroomControl => new ShowroomControlActions(this);
    public interface IShowroomControlActions
    {
        void OnRotate(InputAction.CallbackContext context);
        void OnNewaction(InputAction.CallbackContext context);
    }
}
