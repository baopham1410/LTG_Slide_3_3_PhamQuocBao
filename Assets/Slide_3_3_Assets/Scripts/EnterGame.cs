using UnityEngine;

/// <summary>
/// Practice Slide 3.3 — gắn lên Enter Wall (Is Trigger = true).
/// Khi máy bay (tag "Player" hoặc có Rigidbody) vào trigger → mở popup.
/// </summary>
public class EnterGame : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private string airplaneTag = "Player";

    private bool hasTriggered;

    private void OnTriggerEnter(Collider other)
    {
        if (hasTriggered)
            return;

        // Collider có thể nằm ở con (body/wing) — kiểm tra cả parent
        Transform root = other.transform.root;
        bool isAirplane =
            other.CompareTag(airplaneTag) ||
            root.CompareTag(airplaneTag) ||
            other.CompareTag("Airplane") ||
            root.CompareTag("Airplane") ||
            other.name.Contains("Airplane") ||
            root.name.Contains("Airplane") ||
            other.GetComponentInParent<AirplaneTakeOff>() != null;

        if (!isAirplane)
            return;

        hasTriggered = true;

        if (gameManager == null)
            gameManager = FindFirstObjectByType<GameManager>();

        if (gameManager != null)
            gameManager.ShowPopup();
        else
            Debug.LogWarning("EnterGame: chưa gán GameManager!");
    }
}
