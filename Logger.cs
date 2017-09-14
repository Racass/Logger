// remove and sort usings, cleanup extra whitespace
using System;
using System.IO;

namespace Sonavox
{
    // made class publicly accessible - https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/accessibility-levels
    public class Logger
    {
        private const string DEFAULT_DIR = @"\configs\Log\";
        // made privately accessible
        // reformatted variable declarations
        // removed unnesscary namespace qualifier (System) and ToString() sicne BaseDirectory is a String
        private string dir;
        private string nameOfFile;
        private string message;
        private string pastMessage;
      
        string myDir = Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory.ToString());
        string nameOfFile = String.Empty, message = String.Empty;
      
        //#######################################################################################
        //#################################### Callers ##########################################
        //#######################################################################################
        public Logger(string msg)
            : this(DEFAULT_DIR, String.Empty, msg) { }

        public Logger(string name, string msg)
            : this(DEFAULT_DIR, name, msg) { }

        public Logger(string directory, string name, string msg, bool startOnNewLine = true)
        {
            dir = directory;
            // empty or null name is handled by string interpolation https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/interpolated-strings
            nameOfFile = $"{name}{DateTime.Now.ToString("M.d.yyyy")}";
            message = msg;
            pastMessage = string.Empty;

            try
            {
                if (CheckAndCreateDirectory() && FileExists())
                {
                    ReadTxt();
                }
                else
                {
                    CreateTxt();
                    ReadTxt();
                }

                if (startOnNewLine)
                {
                    WriteTxtOnNewLine();
                }
                else
                {
                    WriteTxt();
                }
                Clear();
            }
            finally
            Clear();
        }


        //######################################################################################
        //###################################### Work ##########################################
        //######################################################################################

        void WriteLineController()
        {
            try
            {
                VerifyAll();
                WriteTxt();
            }
            catch (Exception)
            {
                // https://stackoverflow.com/questions/9291437/use-a-try-finally-block-without-a-catch-block
                ErrorWriter();
                Clear();
            }
        }

        public void Write(string text)
        {
            message = text;
            WriteTxtOnNewLine();
        }

        public string Read()
        {
            ReadTxt();
            return pastMessage;
        }

        void VerifyAll()
        {
            if (!VerifyDirectory())
                CreateDirectory();
        }
      
        private bool CheckAndCreateDirectory()
        {
            if (Directory.Exists(dir))
            {
                return true;
            }

            return CreateDirectory();
        }

        private bool CreateDirectory()
        {
            try
            {
                Directory.CreateDirectory(dir);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        private bool FileExists()
        {
            // use var keyword https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/var
            // use of Path.Combine https://msdn.microsoft.com/en-us/library/fyy7a5kt(v=vs.110).aspx
            var fileName = Path.Combine(dir, nameOfFile);
            if (File.Exists(fileName))
            {
                return true;
            }

            return false;
        }

        private void CreateTxt()
        {
            // using with Dispose classes https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/using-statement
            // using calls Dispose which when properly implemented calls Close
            using (var Log = new StreamWriter(dir + nameOfFile))
            {
                Log.WriteLine($"LOG DO DIA: {DateTime.Now.ToShortDateString()}");
            }
        }

        private void ReadTxt()
        {
            using (var writer = new StreamReader(Path.Combine(dir, nameOfFile)))
            {
                pastMessage = writer.ReadToEnd();
            }
        }

        private void WriteTxt()
        {
            using (var writer = new StreamWriter(Path.Combine(dir, nameOfFile)))
            {
                writer.WriteLine(pastMessage);
                writer.Write($"{DateTime.Now.ToLongTimeString()} : {message}");
            }
        }

        private void WriteTxtOnNewLine()
        {
            using (var writer = new StreamWriter(Path.Combine(dir, nameOfFile)))
            {
                writer.WriteLine(pastMessage);
                writer.WriteLine();
                writer.Write($"{DateTime.Now.ToLongTimeString()} : {message}");

            }
        }

        private void Clear()
        {
            dir         = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);
            nameOfFile  = String.Empty;
            message     = String.Empty;
            pastMessage = String.Empty;
        }

        private void ErrorWriter()
        {
            using (var writer = new StreamWriter(Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory.ToString()) + "UnknownError.txt"))
            {
                writer.Write($"{DateTime.Now.ToLongTimeString()} : Verify your directory.");
            }
        }
    }
}