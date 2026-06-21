using UnityEngine;

public class RobotSelectionButton : MonoBehaviour
{
    [SerializeField] private RobotData robotData;
    [SerializeField] private CharacterSelectUI characterSelectUI;
    [SerializeField] private int characterIndex;

    public void Select()
    {
        characterSelectUI.SelectRobot(robotData);
        CharacterSelection.SelectedCharacter1 = characterIndex;
    }
}
