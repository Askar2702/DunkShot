using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreLabel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textScore;
    private Vector2 _pos;
    public void Init(string text)
    {
        _textScore.text = $"+ {text}";
        _pos = new Vector2(transform.position.x, transform.position.y + 10f);
        Destroy(this.gameObject, 3f);
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _pos, Time.deltaTime * 2f);
    }
}
