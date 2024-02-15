using LibraryModel.Source.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace LibraryModel.Services.Menu
{
    public class BaseMenuService : IBaseMenu
    {
        internal int Choice;
        /*internal string Input;*/
        internal string MenuText { get; set; }
        internal int AmountOfMenuItems { get; set; }
        internal readonly string WrongChoiceText;
        public BaseMenuService()
        {
            //Input = string.Empty;
            WrongChoiceText = "\n\tВозможно, вы ввели некорректное число, попробуйте еще раз:\n";
            MenuText = string.Empty;
            //CheckMenuInput();
            //Navigate();
        }
        public void CheckMenuInput()
        {
            ConsoleKeyInfo userInput = Console.ReadKey();
            //Input = Console.ReadKey().ToString();
            if (char.IsDigit(userInput.KeyChar))
            {
                Choice = int.Parse(userInput.KeyChar.ToString());
                if (Choice == 0 || Choice > AmountOfMenuItems)
                {
                    Console.WriteLine(WrongChoiceText);
                    do
                    {
                        CheckMenuInput();
                    }
                    while (Choice != 0 && Choice <= AmountOfMenuItems);

                }
                else
                {
                    Navigate();
                }
            }
            else
            {
                Console.WriteLine(WrongChoiceText);
                CheckMenuInput();
            }
        }

        public void DrawMenu()
        {
            Console.WriteLine(MenuText);
        }

        protected virtual void Navigate()
        {

        }
    }
}
