using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MenuControler : MonoBehaviour
{
    public Slider QuantJogador;
    public Slider Musica;
    public Slider Volume;
    

    public float numJogador;
    public float numMusica;
    public string[] musicas = { "Comedy", "Color Perfume", "nenhuma" };
    public float numVolume;
    

    public Text textJogador;
    public Text textMusica;
    public Text textVolume;
  


    public GameObject playConfig;
    public GameObject castConfig;

    public bool config;
    public bool ingame;

    public Animator anim;
    public AudioSource aud;
    public static MenuControler control;
    void Start()
    {
        control = this;
        if (ingame)
        {
            gameController.controll.tantoDePlayer = (int)PlayerPrefs.GetFloat("jogadores");
            gameController.controll.music = (int)PlayerPrefs.GetFloat("musica");
            gameController.controll.volume = PlayerPrefs.GetFloat("volume");
           
        }
        else
        {

            QuantJogador.value = (int)PlayerPrefs.GetFloat("jogadores");
            Musica.value = (int)PlayerPrefs.GetFloat("musica");
            Volume.value = PlayerPrefs.GetFloat("volume");
           
        }
    }


    void Update()
    {
        if (config)
        {

            numJogador = QuantJogador.value;
            numMusica = Musica.value;
            numVolume = Volume.value;
         

            textJogador.text = numJogador.ToString();
            textVolume.text = (numVolume * 100).ToString();
           

            textMusica.text = musicas[(int)numMusica];



            PlayerPrefs.SetFloat("jogadores", numJogador);
            PlayerPrefs.SetFloat("volume", numVolume);
            PlayerPrefs.SetFloat("musica", numMusica);
           

            aud.volume = numVolume;
        }
    }

    public void jogar()
    {
       
        SceneManager.LoadScene(1);
    }
    public void ShowJogar()
    {
        config = true;
        playConfig.SetActive(true);
    }
   


    public void EndJogar()
    {
        config = false;
        playConfig.SetActive(false);
    }
    void fimConfig()
    {
        config = false;
        playConfig.SetActive(false);
        castConfig.SetActive(true);
    
    }

    public void ShowCast()
    {
        config = true;
        castConfig.SetActive(true);
    }
    public void EndCast()
    {
        config = false;
        castConfig.SetActive(false);

    }

    public void linkOn(string link)
    {
        Application.OpenURL(link);
    }
}
