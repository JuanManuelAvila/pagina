using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EstadoDeIngreso : MonoBehaviour
{
    int primerEstado = 0;    
    // Start is called before the first frame update
    void Start()
    {
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
        transform.GetChild(0).GetComponent<Button>().interactable = primerEstado != 0;
        transform.GetChild(1).GetComponent<Button>().interactable = primerEstado == 0;
        transform.GetChild(2).GetComponent<Button>().interactable = primerEstado != 0;

        primerEstado = PlayerPrefs.GetInt("primer ingreso");
    }
    void primerClick()
    {
       Process.Start(Application.dataPath + "/StreamingAssets/activar.bat");
       if (primerEstado == 0)        
            guardar();        
    }
    void click()
    {
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
        Process.Start(Application.dataPath + "/StreamingAssets/xampp/xampp_stop.exe");        
    }
    private void OnApplicationQuit()
    {   
       Process.Start(Application.dataPath + "/StreamingAssets/xampp/xampp_stop.exe");       
    } 
}
