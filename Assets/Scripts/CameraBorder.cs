using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class CameraBorder : MonoBehaviour
{
    public Vector2 LefBottom { get; private set; }
    public Vector2 LeftTop { get; private set; }
    public Vector2 RightTop { get; private set; }
    public Vector2 RightBottom { get; private set; }
    private Camera _cam;
    private void Awake()
    {
        _cam = Camera.main;
    }
    void Start()
    {
        if (_cam) AddCollision();
    }

    private async void AddCollision()
    {
        await Task.Delay(1000);
        var edgeCol = GetComponent<EdgeCollider2D>() ? GetComponent<EdgeCollider2D>() : gameObject.AddComponent<EdgeCollider2D>();


        LefBottom = (Vector2)_cam.ScreenToWorldPoint(new Vector3(0, 0, _cam.nearClipPlane));
        LeftTop = (Vector2)_cam.ScreenToWorldPoint(new Vector3(0, _cam.pixelHeight, _cam.nearClipPlane));
        RightTop = (Vector2)_cam.ScreenToWorldPoint(new Vector3(_cam.pixelWidth, _cam.pixelHeight, _cam.nearClipPlane));
        RightBottom = (Vector2)_cam.ScreenToWorldPoint(new Vector3(_cam.pixelWidth, 0, _cam.nearClipPlane));


        var edgePoints = new[] { LefBottom, LeftTop, RightTop, RightBottom };
        edgeCol.points = edgePoints;
    }
}
