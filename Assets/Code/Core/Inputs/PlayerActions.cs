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
                    ""type"": ""Value"",
                    ""id"": ""3d1ea2ab-4d16-48a7-9f83-578e1db4e826"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""1762f729-0049-40e7-81cd-57ad0d8b0483"",
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
                },
                {
                    ""name"": """",
                    ""id"": ""c0c24b0a-da80-4fb0-9269-2fd697c2c82f"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3b55a717-fa50-4672-b70a-292b058d9fc7"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
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
        },
        {
            ""name"": ""Debug"",
            ""id"": ""3ce704b6-3898-4d03-a17f-292d864e4d0f"",
            ""actions"": [
                {
                    ""name"": ""ToggleMenu"",
                    ""type"": ""Button"",
                    ""id"": ""900045d0-1fe8-434a-ae87-aea0f80ac9c3"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Debug1"",
                    ""type"": ""Button"",
                    ""id"": ""d7cf5f9a-1fc9-420a-b37b-e09522dc8698"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""4c1eb45a-42a1-4d00-8677-7b22d46f76ef"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ToggleMenu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ad1c17f3-4e54-4485-9b33-70d7a44b0241"",
                    ""path"": ""<Gamepad>/select"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ToggleMenu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9c93887f-3b61-44be-b734-23f57167ed3d"",
                    ""path"": ""<Keyboard>/f1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Debug1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d72ed445-1cca-4948-b42b-237d439ce440"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Debug1"",
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
            m_Default_Interact = m_Default.FindAction("Interact", throwIfNotFound: true);
            // Title Screen
            m_TitleScreen = asset.FindActionMap("Title Screen", throwIfNotFound: true);
            m_TitleScreen_Start = m_TitleScreen.FindAction("Start", throwIfNotFound: true);
            // Debug
            m_Debug = asset.FindActionMap("Debug", throwIfNotFound: true);
            m_Debug_ToggleMenu = m_Debug.FindAction("ToggleMenu", throwIfNotFound: true);
            m_Debug_Debug1 = m_Debug.FindAction("Debug1", throwIfNotFound: true);
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
        private readonly InputAction m_Default_Interact;
        public struct DefaultActions
        {
            private @PlayerActions m_Wrapper;
            public DefaultActions(@PlayerActions wrapper) { m_Wrapper = wrapper; }
            public InputAction @Move => m_Wrapper.m_Default_Move;
            public InputAction @Interact => m_Wrapper.m_Default_Interact;
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
                    @Interact.started -= m_Wrapper.m_DefaultActionsCallbackInterface.OnInteract;
                    @Interact.performed -= m_Wrapper.m_DefaultActionsCallbackInterface.OnInteract;
                    @Interact.canceled -= m_Wrapper.m_DefaultActionsCallbackInterface.OnInteract;
                }
                m_Wrapper.m_DefaultActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Move.started += instance.OnMove;
                    @Move.performed += instance.OnMove;
                    @Move.canceled += instance.OnMove;
                    @Interact.started += instance.OnInteract;
                    @Interact.performed += instance.OnInteract;
                    @Interact.canceled += instance.OnInteract;
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

        // Debug
        private readonly InputActionMap m_Debug;
        private IDebugActions m_DebugActionsCallbackInterface;
        private readonly InputAction m_Debug_ToggleMenu;
        private readonly InputAction m_Debug_Debug1;
        public struct DebugActions
        {
            private @PlayerActions m_Wrapper;
            public DebugActions(@PlayerActions wrapper) { m_Wrapper = wrapper; }
            public InputAction @ToggleMenu => m_Wrapper.m_Debug_ToggleMenu;
            public InputAction @Debug1 => m_Wrapper.m_Debug_Debug1;
            public InputActionMap Get() { return m_Wrapper.m_Debug; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(DebugActions set) { return set.Get(); }
            public void SetCallbacks(IDebugActions instance)
            {
                if (m_Wrapper.m_DebugActionsCallbackInterface != null)
                {
                    @ToggleMenu.started -= m_Wrapper.m_DebugActionsCallbackInterface.OnToggleMenu;
                    @ToggleMenu.performed -= m_Wrapper.m_DebugActionsCallbackInterface.OnToggleMenu;
                    @ToggleMenu.canceled -= m_Wrapper.m_DebugActionsCallbackInterface.OnToggleMenu;
                    @Debug1.started -= m_Wrapper.m_DebugActionsCallbackInterface.OnDebug1;
                    @Debug1.performed -= m_Wrapper.m_DebugActionsCallbackInterface.OnDebug1;
                    @Debug1.canceled -= m_Wrapper.m_DebugActionsCallbackInterface.OnDebug1;
                }
                m_Wrapper.m_DebugActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @ToggleMenu.started += instance.OnToggleMenu;
                    @ToggleMenu.performed += instance.OnToggleMenu;
                    @ToggleMenu.canceled += instance.OnToggleMenu;
                    @Debug1.started += instance.OnDebug1;
                    @Debug1.performed += instance.OnDebug1;
                    @Debug1.canceled += instance.OnDebug1;
                }
            }
        }
        public DebugActions @Debug => new DebugActions(this);
        public interface IDefaultActions
        {
            void OnMove(InputAction.CallbackContext context);
            void OnInteract(InputAction.CallbackContext context);
        }
        public interface ITitleScreenActions
        {
            void OnStart(InputAction.CallbackContext context);
        }
        public interface IDebugActions
        {
            void OnToggleMenu(InputAction.CallbackContext context);
            void OnDebug1(InputAction.CallbackContext context);
        }
    }
}
