using System;
using System.Collections.Generic;
using System.Linq;
using VirtusGo.Core.Domain.Beneficiarios;
using VirtusGo.Core.Domain.Enums;

namespace VirtusGo.Core.Domain
{
    public class Util
    {
        public static string ReplaceMonetary(string input)
        {
            return input == null ? "0" : input.Replace("R$", "").Replace(".", "").Replace(",", ",").Trim();
        }

        public static string ReplaceMonetaryKeepComma(string input)
        {
            return input == null ? "0" : input.Replace("R$", "").Replace(".", "").Trim();
        }

        public static string ReplaceSpecialChar(string input)
        {
            var output = input;

            output = output.Replace("&#225;", "á");
            output = output.Replace("#Aacute#", "Á");
            output = output.Replace("#aacute#", "á");
            output = output.Replace("#Agrave#", "À");
            output = output.Replace("#agreve#", "à");
            output = output.Replace("#Atilde#", "Ã");
            output = output.Replace("#atilde#", "ã");
            output = output.Replace("#Acirc#", "Â");
            output = output.Replace("#acirc#", "â");
            output = output.Replace("#Ccedil#", "Ç");
            output = output.Replace("#ccedil#", "ç");
            output = output.Replace("#Eacute#", "É");
            output = output.Replace("#eacute#", "é");
            output = output.Replace("#Ecirc#", "Ê");
            output = output.Replace("#ecirc#", "ê");
            output = output.Replace("#Iacute#", "Í");
            output = output.Replace("#iacute#", "í");
            output = output.Replace("#Ntilde#", "N");
            output = output.Replace("#ntilde#", "ñ");
            output = output.Replace("#Oacute#", "Ó");
            output = output.Replace("#oacute#", "ó");
            output = output.Replace("#Otilde#", "Õ");
            output = output.Replace("#otilde#", "õ");
            output = output.Replace("#Ocirc#", "Ô");
            output = output.Replace("#ocirc#", "ô");
            output = output.Replace("#Uacute#", "Ú");
            output = output.Replace("#uacute#", "ú");
            output = output.Replace("#Uuml#", "Ü");
            output = output.Replace("#uuml#", "ü");
            output = output.Replace("#!#", "¡");
            output = output.Replace("#?#", "¿");
            output = output.Replace("#-#", "–");

            return output;
        }

        public static string CNPJSomenteNumeros(string input)
        {
            return input.Replace(".", "").Replace("/", "").Replace("-", "").Trim();
        }

        public static string CnpjSomenteNumeros(string input)
        {
            return input.Replace(".", "").Replace("/", "").Replace("-", "").Trim();
        }
        public static string CNPJFormatar(string input)
        {
            return Convert.ToUInt64(input).ToString(@"00\.000\.000\/0000\-00");
        }

        public static string FormatCNPJ(string input)
        {
            return CNPJFormatar(input);
        }

        public static string GetRaizCnpj(string input)
        {
            return input.Substring(0, 10);
        }

        public static string ToPrefixCnpj(string value)
        {
            return string.IsNullOrWhiteSpace(value) ? value : value.Substring(0, value.IndexOf('/'));
        }

        public static int DateDiff(DateTime dt1, DateTime dt2)
        {
            var days = (dt2 - dt1).TotalDays;
            return (int)Math.Round(days);
        }
        /// <summary>
        /// Transforma os itens do enum em um dictionary de key(valor inteiro do enum)/value(descricao do enum)
        /// </summary>
        /// <typeparam name="T">Tipo do Enum</typeparam>
        /// <returns> Dictionary&lt;int,string&gt; onde: int eh o valor do enum, string é descrição/nome do enum </returns>
        /// 
        //public static Dictionary<int, string> EnumAsDictionary<T>()
        //{
        //    var itens = ((Int32[])Enum.GetValues(typeof(T))).Cast<T>().ToList();
        //    var lista = new Dictionary<int, string>();
        //    itens.ForEach(x =>
        //    {
        //        lista.Add(Convert.ToInt32((x as Enum)), (x as Enum).GetEnumDisplayName());
        //    });
        //    return lista;
        //}

        public static List<dynamic> CompareProperties<T>(T self, T to, params string[] ignore) where T : class
        {
            var ret = new List<dynamic>();
            if (self != null && to != null)
            {
                Type type = typeof(T);
                List<string> ignoreList = new List<string>(ignore);
                foreach (System.Reflection.PropertyInfo pi in type.GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance))
                {
                    if (!ignoreList.Contains(pi.Name))
                    {
                        object selfValue = type.GetProperty(pi.Name).GetValue(self, null);
                        object toValue = type.GetProperty(pi.Name).GetValue(to, null);

                        if (selfValue != toValue && (selfValue == null || !selfValue.Equals(toValue)))
                        {
                            ret.Add(new { PropertyName = pi.Name, SelfValue = selfValue, ToValue = toValue });
                        }
                    }
                }

            }
            return ret;
        }

        public static List<string> UfList()
        {
            return new[] { "AC", "AL", "AM", "AP", "BA", "CE", "DF", "ES", "GO", "MA", "MG", "MS", "MT", "PA", "PB", "PE", "PI", "PR", "RJ", "RN", "RO", "RR", "RS", "SC", "SE", "SP", "TO" }.ToList();
        }
        public class PontuacaoEmpresaGrid
        {
            public int Id { get; set; }
            public string Parceiro { get; set; }
            public string ValorTotal { get; set; }
            public string PontosCreditados { get; set; }
            public string CustoDosPontosCreditados { get; set; }
            public string ComissaoVirtus { get; set; }
            public string ValorFaturar { get; set; }
            public string NomeBeneficiado { get; set; }
            public string Email { get; set; }
            
            // ( Valor a faturar - Spread ) * 0.20;
            public string ComissaoResgate { get; set; }
        }

        public class PontuacaoBeneficiarioGrid
        {
            public int BeneficiarioId { get; set; }
            public Beneficiario Beneficiarios { get; set; }
            public DateTime DataCompra { get; set; }
            public DateTime? DataAlteracao { get; set; }
            public DateTime? DataInterface { get; set; }
            public DateTime DataLancamento { get; set; }
            public string DescricaoErroInterface { get; set; }
            public int EmpresaId { get; set; }
            public string FlagErroInterface { get; set; }
            public FlagExcluidoEnum FlagExcluido { get; set; }
            public string FlagInterface { get; set; }
            public int Id { get; set; }
            public int? UnidadeId { get; set; }
            public int? UsuarioIdAlteracao { get; set; }
            public int UsuarioIdCriacao { get; set; }
            public int? UsuarioIdInterface { get; set; }
            public double ValorLancamento { get; set; }
            public double ValorTotal { get; set; }
            public double PontosCreditados { get; set; }
            public double CustoDosPontosCreditados { get; set; }
            public double ComissaoVirtus { get; set; }
            public double ValorFaturar { get; set; }
            
            // ( Valor a faturar - Spread ) * 0.20;
            public string ComissaoResgate { get; set; }
        }

        //public static string FormatCep(string cepString)
        //{
        //    return cepString.ExtractOnlyNumbers().ToInt().ToString(@"00000\-000");
        //}
    }
}