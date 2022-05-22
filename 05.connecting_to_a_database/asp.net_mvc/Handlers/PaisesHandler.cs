using lab05.Models;
using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;


namespace lab05.Handlers
{
  public class PaisesHandler {
    private SqlConnection connection;
    private string connection_path;

    public PaisesHandler() {
      var builder = WebApplication.CreateBuilder();
      connection_path = builder.Configuration["ConnectionStrings:PaisesContext"];
      connection = new SqlConnection(connection_path);
    }

    private DataTable create_consult_table(string consulta) { 
      SqlCommand consult_command = new SqlCommand(consulta, connection);
      SqlDataAdapter table_adapter = new SqlDataAdapter(consult_command);
      DataTable consult_table_format = new DataTable();
      connection.Open();
      table_adapter.Fill(consult_table_format);
      connection.Close();

      return consult_table_format;
    }

    public List<PaisesModel> get_paises() { 
      List<PaisesModel> paises = new List<PaisesModel>();
      string consult = "SELECT * FROM dbo.PAIS";
      DataTable table_result = create_consult_table(consult);

      foreach (DataRow column in table_result.Rows) {
        paises.Add(new PaisesModel
        {
          Id = Convert.ToInt32(column["Id"]),
          Nombre = Convert.ToString(column["Nombre"]),
          Idioma = Convert.ToString(column["Idioma"]),
          Continente = Convert.ToString(column["Continente"]),
        });
      }

      return paises;
    }
  }
}
