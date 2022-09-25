using UnityEngine;

public class Pointer : MonoBehaviour
{
    [SerializeField] private CoinManager _coinManager;
    [SerializeField] private Coin _closestCoin;
    [SerializeField] private GameObject _arrow;

    private void Update()
    {
        _closestCoin = _coinManager.GetLosest(transform.position);

        if (_closestCoin != null)
        {
            Vector3 delta = _closestCoin.transform.position - transform.position;

            delta.y = 0;

            Quaternion newQuaternion = Quaternion.LookRotation(delta);
            _arrow.transform.rotation = Quaternion.Lerp(_arrow.transform.rotation, newQuaternion, Time.deltaTime * 20);
        }
    }
}
