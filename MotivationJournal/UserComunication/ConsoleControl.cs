using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Odyn.MotivationJournal.UserComunication
{
    public class ConsoleControl:IDisposable
    {
        List<IItemTask> _TaskList;
        public List<IItemTask> TaskList { get { if (_TaskList is null) { _TaskList = new List<IItemTask>(); } return _TaskList; } set => _TaskList = value; }


        public bool UserCommand(string line)
        {
            IEnumerable<MethodInfo> arb = this.GetType().GetMethods().Where(e => e.GetCustomAttribute(typeof(CommandCategoryAttribute)) != null);

            foreach (var method in arb) // iterate through all found methods
            {
                if (method.GetCustomAttribute<CommandCategoryAttribute>() != null)
                {
                    var ConstructorArgument = method.CustomAttributes.First().ConstructorArguments;
                    string command = $"{(CommandType)ConstructorArgument[0].Value} {ConstructorArgument[1].Value}".ToLower();
                    if (command == line.ToLower())
                    {
                        return (bool)method.Invoke(this, new object[] { line }); // invoke the method
                    }
                }
            }
            return false;
        }
        [CommandCategory(CommandType.Add, "new task")]
        public bool AddNewTask(string line)
        {
            Console.WriteLine("Give name of task");
            var s =  Console.ReadLine();
            var t = new MotivationJournal.Action.ItemTask(s);
            Console.WriteLine("how much points it is worth");
            var points = Console.ReadLine();
            if(double.TryParse(points , out double dataP))
            {
                t.Points = dataP;
            }
            TaskList.Add(t);
            Console.WriteLine($"\n new Task was added  {t}");
            return true;
        }
        [CommandCategory(  CommandType.Display, "list task")]
        public bool DisplayTaskList(string line) 
        {
            if (TaskList.Count == 0)
                return false;
            TaskList.ForEach(e => Console.WriteLine(e.ToString()));
            return true;
        }

        [CommandCategory(CommandType.Display, "help")]
        public bool DisplayHelp(string line)
        {
            IEnumerable<MethodInfo> arb = this.GetType().GetMethods().Where(e => e.GetCustomAttribute(typeof(CommandCategoryAttribute)) != null);
            var comands = from command in arb.SelectMany(e => e.CustomAttributes)
                          where command.ConstructorArguments.Count == 2
                          select $"{(CommandType)command.ConstructorArguments[0].Value} {command.ConstructorArguments[1].Value}".ToLower();
            Console.WriteLine("Avaible Commands");
            Console.WriteLine();
            foreach (var item in comands)
            {
                Console.WriteLine(item);
            }
            return true;
        }

        public void Dispose()
        {
            
        }
    }

    [AttributeUsage(AttributeTargets.Method)]
    public class CommandCategoryAttribute : System.Attribute
    {
        public CommandCategoryAttribute(  CommandType type, string name)
        {
            
            Type = type;
            Name = name;
        }


        public CommandType Type { get; }
        public string Name { get; }

        public bool SchouldRun(string line) => $"{Type} {Name}".ToLower() == line;


        public override string ToString()
        {
            return $"{Type} {Name}".ToLower();
        }
    }

    public enum CommandType
    {
        Debug = -3,
        Test = -2,
        Error = -1,
        Invalid = 0,
        Get = 1,
        Set = 2,
        Display = 3,
        Add = 4,
        Delete =5,
        Replace =6,
        Clear =7,
        Dispose =8
    }

}
