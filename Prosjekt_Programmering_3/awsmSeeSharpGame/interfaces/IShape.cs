using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace awsmSeeSharpGame.interfaces
{

    /// <summary>
    /// Skrevet av Dag Ivarsøy
    /// </summary>
    public interface IShape
    {
        float Rotation { get; set; }
        void Draw(PaintEventArgs e);
    }
}
