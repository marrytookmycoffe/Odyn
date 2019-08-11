using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odyn.MotivationJournal.UserComunication
{
public class Engine
    {
        public Engine()
        {

        }

        public void Run()
        {
            using (ConsoleControl CONTROL = new ConsoleControl())
            {
                string line = Console.ReadLine();
                while (!string.IsNullOrWhiteSpace(line))
                {
                    if (line.ToLower() == "close")
                        break;
                    if (line.ToLower() == "help")
                        CONTROL.UserCommand("display help");
                    else
                        CONTROL.UserCommand(line);
                    line = Console.ReadLine();
                }
            }
        }
    }
}