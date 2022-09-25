using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private Rigidbody _playerRigidbody;


    private List<Vector3> _velositiesList = new List<Vector3>();

    private void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            _velositiesList.Add(Vector3.zero);
        }
        
    }

    private void Update()
    {
        Vector3 sum = Vector3.zero;

        for (int i = 0; i < _velositiesList.Count; i++)
        {
            sum += _velositiesList[i];
        }

        if (sum != Vector3.zero)
        {
            transform.position = new Vector3(_playerTransform.position.x, 0, _playerTransform.position.z);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(sum), Time.deltaTime * 10);
        }
    }

    private void FixedUpdate()
    {
        _velositiesList.Add(_playerRigidbody.velocity);
        _velositiesList.RemoveAt(0);
    }
}
