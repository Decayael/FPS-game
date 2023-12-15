using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private Playerinput playerInput;
    public Playerinput .OnFootActions onFoot;
    private playerMotor motor;
    private PlayerLook look;

    // Start is called before the first frame update
    void Awake()
    {
        playerInput = new Playerinput ();
        onFoot = playerInput.onFoot;
        motor = GetComponent<playerMotor>();
        look = GetComponent<PlayerLook>();
        onFoot.Jump.performed += ctx => motor.Jump();
        onFoot.Sprinting.performed += ctx => motor.Sprinting();
        onFoot.Shooting.performed += ctx => motor.Shooting();
        onFoot.Shooting.performed += ctx => motor.SetAimingDirection(look.GetAimingDirection());

    }

    // Update is called once per frame
    void Update()
    {
        //tells the motor to move using values from movement action.
        motor.Processmove(onFoot.Movement.ReadValue<Vector2>());
    }
    private void LateUpdate()
    {
        look.Processlook(onFoot.Look.ReadValue<Vector2>());
    }
    private void OnEnable()
    {
        onFoot.Enable();
    }

    private void OnDisable()
    {
        onFoot.Disable();
    }
}
