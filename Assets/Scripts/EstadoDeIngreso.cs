using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EstadoDeIngreso : MonoBehaviour
{    
    int primerEstado = 0;
    bool startXampp = false;
    // Start is called before the first frame update
    void Start()
    {
        startXampp = false;
        primerEstado = PlayerPrefs.GetInt("primer ingreso");

        transform.GetChild(0).GetComponent<Button>().interactable = primerEstado != 0;
        transform.GetChild(1).GetComponent<Button>().interactable = primerEstado == 0;
        transform.GetChild(2).GetComponent<Button>().interactable = primerEstado != 0;

        transform.GetChild(0).GetComponent<Button>().onClick.AddListener(ResetServer);
        transform.GetChild(1).GetComponent<Button>().onClick.AddListener(primerClick);
        transform.GetChild(2).GetComponent<Button>().onClick.AddListener(click);
    }
    private void FixedUpdate()
    {
        primerEstado = PlayerPrefs.GetInt("primer ingreso");
        transform.GetChild(0).GetComponent<Button>().interactable = primerEstado != 0;
        transform.GetChild(1).GetComponent<Button>().interactable = primerEstado == 0;
        transform.GetChild(2).GetComponent<Button>().interactable = primerEstado != 0;       
    }
    void primerClick()
    {
        Process.Start(Application.dataPath + "/StreamingAssets/activar.bat");
        guardar();                
    }
    void click()
    {
        startXampp = true;
        Process.Start(Application.dataPath + "/StreamingAssets/xampp/xampp_start.exe");
        Application.OpenURL("http://localhost/Index.html");
    }
    void guardar()
    {
        PlayerPrefs.SetInt("primer ingreso", 1);
        PlayerPrefs.Save();
    }
    private void ResetServer()
    {
        PlayerPrefs.DeleteAll();
        if (startXampp)
        {
            Process.Start(Application.dataPath + "/StreamingAssets/xampp/xampp_stop.exe");
            startXampp = false;
        }
    }
    private void OnApplicationQuit()
    {
        if (startXampp)
        {
            Process.Start(Application.dataPath + "/StreamingAssets/xampp/xampp_stop.exe");
            startXampp = false;
        }
    }
}
