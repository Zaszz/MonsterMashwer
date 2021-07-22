using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMasterController : MonoBehaviour
{
    public PlayerAnimationController playerAnimationController;
    public PlayerMovement playerMovement;
    public PlayerHitable playerHitable;

    // Start is called before the first frame update
    void Awake()
    {
        PlayerManager.playerObject = this.gameObject;
    }



}
