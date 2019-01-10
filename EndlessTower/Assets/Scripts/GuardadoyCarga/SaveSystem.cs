using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem {

    /* El "objeto"  sera el que contiene la informacion que se desea guardar 
     * playerData es una clase que guarda los datos de este objeto para luego
     * ser serializada y guardada como archivo
     */

    public static void SavePlayer(/* objeto */) {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/save.data";
        FileStream stream = new FileStream(path, FileMode.Create);

     
        PlayerData data = new PlayerData(/* objeto */);
        formatter.Serialize(stream, data);
        stream.Close();

    }



}
