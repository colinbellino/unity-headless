// GENERATED AUTOMATICALLY FROM 'Assets/Game/Inputs/PlayerActions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace Greed.Core
{
    public class @PlayerActions : IInputActionCollection, IDisposable
    {
        private InputActionAsset asset;
        public @PlayerActions()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerActions"",
    ""maps"": [
        {
            ""name"": ""Default"",
            ""id"": ""45e3b5e3-c3f6-4d74-9fe4-846a73f889a2"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Button"",
                    ""id"": ""3d1ea2ab-4d16-48a7-9f83-578e1db4e826"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""39815b1c-0b97-4725-a8fd-002a939e2b27"",
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
                    ""id"": ""c65dd253-3f2f-4281-aadc-ed72c0a39f8f"",
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
                    ""id"": ""a0fb1678-eb0c-4a03-a938-c2b87b12fed6"",
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
                    ""id"": ""42895834-57bc-477e-800d-6dea3698b4de"",
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
                    ""id"": ""0855ff64-b878-4f44-94fe-e31bea40a30e"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""74ce0fe5-0705-4bc9-96c6-1a123def0d7e"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Title Screen"",
            ""id"": ""e8acfae6-54aa-4bc4-a647-6fa12e19c1d0"",
            ""actions"": [
                {
                    ""name"": ""Start"",
                    ""type"": ""Button"",
                    ""id"": ""dd408607-f2c7-49bf-94a5-35389685dc86"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""529f5ae1-6d3e-45ca-82ce-dc7b1ff641a9"",
                    ""path"": ""<Keyboard>/anyKey"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Start"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3ec85d1c-a7a8-442a-9b0c-64dd5df1e585"",
                    ""path"": ""<Gamepad>/<Button>"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Start"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
            // Default
            m_Default = asset.FindActionMap("Default", throwIfNotFound: true);
            m_Default_Move = m_Default.FindAction("Move", throwIfNotFound: true);
            // Title Screen
            m_TitleScreen = asset.FindActionMap("Title Screen", throwIfNotFound: true);
            m_TitleScreen_Start = m_TitleScreen.FindAction("Start", throwIfNotFound: true);
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

        // Default
        private readonly InputActionMap m_Default;
        private IDefaultActions m_DefaultActionsCallbackInterface;
        private readonly InputAction m_Default_Move;
        public struct DefaultActions
        {
            private @PlayerActions m_Wrapper;
            public DefaultActions(@PlayerActions wrapper) { m_Wrapper = wrapper; }
            public InputAction @Move => m_Wrapper.m_Default_Move;
            public InputActionMap Get() { return m_Wrapper.m_Default; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(DefaultActions set) { return set.Get(); }
            public void SetCallbacks(IDefaultActions instance)
            {
                if (m_Wrapper.m_DefaultActionsCallbackInterface != null)
                {
                    @Move.started -= m_Wrapper.m_DefaultActionsCallbackInterface.OnMove;
                    @Move.performed -= m_Wrapper.m_DefaultActionsCallbackInterface.OnMove;
                    @Move.canceled -= m_Wrapper.m_DefaultActionsCallbackInterface.OnMove;
                }
                m_Wrapper.m_DefaultActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Move.started += instance.OnMove;
                    @Move.performed += instance.OnMove;
                    @Move.canceled += instance.OnMove;
                }
            }
        }
        public DefaultActions @Default => new DefaultActions(this);

        // Title Screen
        private readonly InputActionMap m_TitleScreen;
        private ITitleScreenActions m_TitleScreenActionsCallbackInterface;
        private readonly InputAction m_TitleScreen_Start;
        public struct TitleScreenActions
        {
            private @PlayerActions m_Wrapper;
            public TitleScreenActions(@PlayerActions wrapper) { m_Wrapper = wrapper; }
            public InputAction @Start => m_Wrapper.m_TitleScreen_Start;
            public InputActionMap Get() { return m_Wrapper.m_TitleScreen; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(TitleScreenActions set) { return set.Get(); }
            public void SetCallbacks(ITitleScreenActions instance)
            {
                if (m_Wrapper.m_TitleScreenActionsCallbackInterface != null)
                {
                    @Start.started -= m_Wrapper.m_TitleScreenActionsCallbackInterface.OnStart;
                    @Start.performed -= m_Wrapper.m_TitleScreenActionsCallbackInterface.OnStart;
                    @Start.canceled -= m_Wrapper.m_TitleScreenActionsCallbackInterface.OnStart;
                }
                m_Wrapper.m_TitleScreenActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Start.started += instance.OnStart;
                    @Start.performed += instance.OnStart;
                    @Start.canceled += instance.OnStart;
                }
            }
        }
        public TitleScreenActions @TitleScreen => new TitleScreenActions(this);
        public interface IDefaultActions
        {
            void OnMove(InputAction.CallbackContext context);
        }
        public interface ITitleScreenActions
        {
            void OnStart(InputAction.CallbackContext context);
        }
    }
}
