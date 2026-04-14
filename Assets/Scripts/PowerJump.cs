using UnityEngine;
using UnityEngine.InputSystem;

public class PowerJump : MonoBehaviour
{
     public InputActionAsset inputActions;
    private Rigidbody _rb;
    [SerializeField]
    private float jumpForce = 10f;
    [SerializeField]
    private float VelocidadMovimiento = 5f;
    private InputAction _jumpAction;
    private InputAction _movementAction;
    private bool _isJumpPressed;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _jumpAction = inputActions.FindActionMap("Player").FindAction("Jump");
        _movementAction = inputActions.FindActionMap("Player").FindAction("Movement");
    }
      private void OnEnable()
    {
        inputActions.FindActionMap("Player").Enable();
    }

    private void OnDisable()
    {
        inputActions.FindActionMap("Player").Disable();
    }

    // Update is called once per frame
    void Update()
    {
        // Detectar salto
        if (_jumpAction.WasPressedThisFrame())
        {
            _isJumpPressed = true;
            _rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            Debug.Log("Jump Pressed");
            
        }
        else if (_jumpAction.WasReleasedThisFrame())
        {
            _isJumpPressed = false;
            Debug.Log("Jump Released");
        }

        // Movimiento con WASD
        if (_movementAction != null)
        {
            Vector2 movement = _movementAction.ReadValue<Vector2>();
            Debug.Log("Movement: " + movement);
            _rb.AddForce(new Vector3(movement.x, 0, movement.y) * VelocidadMovimiento, ForceMode.Force);
        }
    }
}


