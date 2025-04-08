namespace Perelesoq.TestAssignment.Core.LevelManagement
{
    // This might be a scriptable object, be I am going with the simplest and agnostic setup for now.
    public sealed class GameLevelsConfig
    {
        // UI is universal for all levels I guess?
        public ProjectScenes ProjectScenes { get; } = new()
        {
            LevelUserInterfaceScene = "Level_test_UI",
        };

        // In real-life scenario we might have different ways to declare a "levels" typically based
        // on each game progression design, I do not know about any of it for this example but this
        // should be pretty straightforward to make list or graph here instead. Single "test level"
        // for development purposes can be also handy in any case.
        public GameLevel TestLevel { get; } = new()
        {
            MainScene = "Level_test",
            EnvironmentScene = "Level_test_Env",
            LightsScene = "Level_test_Lights",
            NavigationScene = "Level_test_Nav",
        };
    }
}
