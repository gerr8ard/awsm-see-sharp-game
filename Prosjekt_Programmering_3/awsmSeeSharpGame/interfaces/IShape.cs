using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace awsmSeeSharpGame.interfaces
{
    public interface IShape
    {
        float Rotation { get; set; }
        void Draw(PaintEventArgs e);
    }
}
