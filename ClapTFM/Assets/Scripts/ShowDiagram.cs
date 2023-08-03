
using Newtonsoft.Json;
using Oculus.Platform.Samples.VrHoops;

using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class ShowDiagram : MonoBehaviour
{
    private LineRenderer lineRenderer;
    Renderer renderer;
    private int diagramSize = 10;
    private float high = 1.5f;
    
    private float[] VectorPoints(string name, int total)
    {
        float[] points = new float[8];
        string filePath = Application.persistentDataPath + "/" + name + total + ".json";

        // Si el archivo ya existe, leemos su contenido y lo deserializamos
        UserData data = new UserData();
        if (File.Exists(filePath))
        {
            string jsonContent = File.ReadAllText(filePath);
            data = JsonUtility.FromJson<UserData>(jsonContent);
        }

        for (int i = 0; i < 8; ++i) ///data.TotalMovs.Count
        {
            points[i] = float.Parse(data.TotalMovs[i]);
        }
        return points;
    }
    private void ActualPoints(string name, int total)
    {
        float[] points = VectorPoints(name, total); 
        //// Define las posiciones de los puntos del diagrama
        Vector3[] positions = new Vector3[]
       {
                new Vector3(-1f, points[0]/diagramSize + high, 0.7f),
                new Vector3(-0.8f, points[1]/diagramSize + high, 0.7f),
                new Vector3(-0.6f, points[2]/diagramSize+high, 0.7f),
                new Vector3(-0.4f,points[3]/diagramSize +high, 0.7f),
                new Vector3(-0.2f, points[4]/diagramSize +high, 0.7f),
                new Vector3(0f, points[5]/diagramSize +high, 0.7f),
                new Vector3(0.2f, points[6]/diagramSize +high, 0.7f),
                new Vector3(0.4f, points[7]/diagramSize +high, 0.7f)
       };

        lineRenderer.SetPositions(positions);
        renderer.material.color = Color.red;
    }
    private void MaxPoints(string name, int total)
    {
        string filePath;
        float[] maxPoints = new float[8];
        float point = 0;
        for(int i = 0; i < total; i++)
        {
            filePath = Application.persistentDataPath + "/" + name + i + ".json";
            UserData data = new UserData();
            if (File.Exists(filePath))
            {
                string jsonContent = File.ReadAllText(filePath);
                data = JsonUtility.FromJson<UserData>(jsonContent);
            }

            for (int j = 0; j < 8; ++j)
            {
                point = float.Parse(data.TotalMovs[j]);
                if(point > maxPoints[j])
                    maxPoints[j] = point;

            }
        }
        Vector3[] positions = new Vector3[]
        {
                new Vector3(-1f, maxPoints[0]/diagramSize +high, 0.7f),
                new Vector3(-0.8f, maxPoints[1]/diagramSize +high, 0.7f),
                new Vector3(-0.6f, maxPoints[2]/diagramSize +high, 0.7f),
                new Vector3(-0.4f,maxPoints[3]/diagramSize +high, 0.7f),
                new Vector3(-0.2f, maxPoints[4]/diagramSize +high, 0.7f),
                new Vector3(0f, maxPoints[5]/diagramSize +high, 0.7f),
                new Vector3(0.2f, maxPoints[6]/diagramSize +high, 0.7f),
                new Vector3(0.4f, maxPoints[7]/diagramSize +high, 0.7f)
        };
        lineRenderer.SetPositions(positions);
        renderer.material.color = Color.green;

      
        float[] actPoints = VectorPoints(name, total);
        DiagramController.instance.differencePoints(maxPoints, actPoints);
    }

    private void MediumPoints(string name, int total)
    {
        string filePath;
        float[] mediumPoints = new float[8];
        float point = 0;
        for (int i = 0; i < total; i++)
        {
            filePath = Application.persistentDataPath + "/" + name + i + ".json";
            UserData data = new UserData();
            if (File.Exists(filePath))
            {  
                string jsonContent = File.ReadAllText(filePath);
                data = JsonUtility.FromJson<UserData>(jsonContent);
            }       

            for (int j = 0; j < 8; ++j)
            {
                point = float.Parse(data.TotalMovs[j]);
                mediumPoints[j] += point;
            }
        }
        for (int j = 0; j < mediumPoints.Length; ++j)
        {
            mediumPoints[j] /= total;
        }
        Vector3[] positions = new Vector3[]
        {
                new Vector3(-1f, mediumPoints[0]/diagramSize +high, 0.7f),
                new Vector3(-0.8f, mediumPoints[1]/diagramSize +high, 0.7f),
                new Vector3(-0.6f, mediumPoints[2]/diagramSize +high, 0.7f),
                new Vector3(-0.4f,mediumPoints[3]/diagramSize +high, 0.7f),
                new Vector3(-0.2f, mediumPoints[4]/diagramSize +high, 0.7f),
                new Vector3(0f, mediumPoints[5]/diagramSize +high, 0.7f),
                new Vector3(0.2f, mediumPoints[6]/diagramSize +high, 0.7f),
                new Vector3(0.4f, mediumPoints[7]/diagramSize +high, 0.7f)
        };
        lineRenderer.SetPositions(positions);
        renderer.material.color = Color.blue;
    }

   

    public void Show(int nd)
    {
        renderer = GetComponent<Renderer>();
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 8;  // Establece el número de puntos para el diagrama

        //  Vector3[] positions = new Vector3[]
        //  {
        //              new Vector3(-1f, 2.2f, 0.7f),
        //              new Vector3(-0.8f, 2.4f, 0.7f),
        //              new Vector3(-0.6f, 2.6f, 0.7f),
        //              new Vector3(-0.4f,2.2f, 0.7f),
        //              new Vector3(-0.2f, 2.2f, 0.7f),
        //              new Vector3(0f, 2.4f, 0.7f),
        //              new Vector3(0.2f, 2.2f, 0.7f),
        //              new Vector3(0.4f, 2.6f, 0.7f)
        //  };
        //  Vector3[] positions2 = new Vector3[]
        //{
        //              new Vector3(-1f, 2.0f, 0.7f),
        //              new Vector3(-0.8f, 2.4f, 0.7f),
        //              new Vector3(-0.6f, 2.2f, 0.7f),
        //              new Vector3(-0.4f,2.2f, 0.7f),
        //              new Vector3(-0.2f, 2.6f, 0.7f),
        //              new Vector3(0f, 2.2f, 0.7f),
        //              new Vector3(0.2f, 2.8f, 0.7f),
        //              new Vector3(0.4f, 2.8f, 0.7f)
        //};

        //  // Establece las posiciones en el Line Renderer
        //  if(totalTries =="0")
        //  lineRenderer.SetPositions(positions);
        //  else
        //      lineRenderer.SetPositions(positions2);
        //  Color randomColor = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        //  renderer.material.color = randomColor;




        int total = SceneData.instance.totalTries;
        string nameUser = SceneData.instance.nameUser;
        //int total = 3;
        //string nameUser = "kana";
        if (nd== 0)
            ActualPoints(nameUser, total);
        else if(nd == 1)
            MaxPoints(nameUser, total);
        else
            MediumPoints(nameUser, total);
    }
}
