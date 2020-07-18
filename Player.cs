using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Player : MonoBehaviour
{
    public static Player instance;
    Animator anim;
    public static float MoveSpeed ;
    Rigidbody2D RB;
    public GameObject food ;
    public GameObject[] Poisonfood;
    public Vector3 size;
    public Text highScore, result ,timer;
    Vector3 foodpos,PoisonFoodPos ,blockpos;
    public static bool isDead = false;
    public AudioSource Eating; 
    public World world;
    private Vector2 diraction = Vector2.zero;
    Score S;

    // Start is called before the first frame update
    void Start()
    {
        S= GameObject.Find("Game Manager").GetComponent<Score>();
        MoveSpeed = 1.5f;
        RB = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        foodSpawner();
        PoisonfoodSpawner();
        highScore.text ="High Score "+ PlayerPrefs.GetInt("highScore", 0).ToString();
    }

    // Update is called once per frame
    void Update()
    {
       
        if (isDead == false)
        {
           
            anim.SetTrigger("move");
            checkdiraction();
            move();
            updatadiraction();
        }
        if (Score.CurrentScore > PlayerPrefs.GetInt("highScore", 0))
        {
            PlayerPrefs.SetInt("highScore", Score.CurrentScore);
            highScore.text = "High Score " + Score.CurrentScore.ToString();
        }
        else if(isDead==true)
        {
            MoveSpeed = 0;
            anim.SetTrigger("dead");
        }

       
    }
    public void foodSpawner()
    {
        if (isDead == false)
        {
            foodpos = new Vector3(Random.Range(-size.x, size.x), Random.Range(-size.y, size.y), 0f );
            Instantiate(food , foodpos, Quaternion.identity);
        }

    }
    public void PoisonfoodSpawner()
    {
        
        if (isDead == false)
        {
            int j = (int)Random.Range(0, Poisonfood.Length);
            PoisonFoodPos = new Vector3(Random.Range(-size.x, size.x), Random.Range(-size.y, size.y), 0f);
            if (foodpos != PoisonFoodPos)
            {
                Instantiate(Poisonfood[j], PoisonFoodPos, Quaternion.identity);
            }
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
       if(collision.gameObject.tag=="Limits")
        {  
            isDead = true;
            S.Lost();
        }
        if (collision.gameObject.tag == "Food")
        {
            Eating.Play();
            Score.CurrentScore++;
            Destroy(GameObject.FindGameObjectWithTag("Food"));
            foodSpawner();
            S.Win();  
        }
        if(collision.gameObject.tag== "PoisonFood")
        {
            Score.CurrentScore--;
            Eating.Play();
            Destroy(GameObject.FindGameObjectWithTag("PoisonFood"));
            Invoke("PoisonfoodSpawner", 10);
        }
    }
    void checkdiraction()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            diraction = Vector2.left;

        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            diraction = Vector2.right;

        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            diraction = Vector2.up;

        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            diraction = Vector2.down;

        }


    }
    void move()
    {
        transform.localPosition += (Vector3)(diraction * MoveSpeed) * Time.deltaTime;

    }
    void updatadiraction()
    {
        if (diraction == Vector2.right)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        else if (diraction == Vector2.left)
        {
            transform.localScale = new Vector3(1, 1, 1);
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        else if (diraction == Vector2.down)
        {
            transform.localScale = new Vector3(1, 1, 1);
            transform.localRotation = Quaternion.Euler(0, 0, 90);
        }
        else if (diraction == Vector2.up)
        {
            transform.localScale = new Vector3(1, 1, 1);
            transform.localRotation = Quaternion.Euler(0, 0, 270);
        }
    }

}
