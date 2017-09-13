

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
        string nameOfFile = String.Empty, message = String.Empty, pastMessage = String.Empty;

        //#######################################################################################
        //#################################### Callers ##########################################
        //#######################################################################################

        public void Init(string directory, string nameOfTxt, string Msg)
        {
            myDir = directory;
            if (nameOfTxt == "")
                nameOfFile = DateTime.Now.ToShortDateString().Replace('/', '.') + ".txt";
            else
                nameOfFile = nameOfTxt + DateTime.Now.ToShortDateString().Replace('/', '.') + ".txt";

            message = Msg;
            try
            {
                if (VerifyDirectory() && VerifyTxt())
                    ReadTxt();

                else
                {
                    CreateTxt();
                    ReadTxt();
                }

                WriteTxt();
            }
            catch (Exception)
            {
                ErrorWritter();
                Clear();
                return;
            }
            Clear();
        }
        public void Init(string nameOfTxt, string Msg)
        {
            myDir += @"\configs\Log\";
            if (nameOfTxt == "")
                nameOfFile = DateTime.Now.ToShortDateString().Replace('/', '.') + ".txt";
            else
                nameOfFile = nameOfTxt + DateTime.Now.ToShortDateString().Replace('/','.') + ".txt";

            message = Msg;
            try
            {
                if (VerifyDirectory() && VerifyTxt())
                    ReadTxt();

                else
                {
                    CreateTxt();
                    ReadTxt();
                }

                WriteTxt();
            }
            catch(Exception)
            {
                ErrorWritter();
                Clear();
                return;
            }
            Clear();
        }
        public void Init(string Msg)
        {
            nameOfFile = DateTime.Now.ToShortDateString().Replace('/', '.') + ".txt";
            myDir += @"\configs\Log\";
            message = Msg;
            try
            {
                if (VerifyDirectory() && VerifyTxt())
                    ReadTxt();

                else
                {
                    CreateTxt();
                    ReadTxt();
                }

                WriteTxt();
            }
            catch (Exception)
            {
                ErrorWritter();
                Clear();
                return;
            }
            Clear();
        }

        public void InitChangeLine(string directory, string nameOfTxt, string Msg)
        {
            myDir = directory;
            if (nameOfTxt == "")
                nameOfFile = DateTime.Now.ToShortDateString().Replace('/', '.') + ".txt";
            else
                nameOfFile = nameOfTxt + DateTime.Now.ToShortDateString().Replace('/', '.') + ".txt";

            message = Msg;
            try
            {
                if (VerifyDirectory() && VerifyTxt())
                    ReadTxt();

                else
                {
                    CreateTxt();
                    ReadTxt();
                }

                WriteTxt_NewLine();
            }
            catch (Exception)
            {
                ErrorWritter();
                Clear();
                return;
            }
            Clear();
        }
        public void InitChangeLine(string nameOfTxt, string Msg)
        {
            myDir += @"\configs\Log\";
            if (nameOfTxt == "")
                nameOfFile = DateTime.Now.ToShortDateString().Replace('/', '.') + ".txt";
            else
                nameOfFile = nameOfTxt + DateTime.Now.ToShortDateString().Replace('/', '.') + ".txt";

            message = Msg;

            try
            {
                if (VerifyDirectory() && VerifyTxt())
                    ReadTxt();

                else
                {
                    CreateTxt();
                    ReadTxt();
                }

                WriteTxt_NewLine();
            }

            catch (Exception)
            {
                ErrorWritter();
                Clear();
                return;
            }
            Clear();
        }
        public void InitChangeLine(string Msg)
        {
            nameOfFile = DateTime.Now.ToShortDateString().Replace('/', '.') + ".txt";
            myDir += @"\configs\Log\";
            message = Msg;

            try
            {
                if (VerifyDirectory() && VerifyTxt())
                    ReadTxt();

                else
                {
                    CreateTxt();
                    ReadTxt();
                }

                WriteTxt_NewLine();
            }

            catch (Exception)
            {
                ErrorWritter();
                Clear();
                return;
            }
            Clear();
        }
        public void InitChangeLine()
        {
            nameOfFile = DateTime.Now.ToShortDateString().Replace('/', '.') + ".txt";
            myDir += @"\configs\Log\";
            try
            {
                if (VerifyDirectory() && VerifyTxt())
                    ReadTxt();

                else
                {
                    CreateTxt();
                    ReadTxt();
                }

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
            StreamWriter Log = new StreamWriter(myDir + nameOfFile);
            Log.WriteLine("LOG DO DIA: " + DateTime.Now.ToShortDateString());
            Log.Close();
            Log.Dispose();
            Log = null;
        }
        void ReadTxt()
        {
            StreamReader writer = new StreamReader(myDir + nameOfFile);
            pastMessage = writer.ReadToEnd();
            writer.Close();
            writer.Dispose();
            writer = null;
        }
        void WriteTxt()
        {
            StreamWriter writer = new StreamWriter(myDir + nameOfFile);
            writer.WriteLine(pastMessage);
            writer.Write(DateTime.Now.ToLongTimeString() + ": " + message);
            writer.Close();
            writer.Dispose();
            writer = null;
        }
        void WriteTxt_NewLine()
        {
            StreamWriter writer = new StreamWriter(myDir + nameOfFile);
            writer.WriteLine(pastMessage);
            writer.WriteLine();
            writer.Write(DateTime.Now.ToLongTimeString() + ": " + message);
            writer.Close();
            writer.Dispose();
            writer = null;
        }
        void JumpLine()
        {
            StreamWriter writer = new StreamWriter(myDir + nameOfFile);
            writer.WriteLine(pastMessage);
            writer.WriteLine();
            writer.Close();
            writer.Dispose();
            writer = null;
        }
        void Clear()
        {
            myDir = Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory.ToString());
            nameOfFile = String.Empty;
            message = String.Empty;
            pastMessage = String.Empty;
        }
        void ErrorWritter()
        {
            StreamWriter writer = new StreamWriter(Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory.ToString()) + "UnknownError.txt");
            writer.Write(DateTime.Now.ToLongTimeString() + ": " + "Verify your directory.");
            writer.Close();
            writer.Dispose();
            writer = null;
        }
    }
}