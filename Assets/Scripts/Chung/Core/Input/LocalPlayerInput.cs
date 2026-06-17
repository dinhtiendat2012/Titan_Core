using UnityEngine;

public class LocalPlayerInput : MonoBehaviour, IRobotInput
{
    [Header("Input Mapping (Local PvP)")]
    public KeyCode keyLeft = KeyCode.A;
    public KeyCode keyRight = KeyCode.D;
    public KeyCode keyCrouch = KeyCode.S;
    public KeyCode keyLightPunch = KeyCode.H;
    public KeyCode keyMediumPunch = KeyCode.J;
    public KeyCode keyHeavyPunch = KeyCode.K;
    public KeyCode keyBlock = KeyCode.L;
    public KeyCode keySpecial = KeyCode.P;

    public float MoveInput
    {
        get
        {
            float val = 0f;
            if (Input.GetKey(keyLeft)) val = -1f;
            if (Input.GetKey(keyRight)) val = 1f;
            return val;
        }
    }

    public bool IsCrouching => Input.GetKey(keyCrouch);
    public bool IsBlocking => Input.GetKey(keyBlock);
    public bool LightPunchDown => Input.GetKeyDown(keyLightPunch);
    public bool MediumPunchDown => Input.GetKeyDown(keyMediumPunch);
    public bool HeavyPunchDown => Input.GetKeyDown(keyHeavyPunch);
    public bool SpecialDown => Input.GetKeyDown(keySpecial);
}