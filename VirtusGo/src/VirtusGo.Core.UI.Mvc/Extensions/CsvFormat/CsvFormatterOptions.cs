﻿namespace VirtusGo.Core.UI.Mvc.Extensions.CsvFormat
{
    public class CsvFormatterOptions
    {
        public bool UseSingleLineHeaderInCsv { get; set; } = true;

        public string CsvDelimiter { get; set; } = ";";

        public string Encoding { get; set; } = "ISO-8859-1";
        
        public bool UseNewtonsoftJsonDataAnnotations { get; set; } = false;
    }
}
