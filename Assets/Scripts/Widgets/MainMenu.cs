using PushKeen.UIFramework.Core.Widgets;
using PushKeen.UIFramework.Core.Widgets.Base;
using PushKeen.UIFramework.Interfaces;
using UnityEngine.UIElements;

namespace Widgets
{
    public class MainMenu : Page, IButtonContainable
    {
        private MainMenuView _view;
        protected override void Initialize()
        {
            _view = new MainMenuView(_currentSceneUIdocument, "MainMenu");
        }

        public void InitButtonEvents()
        {
            _view.StartButton.clicked += () => _navigator.Push<QuestionsPanel>();
            _view.ColectionButton.clicked += () => _navigator.Push<CollectionPanel>();
        }
    }

    public class MainMenuView : View
    {
        public Button StartButton { get; private set; }
        public Button ColectionButton { get; private set; }
        public MainMenuView(UIDocument document, string rootName) : base(document, rootName)
        {
        }
    }
}