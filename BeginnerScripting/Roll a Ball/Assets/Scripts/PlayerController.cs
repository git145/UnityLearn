using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speedMove;
    public float powerJump;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        float jump = Input.GetAxis("Jump");

        Vector3 movement = new Vector3(speedMove * moveHorizontal, powerJump * jump, speedMove * moveVertical);

        rb.AddForce(movement);
    }
}