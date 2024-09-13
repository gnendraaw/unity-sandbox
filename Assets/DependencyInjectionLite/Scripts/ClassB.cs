using UnityEngine;

namespace Sandbox.DependencyInjectionLite {
    public class ClassB : MonoBehaviour {
        [Inject]
        ServiceA serviceA;

        [Inject]
        ServiceB serviceB;
        
        [Inject]
        FactoryA factoryA;
    }
}
