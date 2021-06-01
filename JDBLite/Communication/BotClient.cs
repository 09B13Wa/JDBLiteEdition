using System;
using System.Collections.Generic;
using System.IO;

namespace Communication
{
    public class BotClient
    {
        private HashSet<Server> _servers;

        public BotClient(string name, string logFileName = "")
        {
            Name = name;
            AccessToken = -1;
            _servers = new HashSet<Server>();
            InitializeFileData(logFileName);
        }

        public BotClient(string name, long accessToken, string logFileName = "")
        {
            Name = name;
            AccessToken = accessToken;
            _servers = new HashSet<Server>();
            InitializeFileData(logFileName);
        }

        public BotClient(long accessToken, string logFileName = "")
        {
            Name = GetNameFromAccessToken(accessToken);
            AccessToken = accessToken;
            _servers = new HashSet<Server>();
            InitializeFileData(logFileName);
        }

        public string Name { get; private set; }
        public long AccessToken { get; private set; }
        public string LogFileName { get; private set; }
        private string LogFileLocation { get; set; }

        public void AddServer(Server server)
        {
            CheckServerAccess(server);
            _servers.Add(server);
        }
        private void CheckServerAccess(Server server)
        {
            throw new NotImplementedException();
        }

        private string GetNameFromAccessToken(long accessToken)
        {
            throw new NotImplementedException();
        }

        private void InitializeFileData(string providedFileName)
        {
            if (providedFileName == "")
                LogFileName = $"{Name}LogFile";
            else
                LogFileName = providedFileName;
            LogFileLocation = $"{Directory.GetCurrentDirectory()}{Path.PathSeparator}{LogFileName}";
        }
        
        public void WriteToLog(string toWrite, bool newLine = true, int maximumCharsPerLine = -1, int paragraphSeparation = 0)
        {
            StreamWriter writer = new StreamWriter(LogFileLocation);
            string formattedVersion = ToParagraph(toWrite, maximumCharsPerLine, paragraphSeparation);
            writer.Write(formattedVersion);
            if (newLine)
                writer.Write('\n');
            writer.Close();
        }
        
        public void WriteToLog(char[] chars, bool newLine = true, int maximumCharsPerLine = -1, int paragraphSeparation = 0)
        {
            string str = "";
            foreach (char character in chars)
                str += character;
            WriteToLog(str, newLine, maximumCharsPerLine, paragraphSeparation);
        }

        public void PrintToConsole(string toPrint, bool newLine = true, int maximumCharsPerLine = -1, int paragraphSeparation = 0)
        {
            string formattedVersion = ToParagraph(toPrint, maximumCharsPerLine, paragraphSeparation);
            Console.Write(formattedVersion);
            if (newLine)
                Console.Write('\n');
        }

        public void ToLogAndDisplay(string toPrint, bool newLine = true, int maximumCharsPerLine = -1,
            int paragraphSeparation = 0)
        {
            WriteToLog(toPrint, newLine, maximumCharsPerLine, paragraphSeparation);
            PrintToConsole(toPrint, newLine, maximumCharsPerLine, paragraphSeparation);
        }

        private string ToParagraph(string toParagraph, int maximumCharsPerLine, int paragraphSeparation)
        {
            string paragraphedVersion = "";
            int numbersOfCharOnLine = 0;
            string paragraphSeparationStr = "";
            for (int i = 0; i < paragraphSeparation; i++)
                paragraphSeparationStr += '\n';
            foreach (char character in toParagraph)
            {
                if (character == '\n')
                    paragraphedVersion += paragraphSeparationStr;
                else
                {
                    if (numbersOfCharOnLine == maximumCharsPerLine)
                    {
                        paragraphedVersion += '\n';
                        numbersOfCharOnLine = 0;
                    }

                    paragraphedVersion += character;
                    numbersOfCharOnLine += 1;
                }
            }

            return paragraphedVersion;
        }
    }
}