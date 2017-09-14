# Logger
A simple class in C# to write a log

This class is capable of 2 init functions.

# Using

This logger will prints "LOG OF DAY: DD/MM/YYYY" in the first line when it creates the log.
After that will jump one line and start logging.
The line will follow the pattern: "HH:Min:Sec: "MESSAGE"
It's capable of write in different directorys than the pattern "ACTUAL_EXE_DIRECTORY\configs\Log" and in differents files from the patter "DD\MM\YYYY.TXT". 

# Instructions

In the caller, you CAN send a name of file and a new directory to the program.
Logger log = new Logger(DIRECTORY, NAME_OF_FILE);

If you don't want to, just call the Logger withouth parameters.

Call Logger.init() to write in the log.
INIT() has 1 load.

load 1: 
        
        Enter the MSG
                Enter the MSG that you want write.
                


Call Logger.InitChangeLine() to write in the log, jumping one line BEFORE the msg.
InitChangeLine() has 2 overloads. 1 is equal to Init.

  Overload 0:
  
        Enter nothing. It just jump a clean line withouth a message.
