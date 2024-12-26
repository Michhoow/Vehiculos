using Microsoft.Data.SqlClient;
using System;
public class DataBase
{
    string db = @"Server=MICHAEL;Database=Vehiculosdb;Trusted_Connection=True;TrustServerCertificate=True;";
    string query = "Select * from Vehiculos";
  
    public void Test()
    {
        using SqlConnection connection = new SqlConnection(db);

        try
        {
            connection.Open();


            using SqlCommand command = new SqlCommand(query, connection);

            using SqlDataReader reader = command.ExecuteReader();

            Console.WriteLine("Datos de la tabla Vehículos:");
            Console.WriteLine(new string('-', 80));
            for (int i = 0; i < reader.FieldCount; i++)
            {
                Console.Write($"| {reader.GetName(i),-15}");
            }
            Console.WriteLine("|");
            Console.WriteLine(new string('-', 80));

            
            while (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    Console.Write($"| {reader[i],-15}");
                }
                Console.WriteLine("|");
            }
            Console.WriteLine(new string('-', 80));

        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }


    }

    public void agregar()
    {
        using SqlConnection connection = new SqlConnection(db);
        
        try
        {
            connection.Open();
            Console.WriteLine("Conexion exitosa.");
     
            Console.WriteLine($"Ingrese la marca del vehiculo: ");
            string Marca = Console.ReadLine();
            Console.WriteLine("Ingrese el modelo del vehiculo: ");
            string Modelo = Console.ReadLine();
            Console.WriteLine("Ingrese el año del vehiculo: ");
            int fecha = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese el color del vehiculo: ");
            string Color = Console.ReadLine();
            Console.WriteLine("Ingrese el Tipo de vehiculo(sedan,suv,cambion): ");
            string Tipo = Console.ReadLine();
            Console.WriteLine("Ingrese la placa(6 digitos): ");
            string placa = Console.ReadLine();
            Console.WriteLine("Ingrese los KM: ");
            int km = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese el precio: ");
            decimal precio = decimal.Parse(Console.ReadLine());

            string query2 = @$"INSERT INTO Vehiculos (Marca, Modelo, Año, Color, Tipo, Placa, Kilometraje, Precio) 
                               VALUES('{Marca}', '{Modelo}', '{fecha}', '{Color}', '{Tipo}', '{placa}', '{km}', '{precio}')";

            using SqlCommand sqlCommand = new SqlCommand(query2, connection);
            int rowsAffected = sqlCommand.ExecuteNonQuery();

            Console.WriteLine($"{rowsAffected} vehículo(s) agregado(s) correctamente.");


        }

        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    public void borrar()
    {
        using SqlConnection connection = new SqlConnection( db );
        try
        {
            connection.Open();
            Console.WriteLine("Ingrese el ID del vehiculo a eliminar: ");
            string id = Console.ReadLine();
            string query3 = $"Delete from Vehiculos where id = {id}";
            using SqlCommand sqlCommand = new SqlCommand( query3, connection);
            
            int rowsaffected = sqlCommand.ExecuteNonQuery();


            if (rowsaffected >0)
            {
                Console.WriteLine("Vehiculo eliminado correctamente, pulse una tecla para continuar.");
                Console.ReadKey();

            }
            else
            {
                Console.WriteLine("No hay vehiculos con ese ID, pulse una tecla para continuar.");
                Console.ReadKey();
            }
        }

        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
