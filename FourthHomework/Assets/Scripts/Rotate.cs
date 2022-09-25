using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] float X, Y, Z;

    private void Update()
    {
        transform.Rotate(new Vector3(X, Y, Z) * Time.deltaTime);
    }
}
