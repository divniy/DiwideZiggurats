//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.5.1
//     from Assets/FreeCameraControls.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace Diwide.Ziggurat
{
    public partial class @FreeCameraControls: IInputActionCollection2, IDisposable
    {
        public InputActionAsset asset { get; }
        public @FreeCameraControls()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""FreeCameraControls"",
    ""maps"": [
        {
            ""name"": ""Camera"",
            ""id"": ""7cf83101-75bc-41a7-a399-33a143e0cc5a"",
            ""actions"": [
                {
                    ""name"": ""ActivateRotation"",
                    ""type"": ""Button"",
                    ""id"": ""839a4a2b-1485-4cba-9a75-d63dc3343fde"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Scale"",
                    ""type"": ""Value"",
                    ""id"": ""6fb6c507-70c3-40a6-98a1-13f7acf3fef5"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Rotate"",
                    ""type"": ""Value"",
                    ""id"": ""7c3ad219-c51e-42ff-9f7c-0173ebb18e15"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Select"",
                    ""type"": ""Button"",
                    ""id"": ""c380ef0b-95c4-47f1-aec9-830e8b4a9371"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""22bea389-5aad-459d-a6c7-40ab537aa4d2"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""7a849b98-6edb-4756-a889-db18f1a4dc2d"",
                    ""path"": ""<Keyboard>/ctrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ActivateRotation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4a84291d-c5e6-4fe1-bf13-e71e1131f809"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ActivateRotation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""abe7a821-8dc7-4f41-9aee-873911b7701f"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Scale"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""12b08409-5dd1-4ac3-be3b-b6ff3677a531"",
                    ""path"": ""<Mouse>/scroll/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Scale"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""582d2ec1-7e0f-47b4-92ed-cd42d056012f"",
                    ""path"": ""<Mouse>/scroll/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Scale"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""e6099b0f-4159-4ba9-b874-50ac959ae4ab"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e7960ce6-a028-4413-b161-ed871d48d685"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""7d4ef780-0621-446d-8860-fad3f6fbd92d"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""5e498024-ba01-4fd1-aa0e-85c30e434acd"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""3972ac88-3b09-43be-9dab-c68fb9b70926"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""65d8997d-020e-40ed-b9f5-cba193465549"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""f0fa63b7-e18b-4fb3-9546-9f2553c785fe"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""2D Vector Arrows"",
                    ""id"": ""8c8e19a0-a936-4757-b6ed-b7cee9b83485"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""051d0a02-6968-4dbc-8f34-2c8753cc8bfe"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""90086c64-d739-4136-8b00-bd1bb69ed648"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""c7169441-d160-4100-a1aa-f86a589d6a5b"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""22caf464-2cbe-419b-a4a2-044a785e8304"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
            // Camera
            m_Camera = asset.FindActionMap("Camera", throwIfNotFound: true);
            m_Camera_ActivateRotation = m_Camera.FindAction("ActivateRotation", throwIfNotFound: true);
            m_Camera_Scale = m_Camera.FindAction("Scale", throwIfNotFound: true);
            m_Camera_Rotate = m_Camera.FindAction("Rotate", throwIfNotFound: true);
            m_Camera_Select = m_Camera.FindAction("Select", throwIfNotFound: true);
            m_Camera_Move = m_Camera.FindAction("Move", throwIfNotFound: true);
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

        public IEnumerable<InputBinding> bindings => asset.bindings;

        public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
        {
            return asset.FindAction(actionNameOrId, throwIfNotFound);
        }

        public int FindBinding(InputBinding bindingMask, out InputAction action)
        {
            return asset.FindBinding(bindingMask, out action);
        }

        // Camera
        private readonly InputActionMap m_Camera;
        private List<ICameraActions> m_CameraActionsCallbackInterfaces = new List<ICameraActions>();
        private readonly InputAction m_Camera_ActivateRotation;
        private readonly InputAction m_Camera_Scale;
        private readonly InputAction m_Camera_Rotate;
        private readonly InputAction m_Camera_Select;
        private readonly InputAction m_Camera_Move;
        public struct CameraActions
        {
            private @FreeCameraControls m_Wrapper;
            public CameraActions(@FreeCameraControls wrapper) { m_Wrapper = wrapper; }
            public InputAction @ActivateRotation => m_Wrapper.m_Camera_ActivateRotation;
            public InputAction @Scale => m_Wrapper.m_Camera_Scale;
            public InputAction @Rotate => m_Wrapper.m_Camera_Rotate;
            public InputAction @Select => m_Wrapper.m_Camera_Select;
            public InputAction @Move => m_Wrapper.m_Camera_Move;
            public InputActionMap Get() { return m_Wrapper.m_Camera; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(CameraActions set) { return set.Get(); }
            public void AddCallbacks(ICameraActions instance)
            {
                if (instance == null || m_Wrapper.m_CameraActionsCallbackInterfaces.Contains(instance)) return;
                m_Wrapper.m_CameraActionsCallbackInterfaces.Add(instance);
                @ActivateRotation.started += instance.OnActivateRotation;
                @ActivateRotation.performed += instance.OnActivateRotation;
                @ActivateRotation.canceled += instance.OnActivateRotation;
                @Scale.started += instance.OnScale;
                @Scale.performed += instance.OnScale;
                @Scale.canceled += instance.OnScale;
                @Rotate.started += instance.OnRotate;
                @Rotate.performed += instance.OnRotate;
                @Rotate.canceled += instance.OnRotate;
                @Select.started += instance.OnSelect;
                @Select.performed += instance.OnSelect;
                @Select.canceled += instance.OnSelect;
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
            }

            private void UnregisterCallbacks(ICameraActions instance)
            {
                @ActivateRotation.started -= instance.OnActivateRotation;
                @ActivateRotation.performed -= instance.OnActivateRotation;
                @ActivateRotation.canceled -= instance.OnActivateRotation;
                @Scale.started -= instance.OnScale;
                @Scale.performed -= instance.OnScale;
                @Scale.canceled -= instance.OnScale;
                @Rotate.started -= instance.OnRotate;
                @Rotate.performed -= instance.OnRotate;
                @Rotate.canceled -= instance.OnRotate;
                @Select.started -= instance.OnSelect;
                @Select.performed -= instance.OnSelect;
                @Select.canceled -= instance.OnSelect;
                @Move.started -= instance.OnMove;
                @Move.performed -= instance.OnMove;
                @Move.canceled -= instance.OnMove;
            }

            public void RemoveCallbacks(ICameraActions instance)
            {
                if (m_Wrapper.m_CameraActionsCallbackInterfaces.Remove(instance))
                    UnregisterCallbacks(instance);
            }

            public void SetCallbacks(ICameraActions instance)
            {
                foreach (var item in m_Wrapper.m_CameraActionsCallbackInterfaces)
                    UnregisterCallbacks(item);
                m_Wrapper.m_CameraActionsCallbackInterfaces.Clear();
                AddCallbacks(instance);
            }
        }
        public CameraActions @Camera => new CameraActions(this);
        public interface ICameraActions
        {
            void OnActivateRotation(InputAction.CallbackContext context);
            void OnScale(InputAction.CallbackContext context);
            void OnRotate(InputAction.CallbackContext context);
            void OnSelect(InputAction.CallbackContext context);
            void OnMove(InputAction.CallbackContext context);
        }
    }
}
