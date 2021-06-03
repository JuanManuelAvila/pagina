using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
using System.Threading.Tasks;

public class EstadoDeIngreso : MonoBehaviour
{

    public List<string> lincencias, estados;
    public List<int> rangosFecha;
    public GameObject pantallaLicencia;
    public Button botonActivar;
    public InputField textoLicencia;
    public Text mensajeLicencia,estadoLicencia;
    

    public int estado= 0;
    int primerEstado = 0;
    bool startXampp = false;    
    public int diaActual, mesActual, añoActual;
    public int diaActivacion, mesActivacion, añoActivacion;
    public int diaDesactivacion, mesDesactivacion, añoDesactivacion;
    

    private void Awake()
    {
        LoadFileInfo();
        LoadFileLicense();
        diaActual = DateTime.Now.Day;
        mesActual = DateTime.Now.Month;
        añoActual = DateTime.Now.Year;

        estado = PlayerPrefs.GetInt("estado");

        if (estado == 1)
        {
            pantallaLicencia.SetActive(false);
        }
        else {
            pantallaLicencia.SetActive(true);
        }

        botonActivar.onClick.AddListener(ActivarLicencia);            
    }


    public void LoadFileLicense() {


        string fileName = Application.dataPath + "/StreamingAssets/xampp/licenses/apache/license.txt";

        using (StreamReader reader = new StreamReader(fileName))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                lincencias.Clear();
                estados.Clear();
                string[] lines = File.ReadAllLines(fileName);
                for (int x = 0; x < lines.Length; x++)
                {
                    string[] subs = lines[x].Split(' ');
                    lincencias.Add(subs[0]);
                    estados.Add(subs[1]);
                }
            }
        }
    }

    
    public void LoadFileInfo()
    {
        string fileName = Application.dataPath + "/StreamingAssets/xampp/licenses/apache/info.txt";
        string[] lines = File.ReadAllLines(fileName);

        for (int line = 0; line < lines.Length; line++) {
            string secondLine = lines[1];
            string[] subs = secondLine.Split(':', '-');
            for (int j = 0; j < subs.Length; j++)
            {
                diaDesactivacion = int.Parse(subs[1]);
                mesDesactivacion = int.Parse(subs[2]);
                añoDesactivacion = int.Parse(subs[3]);
            }
        }
    }


    public void WriteFileInfo()
    {

        string fileName = Application.dataPath + "/StreamingAssets/xampp/licenses/apache/info.txt";
        System.IO.File.WriteAllText(fileName, string.Empty);
        using (StreamWriter writer = new StreamWriter(fileName))
        {
            writer.WriteLine("Activacion:" + diaActivacion + "-" + mesActivacion + "-" + añoActivacion);
            writer.WriteLine("Vencimiento:" + diaDesactivacion + "-" + mesDesactivacion + "-" + añoDesactivacion);
        }
        // Read a file  
        string readText = File.ReadAllText(fileName);
    }

    public void WriteFileLicense() {

        string fileName = Application.dataPath + "/StreamingAssets/xampp/licenses/apache/license.txt";
        System.IO.File.WriteAllText(fileName, string.Empty);
        using (StreamWriter writer = new StreamWriter(fileName))
        {
            for (int i = 0; i< lincencias.Count; i++) {
                writer.WriteLine(lincencias[i]+ " "+estados[i]);
            }
        }
        // Read a file  
        string readText = File.ReadAllText(fileName);
    }

    

    public void ActivarLicencia() {
        if (estado == 0)
        {
            if (lincencias.Contains(textoLicencia.text))
            {
                int index = lincencias.IndexOf(textoLicencia.text);
                lincencias.Remove(textoLicencia.text);
                estados.RemoveAt(index);

                WriteFileLicense();
                estado = 1;
                diaActivacion = DateTime.Now.Day;
                mesActivacion = DateTime.Now.Month;
                añoActivacion = DateTime.Now.Year;

                diaDesactivacion = DateTime.Now.Day;
                mesDesactivacion = DateTime.Now.Month;
                añoDesactivacion = (DateTime.Now.Year + 1);

                WriteFileInfo();
                PlayerPrefs.SetInt("estado", 1);
                StartCoroutine(delayPantalla());


            }
            else {
                mensajeLicencia.text = "Licencia no existe";
                textoLicencia.text = "";
                StartCoroutine(delayMensaje());
            }
        }
    }

    IEnumerator delayPantalla()
    {
        yield return new WaitForSeconds(2f);
        mensajeLicencia.text = "";
        pantallaLicencia.SetActive(false);
    }

    IEnumerator delayMensaje() {
        yield return new WaitForSeconds(2f);
        mensajeLicencia.text = "";
    }

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
        
        if (estado == 0)
        {
            if (textoLicencia.text == "")
            {
                botonActivar.interactable = false;
            }
            else
            {
                botonActivar.interactable = true;
            }
            estadoLicencia.text = "Estado licencia: Inactiva";
        }
        else {
            diaActual = DateTime.Now.Day;
            mesActual = DateTime.Now.Month;
            añoActual = DateTime.Now.Year;

            

            if (rangosFecha.Contains(añoActual))
            {
                if (diaActual >= diaDesactivacion &&
                                mesActual >= mesDesactivacion &&
                                añoActual >= añoDesactivacion)
                {
                    pantallaLicencia.SetActive(true);
                    estado = 0;
                    mensajeLicencia.text = "La licencia ha caducado";
                }
                estadoLicencia.text = "Estado licencia: Activa";
                transform.GetChild(0).GetComponent<Button>().interactable = primerEstado != 0;
                transform.GetChild(1).GetComponent<Button>().interactable = primerEstado == 0;
                transform.GetChild(2).GetComponent<Button>().interactable = primerEstado != 0;
            }
            else {
                estadoLicencia.text = "Tiempo de uso ha experidado";

                transform.GetChild(0).GetComponent<Button>().interactable = false;
                transform.GetChild(1).GetComponent<Button>().interactable = false;
                transform.GetChild(2).GetComponent<Button>().interactable = false;

            }

            
        }

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
