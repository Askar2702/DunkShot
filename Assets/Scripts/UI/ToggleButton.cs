using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ToggleButton : MonoBehaviour
{
    [SerializeField] private Image _background;
    [SerializeField] private RectTransform _circle;
    [SerializeField] private Color _onColor;
    [SerializeField] private Color _offColor;
    [SerializeField] private GameObject[] _onAndOff;
    [SerializeField] private float _speed;
    [SerializeField] private string _nameSave;
    private Vector2 _currentPos;
    private float _posX = 65;
    private void Start()
    {
        if (PlayerPrefs.HasKey(_nameSave))
        {
            _currentPos = new Vector2(-_posX, 0);
        }
        else
            _currentPos = new Vector2(_posX, 0);
        _circle.anchoredPosition = _currentPos;
        ChangeColor();
    }

    private void Update()
    {
        if (_circle.anchoredPosition != _currentPos)
            _circle.anchoredPosition = Vector2.Lerp(_circle.anchoredPosition, _currentPos, Time.deltaTime * _speed);
    }
    public void ChangePos()
    {
        if (_currentPos.x == _posX)
        {
            _background.color = _offColor;
            _currentPos = new Vector2(-_posX, 0);

            _onAndOff[0].SetActive(false);
            _onAndOff[1].SetActive(true);

        }

        else
        {
            _background.color = _onColor;
            _currentPos = new Vector2(_posX, 0);

            _onAndOff[0].SetActive(true);
            _onAndOff[1].SetActive(false);
        }
    }

    private void ChangeColor()
    {
        if (_currentPos.x == _posX) _background.color = _onColor;
        else _background.color = _offColor;
        if (PlayerPrefs.HasKey(_nameSave))
        {
            _onAndOff[0].SetActive(false);
            _onAndOff[1].SetActive(true);

        }
        else
        {
            _onAndOff[0].SetActive(true);
            _onAndOff[1].SetActive(false);
        }
    }



}
