using PushKeen.UIFramework.Core.Widgets;
using PushKeen.UIFramework.Core.Widgets.Base;
using PushKeen.UIFramework.Interfaces;
using UnityEngine.UIElements;

namespace Widgets
{
    public class QuestionsPanel : Page, IButtonContainable
    {
        private QuestionsPanelView _view;
        protected override void Initialize()
        {
            _view = new QuestionsPanelView(_currentSceneUIdocument, "QuestionsPanel");
        }

        public void InitButtonEvents()
        {
        }
    }

    public class QuestionsPanelView : View
    {
        public QuestionsPanelView(UIDocument document, string rootName) : base(document, rootName)
        {
        }
    }
}