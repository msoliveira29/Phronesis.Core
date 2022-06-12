using System.Globalization;

namespace Phronesis.Core.Infra.CrossCutting
{
    /// <summary>
    /// Author...............: Marcelo Souza de Oliveira.
    /// Creation/Change Date.: 30/03/2022.
    /// Description..........: .
    /// Reason...............: .
    /// </summary>
    /// <remarks></remarks>
    public class Funcoes
    {
        #region Attributes

        private const string CARACTERES = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        private static readonly Random _rng = new();

        #endregion

        #region Properties
        #endregion

        #region Constructors
        #endregion

        #region Methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static string FormatPhoneNumber(string number)
        {
            var numberAux = long.Parse(number);

            if (numberAux.ToString().Length == 10)
            {
                return numberAux.ToString(@"(00) 0000-0000");
            }

            return numberAux.ToString(@"(00) 00000-0000");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="codigo"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static string GenerateHexadecimalCode(string codigo)
        {
            return long.Parse(codigo, NumberStyles.HexNumber).ToString("d4");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tamanho"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static string GenerateRandomCode(int tamanho)
        {
            char[] buffer = new char[tamanho];
            for (int i = 0; i < tamanho; i++)
            {
                buffer[i] = CARACTERES[_rng.Next(CARACTERES.Length)];
            }
            return new string(buffer);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="estado"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static string GetSiglaEstado(string estado)
        {
            var sigla = string.Empty;
            switch (estado)
            {
                case "Acre":
                    sigla = "AC";
                    break;
                case "Alagoas":
                    sigla = "AL";
                    break;
                case "Amapá":
                    sigla = "AP";
                    break;
                case "Amazonas":
                    sigla = "AM";
                    break;
                case "Bahia":
                    sigla = "BA";
                    break;
                case "Ceará":
                    sigla = "CE";
                    break;
                case "Distrito Federal":
                    sigla = "DF";
                    break;
                case "Espírito Santo":
                    sigla = "ES";
                    break;
                case "Goiás":
                    sigla = "GO";
                    break;
                case "Maranhão":
                    sigla = "MA";
                    break;
                case "Mato Grosso":
                    sigla = "MT";
                    break;
                case "Mato Grosso do Sul":
                    sigla = "MS";
                    break;
                case "Minas Gerais":
                    sigla = "MG";
                    break;
                case "Pará":
                    sigla = "PA";
                    break;
                case "Paraíba":
                    sigla = "PB";
                    break;
                case "Paraná":
                    sigla = "PR";
                    break;
                case "Pernambuco":
                    sigla = "PE";
                    break;
                case "Piauí":
                    sigla = "PI";
                    break;
                case "Rio de Janeiro":
                    sigla = "RJ";
                    break;
                case "Rio Grande do Norte":
                    sigla = "RN";
                    break;
                case "Rio Grande do Sul":
                    sigla = "RS";
                    break;
                case "Rondônia":
                    sigla = "RO";
                    break;
                case "Roraima":
                    sigla = "RR";
                    break;
                case "Santa Catarina":
                    sigla = "SC";
                    break;
                case "São Paulo":
                    sigla = "SP";
                    break;
                case "Sergipe":
                    sigla = "SE";
                    break;
                case "Tocantins":
                    sigla = "TO";
                    break;
                default:
                    break;
            }
            return sigla;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="estado"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static string GetRegiaoEstado(string estado)
        {
            string regiao = string.Empty;
            switch (estado)
            {
                case "Acre":
                case "Amapá":
                case "Amazonas":
                case "Pará":
                case "Rondônia":
                case "Roraima":
                case "Tocantins":
                    regiao = "Norte";
                    break;
                case "Alagoas":
                case "Bahia":
                case "Ceará":
                case "Maranhão":
                case "Paraíba":
                case "Pernambuco":
                case "Piauí":
                case "Rio Grande do Norte":
                case "Sergipe":
                    regiao = "Nordeste";
                    break;
                case "Distrito Federal":
                case "Goiás":
                case "Mato Grosso":
                case "Mato Grosso do Sul":
                    regiao = "Centro-Oeste";
                    break;
                case "Espírito Santo":
                case "Minas Gerais":
                case "Rio de Janeiro":
                case "São Paulo":
                    regiao = "Sudeste";
                    break;
                case "Paraná":
                case "Rio Grande do Sul":
                case "Santa Catarina":
                    regiao = "Sul";
                    break;
                default:
                    break;
            }
            return regiao;
        }

        #endregion
    }
}
