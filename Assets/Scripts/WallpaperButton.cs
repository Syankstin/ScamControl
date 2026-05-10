using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class WallpaperButton : MonoBehaviour, IPointerClickHandler {
    public Sprite wallpaperSprite;

    public void OnPointerClick(PointerEventData eventData) {
        if (DesktopController.Instance != null) DesktopController.Instance.SetWallpaper(wallpaperSprite);
    }

}