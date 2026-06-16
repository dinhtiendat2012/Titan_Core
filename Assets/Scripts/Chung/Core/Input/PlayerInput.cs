using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField]
    public KeyCode leftKey;
    [SerializeField]
    public KeyCode rightKey;
    [SerializeField]
    public KeyCode crouchKey;
    [SerializeField]
    public KeyCode blockKey;

    public float MoveInput { get; private set; }
    public bool IsCrouching { get; private set; }
    public bool IsBlocking { get; private set; }

    private void Update()
    {
        MoveInput = 0;

        if (Input.GetKey(leftKey))
            MoveInput = -1;

        if (Input.GetKey(rightKey))
            MoveInput = 1;

        IsCrouching = Input.GetKey(crouchKey);
        IsBlocking = Input.GetKey(blockKey);
    }
}
