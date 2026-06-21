using UnityEngine;

public class MapCard : MonoBehaviour
{
    [SerializeField] private string mapName;

    [SerializeField] private Sprite previewImage;

    [SerializeField] private string sceneName;

    [SerializeField] private MapSelectionUI mapSelectionUI;

    public void SelectMap()
    {
        mapSelectionUI.SelectMap(
            mapName,
            previewImage,
            sceneName);
    }
}
