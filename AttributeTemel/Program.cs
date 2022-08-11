
using AttributeTemel;
// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

UrunEntity urn = new UrunEntity();
urn.UrunAdi = "Pentium CPU";
urn.Fiyat = 90;
urn.SonSatisTarihi = DateTime.Now.AddDays(30);
urn.Insert();




