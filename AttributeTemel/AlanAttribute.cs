using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttributeTemel
{
    [AttributeUsage(AttributeTargets.Property)]
    class AlanAttribute : Attribute
    {

        public bool NullIcerebilir { get; set; }
        public string AlanAdi { get; set; }

        public bool Identity { get; set; }


        public AlanAttribute(string alaninAdi, bool identityMi, bool nullIcerirMi)
        {
                AlanAdi = alaninAdi;
                Identity = identityMi;
                NullIcerebilir = nullIcerirMi;

        }

        public AlanAttribute(string alaninAdi, bool identityMi) : this(alaninAdi,identityMi, true)
        {

        }

        public AlanAttribute(string alaninAdi)  : this(alaninAdi, true)
        {

        }

        public AlanAttribute()
        {

        }
    }
}
