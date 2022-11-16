using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Anim : MonoBehaviour
{
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void PlayAnim()
    {
        anim.SetTrigger("pressed");
    }
}

