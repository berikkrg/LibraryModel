using LibraryModel.Source.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace LibraryModel.Services.Menu
{
    /// <summary>
    /// The BaseMenuService class implements the IBaseMenu interface and provides a basic structure for a menu.
    /// </summary>
    public class BaseMenuService : IBaseMenu
    {
        internal int Choice;
        internal string MenuText { get; set; }
        internal int AmountOfMenuItems { get; set; }
        //// The text to be displayed when the user makes an incorrect choice.
        internal readonly string WrongChoiceText;
        /// <summary>
        /// The constructor for the BaseMenuService class.
        /// </summary>
        public BaseMenuService()
        {
            //Input = string.Empty;
            WrongChoiceText = "\n\tВозможно, вы ввели некорректное число, попробуйте еще раз:\n";
            MenuText = string.Empty;
            //CheckMenuInput();
            //Navigate();
        }

        /// <summary>
        /// The CheckMenuInput method handles user input within the menu.
        /// </summary>
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

        /// <summary>
        /// The DrawMenu method renders the menu.
        /// </summary>
        public void DrawMenu()
        {
            Console.WriteLine(MenuText);
        }

        /// <summary>
        /// The Navigate method is a placeholder for navigation logic, to be implemented in derived classes.
        /// </summary>
        protected virtual void Navigate()
        {

        }
    }
}
