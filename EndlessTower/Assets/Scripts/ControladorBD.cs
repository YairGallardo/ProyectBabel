using UnityEngine;
using System.Data;
using Mono.Data.Sqlite;
using System.IO;
using System.Collections.Generic;

public class ControladorBD {

    public string NombreDB="proyectobabel";
  

    /*      BASE DE DATOS :  proyectobabel
     * 1) DatosActuales :   Nombre(string); Dinero(int);    Piso(int);  Arma(string); Nivel_arma;
     * 
     * 2) Armas:     Codigo(string);    Nombre(string); Descripcion(string);    Nivel_maximo(int);  Nivel_actual(int);  Estado(string);
     * -> Estados:  Comprada  : Arma ya comprada, se muestra en el inventario y en mejoras si esque no esta a maximo nivel
     *              Bloqueada : Arma que se muesra solo en venta de armas, el estado cambia al ser comprada
     *              Oculta    : Arma que aun no esta habilitada para su compra 
     *              
     * 3) Tablas de codigo : tablas con nombre del codigo del arma. almacenan las caracteristicas de cada nivel del arma
     * Nivel(int);  Daño(int);  Porcentaje(int);    Elemento(string);   Coste_siguiente(int).
     */
    IDbConnection dbcon;

    public void conexion() {
        //string localp = "C:/Users/Vinzo/AppData/LocalLow/Electivo/Proyecto Babel/proyectobabel.db";
        string androidp = Application.persistentDataPath + " /" + "proyectobabel.db";
        string connection = "URI=file:" + androidp;
        //Debug.Log(connection);
        dbcon = new SqliteConnection(connection);
        dbcon.Open();
        Debug.Log("Conexion exitosa");
    }

    public IDataReader consultar(string consulta)
    {
        //regresa un "reader" con la consulta ya realizada
        IDbCommand cmnd_read = dbcon.CreateCommand();
        IDataReader reader;
        cmnd_read.CommandText = consulta;
        reader = cmnd_read.ExecuteReader();
        return reader;
    }

    public string[] obtenerDatosInicio() {
        string[] datos = new string[7];
        conexion();
        IDbCommand cmnd_read = dbcon.CreateCommand();
        IDataReader reader;
        string query = "SELECT * FROM DatosActuales";
        cmnd_read.CommandText = query;
        reader = cmnd_read.ExecuteReader();


        string nivelArma = "1";
        while (reader.Read()) {
            datos[0] = reader[0].ToString(); // nombre
            datos[1] = reader[1].ToString(); // Dinero
            datos[2] = reader[2].ToString();   // Piso
            datos[3] = reader[3].ToString();   // Arma

            nivelArma = reader[4].ToString(); //nivel arma
            //datos[4] atake arma
            //datos[5] % efecto
            //datos[6] elemento
        }

        string consulta2 = "SELECT * FROM " + datos[3] + " WHERE Nivel='" + nivelArma + "'";
        IDataReader readerC2 = consultar(consulta2);
        //datos recibidos 
        //0-Nivel, 1-Daño, 2-Porcentaje, 3-Elemento, 4-Coste_siguiente;
        while (readerC2.Read())
        {
            datos[4] = readerC2[1].ToString(); // 
            datos[5] = readerC2[2].ToString(); // 
            datos[6] = readerC2[3].ToString(); // 
        }
   
    dbcon.Close();
        return datos;
    }

    public List<string[]> obtenerInventario() {
        //envia una lista de todas las armas que actualmente el jugador posee para cargarse
        //en la pantalla de seleccion de arma.
        conexion();
        //1) obtener el listado de armas que estan compradas
        string consulta1 = "SELECT * FROM Armas WHERE Estado='Comprada'";
        IDataReader readerC1 = consultar(consulta1);
        List<string[]> armas = new List<string[]>();
        /* Los datos en la BD estan como :
         * 0) Codigo        1) Nombre   2) Descripcion 
         * 3) Nivel_maximo  4) Nivel_actual     5)Estado
         * Necesitamos 0, 1, 2 y 4.
         * Cada elemento de nuestra lista enlazada sera 
         * String[Codigo, Nombre, Descripcion, Nivel_Actual]
         */

        while (readerC1.Read()) {
            string[] elemento = {
                readerC1[0].ToString(),  // [0] = Codigo
                readerC1[1].ToString(),  // [1] = Nombre
                readerC1[2].ToString(),  // [2] = Descripcion
                readerC1[4].ToString()   // [3] = Nivel_Actual 
            };
            armas.Add(elemento);
        };
        // Al finalizar tendremos una lista de todas las armas compradas junto a datos de estas.
        // ahora faltaria llenar cada arma con sus caracteristicas especificas.
        List<string[]> armasDetalle = new List<string[]>();
        //esta lista ademas de poseer los datos basicos del arma llevara tambien el ataque correspondiente
        //las habilidades y otras cosas para poder mostrarlas correctamente.

        foreach (string[] elemento in armas) {
            string codigo = elemento[0];
            string nivel = elemento[3];
            string consulta2 = "SELECT * FROM "+codigo+" WHERE Nivel='"+nivel+"'";
            Debug.Log(consulta2);
            IDataReader readerC2 = consultar(consulta2);
            //datos recibidos 
            //0-Nivel, 1-Daño, 2-Porcentaje, 3-Elemento, 4-Coste_siguiente;
            while (readerC2.Read()) {
                string[] armaCompleta =
                {
                    elemento[0],            // [0] = Codigo
                    elemento[1],            // [1] = Nombre 
                    elemento[2],            // [2] = Descripcion
                    readerC2[3].ToString(), // [3] = Elemento
                    readerC2[1].ToString(), // [4] = Daño
                    readerC2[2].ToString(), // [5] = Porcentaje
                };
                armasDetalle.Add(armaCompleta);
            };
        }
        dbcon.Close();
        return armasDetalle;
    }

    public List<string[]> obtenerTienda() {
        /*
         * Regresa una Lista enlazada en la cual cada elemnto es un Arreglo de tamaño [7] que contiene todos los datos
         * de las armas que estan en la tienda esperano para ser compradas. las posiciones en el arreglo corresponden a lo siguiente
         *                     
         * [0] = Codigo
         * [1] = Nombre 
         * [2] = Descripcion
         * [3] = Coste de compra
         * [4] = Elemento
         * [5] = Daño
         * [6] = Porcentaje
         */

        conexion();
        string consulta1 = "SELECT * FROM Armas WHERE Estado='Bloqueada'";
        IDataReader readerC1 = consultar(consulta1);
        List<string[]> armas = new List<string[]>();
        /* Los datos en la BD estan como :
         * [0] Codigo        
         * [1] Nombre          
         * [2] Descripcion 
         * [3] Nivel_maximo  
         * [4] Nivel_actual     
         * [5] Estado
         * [6] Coste
         */
        while (readerC1.Read())
        {
            string[] elemento = {
                readerC1[0].ToString(),  // [0] = Codigo
                readerC1[1].ToString(),  // [1] = Nombre
                readerC1[2].ToString(),  // [2] = Descripcion
                readerC1[3].ToString(),  // [3] = Coste
            };
            armas.Add(elemento);
        };
       

        List<string[]> armasDetalle = new List<string[]>();

        foreach (string[] elemento in armas)
        {
            string codigo = elemento[0];
            string nivel = elemento[3];
            string consulta2 = "SELECT * FROM " + codigo + " WHERE Nivel='1'";
            IDataReader readerC2 = consultar(consulta2);
            /* Los datos en la BD estan como :
            * [0] Nivel        
            * [1] Daño          
            * [2] Porcentaje 
            * [3] Elemento  
            * [4] Coste_siguiente (nivel)     
            */
            while (readerC2.Read())
            {
                string[] armaCompleta =
                {
                    elemento[0],            // [0] = Codigo
                    elemento[1],            // [1] = Nombre 
                    elemento[2],            // [2] = Descripcion
                    elemento[3],            // [3] = Coste 
                    readerC2[3].ToString(), // [4] = Elemento
                    readerC2[1].ToString(), // [5] = Daño
                    readerC2[2].ToString(), // [6] = Porcentaje
                };
                armasDetalle.Add(armaCompleta);
            };
        }
        dbcon.Close();
        return armasDetalle;
    }

    public List<string[]> obtenerMejoras ()
    {
        /*
         * Regresa una Lista enlazada en la cual cada elemnto es un Arreglo de tamaño [8] que contiene todos los datos
         * de las armas que estan compradas y aun tienen mejoras en la tienda. las posiciones en el arreglo corresponden a lo siguiente
         *                     
         * [0] = Codigo
         * [1] = Nombre 
         * [2] = Descripcion
         * [3] = Nivel Actual
         * [4] = Elemento
         * [5] = Daño al mejorar
         * [6] = Porcentaje al mejorar
         * [7] = Coste de mejora
         */

        conexion();
        string consulta1 = "SELECT * FROM Armas WHERE Estado='Comprada' AND Nivel_actual <> Nivel_maximo";
        IDataReader readerC1 = consultar(consulta1);
        List<string[]> armas = new List<string[]>();
        /* Los datos en la BD estan como :
         * [0] Codigo        
         * [1] Nombre          
         * [2] Descripcion 
         * [3] Nivel_maximo  
         * [4] Nivel_actual     
         * [5] Estado
         * [6] Coste
         */
        while (readerC1.Read())
        {
            string[] elemento = {
                readerC1[0].ToString(),  // [0] = Codigo
                readerC1[1].ToString(),  // [1] = Nombre
                readerC1[2].ToString(),  // [2] = Descripcion
                readerC1[4].ToString(),  // [3] = Nivel actual
            };
            armas.Add(elemento);
        };


        List<string[]> armasDetalle = new List<string[]>();

        foreach (string[] elemento in armas)
        {
            string codigo = elemento[0];
            string nivel = elemento[3];
            string consulta2 = "SELECT * FROM " + codigo + " WHERE Nivel='"+int.Parse(elemento[4])+1+"'";
            IDataReader readerC2 = consultar(consulta2);
            /* Los datos en la BD estan como :
            * [0] Nivel        
            * [1] Daño          
            * [2] Porcentaje 
            * [3] Elemento  
            * [4] Coste_siguiente (nivel)     
            */
            while (readerC2.Read())
            {
                string[] armaCompleta =
                {
                    elemento[0],            // [0] = Codigo
                    elemento[1],            // [1] = Nombre 
                    elemento[2],            // [2] = Descripcion
                    elemento[3],            // [3] = Nivel actual 
                    readerC2[3].ToString(), // [4] = Elemento
                    readerC2[1].ToString(), // [5] = Daño
                    readerC2[2].ToString(), // [6] = Porcentaje
                    readerC2[4].ToString(), // [7] = Coste nivel
                };
                armasDetalle.Add(armaCompleta);
            };
        }
        dbcon.Close();
        return armasDetalle;
    }










}
