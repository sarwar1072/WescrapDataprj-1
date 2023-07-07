using VillaWebApi.Model;

namespace VillaWebApi.Data
{
    public static class DataStore
    {
        public static List<Villa> listVilla = new List<Villa> 
        {
            new Villa{Id=1,Name="Local Villa"},
            new Villa{Id=2,Name="Beach Villa"},
            new Villa{Id=3,Name="resort Villa"},
            new Villa{Id=4,Name="Coutage Villa"},

        };
    }
}
