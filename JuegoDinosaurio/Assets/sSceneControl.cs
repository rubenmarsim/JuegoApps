using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class sSceneControl : MonoBehaviour
{
    #region Variables
    /// <summary>
    /// Objeto Jugador
    /// </summary>
    public GameObject Player;
    /// <summary>
    /// Objeto camara
    /// </summary>
    public Camera GameCamera;
    /// <summary>
    /// Array de bloques
    /// </summary>
    public GameObject[] aBloquePreFab;
    /// <summary>
    /// Puntero del juego
    /// </summary>
    public float PunteroJuego;
    /// <summary>
    /// Lugar seguro de generacion
    /// </summary>
    public float LugarSeguroDeGeneracion = 12;
    /// <summary>
    /// Texto que colocaremos en el canvas para poner la puntuacion y demas mensajes
    /// </summary>
    public Text txtGame;
    /// <summary>
    /// Indicador de si hemos muerto o no
    /// </summary>
    public bool IsLosed;
    /// <summary>
    /// Objeto de audio
    /// </summary>
    private AudioSource Sonido;
    /// <summary>
    /// Objeto para clips de audio que contendra el audio de los golpes
    /// </summary>
    public AudioClip golpe;
    /// <summary>
    /// Objeto de audio que contendra la musica
    /// </summary>
    public AudioSource Musica;
    #endregion Variables

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        PunteroJuego = -7;
        IsLosed = false;
        Sonido = GetComponent<AudioSource>();
        Musica.Play();
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        if (Player != null)
        {
            GameCamera.transform.position = new Vector3(Player.transform.position.x,
                                                    GameCamera.transform.position.y,
                                                    GameCamera.transform.position.z
                                                    );

            txtGame.text = "Puntuacion: " + Mathf.Floor(Player.transform.position.x);
        }
        else
        {
            if (!IsLosed)
            {
                IsLosed = true;
                txtGame.text += "\n Game Over! \n Pulsa para volver a empezar";
                Sonido.PlayOneShot(golpe, 1f);
                Musica.Stop();
            }
            if (IsLosed)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                }
            }
        }

        while (Player != null && PunteroJuego < Player.transform.position.x + LugarSeguroDeGeneracion)
        {
            int iIndiceBloque = Random.Range(0, aBloquePreFab.Length - 1);
            if (PunteroJuego < 0)
            {
                iIndiceBloque = 3;
            }
            GameObject ObjetoBloque = Instantiate(aBloquePreFab[iIndiceBloque]);
            ObjetoBloque.transform.SetParent(this.transform);
            sBloque bloque = ObjetoBloque.GetComponent<sBloque>();
            ObjetoBloque.transform.position = new Vector2(PunteroJuego + bloque.iTamaño / 2, 0);
            PunteroJuego += bloque.iTamaño;
        }

    }
}
