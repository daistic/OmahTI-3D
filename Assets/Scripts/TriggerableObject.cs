using UnityEngine;

public class TriggerableObject : Interactable
{
    public override void Interact()
    {
        DoSomething();
    }

    void DoSomething()
    {
        Debug.Log("Do Something");
    }
}