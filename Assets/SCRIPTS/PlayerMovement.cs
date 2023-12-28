using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private AudioClip Coin, Jump;
    private Animator animator;
    private Rigidbody m_rigidbody;
    private AudioSource m_audioSource;
    // Start is called before the first frame update
    public static int CurrentTile = 0;
    public static bool IsFlying = false;
    [SerializeField] private GameObject Wings;
    [SerializeField] private GameObject StartScreen, UI_SCREEN;
    [SerializeField] private TextMeshProUGUI Inv_coins;


    private int INV_COINS;

    public void StartGame()
    {
        UI_SCREEN.SetActive(true);
        StartScreen.SetActive(false);
        animator.SetBool("Run", true);
    }
    void Start()
    {

        INV_COINS = PlayerPrefs.GetInt("InventoryCoins");
        Inv_coins.text = INV_COINS.ToString();
        animator = GetComponent<Animator>();
        m_rigidbody = GetComponent<Rigidbody>();
        m_audioSource = GetComponent<AudioSource>();
    }

    private int Next_X_POS;
    private bool Left, Right;
    // Update is called once per frame
    private Vector2 TouchBegan, TouchMove;
    private float DRAG_X, DRAG_Y;
    private bool CanDrag;
    void Update()
    {

        if (Input.touchCount > 0)
        {

            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                CanDrag = true;
                TouchBegan = touch.position;
                TouchMove = Vector2.zero;
            }
            else if (touch.phase == TouchPhase.Moved && CanDrag)
            {
                TouchMove = touch.position;

                DRAG_X = Mathf.Abs(TouchBegan.x - TouchMove.x); //Mathf.Abs Avoid negative value
                DRAG_Y = Mathf.Abs(TouchBegan.y - TouchMove.y);//Mathf.Abs Avoid negative value

                if (DRAG_Y > DRAG_X)
                {
                    //swipe up
                    if (TouchMove.y > TouchBegan.y)
                    {
                        CanDrag = false;
                        if (!animator.GetBool("FLYING"))
                        {
                            m_audioSource.PlayOneShot(Jump);
                            isJumpDown = false;
                            m_rigidbody.position = new Vector3(Next_X_POS, transform.position.y, transform.position.z);
                            animator.SetBool("Slide", false);
                            animator.SetBool("Left", false);
                            animator.SetBool("Right", false);
                            animator.SetBool("Jump", true);
                        }
                    }
                    //swipe down
                    else
                    {
                        CanDrag = false;
                        if (!animator.GetBool("FLYING"))
                        {
                            animator.SetBool("Jump", false);
                            animator.SetBool("Slide", true);
                        }
                    }
                }

                else if (DRAG_X > DRAG_Y)
                {

                    //right
                    if (TouchMove.x > TouchBegan.x)
                    {
                        CanDrag = false;
                        if (!animator.GetBool("Jump") && !animator.GetBool("Slide") && !animator.GetBool("FLYING"))
                            animator.SetBool("Right", true);
                        else
                            Right = true;
                        if (m_rigidbody.position.x >= -3 && m_rigidbody.position.x < -1)
                        {
                            Next_X_POS = 0;
                        }
                        else if (m_rigidbody.position.x >= -1 && m_rigidbody.position.x < 1)
                        {
                            Next_X_POS = 2;
                        }

                    }
                    //left
                    else
                    {
                        CanDrag = false;
                        if (!animator.GetBool("Jump") && !animator.GetBool("Slide") && !animator.GetBool("FLYING"))
                            animator.SetBool("Left", true);
                        else
                            Left = true;
                        if (m_rigidbody.position.x >= 1 && m_rigidbody.position.x < 3)
                        {
                            Next_X_POS = 0;
                        }
                        else if (m_rigidbody.position.x >= -1 && m_rigidbody.position.x < 1)
                        {
                            Next_X_POS = -2;
                        }
                    }
                }
            }
        }
        if (animator.GetBool("FALL_DEAD") || animator.GetBool("DEAD"))
        {
            PlayerPrefs.SetInt("InventoryCoins", CoinsCollected + INV_COINS);
            PlayerPrefs.SetInt("CoinsCollected", CoinsCollected);
            InterstitialAdExample.ad.LoadAd();
            InterstitialAdExample.ad.ShowAd();
            SceneManager.LoadScene("GAME_OVER_SCREEN");
        }
        if (IsFlying && !animator.GetBool("FLYING"))
        {
            animator.SetBool("Slide", false);
            animator.SetBool("Jump", false);
            m_rigidbody.useGravity = false;
            animator.SetBool("FLYING", true);


        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            UI_SCREEN.SetActive(true);
            StartScreen.SetActive(false);
            animator.SetBool("Run", true);
        }

        else if (Input.GetKeyUp(KeyCode.S) && !animator.GetBool("FLYING"))
        {
            animator.SetBool("Jump", false);
            animator.SetBool("Slide", true);
        }
        else if (Input.GetKeyUp(KeyCode.W) && !animator.GetBool("FLYING"))
        {
            m_audioSource.PlayOneShot(Jump);
            isJumpDown = false;
            m_rigidbody.position = new Vector3(Next_X_POS, transform.position.y, transform.position.z);
            animator.SetBool("Slide", false);
            animator.SetBool("Left", false);
            animator.SetBool("Right", false);
            animator.SetBool("Jump", true);
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            if (!animator.GetBool("Jump") && !animator.GetBool("Slide") && !animator.GetBool("FLYING"))
                animator.SetBool("Right", true);
            else
                Right = true;
            if (m_rigidbody.position.x >= -3 && m_rigidbody.position.x < -1)
            {
                Next_X_POS = 0;
            }
            else if (m_rigidbody.position.x >= -1 && m_rigidbody.position.x < 1)
            {
                Next_X_POS = 2;
            }

        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            if (!animator.GetBool("Jump") && !animator.GetBool("Slide") && !animator.GetBool("FLYING"))
                animator.SetBool("Left", true);
            else
                Left = true;
            if (m_rigidbody.position.x >= 1 && m_rigidbody.position.x < 3)
            {
                Next_X_POS = 0;
            }
            else if (m_rigidbody.position.x >= -1 && m_rigidbody.position.x < 1)
            {
                Next_X_POS = -2;
            }

        }
    }
    //Animation event
    void ToggleOff(string Name)
    {
        animator.SetBool(Name, false);
        isJumpDown = false;
    }
    //Animation event
    private bool isJumpDown = false;
    void JumpDown()
    {
        isJumpDown = true;
    }
    private void OnAnimatorMove()
    {
        if (animator.GetBool("FALL_DEAD"))
        {

            m_rigidbody.MovePosition(m_rigidbody.position + Vector3.down * animator.deltaPosition.magnitude);



        }
        else if (animator.GetBool("FLYING"))
        {
            m_rigidbody.velocity = Vector3.zero;
            if (!IsFlying)
            {
                if (m_rigidbody.position.y > 2)
                    m_rigidbody.MovePosition(m_rigidbody.position + new Vector3(0, -1.5F, 1) * animator.deltaPosition.magnitude);
                else
                {
                    Wings.SetActive(false);
                    animator.SetBool("FLYING", false);
                }

            }
            else if (m_rigidbody.position.y < 10)
                m_rigidbody.MovePosition(m_rigidbody.position + new Vector3(0, 3, 2.5F) * animator.deltaPosition.magnitude);
            else
                m_rigidbody.MovePosition(m_rigidbody.position + new Vector3(0, 0, 2.5F) * animator.deltaPosition.magnitude);
        }
        else if (animator.GetBool("Jump"))
        {

            if (isJumpDown)
                m_rigidbody.MovePosition(m_rigidbody.position + new Vector3(0, 0, 2) * animator.deltaPosition.magnitude);
            else
            {
                m_rigidbody.MovePosition(m_rigidbody.position + new Vector3(0, 1.5f, 2) * animator.deltaPosition.magnitude);

            }

        }

        else if (animator.GetBool("Right"))
        {
            if (m_rigidbody.position.x <= Next_X_POS)
                m_rigidbody.MovePosition(m_rigidbody.position + new Vector3(2f, 0, 1.5f) * animator.deltaPosition.magnitude);
            else
            {
                m_rigidbody.position = new Vector3(Next_X_POS, transform.position.y, transform.position.z);
                animator.SetBool("Right", false);
            }



        }

        else if (animator.GetBool("Left"))
        {
            if (m_rigidbody.position.x >= Next_X_POS)
                m_rigidbody.MovePosition(m_rigidbody.position + new Vector3(-2f, 0, 1.5f) * animator.deltaPosition.magnitude);
            else
            {
                m_rigidbody.position = new Vector3(Next_X_POS, transform.position.y, transform.position.z);
                animator.SetBool("Left", false);
            }

        }


        else
            m_rigidbody.MovePosition(m_rigidbody.position + new Vector3(0, 0, 1.5f) * animator.deltaPosition.magnitude);

        if (Left)
        {

            if (m_rigidbody.position.x > Next_X_POS)
                m_rigidbody.MovePosition(m_rigidbody.position + new Vector3(-1, 0, 0) * animator.deltaPosition.magnitude);
            else

                Left = false;
        }

        else if (Right)
        {

            if (m_rigidbody.position.x < Next_X_POS)
                m_rigidbody.MovePosition(m_rigidbody.position + new Vector3(1, 0, 0) * animator.deltaPosition.magnitude);
            else

                Right = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("OBS"))
        {
            animator.SetBool("DEAD", true);
        }

    }

    [SerializeField] private GameObject Camera_obj;
    [SerializeField] private TextMeshProUGUI CoinsText;
    private int CoinsCollected;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("FALL_DAMAGE"))
        {
            Camera_obj.transform.parent = null;
            animator.SetBool("FALL_DEAD", true);
        }
        else if (other.CompareTag("DISABLE FLY"))
        {
            IsFlying = false;
            m_rigidbody.useGravity = true;

        }
        else if (other.CompareTag("Coins"))
        {
            m_audioSource.PlayOneShot(Coin);
            CoinsCollected++;
            CoinsText.text = CoinsCollected.ToString();
        }
    }
}
