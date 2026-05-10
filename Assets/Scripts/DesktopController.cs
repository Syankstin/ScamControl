using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DesktopController : MonoBehaviour {
    public static DesktopController Instance;
    public Image desktopWallpaper;
    public Transform windowLayer;
    public TaskbarController taskbar;

    void Awake() {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void OpenApp(DesktopAppConfig config) {
        if (config == null || config.windowPrefab == null) return;
        
        GameObject existingWindow = GameObject.Find(config.appName + "_Window");

        if (existingWindow != null) {
            existingWindow.transform.SetAsLastSibling();
        }

        else if (config.windowPrefab != null) {
            GameObject newWindow = Instantiate(config.windowPrefab, windowLayer);
            newWindow.name = config.appName + "_Window";

            if (taskbar != null) {
                taskbar.AddIcon(config);
            }
        }
    }

    public void SetWallpaper(Sprite newWallpaper) {
        if (desktopWallpaper != null && newWallpaper != null) {
            desktopWallpaper.sprite = newWallpaper;
        }
    }

    public void CloseApp(string appName) {
        if (taskbar != null) {
            taskbar.RemoveIcon(appName);
        }
    }
}
