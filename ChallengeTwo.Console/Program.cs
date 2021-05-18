using ChallengeTwo.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeTwo_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            ProgramUI ui = new ProgramUI();
            ProgramUI_Manager uiManager = new ProgramUI_Manager();

            Console.WriteLine("Please Select a Claim Interface\n" +
                "1. Claim Agent Tools\n" +
                "2. Claim Manager Tools");
            string input = Console.ReadLine();
            switch (input.ToLower())
            {
                case "1":
                case "agent":
                    ui.Run();
                    break;
                case "2":
                case "manager":
                    uiManager.Run();
                    break;
            }
        }
    }
}
