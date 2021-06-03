using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;

public class Licencia : MonoBehaviour
{
    public List<string> listLiscenses;
    public InputField lector;
    public Button confirmacion;
    
    TextWriter streamWriter;
    TextReader streamReader;
    List<string> w = new List<string>();
    List<int> i = new List<int>();
    public bool activatedLicense;
    void Start()
    {
        confirmacion.onClick.AddListener(confirmarClave);    
    }

    void confirmarClave()
    {       
        foreach (string liscense in listLiscenses)
        {
            if (liscense == lector.text)
            {
                List<string> temp = new List<string>();
                foreach (string s in listLiscenses)
                {
                    if (s != liscense)
                        temp.Add(s);
                }
                listLiscenses.Clear();
                listLiscenses = temp;

                streamWriter = new StreamWriter(Application.dataPath + "//StreamingAssets//save.txt");
                
                streamWriter.WriteLine("licencia activada");
                streamWriter.WriteLine(true);
                
                streamWriter.WriteLine("dia de activacion");
                streamWriter.WriteLine(DateTime.Now.Day);                
                streamWriter.WriteLine("mes de activacion");
                streamWriter.WriteLine(DateTime.Now.Month);                
                streamWriter.WriteLine("año de activacion");
                streamWriter.WriteLine(DateTime.Now.Year);                
                
                streamWriter.WriteLine("dia de desactivacion");
                streamWriter.WriteLine(DateTime.Now.Day);                
                streamWriter.WriteLine("mes de desactivacion");
                streamWriter.WriteLine(DateTime.Now.Month);                
                streamWriter.WriteLine("año de desactivacion");
                streamWriter.WriteLine(DateTime.Now.Year + 1);
                    
                //read("año de desactivacion");
                break;
            }
        }
        read("año de desactivacion");
    }
    void reWrite(string index)
    {    

       
        streamWriter.Close();        
    }
    public void read(string buscar)
    {
        streamReader = new StreamReader(Application.dataPath + "//StreamingAssets//save.txt");
        int dato;

        string linea = streamReader.ReadLine();
        
        List<string> temp = new List<string>();
        while (linea != null)
        {
            print(linea);
            temp.Add(linea);
            linea = streamReader.ReadLine();
        }
        for (int x = 0; x < temp.Count; x++)
        {
            if (temp[x] == buscar)
            {
                Debug.Log(temp[x]);                
                Debug.Log(temp[x + 1]);
                dato = Convert.ToInt32(temp[x + 1]);    
                break;
            }
        }        
        streamReader.Close();
    }
}
