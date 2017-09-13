# Logger
A simple class in C# to write a log

This class is capable of 2 init functions.

# Using

This logger will prints "LOG OF DAY: DD/MM/YYYY" in the first line when it creates the log.
After that will jump one line and start logging.
The line will follow the pattern: "HH:Min:Sec: "MESSAGE"
It's capable of write in different directorys than the pattern "ACTUAL_EXE_DIRECTORY\configs\Log" and in differents files from the patter "DD\MM\YYYY.TXT". 

# Instructions

Call Logger.init() to write in the log.
INIT() has 3 overloads.

  Overload 1: 
  
        Enter the DIRECTORY OF FILE
                The DIRECTORY is by pattern the actual directory of the file + "\configs\Log", and you can add a custom directory 
                by using this.
        Enter the NAME of the file
                the NAME is by pattern the day in the format "DD.MM.YYYY.txt", but u can rename it using this.
        
        Enter the MSG
                Enter the MSG that you want
                
 Overload 2:
 
        Enter the NAME of the file
                the NAME is by pattern the day in the format "DD.MM.YYYY.txt", but u can rename it using this.
        
        Enter the MSG
                Enter the MSG that you want
                
                
  Overload 1:
  
        Enter the MSG
                Enter the MSG that you want
                


Call Logger.InitChangeLine() to write in the log, jumping one line BEFORE the msg.
InitChangeLine() has 4 overloads. 3 of them equals to INIT.

  Overload 0:
  
        Enter nothing. It just jump a clean line withouth a message.
