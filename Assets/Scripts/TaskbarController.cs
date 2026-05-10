using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskbarController : MonoBehaviour {
    public GameObject taskbarIconPrefab;
    public Transform iconContainer;

    private Dictionary<string, GameObject> activeIcons = new Dictionary<string, GameObject>();

    public void AddIcon(DesktopAppConfig config) {
        if (activeIcons.ContainsKey(config.appName)) return;

        GameObject newIcon = Instantiate(taskbarIconPrefab, iconContainer);
        activeIcons.Add(config.appName, newIcon);

        Image img = newIcon.GetComponentInChildren<Image>();
        if (img != null) img.sprite = config.appImage;

        Button btn = newIcon.GetComponent<Button>();
        if (btn != null) {
            btn.onClick.AddListener(() => { DesktopController.Instance.OpenApp(config); });
        }
    }

    public void RemoveIcon(string appName) {
        if (activeIcons.ContainsKey(appName)) {
            Destroy(activeIcons[appName]);
            activeIcons.Remove(appName);
        }
    }
}
