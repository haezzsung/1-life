using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{

    private Rigidbody2D rigidbody;
    private Animator anim;
    public float speed;
    private float defaultSpeed;
    [SerializeField] private float jumppower;
    bool isGround;
    [SerializeField] Transform pos;
    [SerializeField] float checkRadius;
    [SerializeField] LayerMask islayer;
    private bool grounded;
    public int Gold;
    public int damge;

    private float cur;
    public float cool;
    public Transform pos1;
    public Vector2 boxSize;
    public Vector2 boxSize1;

    private float JumpTimeCounter;
    public float JumpTime;
    private bool isJump;
    static bool isdeth = false;

    public static int dethcount = 0;

    public Text DethCountUi;

    public AudioSource mySfx;
    public AudioClip swishSfx;
    

    void Start()
    {
        defaultSpeed = speed;
        rigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    
    }
    public void swishSoundPlay()
    {
        mySfx.PlayOneShot(swishSfx);
    }


    private void Update()
    {

        float horizontalInput = Input.GetAxis("Horizontal");
        //점프    
        isGround = Physics2D.OverlapCircle(pos.position, checkRadius, islayer);

        if (isdeth == false && isGround == true && Input.GetKeyDown(KeyCode.Space))
        {
            isJump = true;
            JumpTimeCounter = JumpTime;
            rigidbody.velocity = Vector2.up * jumppower;
            anim.SetTrigger("jump");
            grounded = false;

           // SoundManger.instance.SFXPlay("Jump", clip); 
        }
        if (Input.GetKey(KeyCode.Space) && isJump == true)
        {
            if (JumpTimeCounter > 0)
            {
                rigidbody.velocity = Vector2.up * jumppower;
                JumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJump = false;
            }
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            isJump = false;
        }

        //애니메이션
        anim.SetBool("run", horizontalInput != 0);
        anim.SetBool("grounded", grounded);


        //공격

        if (cur <= 0)
        {
            //공격
            if (Input.GetKeyDown(KeyCode.X) && isdeth == false)
            {

                Collider2D[] collider2Ds = Physics2D.OverlapBoxAll(pos1.position, boxSize, 0);
                foreach (Collider2D collider in collider2Ds)
                {   
                    if(collider.tag == "Boss")
                    {
                        collider.GetComponent<Boss>().TackDamge(1);
                    }
                    if (collider.tag == "Enemy")
                    {
                        collider.GetComponent<Enemy>().enemyTakeDamge();
                    }
                    if (collider.tag == "Wizard")
                    {
                        collider.GetComponent<Wizard>().DestroyWizard();
                    }
                    if (collider.tag == "fallEnemy")
                    {  
                        collider.GetComponent<FallEnemy>().fallenemyDeth();
                    }
                }
                swishSoundPlay();
                anim.SetTrigger("atk");
                cur = cool;
            }
        }
        else
        {
            cur -= Time.deltaTime;
        }


    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(pos1.position, boxSize);
        Gizmos.DrawWireCube(pos.position, boxSize1);
    }

    public void OverPage()
    {
        SceneManager.LoadScene("GameOver");
        isdeth = false;
    }

    public void isdethfalse()
    {
        isdeth = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = true;
        }
        if (collision.gameObject.CompareTag("Enemy")) //사망
        {
            dethAtcive();
        }
        if (collision.gameObject.CompareTag("Boss")) //사망
        {
            dethAtcive();
        }
        if (collision.gameObject.CompareTag("bullet")) //사망
        {
            dethAtcive();
        }
        if (collision.gameObject.CompareTag("Spike")) //사망
        {
            dethAtcive();
        }
        if (collision.gameObject.CompareTag("fallEnemy")) //사망
        {
            dethAtcive();
        }
        if (collision.gameObject.CompareTag("menugo")) 
        {
            SceneManager.LoadScene("MainMenu");
        }
        if (collision.gameObject.CompareTag("restart")) 
        {
            SceneManager.LoadScene("MainGame");
            dethcount = 0;
        }
    }
    private void dethAtcive()
    {
        dethcount += 1;
        Invoke("isdethfalse", 0.2f);
        Invoke("OverPage", 0.201f);
        anim.SetBool("deth", true);
        isdeth = true;
    }

    private void ResetSpeed()
    {
        defaultSpeed = 6;
    }

    void FixedUpdate()
    {
        //이동
        float hor = Input.GetAxis("Horizontal");
        if(isdeth == false)
        {
            rigidbody.velocity = new Vector2(hor * defaultSpeed, rigidbody.velocity.y);
        }
        

        if (Input.GetKey(KeyCode.LeftShift))
        {
            defaultSpeed = 20;
            Invoke("ResetSpeed", 0.3f);
        }
        else
        {
            defaultSpeed = speed;
        }


        //애니메이션
        if (hor > 0.01f)
            transform.localScale = new Vector3(-1, 1, 1);
        else if (hor < -0.01f)
        {
            transform.localScale = Vector3.one;
        }
        DethCountUi.text = "Death : " + dethcount.ToString();

    }
}

