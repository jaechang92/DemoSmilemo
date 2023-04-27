//public class PlayerPresenter
//{
//    private PlayerModel playerModel;
//    private PlayerView playerView;
//    private FSM<PlayerView> fsm;

//    public PlayerPresenter(PlayerView playerView)
//    {
//        this.playerView = playerView;
//        playerModel = new PlayerModel(playerView.gameObject);
//        fsm = new FSM<PlayerView>(playerView);
//        fsm.SetCurrentState(new IdleState<PlayerView>());
//    }

//    public void MovePlayer(float direction)
//    {
//        playerModel.Move(direction);
//        if (direction != 0)
//        {
//            fsm.ChangeState(new RunningState<PlayerView>());
//        }
//        else
//        {
//            fsm.ChangeState(new IdleState<PlayerView>());
//        }
//    }

//    public void JumpPlayer()
//    {
//        playerModel.Jump();
//        fsm.ChangeState(new JumpingState<PlayerView>());
//    }

//    public void SetGrounded(bool grounded)
//    {
//        playerModel.isGrounded = grounded;
//        if (grounded)
//        {
//            fsm.ChangeState(new IdleState<PlayerView>());
//        }
//    }
//}
