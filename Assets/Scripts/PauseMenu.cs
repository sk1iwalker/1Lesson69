using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseController : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] private GameObject pauseUI;

    private bool isPaused = false;

    private void Start()
    {
        // При запуску гри переконуємося, що час йде, а меню приховане
        Time.timeScale = 1f;

        if (pauseUI != null)
        {
            pauseUI.SetActive(false);
        }
    }

    private void Update()
    {
        Debug.Log("--- ESCAPE НАТИСНУТО! ---"); // Додай цей рядок
        // Відстежуємо натискання Escape
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Pause()
    {
        if (pauseUI != null)
        {
            pauseUI.SetActive(true);
        }

        Time.timeScale = 0f; // Зупиняємо час у грі
        isPaused = true;

        // РОЗБЛОКОВУЄМО КУРСОР (Обов'язково для роботи кнопок!)
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void Resume()
    {
        if (pauseUI != null)
        {
            pauseUI.SetActive(false);
        }

        Time.timeScale = 1f; // Повертаємо час
        isPaused = false;

       
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void Restart()
    {
        Time.timeScale = 1f; // Відновлюємо час перед перезавантаженням!
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Exit()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu"); // Замініть на назву вашої головної сцени
    }
}