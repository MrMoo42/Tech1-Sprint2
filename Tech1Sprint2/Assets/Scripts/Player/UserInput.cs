using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserInput : MonoBehaviour
{
    public static UserInput instance;

    [HideInInspector] public PlayerInputs controls;

    private void Awake()
    {
        if (instance == null) {
            instance = this;
        }

        controls = new PlayerInputs();
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }
}
