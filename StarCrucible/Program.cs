using System;

namespace StarCrucible
{
#if WINDOWS || LINUX
    /// <summary>
    /// The main class.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var gvc = new ElectricHead.GameVc.GameVc();
            using (var game = new StarCrucible())
                game.Run();
        }
    }
#endif
}
