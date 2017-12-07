using System;
using System.Text;
using System.IO;

namespace Class
{
    class Logger
    {
	    
	//#######################################################################################
	//#######################################################################################
	//				A simple to use Logger
	//				Script by Rafael Cassiolato 
	//#######################################################################################
	//#######################################################################################
		
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

        public void Write(string Msg, bool [changeLine = false])
        {
            message = Msg;
			if(changeLine)
				JumpLine();
            WriteTxt();
        }
        public void ChangeLine()
        {
            JumpLine();
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
            writer.WriteLine("DAY LOG: " + DateTime.Now.ToShortDateString());
            writer.WriteLine();
        }
        void SetNameOfFile()
        {
            if (nameOfFile == "")
                nameOfFile = DateTime.Now.ToString("yyyy.MM.d") + ".txt";
            else
                nameOfFile += "_" + DateTime.Now.ToString("yyyy.M.d") + ".txt";
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
