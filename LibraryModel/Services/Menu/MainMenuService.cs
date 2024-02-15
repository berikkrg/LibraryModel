using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryModel.Services.Menu
{
    /// <summary>
    /// The MainMenuService class extends the BaseMenuService and provides the main menu for the application.
    /// </summary>
    public class MainMenuService : BaseMenuService
    {
        public MainMenuService()
        {
            MenuText = "Библиотека имени Абая\n" +
                  "__________________________________________\n" +
                  "\tДобро пожаловать в библиотеку\n" +
                  "__________________________________________\n" +
                  "\tВыберите операцию:\n" +
                  "\t1. Вывести список книг\n";
            AmountOfMenuItems = 1;
            DrawMenu();
            CheckMenuInput();
            //Navigate();
        }

        /// <summary>
        /// The Navigate method overrides the base Navigate method and provides navigation based on the user's choice.
        /// </summary>
        protected override void Navigate()
        {
            Console.Clear();
            if (Choice ==1)
            {
                ListOfBooksMenuService listOfBooksMenuService = new ListOfBooksMenuService();
            }
            //else if (Choice == 2)
            //{
            //    UpdateLibraryMenuService updateService = new UpdateLibraryMenuService();
            //}
            base.Navigate();
        }


    }
}
