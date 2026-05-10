using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class DesktopAppIcon : MonoBehaviour, IPointerClickHandler {
    public DesktopAppConfig config;
    public Image iconDisplay;
    public TextMeshProUGUI nameDisplay;

    void Start() {
        if (config != null) {
            iconDisplay.sprite = config.appImage;
            nameDisplay.text = config.appName;
        }
    }

    public void OnPointerClick(PointerEventData eventData) {
        DesktopController.Instance.OpenApp(config);
    }
}