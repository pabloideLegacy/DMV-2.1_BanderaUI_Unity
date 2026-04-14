using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    //Identificar el action map
    public InputActionAsset inputActions;
    //Elefgimos neustra acción
    private InputAction _jumpAction;
    private bool _isJumpPressed;
    private Rigidbody _rb;
    [SerializeField]
    private float jumpForce = 5f;

    private void OnEnable()
    {
        inputActions.FindActionMap("Player").Enable();
    }

    private void OnDisable()
    {
        inputActions.FindActionMap("Player").Disable();
    }

    private void Awake()
    {
        _jumpAction = inputActions.FindActionMap("Player").FindAction("Jump");
    }

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
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
    }
}
