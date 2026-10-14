using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public AudioSource musica;
    public AudioSource EfectoSfx;
    public AudioClip sfx;
    public Slider volumenMusica;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        musica.volume = 0.3f;
        EfectoSfx.volume = 0.3f;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ActualizarVolumenMusica(float nuevoVolumen)
    {
        musica.volume = nuevoVolumen;
        Debug.Log(" se cambio a " +  nuevoVolumen);
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
