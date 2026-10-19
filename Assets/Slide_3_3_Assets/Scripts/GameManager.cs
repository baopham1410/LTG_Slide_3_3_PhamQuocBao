using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// Practice Slide 3.3 — điều khiển popup GameMenu (Canvas).
/// Gắn script này lên Main Camera, kéo các UI vào Inspector.
/// </summary>
public class GameManager : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private GameObject gameMenuCanvas;
    [SerializeField] private TMP_Text titleText;
    [SerializeField] private TMP_Text messageText;
    [SerializeField] private Button continueButton;
    [SerializeField] private Button restartButton;
    [SerializeField] private TMP_Text continueButtonText;
    [SerializeField] private TMP_Text restartButtonText;

    [Header("Popup Content (set from code)")]
    [SerializeField] private string title = "Welcome to Unity!";
    [SerializeField] private string message = "Do you want continue?";
    [SerializeField] private string continueLabel = "Enter";
    [SerializeField] private string restartLabel = "Restart";

    [Header("Scene Names")]
    [SerializeField] private string nextSceneName = "";

    private void Awake()
    {
        // Gắn OnClick bằng code (chắc chắn hơn kéo Inspector)
        if (continueButton != null)
        {
            continueButton.onClick.RemoveAllListeners();
            continueButton.onClick.AddListener(NextScene);
        }

        if (restartButton != null)
        {
            restartButton.onClick.RemoveAllListeners();
            restartButton.onClick.AddListener(RestartScene);
        }

        // Text không được chặn click nút
        if (titleText != null) titleText.raycastTarget = false;
        if (messageText != null) messageText.raycastTarget = false;
        if (continueButtonText != null) continueButtonText.raycastTarget = false;
        if (restartButtonText != null) restartButtonText.raycastTarget = false;
    }

    private void Start()
    {
        if (gameMenuCanvas != null)
            gameMenuCanvas.SetActive(false);

        ApplyDynamicContent();
    }

    public void ApplyDynamicContent()
    {
        if (titleText != null)
            titleText.text = title;
        if (messageText != null)
            messageText.text = message;
        if (continueButtonText != null)
            continueButtonText.text = continueLabel;
        if (restartButtonText != null)
            restartButtonText.text = restartLabel;
    }

    public void ShowPopup()
    {
        ApplyDynamicContent();
        if (gameMenuCanvas != null)
            gameMenuCanvas.SetActive(true);

        // Không dừng Time.timeScale — tránh UI/Input bị kẹt
        // (máy bay đã dừng vì va tường / hasTriggered)
    }

    public void HidePopup()
    {
        if (gameMenuCanvas != null)
            gameMenuCanvas.SetActive(false);
        Time.timeScale = 1f;
    }

    public void NextScene()
    {
        Time.timeScale = 1f;
        Debug.Log("Enter / NextScene clicked");

        if (!string.IsNullOrEmpty(nextSceneName))
        {
            SceneManager.LoadScene(nextSceneName);
            return;
        }

        int nextIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextIndex < SceneManager.sceneCountInBuildSettings)
            SceneManager.LoadScene(nextIndex);
        else
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // chỉ 1 scene → reload
    }

    public void RestartScene()
    {
        Time.timeScale = 1f;
        Debug.Log("Restart clicked");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
