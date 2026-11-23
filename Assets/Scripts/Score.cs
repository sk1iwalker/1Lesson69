using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    private int _score;

    public void AddScore()
    {
        _score++;

        _text.text = "Score: " + _score;
    }
}
