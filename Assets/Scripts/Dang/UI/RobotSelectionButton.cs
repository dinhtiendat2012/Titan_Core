using UnityEngine;

public class RobotSelectionButton : MonoBehaviour
{
    [SerializeField] private RobotData robotData;
    [SerializeField] private CharacterSelectUI characterSelectUI;

    public void Select()
    {
        characterSelectUI.SelectRobot(robotData);
    }
}
