using PushKeen.UIFramework.Core.Widgets;
using PushKeen.UIFramework.Core.Widgets.Base;
using PushKeen.UIFramework.Interfaces;
using PushKeen.UIFramework.Utils;
using ScriptableObjects;
using UnityEngine.UIElements;
using VContainer;

namespace Widgets
{
    public class CollectionPanel : Page, IButtonContainable, ITemplateContainable
    {
        private CollectionPanelView _view;
        
        private VisualTreeAsset _listItemTemplate;
        private readonly string _lockedCatStyleName = "locked-colection-item";

        [Inject] private EnergyCatsSO _energyCats;
        protected override void Initialize()
        {
            _view = new CollectionPanelView(_currentSceneUIdocument, "CollectionPanel");
            OnOpened += SetUpPage;
        }

        public void InitButtonEvents()
        {
            _view.MainMenuButton.clicked += () => _navigator.JumpTo<MainMenu>();
        }
        
        public void GetUiTemplates()
        {
            _listItemTemplate = _widgetTemplates.GetTemplate("CollectionListItem");
        }

        private void SetUpPage()
        {
            _view.ItemsContainer.Clear();
            foreach (var cat in _energyCats.EnergyCats)
            {
                VisualElement listItem = _listItemTemplate.InstantiateWithoutContainer();
                listItem.MapFieldToUI<VisualElement>("Image").EnableInClassList(_lockedCatStyleName, !cat.IsUnlocked);
                if (cat.IsUnlocked)
                {
                    listItem.MapFieldToUI<VisualElement>("Image").style.backgroundImage =
                        Background.FromSprite(cat.Image);
                    listItem.MapFieldToUI<Label>("Name").text = cat.Name;
                }
                else
                {
                    listItem.MapFieldToUI<Label>("Name").text = "???";
                }
                
                _view.ItemsContainer.Add(listItem);
            }
        }
    }

    public class CollectionPanelView : View
    {
        public Button MainMenuButton { get; private set; }
        public VisualElement ItemsContainer { get; private set; }
        
        public CollectionPanelView(UIDocument document, string rootName) : base(document, rootName)
        {
        }

    }
}