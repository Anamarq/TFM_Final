using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject[] levels;
    public int nlev;
    public string nameUser;
    public string totalTries;
    public GameObject diagrams;
    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        nlev = 0;
        for (int i = 1; i < levels.Length; i++)
        {
            levels[i].SetActive(false);
        }
        nameUser = SceneData.instance.nameUser;
        totalTries = SceneData.instance.totalTries.ToString("0");

    }

    public void Finish()
    {

        levels[nlev].GetComponent<FadeOut>().StartFading();
        string path = "/" + nameUser + totalTries + ".json";
        if (nlev == 0)
            SaveJson.instance.SaveToJson(ChangeGlass.instance.pointGlass.ToString(), path);
        else if (nlev == 1)
            SaveJson.instance.SaveToJson( ChangeWok.instance.points.ToString(), path);
        else if (nlev == 2)
            SaveJson.instance.SaveToJson( DrinkGlass.instance.nDrink.ToString(), path);
        else if (nlev == 3) 
            SaveJson.instance.SaveToJson(CapPoints.instance.points.ToString(), path);
        else if (nlev == 4)
            SaveJson.instance.SaveToJson(ChangeBasket.instance.nbasket.ToString(), path);
        else if (nlev == 5)
            SaveJson.instance.SaveToJson(ColorsShelfPoints.instance.points.ToString(), path);
        else if (nlev == 6)
            SaveJson.instance.SaveToJson(FaucetController.instance.nfaucet.ToString(), path);
        else if (nlev == 7)
            SaveJson.instance.SaveToJson(OvenController.instance.nOven.ToString(), path);
        ++nlev;
        if (nlev < levels.Length)
        {
            levels[nlev].SetActive(true);
            ChangeCanvas.instance.changeCanvas(nlev);
            levels[nlev].GetComponent<FadeOut>().StartActivate();
            Timer.instance.Restart();
        }
        else
        {
            SaveJson.instance.SaveNamesToJson(nameUser, SceneData.instance.totalTries, "/participants.json");
            diagrams.SetActive(true);
            DiagramController.instance.LoadDiagrams();
        }
    }
}
