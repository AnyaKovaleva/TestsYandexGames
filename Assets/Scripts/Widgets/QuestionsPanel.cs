using System.Collections.Generic;
using Collection;
using PushKeen.UIFramework.Core.Widgets;
using PushKeen.UIFramework.Core.Widgets.Base;
using PushKeen.UIFramework.Interfaces;
using PushKeen.UIFramework.Utils;
using ScriptableObjects;
using Test;
using UnityEngine;
using UnityEngine.UIElements;
using VContainer;

namespace Widgets
{
    public class QuestionsPanel : Page, IButtonContainable
    {
        private QuestionsPanelView _view;

        [Inject] private QuestionsSO _questions;
        [Inject] private EnergyCatsSO _energyCats;

        private AnswerHandler _answerHandler;

        private int _currentQuestionIndex = 0;
        protected override void Initialize()
        {
            _view = new QuestionsPanelView(_currentSceneUIdocument, "QuestionsPanel");
            _answerHandler = new AnswerHandler();
            _currentQuestionIndex = 0;
            OnOpened += StartTest;
        }

        public void InitButtonEvents()
        {
            for (int i = 0; i < _view.AnswerButtons.Count; i++)
            {
                int index = i;
                _view.AnswerButtons[i].clicked += () => OnAnswerButtonClick(index);
            }
        }

        private void StartTest()
        {
            _currentQuestionIndex = 0;
            _answerHandler.ClearResults();
            SetUpPageForQuestion();
        }

        private void SetUpPageForQuestion()
        {
            _view.Question.text = _questions.Questions[_currentQuestionIndex].Text;
            for (int i = 0; i < _questions.Questions[_currentQuestionIndex].Answers.Count; i++)
            {
                _view.AnswerButtons[i].text = _questions.Questions[_currentQuestionIndex].Answers[i].Text;
            }
        }

        private void OnAnswerButtonClick(int buttonIndex)
        {
            _answerHandler.Handle(_questions.Questions[_currentQuestionIndex].Answers[buttonIndex]);
            ToNextQuestion();
        }

        private void ToNextQuestion()
        {
            _currentQuestionIndex++;
            if (_currentQuestionIndex == _questions.Questions.Count)
            {
                ShowTestResult();
            }
            else
            {
                SetUpPageForQuestion();
            }
        }

        private void ShowTestResult()
        {
            EnergyCat result = _answerHandler.CalculateTestResults();
            _energyCats.Unlock(result);
            _navigator.Push<ResultPanel>(result);
        }
    }

    public class QuestionsPanelView : View
    {
        public Label Question { get; private set; }
        public List<Button> AnswerButtons { get; private set; }
        public QuestionsPanelView(UIDocument document, string rootName) : base(document, rootName)
        {
        }

        protected override void MapFieldsToUI()
        {
            Question = Root.MapFieldToUI<Label>("Question");

            AnswerButtons = new List<Button>();
            for (int i = 1; i <= 4; i++)
            {
                AnswerButtons.Add(Root.MapFieldToUI<Button>("Answer" + i));
            }
        }
    }
}