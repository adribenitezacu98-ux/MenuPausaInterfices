using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System;

public class Menu : MonoBehaviour
{
    public AudioSource musica;
    public AudioSource EfectoSfx;
    public AudioClip sfx;
    public Slider volumenMusica;

    public TMP_Dropdown dropRes;



    Resolution[] arrayRes;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    int contador = 0;
    int resolucionActual = 0;
    musica.volume = 0.3f;
        EfectoSfx.volume = 0.3f;
        List<string> resoluciones = new List<string>();
        arrayRes = Screen.resolutions;
        foreach (Resolution unityRes in arrayRes)
        {
            resoluciones.Add(unityRes.width + "x" + unityRes.height);
            if (Screen.width== unityRes.width && Screen.height == unityRes.height)
            {
                resolucionActual = contador;
            }
            contador++;
        }
        Debug.Log(arrayRes.Length);
        dropRes.ClearOptions();
        dropRes.AddOptions(resoluciones);
        dropRes.SetValueWithoutNotify(resolucionActual);
        Debug.Log(resolucionActual);



    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToggleFullScreen(bool fullscreen) 
    {
        Screen.fullScreen = fullscreen;
        Debug.Log(fullscreen);
    }
    public void ActualizarVolumenMusica(float nuevoVolumen)
    {
        musica.volume = nuevoVolumen;
        Debug.Log(" se cambio a " +  nuevoVolumen);

    }

    public void ActualizaResolucion(int opcionDD)
    {
        Resolution elegida = arrayRes[opcionDD];
        Debug.Log("Resolución elegida: " + elegida.width + " x " + elegida.height);
        Screen.SetResolution(elegida.width, elegida.height, Screen.fullScreenMode);
    }
    public void ActualizarVolumenSFX(float nuevoVolumen)
    {
        EfectoSfx.volume = nuevoVolumen;
    }

    public void EfectoDeBoton()
    {
        EfectoSfx.PlayOneShot(sfx);
    }
    
}
