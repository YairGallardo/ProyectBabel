
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class CargaDeDatos : MonoBehaviour
{


    void Start()
    {
        Cargar();

    }




   public static void Guardar() {
        BinaryFormatter form = new BinaryFormatter();
        string path = Application.persistentDataPath + "/db.db";
        FileStream stream = new FileStream(path, FileMode.Create);
        form.Serialize(stream,FindObjectOfType<ControladorBaseDeArmas>());
        stream.Close();

        BinaryFormatter form2 = new BinaryFormatter();
        string path2 = Application.persistentDataPath + "/info.info";
        FileStream stream2 = new FileStream(path, FileMode.Create);
        form.Serialize(stream2, FindObjectOfType<DatosPersistentes>());
        stream.Close();

    }

    void Cargar() {
        
        string path = Application.persistentDataPath + "/db.db";
        if (File.Exists(path)) {
            BinaryFormatter form = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
           ControladorBaseDeArmas DB = FindObjectOfType<ControladorBaseDeArmas>();
            DB =  form.Deserialize(stream) as ControladorBaseDeArmas;
            stream.Close();

        }


        string path2 = Application.persistentDataPath + "/info.info";
        if (File.Exists(path))
        {
            BinaryFormatter form = new BinaryFormatter();
            FileStream stream = new FileStream(path2, FileMode.Open);
            DatosPersistentes p = FindObjectOfType<DatosPersistentes>();
            p = form.Deserialize(stream) as DatosPersistentes;
            stream.Close();

        }



    }












}
