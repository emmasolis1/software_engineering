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

    public bool CrearPais(PaisesModel pais)
    {
      var consulta = @"INSERT INTO [dbo].[Pais] ([Nombre],[Idioma] ,[Continente]) VALUES(@Nombre, @Idioma, @Continente) ";
      var comandoParaConsulta = new SqlCommand(consulta, connection);
      comandoParaConsulta.Parameters.AddWithValue("@Nombre", pais.Nombre); comandoParaConsulta.Parameters.AddWithValue("@Idioma", pais.Idioma); comandoParaConsulta.Parameters.AddWithValue("@Continente", pais.Continente);
      connection.Open();
      bool exito = comandoParaConsulta.ExecuteNonQuery() >= 1;
      connection.Close();
      return exito;
    }

    public bool EditarPais(PaisesModel pais) {
      var consulta = @"UPDATE [dbo].[Pais] SET Nombre = @Nombre,
                        Idioma = @Idioma,
                        Continente = @Continente
                      WHERE Id=@Id ";
      var comandoParaConsulta = new SqlCommand(consulta, connection);
      comandoParaConsulta.Parameters.AddWithValue("@Id", pais.Id);
      comandoParaConsulta.Parameters.AddWithValue("@Nombre", pais.Nombre);
      comandoParaConsulta.Parameters.AddWithValue("@Idioma", pais.Idioma);
      comandoParaConsulta.Parameters.AddWithValue("@Continente", pais.Continente);

      connection.Open();
      bool exito = comandoParaConsulta.ExecuteNonQuery() >= 1;
      connection.Close();

      return exito;
    }

    public bool BorrarPais(int identificador) {
      var consulta = @"DELETE [dbo].[Pais] WHERE Id = @Id";
      var query = new SqlCommand(consulta, connection);
      query.Parameters.AddWithValue("@Id", identificador);

      connection.Open();
      bool exito = query.ExecuteNonQuery() >= 1;
      connection.Close();

      return exito;
    }

  }
}
