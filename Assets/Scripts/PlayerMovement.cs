using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController _controller;
    private Vector2 _movementDirection;
    [SerializeField] private GameObject playerCamera;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnEnable()
    {
        _controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    private void Update()
    {
        Vector3 velocity = new Vector3(0, 0, 0);
        Quaternion playerRotation = Quaternion.Euler(0, playerCamera.transform.eulerAngles.y, 0);
        if (_movementDirection != Vector2.zero)
        {
            Debug.Log(playerRotation.eulerAngles.y);
            velocity += playerRotation * Vector3.forward * (_movementDirection.y * 5);
            velocity += playerRotation * Vector3.right * (_movementDirection.x * 5);
        }

        _controller.Move(velocity * Time.deltaTime);
    }

    public void OnMove(InputValue value)
    {
        _movementDirection = value.Get<Vector2>();
    }
}
