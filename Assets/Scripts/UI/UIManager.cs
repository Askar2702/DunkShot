using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Image[] _panels;
    [SerializeField] private Color _white;
    [SerializeField] private Color _dark;

    [SerializeField] private TextMeshProUGUI _currentScoreText;
    [SerializeField] private TextMeshProUGUI _bestScoreText;
    [SerializeField] private TextMeshProUGUI _starScoreText;
    [SerializeField] private AudioSource[] _audio;
    private int _score;
    private int _bestScore;
    private int _countStars;
    private bool isDark;
    private bool isSound;
    private Camera _cam;
    private void Start()
    {
        // PlayerPrefs.DeleteAll();
        _cam = Camera.main;
        LoadSettings();
    }

    public void ChangeHightMode()
    {

        if (isDark)
        {
            foreach (var item in _panels)
                item.color = _white;
            PlayerPrefs.SetInt("dark", 1);
            _cam.backgroundColor = _white;
            isDark = false;
        }
        else
        {
            foreach (var item in _panels)
                item.color = _dark;
            PlayerPrefs.DeleteKey("dark");
            _cam.backgroundColor = _dark;
            isDark = true;
        }

    }

    public void EnableSound()
    {
        if (isSound)
        {
            foreach (var item in _audio)
            {
                item.enabled = false;
            }
            PlayerPrefs.SetInt("soundOff", 1);
            isSound = false;
        }
        else
        {
            foreach (var item in _audio)
            {
                item.enabled = true;
            }
            PlayerPrefs.DeleteKey("soundOff");
            isSound = true;
        }

    }

    public void AddScore(int score)
    {
        _score += score;
        _currentScoreText.text = _score.ToString();
        if (_score > _bestScore)
        {
            PlayerPrefs.SetInt("BestScore", _score);
            _bestScore = _score;
            _bestScoreText.text = _bestScore.ToString();
        }
    }

    public void AddStar()
    {
        _countStars++;
        _starScoreText.text = _countStars.ToString();
        PlayerPrefs.SetInt("Star", _countStars);
    }

    private void LoadSettings()
    {
        _bestScore = PlayerPrefs.GetInt("BestScore");
        _bestScoreText.text = _bestScore.ToString();
        _countStars = PlayerPrefs.GetInt("Star");
        if (_countStars > 0)
            _starScoreText.text = _countStars.ToString();


        isSound = PlayerPrefs.HasKey("soundOff");
        if (isSound)
        {
            isSound = false;
            foreach (var item in _audio)
            {
                item.enabled = false;
            }
        }
        else
        {
            isSound = true;
            foreach (var item in _audio)
            {
                item.enabled = true;
            }
        }


        isDark = PlayerPrefs.HasKey("dark");
        if (isDark)
        {
            isDark = false;
            foreach (var item in _panels)
            {

                item.color = _white;
                _cam.backgroundColor = _white;
            }
        }
        else
        {
            isDark = true;
            foreach (var item in _panels)
            {
                item.color = _dark;
                _cam.backgroundColor = _dark;
            }
        }
    }

}
