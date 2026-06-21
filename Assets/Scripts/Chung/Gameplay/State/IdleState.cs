using UnityEngine;

public class IdleState : RobotState
{
    public IdleState(RobotController robot) : base(robot) { }

    public override void Enter()
    {
        robot.velocity.x = 0f;
        robot.animator?.Play("Idle");
    }

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
        else if (Mathf.Abs(robot.moveInput) > 0.01f)
        {
            robot.TransitionToState(robot.walkState);
        }
    }
}