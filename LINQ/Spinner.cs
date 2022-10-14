using System.ComponentModel;

namespace LINQ
{
    public static class Spinner
    {
        private static BackgroundWorker spinner = initialiseBackgroundWorker();
        private static int spinnerPosition = 25;
        private static int spinWait = 25;
        private static bool isRunning;
        public static bool IsRunning { get { return isRunning; } }

        private static BackgroundWorker initialiseBackgroundWorker()
        {
            BackgroundWorker obj = new BackgroundWorker();
            obj.WorkerSupportsCancellation = true;

            obj.DoWork += delegate
            {
                spinnerPosition = Console.CursorLeft;
                while (!obj.CancellationPending)
                {
                    char[] spinChars = new char[] { '|', '/', '-', '\\' };

                    foreach (char spinChar in spinChars)
                    {
                        Console.CursorLeft = spinnerPosition;
                        Console.Write(spinChar);
                        Thread.Sleep(spinWait);

                    }

                }

            };

            return obj;
        }

        public static void Start()
        {
            isRunning = true;
            if (!spinner.IsBusy)
                spinner.RunWorkerAsync();
            else throw new InvalidOperationException("Cannot start spinner whilst spinner is already running");
        }

        public static void Stop()
        {
            spinner.CancelAsync();
            while (spinner.IsBusy) System.Threading.Thread.Sleep(100);
            Console.CursorLeft = spinnerPosition;
            isRunning = false;
        }
    }
}
