using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb; // reference to the character's rigidbody component
    [SerializeField]
    private bool isGrounded = false; // whether the character is currently on the ground

    public float moveSpeed = 5f; // speed at which the character moves horizontally
    public float jumpForce = 10f; // force with which the character jumps
    public float hitForce = 20f; // force with which the character hit
    public Transform groundCheck; // transform of an object used to check if the character is grounded
    public float checkRadius; // radius of the circle used for ground checking
    public LayerMask groundLayer; // layer mask used to identify ground objects


    public enum CharacterState { Idle, Running, Jumping, Falling, Hit }
    [SerializeField]
    private StateMachine<CharacterState> stateMachine = new StateMachine<CharacterState>();
    //private CharacterState currentState;

    public CharacterState currentState
    {
        get
        {
            return stateMachine.GetState();
        }
        set
        {
            stateMachine.SetState(value);
        }
    }


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // get the rigidbody component reference
        InitState();
    }

    private void Update()
    {
        CheckLogic();
        stateMachine.UpdateState();
        //isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);
        //switch (currentState)
        //{
        //    case CharacterState.Idle:
        //        IdleState();
        //        break;
        //    case CharacterState.Running:
        //        RunningState();
        //        break;
        //    case CharacterState.Jumping:
        //        JumpingState();
        //        break;
        //}
    }


    private void InitState()
    {
        stateMachine.AddState(CharacterState.Idle, IdleState);
        stateMachine.AddState(CharacterState.Running, RunningState);
        stateMachine.AddState(CharacterState.Jumping, JumpingState);
        stateMachine.AddState(CharacterState.Falling, FallingState);
        stateMachine.AddState(CharacterState.Hit, HitState);

        currentState = CharacterState.Idle;
    }

    private void IdleState()
    {
        // Check for transition to running state
        float moveInput = Input.GetAxisRaw("Horizontal");
        if (moveInput != 0)
        {
            currentState = CharacterState.Running;
        }

        // Check for transition to jumping state
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            currentState = CharacterState.Jumping;
        }
    }

    private void RunningState()
    {
        // Check for transition to idle state
        float moveInput = Input.GetAxisRaw("Horizontal");
        if (moveInput == 0)
        {
            currentState = CharacterState.Idle;
        }

        // Check for transition to jumping state
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            currentState = CharacterState.Jumping;
        }

        // Apply horizontal movement
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
    }

    private void JumpingState()
    {
        if (isGrounded)
        {
            // Apply jump force
            isGrounded = false;
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            currentState = CharacterState.Falling;
        }
    }

    private void FallingState()
    {
        if (isGrounded && Mathf.Abs(rb.velocity.y) <= 0.1f)
        {
            currentState = CharacterState.Idle;
        }
    }

    private void HitState()
    {
        if (isGrounded && Mathf.Abs(rb.velocity.y) <= 0.1f)
        {
            currentState = CharacterState.Idle;
        }
    }

    private void CheckLogic()
    {
        CheckGroundLogic();
        CheckHitLogic();
    }

    private void CheckGroundLogic()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, checkRadius, 1 << LayerMask.NameToLayer("Ground"));

        if (hit)
        {
            int hitLayer = hit.collider.gameObject.layer;
            switch (hitLayer)
            {
                case int val when val == LayerMask.NameToLayer("Ground"):
                    isGrounded = true;
                    break;
                default:
                    break;
            }
        }
        else
        {
            isGrounded = false;
        }

    }

    private void CheckHitLogic()
    {
        // ground check
        RaycastHit2D hit = Physics2D.CircleCast(transform.position, checkRadius, Vector2.up, 1, 
                                                1 << LayerMask.NameToLayer("HitGround") | 1 << LayerMask.NameToLayer("Destination"));

        if (hit)
        {
            int hitLayer = hit.collider.gameObject.layer;

            switch (hitLayer)
            {
                case int val when val == LayerMask.NameToLayer("HitGround"):
                    currentState = CharacterState.Hit;
                    rb.velocity = new Vector2(-hitForce, hitForce);
                    break;
                case int val when val == LayerMask.NameToLayer("Destination"):
                    // Next Stage or Main Scene
                    GameManager.Instance.LoadScene("Main");
                    break;
                default:
                    break;
            }
        }
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.collider != null)
    //    {
    //        int hitLayer = collision.collider.gameObject.layer;

    //        switch (hitLayer)
    //        {
    //            case int val when val == LayerMask.NameToLayer("Ground"):
    //                isGrounded = true;
    //                break;
    //            case int val when val == LayerMask.NameToLayer("HitGround"):
    //                currentState = CharacterState.Hit;
    //                rb.velocity = new Vector2(-hitForce, hitForce);

    //                break;
    //            default:
    //                break;
    //        }
    //    }
    //    else
    //    {
    //        isGrounded = false;
    //    }
    //}

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, checkRadius);
    }

}
