using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;

    private CharacterController _characterController;
    private Animator _jumpringAnnAnimation;
    
    private Vector3 _playerMovement;
    private float _verticalVelocity;
    private float gravity = 12.0f;
    private float annimationDuration = 3.0f;

    private bool isPlayerDead = false;
    private float startTime;


    void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _jumpringAnnAnimation = GetComponent<Animator>();
        startTime = Time.time;
    }

    private void Update()
    {
        if (isPlayerDead)
        {
            return;
        }
        
        if (Time.time - startTime< annimationDuration)
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
        
        if (Input.GetKeyDown("space"))
        {
            _jumpringAnnAnimation.Play("PlayerJumping");
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.collider.tag.Equals("DEAD"))
        {
            isPlayerDead = true;
            GetComponent<ScoreManager>().haltScore();
        }
        
    }

    public void SetPlayerSpeed(int delta)
    {
        speed = speed + delta;
    }
}