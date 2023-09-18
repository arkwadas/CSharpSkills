using System.Collections;
using UnityEngine;

public class BlockScript : MonoBehaviour
{
    public float blockManaCost;
    public float blockDuration;
    public float blockRegenerationSpeed;
    public float blockBreakDuration;
    public float moveSpeedWhileBlocking;

    private float currentMana;
    private float blockStartTime;
    private bool isBlocking;
    private bool canBlock;

    private Animator animator;
    private CharacterController characterController;

    private void Start()
    {
        currentMana = blockDuration;
        animator = GetComponentInParent<Animator>();
        characterController = GetComponentInParent<CharacterController>();
    }

    private void Update()
    {
        if (currentMana < blockDuration)
        {
            currentMana += Time.deltaTime * blockRegenerationSpeed;
        }

        if (Input.GetMouseButtonDown(1) && currentMana >= blockManaCost && canBlock)
        {
            StartBlocking();
        }
        if (Input.GetMouseButtonUp(1) && isBlocking)
        {
            StopBlocking();
        }

        if (isBlocking)
        {
            characterController.Move(Vector3.forward * moveSpeedWhileBlocking * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isBlocking && other.gameObject.layer == LayerMask.NameToLayer("Attack"))
        {
            animator.SetTrigger("BlockHit");
            currentMana -= blockManaCost;

            if (currentMana <= 0)
            {
                StopBlocking();
                StartCoroutine(BlockBreak());
            }
        }
    }

    private void StartBlocking()
    {
        animator.SetBool("IsBlocking", true);
        isBlocking = true;
        blockStartTime = Time.time;
    }

    private void StopBlocking()
    {
        animator.SetBool("IsBlocking", false);
        isBlocking = false;
    }

    private IEnumerator BlockBreak()
    {
        canBlock = false;
        yield return new WaitForSeconds(blockBreakDuration);
        canBlock = true;
    }
}
