using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ItemsCbTipoPersona
    {
        
            public string Name { get; set; }
            public int Value { get; set; }

            public ItemsCbTipoPersona(string name, int value)
            {
                Name = name;
                Value = value;
            }
            /*public override string ToString()
            {
                return Name;
            }*/
    }
}
