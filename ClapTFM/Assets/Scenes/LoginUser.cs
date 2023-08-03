using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoginUser : MonoBehaviour
{
    public GameObject LoginCanvas; //Canvas Login
    public GameObject start; //Canvas inicial
    public GameObject newUser; //Canvas nuevo usuario
    private TouchScreenKeyboard overlayKeyboard; //teclado
    public TMP_Text text;  //nombre de usuario por teclado
    private string nameUser; //establece el nombre de usuario
    public AudioSource click; //sonido de botón
    public TMP_Text textExist;

    public static LoginUser instance;
    private void Awake()
    {
        instance = this;
    }

    void Update()
    {
        //guarda el nombre introducido por teclado. 
        if (overlayKeyboard != null)
            text.text = overlayKeyboard.text;
        if (overlayKeyboard != null && overlayKeyboard.status == TouchScreenKeyboard.Status.Done)
        {
            SetNameUser(text.text);
            LoadScene(true);
        }
    }
    //Función que establece el nombre de usuario
    public void SetNameUser(string newNameUser)
    {
       click.Play();   
       nameUser = newNameUser;
    }
    //Guarda el nombre de usuario y carga la escena siguiente
    public void LoadScene(bool isNew)
    {
        if (SceneData.instance.SetData(nameUser, "/participants.json", isNew) == true)
            SceneManager.LoadScene(1);
        else
        {
           textExist.gameObject.SetActive(true);
            overlayKeyboard.active = false;
            overlayKeyboard = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default);
        }
    }
    //Activa el canvas login
    public void Login()
    {
        click.Play();
        LoginCanvas.SetActive(true);
        start.SetActive(false);
    }

    public void Return()
    {
        click.Play();
        LoginCanvas.SetActive(false);
        start.SetActive(true);
    }
    //activa el canvas newUser y activa el teclado
    public void NewUser()
    {
        click.Play();
        newUser.SetActive(true);
        start.SetActive(false);
        overlayKeyboard = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default);
    }
}
