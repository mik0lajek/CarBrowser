namespace CarGate.Configuration
{    public class CepikEndpoints
    {
        public string Version { get; set; }
        public string VersionV1 { get; set; }
        public string Vehicles { get; set; }
        public string Files { get; set; }
        public CepikDictionaryEndpoints Dictionaries { get; set; }
    }

    public class CepikDictionaryEndpoints {
        public string Voivodeships { get; set; } 
    }

}
