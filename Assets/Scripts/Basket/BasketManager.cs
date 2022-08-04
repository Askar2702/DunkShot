using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BasketManager : MonoBehaviour
{
    public static BasketManager instance;
    public UnityEvent Signal;
    [SerializeField] private Trajectory _basket;
    public Basket PreviousBasket => _previousBasket;
    private Basket _previousBasket;
    private Basket _currentBasket;
    private float _minY = 3f;
    private float _maxY = 5f;
    private float _minX = 0.5f;
    private float _maxX = 2f;
    private void Awake()
    {
        if (!instance) instance = this;
    }

    public void SetPreviousBasket(Basket b)
    {
        _previousBasket = b;
    }

    public void RemoveAndSpawnBasket(Basket b)
    {
        if (_previousBasket && b != _previousBasket)
        {
            Signal?.Invoke();
            var posPrev = _previousBasket.transform.position;
            Destroy(_previousBasket.transform.root.gameObject);
            var rand = Random.Range(_minY, _maxY);
            var randX = Random.Range(_minX, _maxX);
            if (posPrev.x < 0) randX = -randX;
            var pos = new Vector2(randX, posPrev.y + rand);
            Instantiate(_basket, pos, Quaternion.identity);
        }
    }
}
