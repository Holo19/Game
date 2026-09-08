using UnityEngine;

public class Move : MonoBehaviour
{
    private Rigidbody _rigidBody;

    [SerializeField] private float _force;
    [SerializeField] private float _jumpForce;

    private float _deadZone = 0.02f;
    private float _xInput;

    private Vector3 _direction;

    private bool _isGrounded = false;
    private bool _canJump = false;

    private string _horizontalAxisName = "Horizontal";

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }
    void Update()
    {
        _xInput = Input.GetAxisRaw(_horizontalAxisName);
        _direction = new Vector3(_xInput, 0, 0);

        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded == true)
                _canJump = true; // Сделал самую простую проверку, можно
                                 // сделать с помощью RayCast-а, но решил не усложнять пока
    }

    private void FixedUpdate()
    {
        if (Mathf.Abs(_xInput) > _deadZone)
            _rigidBody.AddForce(_direction * _force);

        if (_canJump == true)
            Jump();
    }
    private void OnCollisionEnter(Collision collision)
    {
        _isGrounded = true;
    }
    private void OnCollisionExit(Collision collision)
    {
        _isGrounded = false;
    }
    private void Jump()
    {
        _rigidBody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
        _isGrounded = false;
        _canJump = false;
    }
    public void ResetPhysics()
    {
        _rigidBody.velocity = Vector3.zero;
        _rigidBody.angularVelocity = Vector3.zero;
    }
}

