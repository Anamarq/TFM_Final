using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

//Guarda datos entre escenas
public class SceneData : MonoBehaviour
{
    public string nameUser;
    public int totalTries;
    public int extraTime;
    public static SceneData instance;
    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject); // Evita que el GameObject se destruya al cambiar de escena
    }
    //public void setData(string name, int total)
    //{
    //    nameUser = name;
    //    totalTries = total;
    //    if (total == 0)
    //        extraTime = 15;
    //    else
    //        extraTime = 5;
    //}
    public bool SetData(string name, string path, bool isNew)
    {
        int total = 0;
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
                    if (!isNew)
                        total = (int.Parse(data.Total[i]) + 1);
                    else
                        return false;
                }
            }
        }
        nameUser = name;
        totalTries = total;
        if (total == 0)
            extraTime = 15;
        else
            extraTime = 5;
        return true;
    }
}
