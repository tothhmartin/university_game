using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Laby
{
    public class GameMenuViewModel: ObservableRecipient
    {
        public ICommand StartGameCommand { get; set; }
        public ICommand ScoreBoardCommand { get; set; }
        public ICommand HelpCommand { get; set; }

        public ICommand BackCommand { get; set; }
        public ICommand ExitCommand { get; set; }

        private bool showMenu;
        public bool ShowMenu { get { return showMenu; } set { SetProperty(ref showMenu, value); } }

        private bool startGame;
        public bool StartGame { get { return startGame; } set { SetProperty(ref startGame, value); (StartGameCommand as RelayCommand).NotifyCanExecuteChanged(); } }

        private bool scoreBoard;
        public bool ScoreBoard { get { return scoreBoard; } set { SetProperty(ref scoreBoard, value); (ScoreBoardCommand as RelayCommand).NotifyCanExecuteChanged(); } }

        private bool help;
        public bool Help { get { return help; } set { SetProperty(ref help, value); (HelpCommand as RelayCommand).NotifyCanExecuteChanged(); } }

        public GameMenuViewModel()
        {
            this.showMenu = true;
            this.startGame = false;
            this.scoreBoard = false;
            this.help = false;


            StartGameCommand = new RelayCommand(() =>
            {
                //this.StartGame = true;
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.ShowMenu = false;
            });
            ScoreBoardCommand = new RelayCommand(() =>
            {
                this.ScoreBoard = true;
                this.ShowMenu = false;
            });
            HelpCommand = new RelayCommand(() =>
            {
                this.Help = true;
                this.ShowMenu = false;
            });

            ExitCommand = new RelayCommand(() => Environment.Exit(0));

            BackCommand = new RelayCommand(() =>
            {
                this.StartGame = false;
                this.ScoreBoard = false;
                this.Help = false;
                this.ShowMenu = true;
            });
        }
    }
}
