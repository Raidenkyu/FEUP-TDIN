using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gtk;
using UI = Gtk.Builder.ObjectAttribute;
using Newtonsoft.Json.Linq;

namespace Solver {
    class IssueWindow : Window {
        [UI] TextView descriptionBox = null;
        [UI] TextView answerBox = null;
        [UI] Label issueTitle = null;
        [UI] Label authorDate = null;
        [UI] Button solveButton = null;
        [UI] ListBox questionsList = null;

        Issue issue;
        MainWindow mainWindow;
        ListBoxRow row;
        Dictionary<String, Question> questions;

        public IssueWindow(Issue issue, MainWindow mainWindow, ListBoxRow row) : this(new Builder("IssueWindow.glade"), issue, mainWindow, row) { }

        private IssueWindow(Builder builder, Issue _issue, MainWindow _mainWindow, ListBoxRow _row) : base(builder.GetObject("IssueWindow").Handle) {
            builder.Autoconnect(this);

            issue = _issue;
            mainWindow = _mainWindow;
            row = _row;

            issueTitle.Text = issue.Title;
            descriptionBox.Buffer.Text = issue.Description;
            authorDate.Text = $"Submited by {issue.Creator}, at {issue.Date}";

            if (issue.State == "unassigned") {
                solveButton.Label = "Assign";
                solveButton.Clicked += AssignButton_Clicked;
            } else {
                solveButton.Clicked += SolveButton_Clicked;
            }

            questionsList.RowSelected += (object sender, RowSelectedArgs args) => {
                if (args.Row == null) return;

                var label = (Label)args.Row.Child;
                LaunchIssueWindow(label.Text, args.Row);
            }

            var task = FetchQuestions();
        }

        private void AssignButton_Clicked(object sender, EventArgs a) {
            var task = Assign();
        }

        private async Task Assign() {
            var endpoint = $"/api/solver/{issue.ID}/assigned";
            var requestBody = new JObject();
            var response = await SolverApp.PutRequest(endpoint, requestBody);

            if (response["issue"] != null) {
                solveButton.Label = "Solve";
                solveButton.Clicked -= AssignButton_Clicked;
                solveButton.Clicked += SolveButton_Clicked;

                mainWindow.unassignedIssues.Remove(row);
                mainWindow.myIssuesList.Add(row);
            }
        }

        private void SolveButton_Clicked(object sender, EventArgs a) {
            var task = Solve();
        }

        private async Task Solve() {
            var endpoint = $"/api/solver/{issue.ID}/assigned";
            var requestBody = new JObject();
            requestBody["answer"] = answerBox.Buffer.Text;
            var response = await SolverApp.PutRequest(endpoint, requestBody);

            if (response["issue"] != null) {
                mainWindow.myIssuesList.Remove(row);
                this.Hide();
                SolverApp.GetApp().RemoveWindow(this);
            }
        }

        private async Task FetchQuestions() {
            var endpoint = $"/api/solver/{issue.ID}/question";
            var response = await SolverApp.GetRequest(endpoint);

            Console.WriteLine();

        }

        private void InsertQuestion(JToken question) {
            questions[question["question"].ToString()] = new Question() {
                Text = question["question"].ToString(),
                Answer = question["answer"].ToString(),
                State = question["state"].ToString(),
                Department = question["department"].ToString(),
                Date = question["created_at"].ToString()
            };

            var row = new ListBoxRow();
            row.Add(new Label { Text = question["question"].ToString(), Expand = true });
            questionsList.Add(row);
        }

        private void LaunchAnswerWindow(string questionID, ListBoxRow row) {
            var questionDialog = new QuestionDialog(questions[questionID], this);

            SolverApp.GetApp().AddWindow(questionDialog);
            questionDialog.ShowAll();
        }
    }
}
