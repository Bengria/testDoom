using System;
using UnityEngine;

public class AISense : MonoBehaviour
{
    [SerializeField] private float viewDistance = 20;
    [SerializeField] private float viewCone = 60;
    [SerializeField] private Affiliation searchTargets;

    private Damageable target;
    public event Action<Damageable> TargetChanged;
    public Damageable Target
    {
        get => target;
        private set
        {
            if (target == value)
                return;

            target = value;
            TargetChanged?.Invoke(target);
        }
    }
    private void Update()
    {
        Target = EnemyManager.GetFirstVisibleTarget(transform, viewCone, searchTargets, viewDistance);
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        UnityEditor.Handles.color = new Color(1, 0, 0, 0.1f);
        UnityEditor.Handles.zTest = UnityEngine.Rendering.CompareFunction.LessEqual;
        UnityEditor.Handles.DrawSolidArc(
            transform.position, 
            Vector3.up, 
            Quaternion.AngleAxis(-viewCone * 0.5f, Vector3.up) * transform.forward, 
            viewCone, 
            viewDistance);
    }
#endif
}