using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Gtk;
using UI = Gtk.Builder.ObjectAttribute;
using Newtonsoft.Json.Linq;

namespace Department {
    class MainWindow : Window {
        [UI] public ListBox questionsList = null;

        QueueListener queue;
        public Dictionary<String, Question> questions;

        public MainWindow() : this(new Builder("MainWindow.glade")) { }

        private MainWindow(Builder builder) : base(builder.GetObject("MainWindow").Handle) {
            builder.Autoconnect(this);
            LoadData();

            DeleteEvent += Window_DeleteEvent;

            questionsList.RowSelected += (object sender, RowSelectedArgs args) => {
                if (args.Row == null) return;

                var label = (Label)args.Row.Child;
                LaunchQuestionDialog(label.Text, args.Row);
            };

            InitQueue();
        }

        private void Window_DeleteEvent(object sender, DeleteEventArgs a) {
            this.SaveData();
            Application.Quit();
        }

        void InitQueue() {
            queue = new QueueListener();
            queue.MessageReceived += (message) => {
                Task.Run(() => {
                    var question = JObject.Parse(message);
                    if (question["question"] == null) return;
                    questions[question["question"].ToString()] = new Question() {
                        ID = question["_id"].ToString(),
                        issueID = question["issueId"].ToString(),
                        Text = question["question"].ToString(),
                        State = question["state"].ToString(),
                        Department = question["department"].ToString(),
                        Date = question["createdAt"].ToString()
                    };
                    var row = new ListBoxRow();
                    row.Add(new Label { Text = question["question"].ToString(), Expand = true });
                    questionsList.Add(row);
                    row.ShowAll();
                });
            };

            queue.Init();
        }

        private void LaunchQuestionDialog(String questionID, ListBoxRow row) {
            var questionDialog = new QuestionDialog(questions[questionID], this, row);

            DepartmentApp.GetApp().AddWindow(questionDialog);
            questionDialog.ShowAll();
        }

        void LoadData() {
            var FileName = DotNetEnv.Env.GetString("QUESTIONS_STORAGE");
            if (File.Exists(FileName)) {
                try {
                    Stream openFileStream = File.OpenRead(FileName);
                    BinaryFormatter deserializer = new BinaryFormatter();
                    this.questions = (Dictionary<string, Question>)deserializer.Deserialize(openFileStream);
                    openFileStream.Close();
                } catch (Exception e) {
                    Console.WriteLine(e.Message);
                }
            } else {
                questions = new Dictionary<string, Question>();
            }
        }

        public void SaveData() {
            try {
                var FileName = DotNetEnv.Env.GetString("QUESTIONS_STORAGE");
                Stream SaveFileStream = File.Create(FileName);
                BinaryFormatter serializer = new BinaryFormatter();
                serializer.Serialize(SaveFileStream, this.questions);
                SaveFileStream.Close();
            }
            catch (Exception e) {
                Console.WriteLine(e);
            }
        }
    }
}
