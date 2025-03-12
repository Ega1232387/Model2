using UnityEngine;
using UnityEngine.InputSystem;

public class LegacyPlayerMovement : MonoBehaviour
{
    private CharacterController _controller;
    private Vector2 _movementDirection;
    private PlayerInput _playerInput;
    [SerializeField] private GameObject playerCamera;
    private Vector3 _velocity;
    private bool _isJumping;

    private InputAction _movement;

    private void OnEnable()
    {
        _playerInput = GetComponent<PlayerInput>();
        _movement = _playerInput.actions.FindAction("Move");
    }

    // Update is called once per frame
    private void Update()
    {
        _movementDirection = _movement.ReadValue<Vector2>();
        _velocity = Vector3.zero;
        Quaternion playerRotation = Quaternion.Euler(0, playerCamera.transform.eulerAngles.y, 0);
        _velocity += playerRotation * Vector3.forward * (_movementDirection.y * 5);
        _velocity += playerRotation * Vector3.right * (_movementDirection.x * 5);
        transform.Translate(_velocity * Time.deltaTime);
    }
}
