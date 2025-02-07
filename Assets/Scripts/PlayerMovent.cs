using UnityEngine;

public class PlayerMovent : MonoBehaviour
{
    public float speed = 5f;  // Velocidad del personaje
    public float jumpForce = 7f;  // Fuerza del salto
    public LayerMask groundLayer; // Capa del suelo

    private Vector3 moveDirection;
    private Rigidbody rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Movimiento del personaje
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        moveDirection = new Vector3(moveX, 0, moveZ).normalized;
        transform.position += moveDirection * speed * Time.deltaTime;

        // Girar el personaje en la dirección del movimiento
        if (moveDirection != Vector3.zero)
        {
            transform.forward = moveDirection;
        }

        // Comprobar si está en el suelo
        isGrounded = Physics.Raycast(transform.position, Vector3.down, 1.1f, groundLayer);

        // Saltar cuando se presiona espacio y esté en el suelo
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}
