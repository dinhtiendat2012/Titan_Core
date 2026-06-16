using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterSelectUI : MonoBehaviour
{
    [SerializeField] private Image selectedRobotImage;
    [SerializeField] private TMP_Text selectedRobotName;

    private string selectedRobot;

    public void SelectAtom()
    {
        selectedRobot = "ATOM";
        selectedRobotName.text = selectedRobot;
    }

    public void SelectZeus()
    {
        selectedRobot = "ZEUS";
        selectedRobotName.text = selectedRobot;
    }
}
