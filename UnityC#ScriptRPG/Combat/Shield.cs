using UnityEngine;
using UnityEngine.Events;

namespace RPG.Combat
{
    public class Shield : MonoBehaviour
    {
        [SerializeField] UnityEvent onHit;

        public void OnHit()
        {
            onHit.Invoke();
        }
    }
}