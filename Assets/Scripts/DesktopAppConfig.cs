using UnityEngine;

[CreateAssetMenu(fileName = "New App", menuName = "Desktop/App")]
public class DesktopAppConfig: ScriptableObject {
    public string appName;
    public Sprite appImage;
    public GameObject windowPrefab;
}
