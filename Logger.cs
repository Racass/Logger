

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Sonavox
{
    class Logger
    {
        string myDir = Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory.ToString());
        string nameOfFile = String.Empty, message = String.Empty;

        //#######################################################################################
        //#################################### Callers ##########################################
        //#######################################################################################

        public void Init(string directory, string nameOfTxt, string Msg)
        {
            myDir = directory;
            nameOfFile = nameOfTxt;
            message = Msg;
            SetNameOfFile();
            WriteLineController();
            Clear();
        }
        public void Init(string nameOfTxt, string Msg)
        {
            myDir += @"\configs\Log\";
            message = Msg;
            nameOfFile = nameOfTxt;
            SetNameOfFile();
            WriteLineController();
            Clear();
        }
        public void Init(string Msg)
        {
            SetNameOfFile();
            myDir += @"\configs\Log\";
            message = Msg;
            WriteLineController();
            Clear();
        }

        public void InitChangeLine(string directory, string nameOfTxt, string Msg)
        {
            myDir = directory;
            nameOfFile = nameOfTxt;
            SetNameOfFile();
            message = Msg;
            ChangeLineController();
            Clear();
        }
        public void InitChangeLine(string nameOfTxt, string Msg)
        {
            myDir += @"\configs\Log\";
            message = Msg;
            nameOfFile = nameOfTxt;
            SetNameOfFile();
            ChangeLineController();
            Clear();
        }
        public void InitChangeLine(string Msg)
        {
            SetNameOfFile();
            myDir += @"\configs\Log\";
            message = Msg;
            ChangeLineController();
            Clear();
        }
        public void InitChangeLine()
        {
            SetNameOfFile();
            myDir += @"\configs\Log\";
            try
            {
                VerifyAll();
                JumpLine();
            }

            catch (Exception)
            {
                ErrorWritter();
                Clear();
                return;
            }
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
                ErrorWritter();
                Clear();
                return;
            }
        }
        void ChangeLineController()
        {
            try
            {
                VerifyAll();
                WriteTxt_NewLine();
            }

            catch (Exception)
            {
                ErrorWritter();
                Clear();
                return;
            }

        }
        void VerifyAll()
        {
            if (!VerifyDirectory())
                CreateDirectory();

            if (!VerifyTxt())
                CreateTxt(); 
        }
        bool VerifyDirectory()
        {
            if (Directory.Exists(myDir))
                return true;

            else
            {
                if (CreateDirectory())
                    return true;
                else
                    return false;
            }
        }
        bool CreateDirectory()
        {
            try
            {
                Directory.CreateDirectory(myDir);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        bool VerifyTxt()
        {
            string fileName = myDir + nameOfFile;
            if (File.Exists(fileName))
                return true;
            else
                return false;
        }
        void CreateTxt()
        {
            using (StreamWriter writer = new StreamWriter(myDir + nameOfFile, append: true))
            {
                writer.WriteLine("LOG DO DIA: " + DateTime.Now.ToShortDateString());
                writer.WriteLine();
                writer.Close();
            }
        }
        void WriteTxt()
        {
            using (StreamWriter writer = new StreamWriter(myDir + nameOfFile, append: true))
            {
                writer.WriteLine(DateTime.Now.ToString("d.M.yyyy") + ": " + message);
                writer.Close();
            }
        }
        void SetNameOfFile()
        {
            if (nameOfFile == "")
                nameOfFile = DateTime.Now.ToString("d.MM.yyyy") + ".txt";
            else
                nameOfFile += "_" + DateTime.Now.ToString("d.M.yyyy") + ".txt";
        } 
        void WriteTxt_NewLine()
        {
            using (StreamWriter writer = new StreamWriter(myDir + nameOfFile, append: true))
            {
                writer.WriteLine();
                writer.WriteLine(DateTime.Now.ToLongTimeString() + ": " + message);
                writer.Close();
            }
        }
        void JumpLine()
        {
            using (StreamWriter writer = new StreamWriter(myDir + nameOfFile, append: true))
            {
                writer.WriteLine();
                writer.Close();
            }
        }
        void Clear()
        {
            myDir = Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory.ToString());
            nameOfFile = String.Empty;
            message = String.Empty;
        }
        void ErrorWritter()
        {
            using (StreamWriter writer = new StreamWriter(Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory.ToString()) + "UnknownError.txt"))
            {
                writer.Write(DateTime.Now.ToLongTimeString() + ": " + "Verify your directory.");
                writer.Close();
            }
        }
    }
}