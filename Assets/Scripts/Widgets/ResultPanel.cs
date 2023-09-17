using Collection;
using PushKeen.UIFramework.Core.Widgets;
using PushKeen.UIFramework.Core.Widgets.Base;
using PushKeen.UIFramework.Interfaces;
using UnityEngine.UIElements;

namespace Widgets
{
    public class ResultPanel : DynamicDataPage<EnergyCat>, IButtonContainable
    {
        private ResultPanelView _view;
        protected override void Initialize()
        {
            _view = new ResultPanelView(_currentSceneUIdocument, "ResultPanel");
        }

        public void InitButtonEvents()
        {
            _view.MainMenuButton.clicked += ()=> _navigator.JumpTo<MainMenu>();
        }

        protected override void UpdatePage()
        {
            _view.EnergyCatImage.style.backgroundImage = Background.FromSprite(_displayedData.Image);
            _view.ResultLabel.text = "Ты " + _displayedData.Name;
        }
    }

    public class ResultPanelView : View
    {
        public VisualElement EnergyCatImage { get; private set; }
        public Label ResultLabel { get; private set; }
        public Button MainMenuButton { get; private set; }
        
        public ResultPanelView(UIDocument document, string rootName) : base(document, rootName)
        {
        }
    }
}