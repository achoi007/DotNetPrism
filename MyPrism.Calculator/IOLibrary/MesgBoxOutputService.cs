using MyPrism.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IOLibrary
{
    public class MesgBoxOutputService : IOutputService
    {
        public void WriteMessage(string mesg)
        {
            MessageBox.Show(mesg, "Message", MessageBoxButtons.OK);
        }
    }
}
