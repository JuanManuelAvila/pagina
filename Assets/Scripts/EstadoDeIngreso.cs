using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class EstadoDeIngreso : MonoBehaviour
{
    int primerEstado = 0;
    public Text i;
    // Start is called before the first frame update
    void Start()
    {
        primerEstado = PlayerPrefs.GetInt("primer ingreso");
        print(primerEstado);

        transform.GetChild(0).GetComponent<Button>().interactable = primerEstado == 0 ? true : false;
        transform.GetChild(1).GetComponent<Button>().interactable = primerEstado != 0 ? true : false;

        transform.GetChild(0).GetComponent<Button>().onClick.AddListener(primerClick);
        transform.GetChild(1).GetComponent<Button>().onClick.AddListener(click);

        i.text = primerEstado.ToString();
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            PlayerPrefs.DeleteAll();
        }
    }
    void primerClick()
    {
        Process.Start(Application.dataPath + "/StreamingAssets/xampp/setup_xampp.bat");
        Application.OpenURL("http://localhost/Index.html");
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
}
