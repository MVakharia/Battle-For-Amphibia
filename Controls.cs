//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.5.1
//     from Assets/Controls.inputactions
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

public partial class @Controls: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @Controls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controls"",
    ""maps"": [
        {
            ""name"": ""Keyboard 1"",
            ""id"": ""cd42496d-4073-47db-b02f-43ff4fce663e"",
            ""actions"": [
                {
                    ""name"": ""Up"",
                    ""type"": ""Button"",
                    ""id"": ""3a74adbf-abe3-46b7-827a-e7c7cb49650f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Down"",
                    ""type"": ""Button"",
                    ""id"": ""07e7d7a7-ca3c-4910-8071-ae71b48ea6e0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Left"",
                    ""type"": ""Button"",
                    ""id"": ""7422fcc1-bd6f-4e9e-b521-ecfa95c90b65"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Right"",
                    ""type"": ""Button"",
                    ""id"": ""dfe6f309-d0d8-4a91-920a-778341aae37c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Ability 1"",
                    ""type"": ""Button"",
                    ""id"": ""bdaa854b-f645-45ba-ba18-4ff3aa95b840"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Ability 2"",
                    ""type"": ""Button"",
                    ""id"": ""4ee672b4-d381-4b0b-b7d3-1ea054419e4e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Primary Fire"",
                    ""type"": ""Button"",
                    ""id"": ""49b52b1d-95aa-4972-bf2e-9b7d4008ac81"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Select Prevous Hero"",
                    ""type"": ""Button"",
                    ""id"": ""ce0783c2-c40f-4f72-b1e3-ca0dce916bbe"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Select Next Hero"",
                    ""type"": ""Button"",
                    ""id"": ""d31fcc3e-0125-4d36-8dc3-a8d08aa677d3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""c3505efd-6141-4dec-86c1-7b8296a842c7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""5e9715cc-56f5-44ba-8167-e2965b669366"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Control scheme"",
                    ""action"": ""Up"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fec2336c-af09-48a6-9465-5f5d860ba6fe"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Control scheme"",
                    ""action"": ""Down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""62b5e698-b579-4432-b67e-933e24e72478"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Control scheme"",
                    ""action"": ""Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f0d53bbc-ac84-4cb7-837a-9c1330cb1bf7"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Control scheme"",
                    ""action"": ""Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""49968b28-3847-4454-b7d5-de523d91d591"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Control scheme"",
                    ""action"": ""Select Prevous Hero"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1b081b3d-6b4b-4abf-adc4-1733aad01733"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Control scheme"",
                    ""action"": ""Select Next Hero"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""83b446f8-7fd0-4589-a764-768df59dd7b2"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Control scheme"",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""838a4928-0ccd-46c2-9bab-87759877b83b"",
                    ""path"": ""<Keyboard>/z"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Control scheme"",
                    ""action"": ""Ability 1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cd7b44f5-9b9a-4d43-a941-4d926ec94e5f"",
                    ""path"": ""<Keyboard>/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Control scheme"",
                    ""action"": ""Ability 2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e833a91f-1486-4618-aaa7-18c7830ce9ef"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Control scheme"",
                    ""action"": ""Primary Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Control scheme"",
            ""bindingGroup"": ""Control scheme"",
            ""devices"": []
        }
    ]
}");
        // Keyboard 1
        m_Keyboard1 = asset.FindActionMap("Keyboard 1", throwIfNotFound: true);
        m_Keyboard1_Up = m_Keyboard1.FindAction("Up", throwIfNotFound: true);
        m_Keyboard1_Down = m_Keyboard1.FindAction("Down", throwIfNotFound: true);
        m_Keyboard1_Left = m_Keyboard1.FindAction("Left", throwIfNotFound: true);
        m_Keyboard1_Right = m_Keyboard1.FindAction("Right", throwIfNotFound: true);
        m_Keyboard1_Ability1 = m_Keyboard1.FindAction("Ability 1", throwIfNotFound: true);
        m_Keyboard1_Ability2 = m_Keyboard1.FindAction("Ability 2", throwIfNotFound: true);
        m_Keyboard1_PrimaryFire = m_Keyboard1.FindAction("Primary Fire", throwIfNotFound: true);
        m_Keyboard1_SelectPrevousHero = m_Keyboard1.FindAction("Select Prevous Hero", throwIfNotFound: true);
        m_Keyboard1_SelectNextHero = m_Keyboard1.FindAction("Select Next Hero", throwIfNotFound: true);
        m_Keyboard1_Pause = m_Keyboard1.FindAction("Pause", throwIfNotFound: true);
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

    // Keyboard 1
    private readonly InputActionMap m_Keyboard1;
    private List<IKeyboard1Actions> m_Keyboard1ActionsCallbackInterfaces = new List<IKeyboard1Actions>();
    private readonly InputAction m_Keyboard1_Up;
    private readonly InputAction m_Keyboard1_Down;
    private readonly InputAction m_Keyboard1_Left;
    private readonly InputAction m_Keyboard1_Right;
    private readonly InputAction m_Keyboard1_Ability1;
    private readonly InputAction m_Keyboard1_Ability2;
    private readonly InputAction m_Keyboard1_PrimaryFire;
    private readonly InputAction m_Keyboard1_SelectPrevousHero;
    private readonly InputAction m_Keyboard1_SelectNextHero;
    private readonly InputAction m_Keyboard1_Pause;
    public struct Keyboard1Actions
    {
        private @Controls m_Wrapper;
        public Keyboard1Actions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Up => m_Wrapper.m_Keyboard1_Up;
        public InputAction @Down => m_Wrapper.m_Keyboard1_Down;
        public InputAction @Left => m_Wrapper.m_Keyboard1_Left;
        public InputAction @Right => m_Wrapper.m_Keyboard1_Right;
        public InputAction @Ability1 => m_Wrapper.m_Keyboard1_Ability1;
        public InputAction @Ability2 => m_Wrapper.m_Keyboard1_Ability2;
        public InputAction @PrimaryFire => m_Wrapper.m_Keyboard1_PrimaryFire;
        public InputAction @SelectPrevousHero => m_Wrapper.m_Keyboard1_SelectPrevousHero;
        public InputAction @SelectNextHero => m_Wrapper.m_Keyboard1_SelectNextHero;
        public InputAction @Pause => m_Wrapper.m_Keyboard1_Pause;
        public InputActionMap Get() { return m_Wrapper.m_Keyboard1; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(Keyboard1Actions set) { return set.Get(); }
        public void AddCallbacks(IKeyboard1Actions instance)
        {
            if (instance == null || m_Wrapper.m_Keyboard1ActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_Keyboard1ActionsCallbackInterfaces.Add(instance);
            @Up.started += instance.OnUp;
            @Up.performed += instance.OnUp;
            @Up.canceled += instance.OnUp;
            @Down.started += instance.OnDown;
            @Down.performed += instance.OnDown;
            @Down.canceled += instance.OnDown;
            @Left.started += instance.OnLeft;
            @Left.performed += instance.OnLeft;
            @Left.canceled += instance.OnLeft;
            @Right.started += instance.OnRight;
            @Right.performed += instance.OnRight;
            @Right.canceled += instance.OnRight;
            @Ability1.started += instance.OnAbility1;
            @Ability1.performed += instance.OnAbility1;
            @Ability1.canceled += instance.OnAbility1;
            @Ability2.started += instance.OnAbility2;
            @Ability2.performed += instance.OnAbility2;
            @Ability2.canceled += instance.OnAbility2;
            @PrimaryFire.started += instance.OnPrimaryFire;
            @PrimaryFire.performed += instance.OnPrimaryFire;
            @PrimaryFire.canceled += instance.OnPrimaryFire;
            @SelectPrevousHero.started += instance.OnSelectPrevousHero;
            @SelectPrevousHero.performed += instance.OnSelectPrevousHero;
            @SelectPrevousHero.canceled += instance.OnSelectPrevousHero;
            @SelectNextHero.started += instance.OnSelectNextHero;
            @SelectNextHero.performed += instance.OnSelectNextHero;
            @SelectNextHero.canceled += instance.OnSelectNextHero;
            @Pause.started += instance.OnPause;
            @Pause.performed += instance.OnPause;
            @Pause.canceled += instance.OnPause;
        }

        private void UnregisterCallbacks(IKeyboard1Actions instance)
        {
            @Up.started -= instance.OnUp;
            @Up.performed -= instance.OnUp;
            @Up.canceled -= instance.OnUp;
            @Down.started -= instance.OnDown;
            @Down.performed -= instance.OnDown;
            @Down.canceled -= instance.OnDown;
            @Left.started -= instance.OnLeft;
            @Left.performed -= instance.OnLeft;
            @Left.canceled -= instance.OnLeft;
            @Right.started -= instance.OnRight;
            @Right.performed -= instance.OnRight;
            @Right.canceled -= instance.OnRight;
            @Ability1.started -= instance.OnAbility1;
            @Ability1.performed -= instance.OnAbility1;
            @Ability1.canceled -= instance.OnAbility1;
            @Ability2.started -= instance.OnAbility2;
            @Ability2.performed -= instance.OnAbility2;
            @Ability2.canceled -= instance.OnAbility2;
            @PrimaryFire.started -= instance.OnPrimaryFire;
            @PrimaryFire.performed -= instance.OnPrimaryFire;
            @PrimaryFire.canceled -= instance.OnPrimaryFire;
            @SelectPrevousHero.started -= instance.OnSelectPrevousHero;
            @SelectPrevousHero.performed -= instance.OnSelectPrevousHero;
            @SelectPrevousHero.canceled -= instance.OnSelectPrevousHero;
            @SelectNextHero.started -= instance.OnSelectNextHero;
            @SelectNextHero.performed -= instance.OnSelectNextHero;
            @SelectNextHero.canceled -= instance.OnSelectNextHero;
            @Pause.started -= instance.OnPause;
            @Pause.performed -= instance.OnPause;
            @Pause.canceled -= instance.OnPause;
        }

        public void RemoveCallbacks(IKeyboard1Actions instance)
        {
            if (m_Wrapper.m_Keyboard1ActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IKeyboard1Actions instance)
        {
            foreach (var item in m_Wrapper.m_Keyboard1ActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_Keyboard1ActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public Keyboard1Actions @Keyboard1 => new Keyboard1Actions(this);
    private int m_ControlschemeSchemeIndex = -1;
    public InputControlScheme ControlschemeScheme
    {
        get
        {
            if (m_ControlschemeSchemeIndex == -1) m_ControlschemeSchemeIndex = asset.FindControlSchemeIndex("Control scheme");
            return asset.controlSchemes[m_ControlschemeSchemeIndex];
        }
    }
    public interface IKeyboard1Actions
    {
        void OnUp(InputAction.CallbackContext context);
        void OnDown(InputAction.CallbackContext context);
        void OnLeft(InputAction.CallbackContext context);
        void OnRight(InputAction.CallbackContext context);
        void OnAbility1(InputAction.CallbackContext context);
        void OnAbility2(InputAction.CallbackContext context);
        void OnPrimaryFire(InputAction.CallbackContext context);
        void OnSelectPrevousHero(InputAction.CallbackContext context);
        void OnSelectNextHero(InputAction.CallbackContext context);
        void OnPause(InputAction.CallbackContext context);
    }
}
