using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatBot
{
    internal class Library
    {
        public List<ChatBotData> data = new List<ChatBotData>();
        public void LoadData()
        {

            // read from file
            if (File.Exists("Program.cs/chatbotdata.txt"))
            {
                string[] lines = File.ReadAllLines("Program.cs/chatbotdata.txt");
                foreach (string line in lines)
                {
                    string[] parts = line.Split('|'); // Use '|' to separate subject and content
                    if (parts.Length == 2)
                    {
                        data.Add(new ChatBotData { Content = parts[1].Trim(), Subject = parts[0] });

                    }
                }
            }
        }

    }
}