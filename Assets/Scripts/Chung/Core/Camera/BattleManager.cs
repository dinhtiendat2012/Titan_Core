using UnityEngine;

public class BattleManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] characterPrefabs;

    [SerializeField] private Transform spawnP1;
    [SerializeField] private Transform spawnP2;

    [Header("UI Links")]
    [SerializeField] private BattleHUD p1HUD;
    [SerializeField] private BattleHUD p2HUD;

    private GameObject player1;
    private GameObject player2;
    private void Awake()
    {
        SpawnPlayers();
    }
    private void Start()
    {
        CameraFollow cameraFollow = Camera.main.GetComponent<CameraFollow>();
        if (player1 != null && player2 != null)
        {
            cameraFollow.SetTargets(player1.transform, player2.transform);
        }   
    }

    private void SpawnPlayers()
    {
        // Lấy Prefab từ màn hình chọn nhân vật
        GameObject prefab1 = characterPrefabs[(int)CharacterSelection.SelectedCharacter1];
        GameObject prefab2 = characterPrefabs[(int)CharacterSelection.SelectedCharacter2];

        // Sinh Player 1
        player1 = Instantiate(prefab1, spawnP1.position, spawnP1.rotation, spawnP1);
        player1.name = "Player1_Robot";

        // Sinh Player 2
        player2 = Instantiate(prefab2, spawnP2.position, spawnP2.rotation, spawnP2);
        player2.name = "Player2_Robot";
        // ÉP PLAYER 2 QUAY MẶT SANG TRÁI
        player2.transform.rotation = Quaternion.Euler(0f, 180f, 0f);

        // KẾT NỐI HỆ THỐNG: Cấu hình Input độc lập cho Player 2
        LocalPlayerInput p2Input = player2.GetComponent<LocalPlayerInput>();
        if (p2Input != null)
        {
            p2Input.keyLeft = KeyCode.LeftArrow;
            p2Input.keyRight = KeyCode.RightArrow;
            p2Input.keyCrouch = KeyCode.DownArrow;
            p2Input.keyLightPunch = KeyCode.Keypad1;
            p2Input.keyMediumPunch = KeyCode.Keypad2;
            p2Input.keyHeavyPunch = KeyCode.Keypad3;
            p2Input.keyBlock = KeyCode.Keypad5;
            p2Input.keySpecial = KeyCode.Keypad0;
        }

        // KẾT NỐI HỆ THỐNG: Gắn tự động Robot vào thanh máu (HUD)
        if (p1HUD != null) p1HUD.targetRobot = player1.GetComponent<RobotController>();
        if (p2HUD != null) p2HUD.targetRobot = player2.GetComponent<RobotController>();

        // Bàn giao 2 thí sinh cho Trọng tài (RoundManager)
        RoundManager referee = GetComponent<RoundManager>();
        if (referee != null)
        {
            RobotController controllerP1 = player1.GetComponent<RobotController>();
            RobotController controllerP2 = player2.GetComponent<RobotController>();
            referee.InitializeRound(controllerP1, controllerP2);
        }
        else
        {
            Debug.LogWarning("Chưa gắn RoundManager vào hệ thống!");
        }
    }
}
