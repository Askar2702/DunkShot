using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customize : MonoBehaviour
{
    [SerializeField] private Color[] _color;
    [SerializeField] private SpriteRenderer _player;
    public void SetColorBall(int i)
    {
        _player.material.color = _color[i];
    }
}
