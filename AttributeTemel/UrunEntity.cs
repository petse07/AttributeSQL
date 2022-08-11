using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AttributeTemel
{
    [Tablo(SchemaAdi = "Production", TabloAdi = "Product")]
    public class UrunEntity
    {

        [Alan(AlanAdi = "ProductID", Identity = true, NullIcerebilir = false)]
        public int UrunId { get; set; }

        [Alan("Name", false, false)]
        public string UrunAdi { get; set; }


        [Alan("ListPrice", Identity = false, NullIcerebilir = false)]
        public decimal Fiyat { get; set; }

        [Alan("SellStartDate", false, true)]
        public DateTime SonSatisTarihi { get; set; }


        public UrunEntity(int idsi, string adi, decimal fiyati)
        {
            UrunId = idsi;
            UrunAdi = adi;
            Fiyat = fiyati;
        }
        public UrunEntity()
        {
        }


        public int Insert()
        {
            Type tip = this.GetType();
            TabloAttribute tblAtr = ((TabloAttribute[])tip.GetCustomAttributes(typeof(TabloAttribute), false))[0];
            string tabloAdi = tblAtr.TabloAdi;
            string schemaAdi = tblAtr.SchemaAdi;
            StringBuilder insertBuilder = new StringBuilder();
            insertBuilder.Append("Insert into ");
            insertBuilder.Append(schemaAdi);
            insertBuilder.Append(".");
            insertBuilder.Append(tabloAdi);
            insertBuilder.Append(" (");

            // Insert sorgusundaki alan adları çekiliyor.
            foreach (PropertyInfo prp in tip.GetProperties())
            {
                AlanAttribute atr = ((AlanAttribute[])prp.GetCustomAttributes(typeof(AlanAttribute), false))[0];
                if (!atr.Identity)
                {
                    string alanAdi = atr.AlanAdi;
                    insertBuilder.Append(alanAdi);
                    insertBuilder.Append(",");
                }
            }
            // Son eklenen virgülü kaldırmak için.
            insertBuilder.Remove(insertBuilder.Length - 1, 1);
            insertBuilder.Append(") Values (");

            // insert sorgusundaki değerleri çekiliyor.
            foreach (PropertyInfo prp in tip.GetProperties())
            {
                AlanAttribute atr = ((AlanAttribute[])prp.GetCustomAttributes(typeof(AlanAttribute), false))[0];
                if (!atr.Identity)
                {
                    object alanDegeri = prp.GetValue(this, null);
                    if ((prp.PropertyType.Name == "String")
                            || (prp.PropertyType.Name == "DateTime"))
                        insertBuilder.Append("'" + prp.GetValue(this, null).ToString() + "',");
                    else
                        insertBuilder.Append(prp.GetValue(this, null).ToString() + ",");
                }
            }
            insertBuilder.Remove(insertBuilder.Length - 1, 1);
            insertBuilder.Append(")");

            //Insert işlemi için gerekli sorgula çalıştırılır.

            return 0;
        }




    }
}
