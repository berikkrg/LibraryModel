using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryModel.Services.Menu
{
    public class UpdateLibraryMenuService : BaseMenuService
    {
        public UpdateLibraryMenuService()
        {
            MenuText = "Библиотека\\Обновление данных\n" +
                      "_____________________________________________\n" +
                      "ОБНОВЛЕНИЕ ДАННЫХ ПО БИБЛИОТЕКЕ\n" +
                      "\tВыберите операцию:\n" +
                      "\t1. Добавить книгу\n" +
                      "\t2. Удалить книгу\n" +
                      "\t3. Исправить данные по книге\n" +
                      "\t4. Назад\n" +
                      "\t5. Вернуться в главное меню\n";
            AmountOfMenuItems = 5;
            DrawMenu();
            CheckMenuInput();
            //Navigate();
        }

        protected override void Navigate()
        {
            //if (Choice == 0 || Choice > AmountOfMenuItems)
            //{
            //    do
            //    {
            //        CheckMenuInput();
            //    }
            //    while (Choice != 0 && Choice <= AmountOfMenuItems);

            //}
            //else
            //{
            Console.Clear();

            if (Choice==5)
            {
                MainMenuService menuService = new MainMenuService();
            }
            //Console.WriteLine("Библиотека\\Обновление данных");
            //Console.WriteLine("ОБНОВЛЕНИЕ ДАННЫХ ПО БИБЛИОТЕКЕ");
            //Console.WriteLine("\tВыберите операцию:\t");
            //Console.WriteLine("\t1. Добавить книгу\n" +
            //    "\t2. Удалить книгу\n" +
            //    "\t3. Исправить данные по книге\n" +
            //    "\t4. Назад\n" +
            //    "\t5. Вернуться в главное меню\n");
            //}



            base.Navigate();
        }
    }
}
