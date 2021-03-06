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

        static readonly ActiveComponent activeComponent = new ActiveComponent();

        public bool isActive {
            get { return HasComponent(CoreComponentIds.Active); }
            set {
                if(value != isActive) {
                    if(value) {
                        AddComponent(CoreComponentIds.Active, activeComponent);
                    } else {
                        RemoveComponent(CoreComponentIds.Active);
                    }
                }
            }
        }

        public Entity IsActive(bool value) {
            isActive = value;
            return this;
        }
    }
}

    public partial class CoreMatcher {

        static IMatcher _matcherActive;

        public static IMatcher Active {
            get {
                if(_matcherActive == null) {
                    var matcher = (Matcher)Matcher.AllOf(CoreComponentIds.Active);
                    matcher.componentNames = CoreComponentIds.componentNames;
                    _matcherActive = matcher;
                }

                return _matcherActive;
            }
        }
    }
