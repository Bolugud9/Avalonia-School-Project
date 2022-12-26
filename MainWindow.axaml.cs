using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using System.ComponentModel;
using Avalonia.Input;
using System;
using System.Timers;
using System.Collections.Generic;
// using ReactiveUI;


namespace MyApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
        }
    }
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        Words w = new Words();
        
        Random r = new Random();

        int count(){
            return w.wordClasses.Count;
        }

        int RandomNumber(){
            return r.Next(0,count());
        }

        string[] results;

        string[] Results{
            get{
                for (int i = 0; i < w.wordClasses.Count; i++)
                {
                    if( w.wordClasses[i].wordToFind == TextToFind){
                        results = w.wordClasses[i].listOfAnswers;
                    }
                }
                return results;
            }
        }

        String textToFind = String.Empty;
        bool notSet = false;
        
        string combinations = string.Empty;
        bool firstButtonPressed = false;
        bool secondButtonPressed = false;
        bool thirdButtonPressed = false;
        bool fourthButtonPressed = false;
        bool fifthButtonPressed = false;
        bool sixthButtonPressed = false;

        public string Combinations
        {
            get => combinations;
            set
            {
                combinations = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Combinations)));
            }
        }

        #region Color and Button Press function

        private string firstPressedColor = "red";
        public string FirstPressedColor {
            get => firstPressedColor;
            set
            {
                firstPressedColor = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(FirstPressedColor)));
            }
        }
        

        private string secondPressedColor = "red";
        public string SecondPressedColor {
            get => secondPressedColor;
            set
            {
                secondPressedColor = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SecondPressedColor)));
            }
        }
        


        private string thirdPressedColor = "red";
        public string ThirdPressedColor {
            get => thirdPressedColor;
            set
            {
                thirdPressedColor = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ThirdPressedColor)));
            }
        }
        

        private string fourthPressedColor = "red";
        public string FourthPressedColor {
            get => fourthPressedColor;
            set
            {
                fourthPressedColor = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(FourthPressedColor)));
            }
        }
        

        private string fifthPressedColor = "red";
        public string FifthPressedColor {
            get => fifthPressedColor;
            set
            {
                fifthPressedColor = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(FifthPressedColor)));
            }
        }
        

        private string sixthPressedColor = "red";
        public string SixthPressedColor {
            get => sixthPressedColor;
            set
            {
                sixthPressedColor = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SixthPressedColor)));
            }
        }
        
        public string TextToFind
        {
            get{
                if(textToFind == String.Empty && !notSet){
                    textToFind = w.wordClasses[RandomNumber()].wordToFind;
                    notSet = true;
                    return textToFind;
                }else{
                    return textToFind;
                }
            } 
            set 
            {
                textToFind = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TextToFind)));
            }
        }
        
        #endregion

        public event PropertyChangedEventHandler PropertyChanged;

        public List<string> SubmittedWords = new List<string>();

        int i = 0;
        int Score = 0;
        int HighScore = 0;
        int timeLeft = 5;
        
        public void Clicked(char value){
            Combinations += value;
            i++;

            #region check

            if(firstButtonPressed && value == TextToFind[0]){
                FirstPressedColor = "red";
                firstButtonPressed = false;
            }else if(secondButtonPressed && value == TextToFind[1]){
                SecondPressedColor = "red";
                secondButtonPressed = false;
            }else if(thirdButtonPressed && value == TextToFind[2]){
                ThirdPressedColor = "red";
                thirdButtonPressed = false;
            }else if(fourthButtonPressed && value == TextToFind[3]){
                FourthPressedColor = "red";
                fourthButtonPressed = false;
            }else if(fifthButtonPressed && value == TextToFind[4]){
                FifthPressedColor = "red";
                fifthButtonPressed = false;
            }else if(sixthButtonPressed && value == TextToFind[5]){
                SixthPressedColor = "red";
                sixthButtonPressed = false;
            }
            else if(!firstButtonPressed && value == TextToFind[0]){
                FirstPressedColor = "Black";
                firstButtonPressed = true;
            }else if(!secondButtonPressed && value == TextToFind[1]){
                SecondPressedColor = "Black";
                secondButtonPressed = true;
            }else if(!thirdButtonPressed && value == TextToFind[2]){
                ThirdPressedColor = "Black";
                thirdButtonPressed = true;
            }else if(!fourthButtonPressed && value == TextToFind[3]){
                FourthPressedColor = "Black";
                fourthButtonPressed = true;
            }else if(!fifthButtonPressed && value == TextToFind[4]){
                FifthPressedColor = "Black";
                fifthButtonPressed = true;
            }else if(!sixthButtonPressed && value == TextToFind[5]){
                SixthPressedColor = "Black";
                sixthButtonPressed = true;
            }

            #endregion
            
            if(i == 6){
                checkWords();
                i = 0;
                if(timeLeft == 0){
                    StartAgain = true;
                }

            }
        }

        bool found = false;
        void checkWords(){
            foreach (string value in Results)
            {
                if(Combinations == value){
                    found = true;
                }
            }
            if(found){
                SubmittedWords.Add(Combinations);
                Combinations = String.Empty;
                ResetColorValue();
                found = false;
                Score += i * 100;
                timeLeft--;
                ScoreDisplay = $"Score: {Score}";
                Notification = $"++ {i * 100} 😁";
                TimeLeftDisplay = $"Time Left: {timeLeft}";
                i = 0;
            }
            else{
                Combinations = String.Empty;
                ResetColorValue();
                timeLeft--;
                Notification = $"😔 not available";
                TimeLeftDisplay = $"Time Left: {timeLeft}";
                i = 0;
            }

            if(timeLeft == 0){
                Notification = Score > HighScore ? $"New High Score {Score} 👏👏👏" :  $"Total Score {Score}";
                HighScore = Score == 0 ? 0 : Score > HighScore ? Score : HighScore;
                HighScoreDisplay = $"High Score: {HighScore}";
            }
        }

        void ClearWords(){
            if(timeLeft > 0){
                Combinations = string.Empty;
                ResetColorValue();
                i = 0;
            }
        }

        void SubmitWords(){
            if(!foundWord(Combinations)){
                Notification = "";
                if(i >= 3 && timeLeft > 0){
                    checkWords();
                }

                if(timeLeft == 0){
                    StartAgain = true;
                }
            }else{
                ClearWords();
                Notification = "Word used already";
            }
        }

        string scoreDisplay = "Score: 0";
        string ScoreDisplay{
            get {
                return scoreDisplay;
            }set{
                scoreDisplay = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ScoreDisplay)));
            }
        }

        string highScoreDisplay = "HighScore: 0";
        string HighScoreDisplay{
            get {
                return highScoreDisplay;
            }set{
                highScoreDisplay = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(HighScoreDisplay)));
            }
        }
        
        string timeLeftDisplay = "Time Left: 5";

        string TimeLeftDisplay{
            get {
                return timeLeftDisplay;
            }set{
                timeLeftDisplay = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TimeLeftDisplay)));
            }
        }

        bool startAgain = false;
        bool StartAgain{
            get => startAgain;
            set{
                startAgain=value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(StartAgain)));
            }
        }

        void ResetColorValue(){
            FirstPressedColor = "red";
            firstButtonPressed = false;
            SecondPressedColor = "red";
            secondButtonPressed = false;
            ThirdPressedColor = "red";
            thirdButtonPressed = false;
            FourthPressedColor = "red";
            fourthButtonPressed = false;
            FifthPressedColor = "red";
            fifthButtonPressed = false;
            SixthPressedColor = "red";
            sixthButtonPressed = false;
        }

        public void PlayAgain(){
            ResetColorValue();
            timeLeft = 5;
            TimeLeftDisplay = "Score: 5";
            StartAgain = false;
            Combinations = String.Empty;
            i = 0;
            Score = 0;
            ScoreDisplay = "Score: 0";
            TextToFind = w.wordClasses[RandomNumber()].wordToFind;
        }

        bool foundWord(string word){
            if(SubmittedWords.Count == 0) return false;
            foreach (string value in SubmittedWords)
            {
                if(word == value){
                    return true;
                }
            }
            return false;
        }

        string notification = String.Empty;
        string Notification{
            get => notification;
            set {
                notification = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Notification)));
            }
        }
    }
}