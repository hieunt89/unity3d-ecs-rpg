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

        public MoveSpeedComponent moveSpeed { get { return (MoveSpeedComponent)GetComponent(CoreComponentIds.MoveSpeed); } }
        public bool hasMoveSpeed { get { return HasComponent(CoreComponentIds.MoveSpeed); } }

        public Entity AddMoveSpeed(float newValue) {
            var component = CreateComponent<MoveSpeedComponent>(CoreComponentIds.MoveSpeed);
            component.value = newValue;
            return AddComponent(CoreComponentIds.MoveSpeed, component);
        }

        public Entity ReplaceMoveSpeed(float newValue) {
            var component = CreateComponent<MoveSpeedComponent>(CoreComponentIds.MoveSpeed);
            component.value = newValue;
            ReplaceComponent(CoreComponentIds.MoveSpeed, component);
            return this;
        }

        public Entity RemoveMoveSpeed() {
            return RemoveComponent(CoreComponentIds.MoveSpeed);
        }
    }
}

    public partial class CoreMatcher {

        static IMatcher _matcherMoveSpeed;

        public static IMatcher MoveSpeed {
            get {
                if(_matcherMoveSpeed == null) {
                    var matcher = (Matcher)Matcher.AllOf(CoreComponentIds.MoveSpeed);
                    matcher.componentNames = CoreComponentIds.componentNames;
                    _matcherMoveSpeed = matcher;
                }

                return _matcherMoveSpeed;
            }
        }
    }
