using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MapSelectionUI : MonoBehaviour
{
    [SerializeField] private Image selectedMapImage;
    [SerializeField] private TMP_Text selectedMapName;
    [SerializeField] private Button confirmButton;
    [SerializeField] private SceneNavigator sceneNavigator;

    private string selectedSceneName;

    private void Start()
    {
        confirmButton.interactable = false;
        selectedMapName.text = "No Map Selected";
    }

    public void SelectMap(
        string mapName,
        Sprite previewImage,
        string sceneName)
    {
        selectedMapName.text = mapName;

        selectedMapImage.sprite = previewImage;

        selectedSceneName = sceneName;

        confirmButton.interactable = true;
    }

    public void ConfirmMap()
    {
        if (string.IsNullOrEmpty(selectedSceneName))
            return;

        sceneNavigator.GoToBattle();
    }

    public void BackToCharacterSelect()
    {
        sceneNavigator.GoToCharacterSelect();
    }
}
