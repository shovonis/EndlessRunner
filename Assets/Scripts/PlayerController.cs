using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;

    private CharacterController _characterController;
    private Vector3 _playerMovement;
    private float _verticalVelocity;
    private float gravity = 12.0f;
    private float annimationDuration = 3.0f;


    void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if (Time.time < annimationDuration)
        {
            _characterController.Move(Vector3.forward * speed * Time.deltaTime);
        }
        else
        {
            _playerMovement = Vector3.zero; // Refreshing every time

            if (_characterController.isGrounded)
            {
                _verticalVelocity = -gravity;
            }
            else
            {
                _verticalVelocity -= gravity * Time.deltaTime;
            }

            _playerMovement.x = Input.GetAxisRaw("Horizontal") * speed;
            _playerMovement.y = _verticalVelocity;
            _playerMovement.z = speed;

            _characterController.Move(_playerMovement * Time.deltaTime);
        }
    }

    public void SetPlayerSpeed(int delta)
    {
        speed = speed + delta;
    }
}