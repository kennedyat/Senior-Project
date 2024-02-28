//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/Scripts/Input/PlayerInputActions.inputactions
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

public partial class @PlayerInputActions: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputActions"",
    ""maps"": [
        {
            ""name"": ""Cashier"",
            ""id"": ""f94cfc0a-96e1-40d9-90c8-2b6ae7df6da5"",
            ""actions"": [
                {
                    ""name"": ""Grab"",
                    ""type"": ""Button"",
                    ""id"": ""fc45ae7a-80e2-496b-907c-9a451698e0c8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Selection"",
                    ""type"": ""Button"",
                    ""id"": ""162b85f6-2a78-4caa-adc6-8070564bb830"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Hold"",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Select"",
                    ""type"": ""Button"",
                    ""id"": ""6416db99-c4ca-4b5b-aed8-4be57653bdde"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Tap(duration=0.3)"",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Inclusive"",
                    ""type"": ""Button"",
                    ""id"": ""06f668b1-8613-413c-8573-4a4f893b45ea"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""450941da-72f9-4598-b643-29cf89ffbbb9"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Grab"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""db934035-1b52-454d-a00b-2ba5db9e2d8b"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": ""Hold"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Selection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e30a16ef-a442-464a-96df-2a055f90f626"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": ""Tap(duration=0.3)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""55c7fa0e-7306-4632-ba73-4ba987a18ea3"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Inclusive"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard&Mouse"",
            ""bindingGroup"": ""Keyboard&Mouse"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Gamepad"",
            ""bindingGroup"": ""Gamepad"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Touch"",
            ""bindingGroup"": ""Touch"",
            ""devices"": [
                {
                    ""devicePath"": ""<Touchscreen>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Joystick"",
            ""bindingGroup"": ""Joystick"",
            ""devices"": [
                {
                    ""devicePath"": ""<Joystick>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""XR"",
            ""bindingGroup"": ""XR"",
            ""devices"": [
                {
                    ""devicePath"": ""<XRController>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Cashier
        m_Cashier = asset.FindActionMap("Cashier", throwIfNotFound: true);
        m_Cashier_Grab = m_Cashier.FindAction("Grab", throwIfNotFound: true);
        m_Cashier_Selection = m_Cashier.FindAction("Selection", throwIfNotFound: true);
        m_Cashier_Select = m_Cashier.FindAction("Select", throwIfNotFound: true);
        m_Cashier_Inclusive = m_Cashier.FindAction("Inclusive", throwIfNotFound: true);
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

    // Cashier
    private readonly InputActionMap m_Cashier;
    private List<ICashierActions> m_CashierActionsCallbackInterfaces = new List<ICashierActions>();
    private readonly InputAction m_Cashier_Grab;
    private readonly InputAction m_Cashier_Selection;
    private readonly InputAction m_Cashier_Select;
    private readonly InputAction m_Cashier_Inclusive;
    public struct CashierActions
    {
        private @PlayerInputActions m_Wrapper;
        public CashierActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Grab => m_Wrapper.m_Cashier_Grab;
        public InputAction @Selection => m_Wrapper.m_Cashier_Selection;
        public InputAction @Select => m_Wrapper.m_Cashier_Select;
        public InputAction @Inclusive => m_Wrapper.m_Cashier_Inclusive;
        public InputActionMap Get() { return m_Wrapper.m_Cashier; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CashierActions set) { return set.Get(); }
        public void AddCallbacks(ICashierActions instance)
        {
            if (instance == null || m_Wrapper.m_CashierActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_CashierActionsCallbackInterfaces.Add(instance);
            @Grab.started += instance.OnGrab;
            @Grab.performed += instance.OnGrab;
            @Grab.canceled += instance.OnGrab;
            @Selection.started += instance.OnSelection;
            @Selection.performed += instance.OnSelection;
            @Selection.canceled += instance.OnSelection;
            @Select.started += instance.OnSelect;
            @Select.performed += instance.OnSelect;
            @Select.canceled += instance.OnSelect;
            @Inclusive.started += instance.OnInclusive;
            @Inclusive.performed += instance.OnInclusive;
            @Inclusive.canceled += instance.OnInclusive;
        }

        private void UnregisterCallbacks(ICashierActions instance)
        {
            @Grab.started -= instance.OnGrab;
            @Grab.performed -= instance.OnGrab;
            @Grab.canceled -= instance.OnGrab;
            @Selection.started -= instance.OnSelection;
            @Selection.performed -= instance.OnSelection;
            @Selection.canceled -= instance.OnSelection;
            @Select.started -= instance.OnSelect;
            @Select.performed -= instance.OnSelect;
            @Select.canceled -= instance.OnSelect;
            @Inclusive.started -= instance.OnInclusive;
            @Inclusive.performed -= instance.OnInclusive;
            @Inclusive.canceled -= instance.OnInclusive;
        }

        public void RemoveCallbacks(ICashierActions instance)
        {
            if (m_Wrapper.m_CashierActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(ICashierActions instance)
        {
            foreach (var item in m_Wrapper.m_CashierActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_CashierActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public CashierActions @Cashier => new CashierActions(this);
    private int m_KeyboardMouseSchemeIndex = -1;
    public InputControlScheme KeyboardMouseScheme
    {
        get
        {
            if (m_KeyboardMouseSchemeIndex == -1) m_KeyboardMouseSchemeIndex = asset.FindControlSchemeIndex("Keyboard&Mouse");
            return asset.controlSchemes[m_KeyboardMouseSchemeIndex];
        }
    }
    private int m_GamepadSchemeIndex = -1;
    public InputControlScheme GamepadScheme
    {
        get
        {
            if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
            return asset.controlSchemes[m_GamepadSchemeIndex];
        }
    }
    private int m_TouchSchemeIndex = -1;
    public InputControlScheme TouchScheme
    {
        get
        {
            if (m_TouchSchemeIndex == -1) m_TouchSchemeIndex = asset.FindControlSchemeIndex("Touch");
            return asset.controlSchemes[m_TouchSchemeIndex];
        }
    }
    private int m_JoystickSchemeIndex = -1;
    public InputControlScheme JoystickScheme
    {
        get
        {
            if (m_JoystickSchemeIndex == -1) m_JoystickSchemeIndex = asset.FindControlSchemeIndex("Joystick");
            return asset.controlSchemes[m_JoystickSchemeIndex];
        }
    }
    private int m_XRSchemeIndex = -1;
    public InputControlScheme XRScheme
    {
        get
        {
            if (m_XRSchemeIndex == -1) m_XRSchemeIndex = asset.FindControlSchemeIndex("XR");
            return asset.controlSchemes[m_XRSchemeIndex];
        }
    }
    public interface ICashierActions
    {
        void OnGrab(InputAction.CallbackContext context);
        void OnSelection(InputAction.CallbackContext context);
        void OnSelect(InputAction.CallbackContext context);
        void OnInclusive(InputAction.CallbackContext context);
    }
}
