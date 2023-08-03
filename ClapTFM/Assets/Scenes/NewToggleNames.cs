using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using TMPro;
using System.IO;

public class NewToggleNames : MonoBehaviour
{
    public GameObject toggle; //toggle donde viene el nombre
    public TMP_Text textResult; //texto a mostrar al usuario

    void Start()
    {
        //Lee el archivo json y busca los nombres guardados
        string filePath = Application.persistentDataPath + "/participants.json";
        // Si el archivo ya existe, leemos su contenido y lo deserializamos
        NameData data = new NameData();
        if (File.Exists(filePath))
        {
            string jsonContent = File.ReadAllText(filePath);
            data = JsonUtility.FromJson<NameData>(jsonContent);
            for (int i = 0; i < data.ListData.Count; ++i)
            {
                    NewToggle(data.ListData[i]);
            }
        }
    }

    //Instancia un nuevo toggle con el nombre pasado como parametro
    public void NewToggle(string name)
    {
        GameObject newToggle;
        newToggle = Instantiate(toggle);
        newToggle.transform.SetParent(transform, false);
        newToggle.GetComponent<ToggleName>().textShow = textResult;
        newToggle.GetComponentInChildren<TMP_Text>().text = name;
    }
}
