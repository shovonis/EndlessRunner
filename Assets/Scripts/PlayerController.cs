using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody _rigidbody;
    private Animator _jumpringAnnAnimation;
    private Vector3 _lastPosition;
    private float lenghtOfPlatform = 7.6f;


    public float Speed;
    public GameObject gamePlatform;
    public Transform firstGround;
    

    void Start()
    {
        _jumpringAnnAnimation = GetComponent<Animator>();
        MovePlayer();
        _lastPosition = firstGround.transform.position;
        InvokeRepeating("SpwaningGround", 0.0f, 0.5f);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _rigidbody.AddForce(0f, 4f, 0f, ForceMode.Impulse);
            _jumpringAnnAnimation.Play("PlayerJumping");
        }
    }

    private void MovePlayer()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.velocity = transform.forward * Speed;
    }

    private void SpwaningGround()
    {
        GameObject grassGround = Instantiate(gamePlatform);
        grassGround.transform.position = _lastPosition + new Vector3(0.0f, 0.0f, lenghtOfPlatform);
        _lastPosition = grassGround.transform.position;

    }
}