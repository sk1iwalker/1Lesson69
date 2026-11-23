using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] private TMP_Text winText;
    [SerializeField] private PlayerController player;
    [SerializeField] private TMP_Text timerText;
    [SerializeField] private float timeRemaining = 180f;

    private bool isTimerRunning = false;

    private void Start()
    {
        winText.gameObject.SetActive(false);
        isTimerRunning = true;
    }

    private void Update()
    {
        if (!isTimerRunning) return;

        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            UpdateTimerDisplay(timeRemaining);
        }
        else
        {
            timeRemaining = 0;
            isTimerRunning = false;
            UpdateTimerDisplay(timeRemaining);
            OnTimerEnd();
        }
    }

    private void UpdateTimerDisplay(float timeToDisplay)
    {

        if (timeToDisplay < 0) timeToDisplay = 0;


        int minutes = Mathf.FloorToInt(timeToDisplay / 60);
        int seconds = Mathf.FloorToInt(timeToDisplay % 60);


        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
    
    private void OnTimerEnd()
    {

        if (player != null && player.gameObject.activeSelf)
        {
            ShowWinScreen();

        }
        Time.timeScale = 0f;
    }

    private void ShowWinScreen()
    {
        if (winText != null)
        {
            winText.text = "You win!";
            winText.gameObject.SetActive(true);
        }
    }
}