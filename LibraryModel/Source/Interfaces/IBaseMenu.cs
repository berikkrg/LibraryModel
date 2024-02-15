using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryModel.Source.Interfaces
{
    public interface IBaseMenu
    {
        void DrawMenu();
        void CheckMenuInput();
        //abstract void Navigate();
    }
}
