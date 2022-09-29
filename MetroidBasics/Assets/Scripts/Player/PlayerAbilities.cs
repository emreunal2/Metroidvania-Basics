using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilities : MonoBehaviour
{
    [SerializeField] bool canDropBomb;
    [SerializeField] bool canDoubleJump;
    [SerializeField] bool canDash;
    [SerializeField] bool canTurnBall;

    public bool CanDropBomb { get => canDropBomb; set => canDropBomb = value; }
    public bool CanDoubleJump { get => canDoubleJump; set => canDoubleJump = value; }
    public bool CanDash { get => canDash; set => canDash = value; }
    public bool CanTurnBall { get => canTurnBall; set => canTurnBall = value; }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
