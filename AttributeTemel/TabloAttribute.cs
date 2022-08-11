using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttributeTemel
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
    class TabloAttribute    : Attribute
    {


        public string TabloAdi { get; set; }

        public string SchemaAdi { get; set; }

        public TabloAttribute(string tablonunAdi, string shemaninAdi)
        {
            TabloAdi = tablonunAdi;
            SchemaAdi = shemaninAdi;
        }

        public TabloAttribute(string tablonunAdi)   : this(tablonunAdi, "dbo")
        {

        }

        public TabloAttribute()
        {

        }
    }
}
