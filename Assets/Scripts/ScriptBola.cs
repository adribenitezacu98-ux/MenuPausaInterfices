using UnityEngine;
using UnityEngine.InputSystem;
using System.IO;
using TMPro;

[System.Serializable]
public class DatosRebotes
{
    public int Rebotes;
}

public class ScriptBola : MonoBehaviour
{
    private int rebotes = 0;
    private string rutaArchivo;
    public TMP_Text textoRebotes;
    public bool pausa = false;
    public GameObject panelIngame;
    public GameObject panelPausa;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rutaArchivo = Application.dataPath + "/rebotes.json";
        panelIngame.SetActive(true);
        panelPausa.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        TeclaPausa();
        
    }

    void TeclaPausa()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame && pausa == false)
        {
            Time.timeScale = 0;
            pausa = true;
            panelIngame.SetActive(false);
            panelPausa.SetActive(true);
        }
        else if (Keyboard.current.escapeKey.wasPressedThisFrame && pausa == true)
        {
            Time.timeScale = 1;
            pausa = false;
            panelIngame.SetActive(true);
            panelPausa.SetActive(false);
        }
    }

    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("superficie"))
        {
            rebotes++;
            textoRebotes.text = "Rebotes = " + rebotes;
        }
    }

    public void GuardarRebotes()
    {
        DatosRebotes datos = new DatosRebotes();

        datos.Rebotes = rebotes;
        string json = JsonUtility.ToJson(datos);

        File.WriteAllText(rutaArchivo, json);
        Debug.Log("Guardado");
    }

    public void Cargar()
    {
        string json = File.ReadAllText(rutaArchivo);
        DatosRebotes datos = JsonUtility.FromJson<DatosRebotes>(json);
        rebotes = datos.Rebotes;
        textoRebotes.text = "Rebotes = " + rebotes;

    }
}
