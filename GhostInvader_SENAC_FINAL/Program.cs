using System;

namespace GhostInvader_SENAC_FINAL
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
            using (var game = new BoardGame())
                game.Run();
        }
    }
#endif
}
