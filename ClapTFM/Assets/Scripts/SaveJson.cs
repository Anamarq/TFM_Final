using System.Collections.Generic;
using System;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SaveJson : MonoBehaviour
{
    public static SaveJson instance;
    private void Awake()
    {
        instance = this;
    }

    public void SaveToJson(string movs, string path)
    {
        string filePath = Application.persistentDataPath + path;

        // Si el archivo ya existe, leemos su contenido y lo deserializamos
        UserData data = new UserData();
        if (File.Exists(filePath))
        {
            string jsonContent = File.ReadAllText(filePath);
            data = JsonUtility.FromJson<UserData>(jsonContent);
        }
        else
            data.TotalMovs = new List<string>();


        // Agregar nuevos datos al JSON existente
        data.TotalMovs.Add(movs);

        // Convertir el JSON actualizado a una cadena JSON
        string json = JsonUtility.ToJson(data, true);

        // Escribir la cadena JSON actualizada en el archivo
        File.WriteAllText(filePath, json);
    }
 
    //public void SetData(string name, string path)
    //{
    //    int total = 0;
    //    string filePath = Application.persistentDataPath + path;

    //    //// Si el archivo ya existe, leemos su contenido y lo deserializamos
    //    NameData data = new NameData();
    //    if (File.Exists(filePath))
    //    {
    //        string jsonContent = File.ReadAllText(filePath);
    //        data = JsonUtility.FromJson<NameData>(jsonContent);

    //        for (int i = 0; i < data.ListData.Count; i++)
    //        {
    //            if (data.ListData[i] == name)
    //            {
    //                total = (int.Parse(data.Total[i]) + 1);
    //            }
    //        }
    //    }
    //    SceneData.instance.setData(name, total);
    //}
    public void SaveNamesToJson(string name, int total, string path)
    {
        string filePath = Application.persistentDataPath + path;

        //// Si el archivo ya existe, leemos su contenido y lo deserializamos
        NameData data = new NameData();
        if (File.Exists(filePath))
        {
            string jsonContent = File.ReadAllText(filePath);
            data = JsonUtility.FromJson<NameData>(jsonContent);
            for (int i = 0; i < data.ListData.Count; i++)
            {
                if (data.ListData[i] == name)
                {  
                    data.Total[i] = total.ToString("0");
                }
            }
        }
        else
        {
            data.ListData = new List<string>();
            data.Total = new List<string>();
        }
        // Agregar nuevos datos al JSON existente
        if (total == 0)
        {
            data.ListData.Add(name);
            data.Total.Add("0");
        }

        // Convertir el JSON actualizado a una cadena JSON
        string json = JsonUtility.ToJson(data, true);

        // Escribir la cadena JSON actualizada en el archivo
        File.WriteAllText(filePath, json);
    }

}