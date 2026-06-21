using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RoundManager : MonoBehaviour
{
    public enum RoundState { Starting, Fighting, RoundOver }

    [Header("Match Settings")]
    public float maxRoundTime = 99f;
    private float currentTimer;
    public RoundState currentState = RoundState.Starting;

    [Header("UI References")]
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI matchResultText; // Hiển thị "FIGHT", "K.O.", "P1/P2 WINS"

    private RobotController p1;
    private RobotController p2;

    public void InitializeRound(RobotController player1, RobotController player2)
    {
        p1 = player1;
        p2 = player2;

        currentTimer = maxRoundTime;
        UpdateTimerUI();

        currentState = RoundState.Starting;

        LockBothPlayers();

        if (matchResultText != null)
        {
            matchResultText.text = "FIGHT!";
            matchResultText.gameObject.SetActive(true);

            Invoke("StartFight", 1.5f);
        }
        else
        {
            StartFight();
        }
    }

    void Update()
    {
        if (currentState != RoundState.Fighting) return;
        if (p1 == null || p2 == null) return;

        // Quản lý đồng hồ đếm ngược
        currentTimer -= Time.deltaTime;
        UpdateTimerUI();

        // Kiểm tra điều kiện Hết giờ (Time Over)
        if (currentTimer <= 0)
        {
            currentTimer = 0;
            UpdateTimerUI();
            DeclareWinnerByTime();
            return;
        }

        // Kiểm tra điều kiện K.O. (Chết do cạn HP tổng HOẶC bị đập nát Thân)
        bool isP1Dead = p1.currentGlobalHP <= 0 || p1.GetPartCurrentHP(RobotData.PartType.Torso) <= 0;
        bool isP2Dead = p2.currentGlobalHP <= 0 || p2.GetPartCurrentHP(RobotData.PartType.Torso) <= 0;

        if (isP1Dead || isP2Dead)
        {
            DeclareWinnerByKO(isP1Dead, isP2Dead);
        }
    }

    private void UpdateTimerUI()
    {
        if (timerText != null)
        {
            timerText.text = Mathf.CeilToInt(currentTimer).ToString();
        }
    }

    private void DeclareWinnerByKO(bool isP1Dead, bool isP2Dead)
    {
        currentState = RoundState.RoundOver;

        LockBothPlayers();

        if (isP1Dead && isP2Dead)
            DisplayResult("DOUBLE K.O. \n DRAW");
        else if (isP1Dead)
            DisplayResult("K.O. \n PLAYER 2 WINS");
        else
            DisplayResult("K.O. \n PLAYER 1 WINS");
    }

    private void DeclareWinnerByTime()
    {
        currentState = RoundState.RoundOver;

        LockBothPlayers();

        if (p1.currentGlobalHP > p2.currentGlobalHP)
        {
            DisplayResult("TIME OVER \n PLAYER 1 WINS");
        }
        else if (p2.currentGlobalHP > p1.currentGlobalHP)
        {
            DisplayResult("TIME OVER \n PLAYER 2 WINS");
        }
        else
        {
            DisplayResult("TIME OVER \n DRAW");
        }
    }

    private void DisplayResult(string message)
    {
        Debug.Log($"KẾT QUẢ TRẬN ĐẤU: {message}");
        if (matchResultText != null)
        {
            matchResultText.text = message;
            matchResultText.gameObject.SetActive(true);
        }
    }

    private void ClearResultText()
    {
        if (matchResultText != null) matchResultText.gameObject.SetActive(false);
    }

    private void LockBothPlayers()
    {
        if (p1 != null) p1.LockInput();
        if (p2 != null) p2.LockInput();

        Debug.Log("ĐÃ KHÓA BẢNG ĐIỀU KHIỂN CỦA CẢ 2 ROBOT!");
    }

    // Bắt đầu trận đấu thực sự
    private void StartFight()
    {
        ClearResultText();
        UnlockBothPlayers(); 

        currentState = RoundState.Fighting; 
        Debug.Log("TRẬN ĐẤU CHÍNH THỨC BẮT ĐẦU!");
    }

    // Mở khóa tay cho 2 người chơi
    private void UnlockBothPlayers()
    {
        if (p1 != null) p1.UnlockInput();
        if (p2 != null) p2.UnlockInput();
    }
}