using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private Transform _cameraCenter;

    [SerializeField] private float _speed;

    private float _boostSpeed;
    private float _startSpeed;

    private Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _startSpeed = _speed;
        _boostSpeed = _speed * 3;
        _rb.maxAngularVelocity = 5000;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
            _speed = _boostSpeed;
        else
            _speed = _startSpeed;
    }

    private void FixedUpdate()
    {
        _rb.AddTorque(_cameraCenter.right * Input.GetAxis("Vertical") * _speed);
        _rb.AddTorque(-_cameraCenter.forward * Input.GetAxis("Horizontal") * _speed);
    }

    public void ClearSpeed()
    {
        _startSpeed = _boostSpeed = _speed = 0;
    }
}
