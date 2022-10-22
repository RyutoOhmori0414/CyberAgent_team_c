public static class StageStateHolder
{
    public static StageState StageState { get; set; }
}

public enum StageState
{
    None,
    BeforeGame,
    InGame,
    AfterGame,
}