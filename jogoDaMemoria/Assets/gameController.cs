using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameController : MonoBehaviour
{
    public static gameController controll;
    public Transform[] cardsBox;
    public GameObject[] card;
    public Transform[] buttom;
    public bool[] check;
    

    public int randNum;
    public int num;

    public bool c;
    public int turn;
    public bool ini;
    public int[] id = { 100, 100 };
    public int[] cdBar = { 100, 100 };

    public int plIn;
    public Text[] pontosTxt;
    public int[] pontoNum;
    public int tantoDePlayer;

    public Transform[] playerCases;
    public Transform playerShowTurn;

    
    public int endGame;
    public Text winMenssage;
    public Text poinstsMenssage;
    public Text placarManssage;

    public Image winnwer;
    public Sprite[] Pw;

    public string[] players = { "Player 1", "Player 2", "Player 3", "Player 4" };
    public int max;
    public int plMax;
    public GameObject showWin;

    public GameObject star;
    public Animator anim;

    public int fase;

    public AudioSource[] musicPlayer;
    public double timer;

    public int music;


    public float volume;
   


    void Start()
    {

        controll = this;

        desStar();



    }


    void Update()
    {


        if (music == 2)
        {

        }
        else
        {
            bool start = false;
            if (musicPlayer[music].isPlaying == false && start == false)
            {


                musicPlayer[music].Play();
                start = true;
                musicPlayer[music].volume = volume;
            }

            if (musicPlayer[0].isPlaying == false && music == 0)
            {
                music = 1;
                musicPlayer[music].Play();
            }
            if (musicPlayer[1].isPlaying == false && music == 1)
            {
                music = 0;
                musicPlayer[music].Play();
            }
        }


        randomCards();

        if(endGame == 6)
        {
            endgame();
        }

            if (turn != 0)
            {
                if (turn == 2)
                {
                    c = true;
                    turn = 0;
                    if (id[0] == id[1])
                    {
                        endGame++;
                        pontoNum[plIn]++;
                        pontosTxt[plIn].text = pontoNum[plIn].ToString();
                        star.SetActive(true);
                        anim.SetInteger("jogador", plIn);
                        Invoke("desStar", 0.83f);
                        fase = 2;

                    }
                    else
                    {
                        Invoke("retur", 0.5f);

                    }

                }
            }
        
    }



    public void randomCards()
    {
       

        if (num != cardsBox.Length)
        {
            pontosTxt[0].text = pontoNum[0].ToString();
            pontosTxt[1].text = pontoNum[1].ToString();
            pontosTxt[2].text = pontoNum[2].ToString();
            pontosTxt[3].text = pontoNum[3].ToString();

            randNum = Random.Range(0, cardsBox.Length);
            if (check[randNum] == false)
            {
                card[num].transform.position = cardsBox[randNum].position;
                check[randNum] = true;
                card[num].SetActive(false);
                buttom[num].position = cardsBox[randNum].position;
                num++;

            }
        }
    }

    public void desStar()
    {
        c = false;
        anim.SetInteger("jogador", 10);
        star.SetActive(false);
     
    }
    public void escolha(int escB)
    {

        if (c) { }
        else
        {

            fase = 1;
            cdBar[turn] = escB;
            card[escB].SetActive(true);
        }
    }
    public void ids( int iden)
    {


        if (c) { }
        else
        {
            id[turn] = iden;
            turn++;
        }

        

    }



    public void retur()
    {
      
        card[cdBar[0]].SetActive(false);
        card[cdBar[1]].SetActive(false);
        turn = 0;
        id[0] = 100;
        id[1] = 100;
        cdBar[0] = 100;
        cdBar[1] = 100;

        fase = 0;


        if (plIn == tantoDePlayer - 1)
        {
            plIn = 0;
            playerShowTurn.position = playerCases[plIn].position;
        }
        else
        {
            plIn++;
            playerShowTurn.position = playerCases[plIn].position;

        }
        c = false;
    }

    public void endgame()
    {
     
        

       
            showWin.SetActive(true);
            int f = 1;
            max = pontoNum[0];
         

        int Maximus = 0;
        while(f < tantoDePlayer)
        {
            if(pontoNum[Maximus] < pontoNum[f])
            {
                Maximus = f;
                plMax = f;
                max = pontoNum[f];
                f = 0;
               
            }
            else
            {
                f++;
            }

        }





            winMenssage.text = "Vitória do  " + players[plMax];
            poinstsMenssage.text = max.ToString() + " Estrelas adquiridas";
            placarManssage.text = "Player1: " + pontoNum[0] + " " + " Player2: " + pontoNum[1] + " " + " Player3: " + pontoNum[2] + " " + " Player4: " + pontoNum[3];
            winnwer.sprite = Pw[plMax];
        
        

       
           
           


        
    }

    public void retry()
    {
        SceneManager.LoadScene(1);
    }
    public void back()
    {
        SceneManager.LoadScene(0);
    }
}
