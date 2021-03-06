//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGenerator.ComponentExtensionsGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using Entitas;

namespace Entitas {

    public partial class Entity {

        public HitPointComponent hitPoint { get { return (HitPointComponent)GetComponent(CoreComponentIds.HitPoint); } }
        public bool hasHitPoint { get { return HasComponent(CoreComponentIds.HitPoint); } }

        public Entity AddHitPoint(int newAmount) {
            var component = CreateComponent<HitPointComponent>(CoreComponentIds.HitPoint);
            component.amount = newAmount;
            return AddComponent(CoreComponentIds.HitPoint, component);
        }

        public Entity ReplaceHitPoint(int newAmount) {
            var component = CreateComponent<HitPointComponent>(CoreComponentIds.HitPoint);
            component.amount = newAmount;
            ReplaceComponent(CoreComponentIds.HitPoint, component);
            return this;
        }

        public Entity RemoveHitPoint() {
            return RemoveComponent(CoreComponentIds.HitPoint);
        }
    }
}

    public partial class CoreMatcher {

        static IMatcher _matcherHitPoint;

        public static IMatcher HitPoint {
            get {
                if(_matcherHitPoint == null) {
                    var matcher = (Matcher)Matcher.AllOf(CoreComponentIds.HitPoint);
                    matcher.componentNames = CoreComponentIds.componentNames;
                    _matcherHitPoint = matcher;
                }

                return _matcherHitPoint;
            }
        }
    }
