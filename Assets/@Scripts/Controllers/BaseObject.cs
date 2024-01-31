using Spine;
using Spine.Unity;
using UnityEngine;
using UnityEngine.Rendering;
using static Define;

public class BaseObject : InitBase
{
    public EObjectType ObjectType { get; protected set; } = EObjectType.None;
    public CircleCollider2D Collider { get; private set; }
    public SkeletonAnimation SkeletonAnimation { get; private set; }
    public Rigidbody2D RigidBody { get; private set; }

    public float ColliderRadius { get { return Collider != null ? Collider.radius : 0.0f; } }
    public Vector3 CenterPosition { get { return transform.position + Vector3.up * ColliderRadius; } }

    public int DataTemplateID { get; set; }

    bool _lookLeft = true;
    public bool LookLeft
    {
        get { return _lookLeft; }
        set
        {
            _lookLeft = value;
            Flip(!value);
        }
    }

    public override bool Init()
    {
        if (base.Init() == false)
            return false;

        Collider = gameObject.GetOrAddComponent<CircleCollider2D>();
        SkeletonAnimation = GetComponent<SkeletonAnimation>();
        RigidBody = GetComponent<Rigidbody2D>();

        return true;
    }

    public void LookAtTarget(BaseObject target)
    {
        Vector2 dir = target.transform.position - transform.position;
        if (dir.x < 0)
            LookLeft = true;
        else
            LookLeft = false;
    }

    #region Battle
    public virtual void OnDamaged(BaseObject attacker, SkillBase skillBase)
    {

    }

    public virtual void OnDead(BaseObject attacker, SkillBase skillBase)
    {

    }
    #endregion


    #region Spine
    protected virtual void SetSpineAnimation(string dataLabel, int sortingOrder)
    {
        if (SkeletonAnimation == null)
            return;

        SkeletonAnimation.skeletonDataAsset = Managers.Resource.Load<SkeletonDataAsset>(dataLabel);
        SkeletonAnimation.Initialize(true);

        // Spine SkeletonAnimation은 SpriteRenderer 를 사용하지 않고 MeshRenderer을 사용함
        // 그렇기떄문에 2D Sort Axis가 안먹히게 되는데 SortingGroup을 SpriteRenderer,MeshRenderer을 같이 계산함.
        SortingGroup sg = Util.GetOrAddComponent<SortingGroup>(gameObject);
        sg.sortingOrder = sortingOrder;
    }

    protected virtual void UpdateAnimation()
    {
    }

    public void SetRigidBodyVelocity(Vector2 velocity)
    {
        if (RigidBody == null)
            return;

        RigidBody.velocity = velocity;

        if (velocity.x < 0)
            LookLeft = true;
        else if (velocity.x > 0)
            LookLeft = false;
    }

    public void PlayAnimation(int trackIndex, string AnimName, bool loop)
    {
        if (SkeletonAnimation == null)
            return;

        SkeletonAnimation.AnimationState.SetAnimation(trackIndex, AnimName, loop);
    }

    public void AddAnimation(int trackIndex, string AnimName, bool loop, float delay)
    {
        if (SkeletonAnimation == null)
            return;

        SkeletonAnimation.AnimationState.AddAnimation(trackIndex, AnimName, loop, delay);
    }

    public void Flip(bool flag)
    {
        if (SkeletonAnimation == null)
            return;

        SkeletonAnimation.Skeleton.ScaleX = flag ? -1 : 1;
    }

    public virtual void OnAnimEventHandler(TrackEntry trackEntry, Spine.Event e)
    {
        Debug.Log("OnAnimEventHandler");
    }
    #endregion
}
