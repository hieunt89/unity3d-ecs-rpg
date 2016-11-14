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

        public PauseListenerComponent pauseListener { get { return (PauseListenerComponent)GetComponent(GuiComponentIds.PauseListener); } }
        public bool hasPauseListener { get { return HasComponent(GuiComponentIds.PauseListener); } }

        public Entity AddPauseListener(IPauseListener newListener) {
            var component = CreateComponent<PauseListenerComponent>(GuiComponentIds.PauseListener);
            component.listener = newListener;
            return AddComponent(GuiComponentIds.PauseListener, component);
        }

        public Entity ReplacePauseListener(IPauseListener newListener) {
            var component = CreateComponent<PauseListenerComponent>(GuiComponentIds.PauseListener);
            component.listener = newListener;
            ReplaceComponent(GuiComponentIds.PauseListener, component);
            return this;
        }

        public Entity RemovePauseListener() {
            return RemoveComponent(GuiComponentIds.PauseListener);
        }
    }
}

    public partial class GuiMatcher {

        static IMatcher _matcherPauseListener;

        public static IMatcher PauseListener {
            get {
                if(_matcherPauseListener == null) {
                    var matcher = (Matcher)Matcher.AllOf(GuiComponentIds.PauseListener);
                    matcher.componentNames = GuiComponentIds.componentNames;
                    _matcherPauseListener = matcher;
                }

                return _matcherPauseListener;
            }
        }
    }