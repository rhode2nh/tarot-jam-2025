using UnityEngine;

public abstract class CardContent : ScriptableObject, ICardContent
{
    public abstract void Realize(GameObject player);
}
