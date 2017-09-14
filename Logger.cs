using System;
using System.Text;
using System.IO;

namespace Class
{
    class Logger
    {
        string myDir = Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory.ToString());
        string nameOfFile = String.Empty, message = String.Empty;
        StreamWriter writer;

        //#######################################################################################
        //#################################### Constructors #####################################
        //#######################################################################################

        public Logger(string directory, string nameOfTxt)
        {
            myDir = directory;
            nameOfFile = nameOfTxt;
            SetNameOfFile();
            Init();
        }
        public Logger(string nameOfTxt)
        {
            myDir += @"\configs\Log\";
            nameOfFile = nameOfTxt;
            SetNameOfFile();
            Init();
        }
        public Logger()
        {
            myDir += @"\configs\Log\";
            SetNameOfFile();
            Init();
        }

        void Init()
        {
            try
            {
                writer = new StreamWriter(myDir + nameOfFile, append: true);
                VerifyAll();
            }
            catch(Exception ex)
            {
                ErrorWritter(ex);
            }
        }


        //#######################################################################################
        //#################################### Destructors ######################################
        //#######################################################################################

        public void KillMe()
        {
            Clear();
            writer.Close();
            writer.Dispose();
        }
        void Clear()
        {
            myDir = Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory.ToString());
            nameOfFile = String.Empty;
            message = String.Empty;
        }

        //#######################################################################################
        //#################################### Callers ##########################################
        //#######################################################################################

        public void Write(string Msg)
        {
            message = Msg;
            WriteTxt();
            Clear();
        }
        public void ChangeLine(string Msg)
        {
            message = Msg;
            JumpLine();
            WriteTxt();
            Clear();
        }
        public void ChangeLine()
        {
            JumpLine();
            Clear();
        }


        //######################################################################################
        //###################################### Work ##########################################
        //######################################################################################

        void VerifyAll()
        {
            string fileName = myDir + nameOfFile;

            if (Directory.Exists(myDir) == false)
                CreateDirectory();

            if (File.Exists(fileName) == false)
                FirstLine();
        }
        void CreateDirectory()
        {
            try
            {
                Directory.CreateDirectory(myDir);
            }
            catch (Exception ex)
            {
                ErrorWritter(ex);
            }
        }
        void FirstLine()
        {
            writer.WriteLine("LOG DO DIA: " + DateTime.Now.ToShortDateString());
            writer.WriteLine();
        }
        void SetNameOfFile()
        {
            if (nameOfFile == "")
                nameOfFile = DateTime.Now.ToString("d.MM.yyyy") + ".txt";
            else
                nameOfFile += "_" + DateTime.Now.ToString("d.M.yyyy") + ".txt";
        } 
        void WriteTxt()
        {
             writer.WriteLine(DateTime.Now.ToLongTimeString() + ": " + message);
        }
        void JumpLine()
        {
             writer.WriteLine();
        }
        void ErrorWritter(Exception exe)
        {
            using (StreamWriter writer = new StreamWriter(Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory.ToString()) + "UnknownError.txt"))
            {
                writer.Write(DateTime.Now.ToLongTimeString() + ": Exception Source: " + exe.Source + " Message:" + exe.Message);
                writer.Close();
            }
        }
    }
}