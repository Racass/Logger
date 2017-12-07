# Logger
A simple class in C# to write a log

# Using

This logger will prints "LOG OF DAY: DD/MM/YYYY" in the first line when it creates the file.
After that will jump one line and start.
The line will follow the pattern: "HH:Min:Sec: "MESSAGE"
It's capable of write in different directorys than the pattern "CURRENT_DIRECTORY\configs\Log" and in differents files from the patter "YYYY\MM\DD.TXT". 

# Instructions

In the constructor, you can send a name of file and a new directory to the program.
for both new Direc and Name: Logger log = new Logger(DIRECTORY, NAME_OF_FILE);
for new Direc: Logger log = new Logger(Directory, "");
for just File name: Logger log = new Logger(Name_Of_File);
for standard just call a new instance withouth parameters


                

# Callers:
Write(string MESSAGE, bool [changeLine = false])
This caller will write in the log. It's required to have a Msg but changeLine is for standard false. If you want to put a line BEFORE the Msg, just send the load.


ChangeLine()
This caller will just jump one line in the log.

# Important

If you don't call KillMe() in the end of program/when you stop logging, the logger will not save the file and you will lost any new changes to the log.
