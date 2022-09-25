using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private CoinManager _coinManager;
    [SerializeField] ParticleSystem _bounce;

    private void OnTriggerEnter(Collider other)
    {
        Coin coin = other.GetComponent<Coin>();
        if (coin)
        {
            _coinManager.CollectCoin(coin);
            _bounce.Play();
        }
    }
}
