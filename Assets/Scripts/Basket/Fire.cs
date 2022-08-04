using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class Fire : MonoBehaviour
{
    [SerializeField] private BoxCollider2D _collider2D;
    public float Force { get; private set; }
    private Vector2 _touchStarted;
    private Camera _cam;

    private void Start()
    {
        _cam = Camera.main;
        InputManager.instance.Down.AddListener(StartToch);
        InputManager.instance.Drag.AddListener(CalculateForce);
        InputManager.instance.Up.AddListener(EnabledCollider);
    }
    // void Update()
    // {
    //     if (Input.GetMouseButtonDown(0))
    //     {
    //         _touchStarted = Input.mousePosition;
    //     }
    //     else if (Input.GetMouseButton(0))
    //     {
    //         Vector2 touchEnded = Input.mousePosition;
    //         var swipe = touchEnded - _touchStarted;
    //         Force = swipe.magnitude / 100;
    //     }
    //     else if (Input.GetMouseButtonUp(0))
    //     {
    //         _collider2D.enabled = true;
    //     }
    // }
    private void StartToch()
    {
        _touchStarted = Input.mousePosition;
    }

    private void CalculateForce()
    {
        Vector2 touchEnded = Input.mousePosition;
        var swipe = touchEnded - _touchStarted;
        Force = swipe.magnitude / 100;
    }

    private void EnabledCollider()
    {
        _collider2D.enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out PlayerBall player)) player.Losed();
    }
}
