using Unity.VisualScripting;
using UnityEngine;

public class WindowManager : MonoBehaviour {
    private Vector3 originalScale;
    private Vector2 originalSize;
    private Vector2 originalPosition;
    private bool isMinimised = false;
    private bool isMaximised = false;
    public string appName;

    void Awake() {
        originalScale = transform.localScale;
    }

    public void CloseWindow() {
        Debug.Log("Closing app: " + appName + "\n");
        DesktopController.Instance.CloseApp(appName);
        Destroy(gameObject);
    }

    public void ToggleMinimise() {
        isMinimised = !isMinimised;

        gameObject.SetActive(!isMinimised);
    }

    public void MaximiseWindow() {
        RectTransform rect = GetComponent<RectTransform>();

        if (!isMaximised) {
            originalSize = rect.sizeDelta;
            originalPosition = rect.anchoredPosition;

            rect.anchorMin = Vector2.zero;
            rect.anchorMax = Vector2.one;
            rect.offsetMin = Vector2.zero;
            rect.offsetMax = Vector2.zero;
            isMaximised = true;
        }

        else {
            rect.anchorMin = new Vector2(0.5f, 0.5f);
            rect.anchorMax = new Vector2(0.5f, 0.5f);
            rect.sizeDelta = originalSize;
            rect.anchoredPosition = originalPosition;
            isMaximised = false;
        }
    }
}
