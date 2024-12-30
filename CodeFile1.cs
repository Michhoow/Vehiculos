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
            Console.WriteLine(new string('-', 154));
            for (int i = 0; i < reader.FieldCount; i++)
            {
                Console.Write($"| {reader.GetName(i),-15}");
            }
            Console.WriteLine("|");
            Console.WriteLine(new string('-', 154));


            while (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    Console.Write($"| {reader[i],-15}");
                }
                Console.WriteLine("|");
            }
            Console.WriteLine(new string('-', 154));

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
            Color.ToLower();
            while (Color != "azul" || Color != "rojo" || Color != "amarillo" || Color != "verde" || Color != "negro" || Color != "blanco")
            {
                Console.WriteLine("Color invalido, ingrese otra vez.");
            }
            Console.WriteLine("Ingrese el Tipo de vehiculo(sedan,suv,cambion): ");
            string Tipo = Console.ReadLine();
            Console.WriteLine("Ingrese la placa(6 digitos): ");
            string placa = Console.ReadLine();
            while (placa.Length < 6 || placa.Length > 6)
            {
                Console.WriteLine("La placa tiene que ser de 6 digitos.");
            }
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
        using SqlConnection connection = new SqlConnection(db);
        try
        {
            connection.Open();
            Console.WriteLine("Ingrese el ID del vehiculo a eliminar: ");
            string id = Console.ReadLine();
            string query3 = $"Delete from Vehiculos where id = {id}";
            using SqlCommand sqlCommand = new SqlCommand(query3, connection);

            int rowsaffected = sqlCommand.ExecuteNonQuery();


            if (rowsaffected > 0)
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
    public void update()
    {
        using SqlConnection sqlConnection = new SqlConnection(db);
        sqlConnection.Open();
        try
        {
            DataBase dbData = new DataBase();
            dbData.Test();
            Console.WriteLine("Pulse una tecla para continuar...");
            Console.ReadKey();

            // Pedir ID o placa
            Console.WriteLine("Ingrese el ID o placa del vehículo a actualizar: ");
            var query4 = Console.ReadLine();
            int query5;

            if (!int.TryParse(query4, out query5))
            {
                Console.WriteLine("Ingrese el nombre de la columna a cambiar: ");
                string columna = Console.ReadLine();
                Console.WriteLine("Ingrese el nuevo valor: ");
                var valor = Console.ReadLine();
                int valor2;
                if (int.TryParse(valor, out valor2))
                {

                    string consulta = $@"UPDATE Vehiculos SET {columna} = '{valor2}' WHERE placa = '{query4}'";
                    using SqlCommand sqlCommand = new SqlCommand(consulta, sqlConnection);


                    int rowsaffected = sqlCommand.ExecuteNonQuery();

                    if (rowsaffected > 0)
                    {
                        Console.WriteLine(@$"Vehiculo actualizado con exito {rowsaffected}s columnas actualizadas.");
                        Console.ReadKey();

                    }
                    else
                    {
                        Console.WriteLine("No hay vehiculos con esa placa, pulse una tecla para continuar.");
                        Console.ReadKey();
                    }

                }
                else
                {
                    string consulta2 = $@"UPDATE Vehiculos SET {columna} = {valor} WHERE placa = '{query4}'";
                    using SqlCommand sqlCommand = new SqlCommand(consulta2, sqlConnection);


                    int rowsaffected = sqlCommand.ExecuteNonQuery();

                    if (rowsaffected > 0)
                    {
                        Console.WriteLine(@$"Vehiculo actualizado con exito {rowsaffected}s columnas actualizadas.");
                        Console.ReadKey();

                    }
                    else
                    {
                        Console.WriteLine("No hay vehiculos con esa placa, pulse una tecla para continuar.");
                        Console.ReadKey();
                    }

                }
            }




            else
            {
                
                    Console.WriteLine("Ingrese el nombre de la columna a cambiar: ");
                    string columna = Console.ReadLine();
                    Console.WriteLine("Ingrese el nuevo valor: ");
                    var valor = Console.ReadLine();
                    int valor2;
                    if (int.TryParse(valor, out valor2))
                    {

                        string consulta = $@"UPDATE Vehiculos SET {columna} = '{valor2}' WHERE ID = {query4}";
                        using SqlCommand sqlCommand = new SqlCommand(consulta, sqlConnection);


                        int rowsaffected = sqlCommand.ExecuteNonQuery();

                        if (rowsaffected > 0)
                        {
                            Console.WriteLine(@$"Vehiculo actualizado con exito {rowsaffected}s columnas actualizadas.");
                            Console.ReadKey();

                        }
                        else
                        {
                            Console.WriteLine("No hay vehiculos con esa placa, pulse una tecla para continuar.");
                            Console.ReadKey();
                        }

                    }
                    else
                    {
                        string consulta2 = $@"UPDATE Vehiculos SET {columna} = {valor} WHERE placa = '{query4}'";
                        using SqlCommand sqlCommand = new SqlCommand(consulta2, sqlConnection);


                        int rowsaffected = sqlCommand.ExecuteNonQuery();

                        if (rowsaffected > 0)
                        {
                            Console.WriteLine(@$"Vehiculo actualizado con exito {rowsaffected}s columnas actualizadas.");
                            Console.ReadKey();

                        }
                        else
                        {
                            Console.WriteLine("No hay vehiculos con esa placa, pulse una tecla para continuar.");
                            Console.ReadKey();
                        }


                    }
                }
            
        }

        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
