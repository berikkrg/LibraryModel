using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryModel.Source.Interfaces
{
    /// <summary>
    /// The IBaseMenu interface declares the structure for a basic menu.
    /// </summary>
    public interface IBaseMenu
    {
        //this method is responsible for rendering the menu on console app
        void DrawMenu();
        //method for handling user input within the menu
        void CheckMenuInput();
    }
}
