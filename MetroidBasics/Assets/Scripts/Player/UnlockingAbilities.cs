using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockingAbilities : MonoBehaviour
{
    [SerializeField] enum Ability {unlockDash,unlockBall,unlockJump,unlockBomb};
    [SerializeField] Ability ability;
    PlayerAbilities abilities;
    // Start is called before the first frame update


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("test2");
            abilities = collision.GetComponentInParent<PlayerAbilities>();
            switch (ability)
            {
                case Ability.unlockDash:
                    abilities.CanDash = true;
                    break;
                case Ability.unlockJump:
                    abilities.CanDoubleJump = true;
                    break;
                case Ability.unlockBomb:
                    abilities.CanDropBomb = true;
                    break;
                case Ability.unlockBall:
                    abilities.CanTurnBall = true;
                    break;
            }
            Destroy(gameObject);
        }
    }
}
