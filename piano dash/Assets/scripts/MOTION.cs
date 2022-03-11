using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
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
    public int lives;
    public AudioSource speaker;
    public AudioClip bombAudio;
    public AudioClip boundarybounce;
    public Text coinDisplay;
    public TextMeshProUGUI totalcoins;
    public GameObject[] heart;
   

    public Transform Target;
    public Vector2 Direction;
    AudioClip playsound;
    public TileDecider decide_tile;
    private bool CollidedTop = false;
    private bool CollidedBottom = false;
    bool manualmode = false;
    public Transform anchor;
    public Transform scopepos;
    public Transform shootingaim;
    float direction = -1f;
    int screenwidth;

    public bool dragged = false;
    public bool aimmove = false;
    float x=-0.28f, y=-1.5f, z=91.7f;              //initial values for the replacement of fire if it gets out of bounds at the very start of the game//

    public void Start()
    {
        fire = this.GetComponent<Rigidbody2D>();
        if (!PlayerPrefs.HasKey("totalcoin"))
        {
            PlayerPrefs.SetInt("totalcoin", 0);
            coin = PlayerPrefs.GetInt("totalcoin");
            totalcoins.text = coin.ToString();
        }
        else
        {
            coin = PlayerPrefs.GetInt("totalcoin");
            totalcoins.text = coin.ToString();
        }
        Invoke("checkformanual", 0.5f);
        screenwidth = Screen.width;
    }
    void Update()
    {
        if (manualmode)
        {
            /*if (!scriptManager.Pause.activeInHierarchy && !scriptManager.levelcomplete.activeInHierarchy && !scriptManager.GameOverScreen.activeInHierarchy)
            {
               // 
            }*/
            checkfordragging();
            if (!EventSystem.current.IsPointerOverGameObject(0) && !EventSystem.current.IsPointerOverGameObject() && !dragged && aimmove && FireAllowed)
            {
                Debug.Log("fire");
                CanFire();
            }
            shoot();
        }
        else if (!manualmode)
        {
            if (!EventSystem.current.IsPointerOverGameObject(0) && !EventSystem.current.IsPointerOverGameObject() && Input.GetMouseButtonDown(0) && FireAllowed)
            {
                CanFire();
            }
        }
        if (fire.transform.position.y > 2f || fire.transform.position.y < -4f){
            fire.transform.position = new Vector3(x, y, z);
            fire.velocity = Vector2.zero;
            FireAllowed = true;
            AIM.SetActive(true);
        }
        /*if (Input.GetMouseButtonDown(0))
        {
            dragged = true;
            aimmove = false;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            dragged = false;
            aimmove = true;
        }*/
    }
    void checkfordragging()
    {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            dragged = true;
            aimmove = false;
        }
        else if (Input.GetMouseButtonUp(0) && !EventSystem.current.IsPointerOverGameObject(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            dragged = false;
            aimmove = true;
        }
    }
    void checkformanual()
    {
        if (PlayerPrefs.GetInt("manual") == 1)
        {
            manualmode = true;
        }
        else
        {
            manualmode = false;
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
    public void shoot()
    {
        if (dragged)
        {
            Vector3 initial = Input.mousePosition;
            float mouseposition = initial.x;
            float distanceleft = mouseposition - (screenwidth / 2);
            shootingaim.rotation = Quaternion.Euler(0f, 0f, direction * distanceleft * 160f / screenwidth);
            /*Vector3 final = scopepos.position;
            Vector3 decidingvector = initial - final;
            Vector3 shootingvector;
            shootingvector.x = 0f;
            shootingvector.y = 0f;
            shootingvector.z = -decidingvector.x;
            shootingaim.rotation = Quaternion.Euler(0f, 0f, (shootingvector.z + 90f) * 0.85f * direction);*/

            /*if (shootingaim.rotation.z>=-0.62f && shootingaim.rotation.z<=0.62f)
            {
                Vector3 initial = Input.mousePosition;
                Vector3 final = scopepos.position;
                Vector3 decidingvector = initial - final;
                Vector3 shootingvector;
                shootingvector.x = 0f;
                shootingvector.y = 0f;
                shootingvector.z = -decidingvector.x;
                shootingaim.rotation = Quaternion.Euler(0f, 0f, (shootingvector.z + 90f) * 0.85f * direction);
            }
            if (shootingaim.rotation.z > 0.62f)
            {
                shootingaim.rotation = Quaternion.Euler(0f, 0f, 80f);
            }
            else if (shootingaim.rotation.z < -0.62f)
            {
                shootingaim.rotation = Quaternion.Euler(0f, 0f, -80f);
            }*/
            //Debug.Log(shootingaim.rotation.z);
        }
        
        //}
    }
    public void OnCollisionEnter2D(Collision2D crashed)
    {
        
        if (!CollidedTop && crashed.gameObject.tag == "Top")
        {
            aimmove = false;
            anchor.transform.position = new Vector3(0f, 5f, 0f);
            direction = 1f;
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
            
            
            if (crashed.gameObject.GetComponent<SpriteRenderer>().color==Color.green)
            {
                crashed.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
                playsound = decide_tile.pickSound();
                speaker.GetComponent<AudioSource>().clip = playsound;
                speaker.Play();
            }
            else if (crashed.gameObject.GetComponent<SpriteRenderer>().color==Color.cyan)
            {
                speaker.GetComponent<AudioSource>().clip = bombAudio;
                speaker.Play();
                lives -= 2;
                FireAllowed = true;
                if (lives<1)
                {
                    scriptManager.continuescreen();
                }
                else
                {
                    for (int temp = 6; temp > lives; temp--)
                    {
                        heart[temp - 1].SetActive(false);
                    }
                }
            }
            else                                                                         
            {
                //for white tiles
                --lives;
                if (lives < 1)
                {
                    scriptManager.continuescreen();
                }
                else
                {
                    for (int temp = 6; temp > lives; temp--)
                    {
                        heart[temp - 1].SetActive(false);
                    }
                }
                speaker.GetComponent<AudioSource>().clip = bombAudio;
                speaker.Play();
            }
            TileCon.SelectTileBottom();
            //Debug.Log(lives);
        }
        else if(!CollidedBottom && crashed.gameObject.tag == "Bottom")
        {
            aimmove = false;
            anchor.transform.position = new Vector3(0f, -5f, 0f);
            direction = -1f;
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
            
            if (crashed.gameObject.GetComponent<SpriteRenderer>().color == Color.green)
            {
                crashed.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
                playsound = decide_tile.pickSound();
                speaker.GetComponent<AudioSource>().clip = playsound;
                speaker.Play();
            }
            else if (crashed.gameObject.GetComponent<SpriteRenderer>().color == Color.cyan)
            {
                speaker.GetComponent<AudioSource>().clip = bombAudio;
                speaker.Play();
                lives -= 2;
                FireAllowed = true;
                if (lives<1)
                {
                    scriptManager.continuescreen();
                }
                else
                {
                    for (int temp = 6; temp > lives; temp--)
                    {
                        heart[temp - 1].SetActive(false);
                    }
                }
            }
            else
            {
                //for white tiles
                --lives;
                if (lives < 1)
                {
                    scriptManager.continuescreen();
                }
                else
                {
                    for (int temp = 6; temp > lives; temp--)
                    {
                        heart[temp - 1].SetActive(false);
                    }
                }
                speaker.GetComponent<AudioSource>().clip = bombAudio;
                speaker.Play();
            }
            TileCon.SelectTileTop();
            //Debug.Log(lives);
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
            PlayerPrefs.SetInt("totalcoin", coin);
            totalcoins.text= coin.ToString();

        }
    }  
     
}
  