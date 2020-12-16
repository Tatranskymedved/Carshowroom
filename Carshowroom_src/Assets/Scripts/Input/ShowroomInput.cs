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
                    ""name"": ""AutoRotate"",
                    ""type"": ""Button"",
                    ""id"": ""93804045-6042-4e93-a1a2-e48f197deae1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Zoom"",
                    ""type"": ""Value"",
                    ""id"": ""26a61c15-5ef8-472a-a2ea-dd4eb9ebf8cd"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""OnLeftDoorOpen"",
                    ""type"": ""Button"",
                    ""id"": ""7a828884-4ccf-45df-a52d-d729e9f6600f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""8ccdffea-9412-4442-ac87-c9a25def27c7"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AutoRotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""151f187a-901a-482d-9ba9-19cca9edb8e4"",
                    ""path"": ""<Mouse>/scroll"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Zoom"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6374a222-c687-49fb-a19f-cae7cc9af93c"",
                    ""path"": ""<Keyboard>/l"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""OnLeftDoorOpen"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""60114079-9f5e-4619-8095-08e176e1677f"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""down"",
                    ""id"": ""e0854a19-3eac-4101-abb8-72bd12fb4f55"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""up"",
                    ""id"": ""0a904169-8c0d-46d6-92e3-8ade7cb83cec"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""ed105820-0d0f-47da-8a78-aad959e7d657"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""e1695bcf-f9bb-4a3a-9e6e-d6fd49c8bc3f"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""29f30e5d-b3b4-4488-958b-ce2dd1f3ace1"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""down"",
                    ""id"": ""451f3cc9-f38b-4847-83cc-142f39ab945f"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""up"",
                    ""id"": ""178d1ce1-a52e-4e43-a50c-cff447535c53"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""06031d9c-af40-4848-91c7-56311b954acb"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""04f07107-7d9f-4dd8-a58b-98fbfaf909be"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // ShowroomControl
        m_ShowroomControl = asset.FindActionMap("ShowroomControl", throwIfNotFound: true);
        m_ShowroomControl_Rotate = m_ShowroomControl.FindAction("Rotate", throwIfNotFound: true);
        m_ShowroomControl_AutoRotate = m_ShowroomControl.FindAction("AutoRotate", throwIfNotFound: true);
        m_ShowroomControl_Zoom = m_ShowroomControl.FindAction("Zoom", throwIfNotFound: true);
        m_ShowroomControl_OnLeftDoorOpen = m_ShowroomControl.FindAction("OnLeftDoorOpen", throwIfNotFound: true);
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
    private readonly InputAction m_ShowroomControl_AutoRotate;
    private readonly InputAction m_ShowroomControl_Zoom;
    private readonly InputAction m_ShowroomControl_OnLeftDoorOpen;
    public struct ShowroomControlActions
    {
        private @ShowroomInput m_Wrapper;
        public ShowroomControlActions(@ShowroomInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Rotate => m_Wrapper.m_ShowroomControl_Rotate;
        public InputAction @AutoRotate => m_Wrapper.m_ShowroomControl_AutoRotate;
        public InputAction @Zoom => m_Wrapper.m_ShowroomControl_Zoom;
        public InputAction @OnLeftDoorOpen => m_Wrapper.m_ShowroomControl_OnLeftDoorOpen;
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
                @AutoRotate.started -= m_Wrapper.m_ShowroomControlActionsCallbackInterface.OnAutoRotate;
                @AutoRotate.performed -= m_Wrapper.m_ShowroomControlActionsCallbackInterface.OnAutoRotate;
                @AutoRotate.canceled -= m_Wrapper.m_ShowroomControlActionsCallbackInterface.OnAutoRotate;
                @Zoom.started -= m_Wrapper.m_ShowroomControlActionsCallbackInterface.OnZoom;
                @Zoom.performed -= m_Wrapper.m_ShowroomControlActionsCallbackInterface.OnZoom;
                @Zoom.canceled -= m_Wrapper.m_ShowroomControlActionsCallbackInterface.OnZoom;
                @OnLeftDoorOpen.started -= m_Wrapper.m_ShowroomControlActionsCallbackInterface.OnOnLeftDoorOpen;
                @OnLeftDoorOpen.performed -= m_Wrapper.m_ShowroomControlActionsCallbackInterface.OnOnLeftDoorOpen;
                @OnLeftDoorOpen.canceled -= m_Wrapper.m_ShowroomControlActionsCallbackInterface.OnOnLeftDoorOpen;
            }
            m_Wrapper.m_ShowroomControlActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Rotate.started += instance.OnRotate;
                @Rotate.performed += instance.OnRotate;
                @Rotate.canceled += instance.OnRotate;
                @AutoRotate.started += instance.OnAutoRotate;
                @AutoRotate.performed += instance.OnAutoRotate;
                @AutoRotate.canceled += instance.OnAutoRotate;
                @Zoom.started += instance.OnZoom;
                @Zoom.performed += instance.OnZoom;
                @Zoom.canceled += instance.OnZoom;
                @OnLeftDoorOpen.started += instance.OnOnLeftDoorOpen;
                @OnLeftDoorOpen.performed += instance.OnOnLeftDoorOpen;
                @OnLeftDoorOpen.canceled += instance.OnOnLeftDoorOpen;
            }
        }
    }
    public ShowroomControlActions @ShowroomControl => new ShowroomControlActions(this);
    public interface IShowroomControlActions
    {
        void OnRotate(InputAction.CallbackContext context);
        void OnAutoRotate(InputAction.CallbackContext context);
        void OnZoom(InputAction.CallbackContext context);
        void OnOnLeftDoorOpen(InputAction.CallbackContext context);
    }
}
