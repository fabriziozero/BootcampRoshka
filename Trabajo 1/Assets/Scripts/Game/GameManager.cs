using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class GameManager : MonoBehaviour
{
    public int nivel;
    public int puntos;
    public int vida;
    public float valorTimeScale;

    // Control del estado
    public TiposDeEstado estadoActual;

    // Definimos previamente el enumerado
    public enum TiposDeEstado { INTRO, MENU, JUEGO, SALIR }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    

	/*public void cambiarEscena(string escena)
	{
        guardarPartida();
        SceneManager.LoadScene(escena);
    }
    */

    public void reiniciar()
	{
        //guardarPartida();
        quitarPausa();
        //SceneManager.LoadScene(SceneManager.GetActiveScene().Game);
        SceneManager.LoadScene("Game");
    }

    /*public void guardarPartida()
	{
        if(PlayerPrefs.GetInt ("nivelDesbloqueado") < nivel)
            PlayerPrefs.SetInt("nivelDesbloqueado", nivel);
        if(PlayerPrefs.GetInt ("puntosMax") < puntos)
            PlayerPrefs.SetInt("puntosMax", puntos);
     }

    public void cargarPartida()
	{
        nivel = PlayerPrefs.GetInt("nivelDesbloqueado");
        puntos = PlayerPrefs.GetInt("puntosMax");
	}*/

    public void pausar()
    {
        // si esta activo lo pausamos
        if(Time.timeScale > 0){
            valorTimeScale = Time.timeScale;
            Time.timeScale = 0;
        }
        // sino, quitamos la pausa
        else{
            quitarPausa();
        }
    }
    public void quitarPausa()
    {
        if(Time.timeScale == 0) Time.timeScale = valorTimeScale;
    }
    
}
