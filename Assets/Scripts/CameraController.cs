using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;
    private Vector3 moveVector;

    private float transition = 0.0f;
    private float annimationDuration = 3.0f;
    private Vector3 annimationOffset = new Vector3(0, 4, 5);


    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    void LateUpdate()
    {
        moveVector = player.transform.position + offset;
        moveVector.x = 0;
        moveVector.y = Mathf.Clamp(moveVector.y, 2, 5);

        if (transition > 1.0f)
        {
            transform.position = moveVector;
        }
        else
        {
            transform.position = Vector3.Lerp(moveVector + annimationOffset, moveVector, transition);
            transition += Time.deltaTime / annimationDuration;
            transform.LookAt(player.transform.position + Vector3.up);
        }
    }
}