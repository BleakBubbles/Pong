using UnityEngine;

public abstract class ItemButSomeAbstractStuff : MonoBehaviour
{
    public abstract void Pickup(Ball ball, Player playerPaddle);

    public abstract void Drop(Ball ball, Player playerPaddle);
}
