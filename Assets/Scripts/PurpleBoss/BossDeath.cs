using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDeath : BossBaseState
{
    public override void RunState()
    {
        EndGameManager.endManager.possibleWin = true;
        EndGameManager.endManager.StartResolveSequence();
        gameObject.SetActive(false);
    }
}
