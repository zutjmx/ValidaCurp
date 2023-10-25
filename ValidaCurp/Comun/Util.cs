using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ValidaCurp.Comun
{
    class Util
    {
        public Util()
        {
            //Constructor por convención
        }

        public void ValidarCurpEmpleado()
        {
            string cadenaConexion = ConfigurationManager.ConnectionStrings["BDEnrolamiento"].ConnectionString;
            StringBuilder sb = new StringBuilder("");
            SqlConnection connection = null;
            string curp = "";

            try
            {
                connection = new SqlConnection
                {
                    ConnectionString = cadenaConexion
                };
                connection.Open();

                sb.Append("select EmployeeId, Name, LastName, MiddleName, PersonalNumber from Employees");
                sb.Append(" where EmployeeId not in ('IN097964')");
                sb.Append(" order by EmployeeId");

                SqlCommand comando = new SqlCommand(sb.ToString(), connection);
                SqlDataReader registro = comando.ExecuteReader();

                if(registro.HasRows)
                {
                    while (registro.Read())
                    {
                        curp = registro["PersonalNumber"].ToString();
                        if(!CurpValida(curp))
                        {
                            LogToFile("Curp: " + curp + ", invalida, IN: " + registro["EmployeeId"].ToString());
                        }
                    }
                }

                registro.Close();
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: ", ex.Message);
                LogToFile("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private bool CurpValida(string curp)
        {
            var re = @"^([A-Z][AEIOUX][A-Z]{2}\d{2}(?:0[1-9]|1[0-2])(?:0[1-9]|[12]\d|3[01])[HM](?:AS|B[CS]|C[CLMSH]|D[FG]|G[TR]|HG|JC|M[CNS]|N[ETL]|OC|PL|Q[TR]|S[PLR]|T[CSL]|VZ|YN|ZS)[B-DF-HJ-NP-TV-Z]{3}[A-Z\d])(\d)$";
            Regex rx = new Regex(re, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            var validado = rx.IsMatch(curp);

            if (!validado)  //Coincide con el formato general?
                return false;

            //Validar que coincida el dígito verificador
            if (!curp.EndsWith(DigitoVerificador(curp.ToUpper())))
                return false;

            return true; //Validado
        }

        private string DigitoVerificador(string curp17)
        {
            //Fuente https://consultas.curp.gob.mx/CurpSP/
            var diccionario = "0123456789ABCDEFGHIJKLMNÑOPQRSTUVWXYZ";
            var suma = 0.0;
            var digito = 0.0;
            for (var i = 0; i < 17; i++)
                suma = suma + diccionario.IndexOf(curp17[i]) * (18 - i);
            digito = 10 - suma % 10;
            if (digito == 10) return "0";
            return digito.ToString();
        }

        public void LogToFile(string text)
        {

            try
            {
                string filePrefix = "ValidaCurp";

                string extension;
                extension = "txt";

                string filePath = ConfigurationManager.AppSettings["rutaLog"];
                if (!Directory.Exists(filePath))
                    Directory.CreateDirectory(filePath);

                string fileName = $"{filePath}{filePrefix} {DateTime.Now.ToString("ddMMyyyy")}.{extension}";

                using (StreamWriter writer = new StreamWriter(fileName, append: true))
                {
                    writer.WriteLine(DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss:tt") + " :: " + text);
                    writer.Flush();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en LogToFile: " + ex.Message);
            }

        }

    }
}
