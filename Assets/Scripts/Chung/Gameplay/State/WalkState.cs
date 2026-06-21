using UnityEngine;

public class WalkState : RobotState
{

    private string currentAnim;

    public override void Enter()
    {
        UpdateWalkAnimation();
    }

    public WalkState(RobotController robot) : base(robot) { }

    public override void LogicUpdate()
    {
        if (robot.isBlocking && !robot.isOverheated)
        {
            robot.TransitionToState(robot.blockState);
            return;
        }
        if (robot.isCrouching)
        {
            robot.TransitionToState(robot.crouchState);
        }
        else if (Mathf.Abs(robot.moveInput) < 0.01f)
        {
            robot.TransitionToState(robot.idleState);
        }
        else
        {
            UpdateWalkAnimation();
        }
    }

    private void UpdateWalkAnimation()
    {
        string expectedAnim = robot.IsMovingForward() ? "Forward" : "Back";
       
        if (currentAnim != expectedAnim)
        {
            currentAnim = expectedAnim;
            robot.animator?.Play(currentAnim);
        }
    }

    public override void PhysicsUpdate()
    {
        robot.velocity.x = robot.moveInput * robot.moveSpeed;
    }
}