using UnityEngine;

namespace HEXRPG.Combat
{
    [CreateAssetMenu(fileName = "Weapon", menuName = "Weapons/Make New Weapon", order = 0)]
    public class Weapon : ScriptableObject
    {
        [SerializeField] private AnimatorOverrideController _animatorOverride = null;
        [SerializeField] GameObject _weaponPrefab = null;

        public void Spawn(Transform handTransform, Animator animator)
        {
            Instantiate(_weaponPrefab, handTransform);
            animator.runtimeAnimatorController = _animatorOverride;
        }
    }
}
