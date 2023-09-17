using ScriptableObjects;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace DI
{
    public class ApplicationController : LifetimeScope
    {
        [SerializeField] private QuestionsSO _questionsSo;
        [SerializeField] private EnergyCatsSO _energyCatsSo;
        protected override void Configure(IContainerBuilder builder)
        {
            base.Configure(builder);

            builder.RegisterInstance(_questionsSo);
            builder.RegisterInstance(_energyCatsSo);
        }
    }
}