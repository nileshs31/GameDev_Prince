using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MOTION : MonoBehaviour
{ 
    public Rigidbody2D fire;
    public float speed = 300.0f;
    public bool FireAllowed = true;
    public GameObject AIM; 
    
    public TileController TileCon;
    //public ScoreManager1 SM;
    //public SceneLoader SL;
    //public audioManager AM;
    public gameConroller scriptManager;
    //public health h;
    public int coin;
    public int hearts;
    public AudioSource speaker;
    public AudioClip bombAudio;
    public AudioClip boundarybounce;
    public Text coinDisplay;
   

    public Transform Target;
    public Vector2 Direction;
    AudioClip playsound;
    public TileDecider decide_tile;
    private bool CollidedTop = false;
    private bool CollidedBottom = false;

    float x=-0.28f, y=-1.5f, z=91.7f;              //initial values for the replacement of fire if it gets out of bounds at the very start of the game//

    public void Start()
    {
        fire = this.GetComponent<Rigidbody2D>();
     }
    void Update()
    {
        if (!EventSystem.current.IsPointerOverGameObject(0) && !EventSystem.current.IsPointerOverGameObject() && Input.GetMouseButtonDown(0) && FireAllowed)
        {
            CanFire();
        }
        if (fire.transform.position.y > 2f || fire.transform.position.y < -4f){
            fire.transform.position = new Vector3(x, y, z);
            fire.velocity = Vector2.zero;
            FireAllowed = true;
            AIM.SetActive(true);
        }
        
    }
    void CanFire()
    {
        Vector2 targetpos = Target.position;
        Direction = targetpos - (Vector2)transform.position;
        fire.AddForce(Direction * speed);
        AIM.SetActive(false);
        FireAllowed = false;

    }
    public void OnCollisionEnter2D(Collision2D crashed)
    {
        
        if (!CollidedTop && crashed.gameObject.tag == "Top")
        {
            CollidedTop = true;
            CollidedBottom = false;
            FireAllowed = true;
            x = crashed.gameObject.GetComponent<Transform>().position.x;
            y = crashed.gameObject.GetComponent<Transform>().position.y - (crashed.gameObject.GetComponent<RectTransform>().rect.height) / 2-0.05f;     //since we already know it is top tile//
            z = crashed.transform.position.z;
            fire.transform.position = new Vector3(x, y, z);
            fire.velocity = Vector2.zero;
            gameObject.transform.localScale = new Vector3(0.3196901f, -0.3196901f, 0.3196901f);
            AIM.SetActive(true);
            
            
            if (crashed.gameObject.GetComponent<SpriteRenderer>().color==Color.green) ////FOR SCORE and game
            {
                crashed.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
                playsound = decide_tile.pickSound();
                speaker.GetComponent<AudioSource>().clip = playsound;
                speaker.Play();
                if (false)
                {
                    //TileCon.SelectTileBottom();
                    //SM.AddScore();

                    /*if (crashed.gameObject.GetComponent<Tiles>().tileNum == TileCon.num)
                    {
                        //TileCon.SelectTileBottom();

                    }*/
                    //AM.Play1();
                }                  //commented part
            }
            else if (crashed.gameObject.GetComponent<SpriteRenderer>().color==Color.cyan)///FOR QUIT
            {
                //crashed.gameObject.GetComponent<SpriteRenderer>().color = Color.cyan;
                if (hearts == 1)
                {
                    scriptManager.GameOver();
                }
                else
                {
                    --hearts;
                    FireAllowed = true;
                    AIM.SetActive(true);
                    speaker.GetComponent<AudioSource>().clip = bombAudio;
                    speaker.Play();
                    if (false)
                    {
                        //transform.position = crashed.gameObject.GetComponent<Tiles>().Rester().transform.position;
                        //fire.velocity = Vector2.zero;
                        //gameObject.transform.localScale = new Vector3(0.3196901f, -0.3196901f, 0.3196901f);

                        //AM.PlayA3();
                        /*if (crashed.gameObject.GetComponent<Tiles>().tileNum != TileCon.num)
                        {
                            //TileCon.SelectTileBottom();

                        }*/
                    }              //commented part
                }
            }
            else                                                                         /////for other tiles 
            {
                
                //crashed.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
                if (false)
                {
                    //TileCon.showBombTop();
                    /*AIM.SetActive(true);
                    fire.velocity = Vector2.zero;
                    gameObject.transform.localScale = new Vector3(0.3196901f, -0.3196901f, 0.3196901f);
                    transform.position = crashed.gameObject.GetComponent<Tiles>().Rester().transform.position;
                    FireAllowed = true;*/
                    //AM.Play1();
                    /*if (crashed.gameObject.GetComponent<Tiles>().tileNum != TileCon.num)
                    {
                        TileCon.SelectTileBottom();


                    }*/
                }                  //commented part
            }
            TileCon.SelectTileBottom();

        }
        else if(!CollidedBottom && crashed.gameObject.tag == "Bottom")
        {
            CollidedBottom = true;
            CollidedTop = false;
            FireAllowed = true;
            x = crashed.transform.position.x;
            y = crashed.transform.position.y + (crashed.gameObject.GetComponent<RectTransform>().rect.height) / 2+0.05f;     //since we already know it is top tile//
            z = crashed.transform.position.z;
            fire.transform.position = new Vector3(x, y, z);
            fire.velocity = Vector2.zero;
            gameObject.transform.localScale = new Vector3(0.3196901f, 0.3196901f, 0.3196901f);
            AIM.SetActive(true);
            
            if (crashed.gameObject.GetComponent<SpriteRenderer>().color == Color.green)///FOR SCORE
            {
                crashed.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
                playsound = decide_tile.pickSound();
                speaker.GetComponent<AudioSource>().clip = playsound;
                speaker.Play();
                if (false)
                {
                    //TileCon.SelectTileTop();
                    //SM.AddScore();

                    //AM.Play1();
                    /*if (crashed.gameObject.GetComponent<Tiles>().tileNum == TileCon.num)
                    {

                        TileCon.SelectTileTop();

                    }*/
                }                //commented part
            }
            else if (crashed.gameObject.GetComponent<SpriteRenderer>().color == Color.cyan)/// FOR QUit
            {
                //crashed.gameObject.GetComponent<SpriteRenderer>().color = Color.cyan;
                speaker.GetComponent<AudioSource>().clip = bombAudio;
                speaker.Play();
                if (hearts == 1)
                {
                    scriptManager.GameOver();
                }
                else
                {
                    --hearts;
                    FireAllowed = true;
                    if (false)
                    {
                        /*transform.position = crashed.gameObject.GetComponent<Tiles>().Rester().transform.position;
                        fire.velocity = Vector2.zero;
                        gameObject.transform.localScale = new Vector3(0.3196901f, 0.3196901f, 0.3196901f);
                        AIM.SetActive(true);*/
                        //AM.PlayA3();
                        /*if (crashed.gameObject.GetComponent<Tiles>().tileNum != TileCon.num)
                        {

                            TileCon.SelectTileTop();

                        }*/
                    }            //commented part
                }

            }
            else
            {
                
                //crashed.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
                if (false)
                {
                    //TileCon.showBombBottom();
                    /*AIM.SetActive(true);
                    transform.position = crashed.gameObject.GetComponent<Tiles>().Rester().transform.position;
                    fire.velocity = Vector2.zero;
                    gameObject.transform.localScale = new Vector3(0.3196901f, 0.3196901f, 0.3196901f);
                    FireAllowed = true;*/
                    //AM.Play1();
                    /*if (crashed.gameObject.GetComponent<Tiles>().tileNum != TileCon.num)
                    {

                        TileCon.SelectTileTop();

                    }*/
                }                //commented part
            }
            TileCon.SelectTileTop();

        }  
        else if(crashed.gameObject.tag == "boundary")             //just for fun bouncing sound//
        {
            speaker.GetComponent<AudioSource>().clip = boundarybounce;
            speaker.Play();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "bomb")

        {
            //AM.PlayA2();
            int ss;
            if (y > 0f)
            {
                ss = 1;
            }
            else
            {
                ss = 0;
            }
                Destroy(collision.gameObject);
            if (ss == 0) {
                TileCon.showBombTop();
            }
            else
            {
                TileCon.showBombBottom();
            }
        } 
        if (collision.gameObject.tag == "coin")
        {
            Destroy(collision.gameObject);
            coin = coin + 1;
            coinDisplay.text = coin.ToString();

        }
    }  
     
}
  