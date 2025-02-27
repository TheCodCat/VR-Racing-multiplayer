using Assets.Scripts.Race;
using Fusion;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : NetworkBehaviour
{
    [SerializeField] private float currentTorque;
    [SerializeField] private float currentBrake;
    [SerializeField] private float currentAngle;
    [Header("Параметры")]
    [SerializeField] private Animator animator;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private float torque;
    [SerializeField] private float brake;
    [SerializeField] private float maxAngle;
    [SerializeField] private WheelCollider wheelColliderRight;
    [SerializeField] private WheelCollider wheelColliderLeft;
    [SerializeField] private RaceState raceState;
    [SerializeField] private bool move = false;
    [SerializeField] private bool nitro = true;
    private void OnEnable()
    {
        RaceController.ChangeState += GetRaceState;
    }
    private void OnDisable()
    {
        RaceController.ChangeState -= GetRaceState;
    }
    public void GetRaceState(RaceState raceState)
    {
        this.raceState = raceState;
    }
    public override void FixedUpdateNetwork()
    {
        if (raceState != RaceState.Race) return;

        wheelColliderRight.motorTorque = raceState == RaceState.Race ? currentTorque : 0;
        wheelColliderLeft.motorTorque = raceState == RaceState.Race ? currentTorque : 0;

        wheelColliderRight.brakeTorque = raceState == RaceState.Race ? currentBrake : brake;
        wheelColliderLeft.brakeTorque = currentBrake;

        wheelColliderRight.steerAngle = currentAngle;
        wheelColliderLeft.steerAngle = currentAngle;
    }
    public void GetRotation(InputAction.CallbackContext callbackContext)//получение поварота
    {
        currentAngle = callbackContext.ReadValue<Vector2>().x * maxAngle;
        animator.SetFloat("Blend", callbackContext.ReadValue<Vector2>().x);
    }
    public void Gas(InputAction.CallbackContext callbackContext)//газ
    {
        if(callbackContext.ReadValue<float>() >= 0.1)
        currentTorque = torque * callbackContext.ReadValue<float>();
    }
    public void Brake(InputAction.CallbackContext callbackContext)//тормоз
    {
        currentBrake = callbackContext.ReadValueAsButton() == true ? brake : 0;
    }
    public void Clutch(InputAction.CallbackContext callbackContext)//смена направления движения
    {
        if (callbackContext.performed)
        {
            torque *= -1;
        }
    }
    public void Nitro(InputAction.CallbackContext callbackContext)//запуск нитро
    {
        if (callbackContext.performed)
            StartCoroutine(NitroCor());
    }
    private IEnumerator NitroCor()//нитро
    {
        if (nitro)
        {
            nitro = false;
            float temp = torque;
            torque *= 1.5f;
            yield return new WaitForSeconds(2f);
            torque = temp;
            yield return new WaitForSeconds(10f);
            nitro = true;
        }
    }
}
