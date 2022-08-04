using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class InputManager : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    public static InputManager instance;
    public UnityEvent Down;
    public UnityEvent Drag;
    public UnityEvent Up;
    private void Awake()
    {
        if (!instance) instance = this;
    }


    public void OnPointerDown(PointerEventData eventData)
    {
        Down?.Invoke();
    }

    public void OnDrag(PointerEventData eventData)
    {
        Drag?.Invoke();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Up?.Invoke();
    }
}
