using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    [SerializeField] private Transform _gabaritePlane;

    [SerializeField] private GameObject _coinPrefab;

    [SerializeField] private List<Coin> _coinsList = new List<Coin>();

    [SerializeField] private UIController _controller;

    [SerializeField] private float _maxCoinsGenerate = 10;

    [SerializeField] private LayerMask _layerMask;

    private void Start()
    {
        int numberOfCreated = 0;
        int numberOfRetries = 0;
        while (numberOfCreated < _maxCoinsGenerate && numberOfRetries < 1000)
        {
            Vector3 localPoint = new Vector3(GetRandom(0.5f), 1, GetRandom(0.5f));
            Vector3 worldPoint = _gabaritePlane.TransformPoint(localPoint);

            if (Physics.CheckSphere(worldPoint, 0.35f, _layerMask, QueryTriggerInteraction.Collide) == false)
            {
                GameObject newCoin = Instantiate(_coinPrefab, worldPoint, Quaternion.identity);

                //newCoin.transform.position = new Vector3(newCoin.transform.position.x, 0.5f, newCoin.transform.position.z);

                numberOfCreated++;
                _coinsList.Add(newCoin.GetComponent<Coin>());
            }
            numberOfRetries++;
            
        }

        Debug.Log(numberOfCreated + " / " + numberOfRetries);

        _controller.CoinsCouintUpdate(_coinsList.Count);
    }

    private float GetRandom(float value)
    {
        return Random.Range(-value, value);
    }

    public void CollectCoin(Coin coin)
    {
        _coinsList.Remove(coin);
        Destroy(coin.gameObject);

        _controller.CoinsCouintUpdate(_coinsList.Count);

        if (_coinsList.Count <= 0)
        {
            _controller.ShowWinPanel();
        }
    }

    public Coin GetLosest(Vector3 point)
    {
        float minDistance = Mathf.Infinity;
        Coin closestCoin = null;

        for (int i = 0; i < _coinsList.Count; i++)
        {
            float distance = Vector3.Distance(point, _coinsList[i].transform.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                closestCoin = _coinsList[i];
            }
                
        }

        return closestCoin;
    }
}
