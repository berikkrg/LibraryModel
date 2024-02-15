using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryModel.Services.Menu
{
    public class MainMenuService : BaseMenuService
    {
        public MainMenuService()
        {
            MenuText = "Библиотека имени Абая\n" +
                  "__________________________________________\n" +
                  "\tДобро пожаловать в библиотеку\n" +
                  "__________________________________________\n" +
                  "\tВыберите операцию:\n" +
                  "\t1. Вывести список книг\n" +
                  "\t2. Выдача/возврат книги(Inactive.Coming in version 2.0)\n" +
                  "\t3. Добавить/Удалить читателя(Inactive. Coming in verson 2.0)\n";
            AmountOfMenuItems = 1;
            DrawMenu();
            CheckMenuInput();
            //Navigate();
        }

        protected override void Navigate()
        {
            Console.Clear();
            if (Choice ==1)
            {
                ListOfBooksMenuService listOfBooksMenuService = new ListOfBooksMenuService();
            }
            else if (Choice == 2)
            {
                UpdateLibraryMenuService updateService = new UpdateLibraryMenuService();
            }
            base.Navigate();
        }


    }
}
