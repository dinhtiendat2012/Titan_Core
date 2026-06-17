using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterSelectUI : MonoBehaviour
{
    [SerializeField] private TMP_Text selectedRobotName;

    private RobotData selectedRobot;

    public void SelectRobot(RobotData robot)
    {
        selectedRobot = robot;

        selectedRobotName.text = robot.robotName;
    }

    public RobotData GetSelectedRobot()
    {
        return selectedRobot;
    }
}
