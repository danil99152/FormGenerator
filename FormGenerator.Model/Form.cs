using FormGenerator.Model.Models;
using System.Collections.Generic;

namespace FormGenerator.Model
{
    internal class Form
    {
        internal Form()
        {
            this.Items = new List<IControl>();
        }

        internal string Name { get; set; }
        internal List<IControl> Items { get; set; }
        internal string Postmessage { get; set; }
    }
}
