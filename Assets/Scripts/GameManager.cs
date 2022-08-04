using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] private GameObject _panelLose;
    [field: SerializeField] public Transform StarPoint;
    private Transform _cam;
    private float _posY;
    private UIManager _uIManager;

    private void Awake()
    {
        if (!instance) instance = this;
    }
    private void Start()
    {
        _cam = Camera.main.transform;
        _posY = _cam.position.y;
        _uIManager = GetComponent<UIManager>();
    }



    public void LosedGame()
    {
        _panelLose.SetActive(true);
    }

    public void AddScore(int score)
    {
        _uIManager.AddScore(score);
    }

    public void AddStar()
    {
        _uIManager.AddStar();
    }


}
