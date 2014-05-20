using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace awsmSeeSharpGame.interfaces
{
    public interface IShape
    {
        int XPosition { get; set; }
        int YPosition { get; set; }
        float Rotation { get; set; }
        void Draw(PaintEventArgs e);
    }
}
