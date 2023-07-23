namespace TransactionsTool.ViewModels
{
    public class MainMenuViewModel
    {
        public delegate void FileOpenHandler();
        public event FileOpenHandler OnFileOpen;

        public void FileOpen() => OnFileOpen?.Invoke();

        public delegate void FileExitHandler();
        public event FileExitHandler OnFileExit;

        public void FileExit() => OnFileExit?.Invoke();
    }
}
