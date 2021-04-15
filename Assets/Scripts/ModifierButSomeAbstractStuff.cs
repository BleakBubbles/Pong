using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ModifierButSomeAbstractStuff : MonoBehaviour
{
    public abstract void Activate(Ball ball, Player playerPaddle);

    public abstract void Deactivate(Ball ball, Player playerPaddle);
}
