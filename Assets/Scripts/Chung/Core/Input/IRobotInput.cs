public interface IRobotInput
{
    float MoveInput { get; }
    bool IsCrouching { get; }
    bool IsBlocking { get; }
    bool LightPunchDown { get; }
    bool MediumPunchDown { get; }
    bool HeavyPunchDown { get; }
    bool SpecialDown { get; }
}