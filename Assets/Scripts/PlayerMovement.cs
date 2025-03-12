using System;
using System.Collections;
using System.Collections.Generic;
using KinematicCharacterController;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour, ICharacterController
{
    public KinematicCharacterMotor Motor;
    private PlayerInput _playerInput;
    private InputAction movementAction;
    private Vector2 moveInput;
    [SerializeField] private GameObject playerCamera;
    // Start is called before the first frame update
    void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
        movementAction = _playerInput.actions.FindAction("Move");
        Motor.CharacterController = this;
    }

    private void OnEnable()
    {
        movementAction.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        moveInput = movementAction.ReadValue<Vector2>();
        Debug.Log(moveInput);
    }

    public void UpdateVelocity(ref Vector3 currentVelocity, float deltaTime)
    {
        Quaternion playerRotation = Quaternion.Euler(0, playerCamera.transform.eulerAngles.y, 0);
        Vector3 forward = playerRotation * Vector3.forward;
        Vector3 right = playerRotation * Vector3.right;
        if(Motor.GroundingStatus.IsStableOnGround) currentVelocity = ((forward * moveInput.y) + (right * moveInput.x)) * 10f;
        else
        {
            currentVelocity += Vector3.down * (9.8f * deltaTime);
            currentVelocity += ((forward * moveInput.y) + (right * moveInput.x))  * (10f * deltaTime);
        }
    }

    public void UpdateRotation(ref Quaternion currentRotation, float deltaTime)
    {
        currentRotation = new Quaternion(0, 0, 0, 0);
        //Debug.Log("UpdateRotation");
        //throw new NotImplementedException();
    }

    public void BeforeCharacterUpdate(float deltaTime)
    {
        Debug.Log("BeforeCharacterUpdate");
    }

    public void AfterCharacterUpdate(float deltaTime)
    {
        Debug.Log("AfterCharacterUpdate");
    }

    public void PostGroundingUpdate(float deltaTime)
    {
        Debug.Log("PostGroundingUpdate");
    }

    public bool IsColliderValidForCollisions(Collider collide)
    {
        Debug.Log("IsColliderValidForCollisions");
        return true;
    }

    public void OnGroundHit(Collider hitCollider, Vector3 hitNormal, Vector3 hitPoint, ref HitStabilityReport hitStabilityReport)
    {
        Debug.Log("OnGroundHit");
    }

    public void OnMovementHit(Collider hitCollider, Vector3 hitNormal, Vector3 hitPoint, ref HitStabilityReport hitStabilityReport)
    {
        Debug.Log("OnMovementHit");
    }

    public void ProcessHitStabilityReport(Collider hitCollider, Vector3 hitNormal, Vector3 hitPoint, Vector3 atCharacterPosition, Quaternion atCharacterRotation, ref HitStabilityReport hitStabilityReport)
    {
        Debug.Log("ProcessHitStabilityReport");
    }

    public void OnDiscreteCollisionDetected(Collider hitCollider)
    {
        Debug.Log("OnDiscreteCollisionDetected");
    }
}
