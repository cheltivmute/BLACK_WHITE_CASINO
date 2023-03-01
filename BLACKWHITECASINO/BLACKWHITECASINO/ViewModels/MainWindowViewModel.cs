using BLACKWHITECASINO.Infrastructure.Commands;
using BLACKWHITECASINO.ViewModels.Base;
using ResultSpins;
using BetClass;
using TotalClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using BLACKWHITECASINO.Views.Windows;
using BLACKWHITECASINO.Models;
using DoubleBetsClass;
using System.Windows.Controls;
using RandMassMinesClass;
using BetMinesWinClass;
using BLACKWHITECASINO.Data;
using System.Collections.ObjectModel;

namespace BLACKWHITECASINO.ViewModels
{
     internal class MainWindowViewModel : ViewModel
    {

        #region Ввод переменных

        Random rndAngle = new Random();

        public CircleEase easingFunction = new CircleEase();
        public SineEase easingFunction1 = new SineEase();
        public Window BetWindow { get; set; }
        public Window DepositWindow { get; set; }

        public Window MainWindow { get; set; }
        public Window LoginWindow { get; set; }

        public Bet bet = new Bet();
        public Total total = new Total(Convert.ToDouble(ActiveUser.activeUser.Total));

        Random rndMrgn = new Random();
        Random lossText = new Random();

        public bool opnmntrue = true;

        public DoubleBets doubleBets = new DoubleBets();
        public double result = 0;

        public int zIndexTabs { get; set; } = 0;
        public Thickness Roll1FromNext { get; set; }
        public Thickness Roll2FromNext { get; set; }
        public Thickness Roll3FromNext { get; set; }
        public int x { get; set; }

        public bool provSlot = true;
        
        public RandMassMines rndMssMns1 = new RandMassMines();
        public RandMassMines rndMssMns2 = new RandMassMines();
        public RandMassMines rndMssMns3 = new RandMassMines();
        public RandMassMines rndMssMns4 = new RandMassMines();
        public RandMassMines rndMssMns5 = new RandMassMines();

        public int[] elemNumber1 = new int[3];
        public int[] elemNumber2 = new int[3];
        public int[] elemNumber3 = new int[3];
        public int[] elemNumber4 = new int[3];
        public int[] elemNumber5 = new int[3];

        public string[] xNineAll = new string[] { "0.25x", "0.5x", "1x", "1.5x", "2x", "3x", "4x", "5x", "6x", "7x", "10x", "15x", "20x", "50x", "100x" };
        public Random xNineRandom = new Random();
        public int[] xNineHelp = new int[3];
        public string xNine1 { get; set; }
        public string xNine2 { get; set; }
        public string xNine3 { get; set; }

        public int XWin0025 { get; set; } = 0;
        public int XWin005 { get; set; } = 0;
        public int XWin01 { get; set; } = 0;
        public int XWin015 { get; set; } = 0;
        public int XWin02 { get; set; } = 0;
        public int XWin03 { get; set; } = 0;
        public int XWin04 { get; set; } = 0;
        public int XWin05 { get; set; } = 0;
        public int XWin06 { get; set; } = 0;
        public int XWin07 { get; set; } = 0;
        public int XWin10 { get; set; } = 0;
        public int XWin15 { get; set; } = 0;
        public int XWin20 { get; set; } = 0;
        public int XWin50 { get; set; } = 0;
        public int XWin100 { get; set; } = 0;

        public bool WinState { get; set; } = false;
        public string xNineWin { get; set; }
        public double xNineWinBet { get; set; } = 0;
        
        public void xNineWinMethod(string xninewin)
        {
            if (xninewin == "0.25x")
                XWin0025++;
            else if (xninewin == "0.5x")
                XWin005++;
            else if (xninewin == "1x")
                XWin01++;
            else if (xninewin == "1.5x")
                XWin015++;
            else if (xninewin == "2x")
                XWin02++;
            else if (xninewin == "3x")
                XWin03++;
            else if (xninewin == "4x")
                XWin04++;
            else if (xninewin == "5x")
                XWin05++;
            else if (xninewin == "6x")
                XWin06++;
            else if (xninewin == "7x")
                XWin07++;
            else if (xninewin == "10x")
                XWin10++;
            else if (xninewin == "15x")
                XWin15++;
            else if (xninewin == "20x")
                XWin20++;
            else if (xninewin == "50x")
                XWin50++;
            else if (xninewin == "100x")
                XWin100++;

            if(XWin0025 == 3 || XWin005 == 3 || XWin01 == 3 || XWin015 == 3 || XWin02 == 3 || XWin03 == 3 ||
                XWin04 == 3 || XWin05 == 3 || XWin06 == 3 || XWin07 == 3 || XWin10 == 3 || XWin15 == 3 ||
                XWin20 == 3 || XWin50 == 3 || XWin100 == 3)
            {
                WinState = true;
            }
        }

        public bool checkResultForDB { get; set; }
        public string resultForDB { get; set; }
        public double profitForDB { get; set; }

        public void GameAddMines(double x, int y)
        {
            BLACK_WHITE_CASINOContext context = new BLACK_WHITE_CASINOContext();

            profitForDB = profitForDB + x - y;

            if (checkResultForDB == true)
                resultForDB = "Победа";
            else
                resultForDB = "Проигрыш";

            Game game = new Game
            {
                UserId = ActiveUser.activeUser.Id,
                UserGameId = ActiveUser.activeUser.GameQuantity,
                Name = "Mines",
                Bet = x + "$",
                Result = resultForDB,
                Profit = profitForDB + "$",
                Date = DateTime.Now
            };

            // Добавить в DbSet
            context.Games.Add(game);

            // Сохранить изменения в базе данных
            context.SaveChanges();
        }
        public void GameAddNine(double x, int y)
        {
            BLACK_WHITE_CASINOContext context = new BLACK_WHITE_CASINOContext();
            profitForDB = 0;
            if (IsCheckedNine != false)
                x = x * 0.5;

            profitForDB = profitForDB + x - y;

            if (checkResultForDB == true)
                resultForDB = "Победа";
            else
                resultForDB = "Проигрыш";

            Game game = new Game
            {
                UserId = ActiveUser.activeUser.Id,
                UserGameId = ActiveUser.activeUser.GameQuantity,
                Name = "Nine",
                Bet = y + "$",
                Result = resultForDB,
                Profit = profitForDB + "$",
                Date = DateTime.Now
            };

            // Добавить в DbSet
            context.Games.Add(game);

            // Сохранить изменения в базе данных
            context.SaveChanges();
        }

        public bool checkDep { get; set; }
        public string DepTextMain { get; set; }
        #endregion

        #region Баланс
        private string _TotalValue = Convert.ToDouble(ActiveUser.activeUser.Total).ToString();

        public string TotalValue
        {
            get
            {
                return _TotalValue + "$";
            }
            set => Set(ref _TotalValue, value);
        }
        #endregion

        #region Логин
        private string _LoginMainWindow;

        public string LoginMainWindow
        {
            get
            {
                _LoginMainWindow = ActiveUser.activeUser.Login;
                return _LoginMainWindow;
            }
            set => Set(ref _LoginMainWindow, value);
        }
        #endregion

        #region BetUp

        public ICommand BetUpCommand { get; }

        private bool CanBetUpExecuted(object p)
        {
            if (Bet.betTotal <= 99989) return true;
            else return false;
        }

        private void OnBetUpExecuted(object p)
        {
            bet.betUp(10);
            BetValue = Bet.betTotal;
            SlotInfoBetText = Bet.betTotal + "$";
            SlotInfoBetTextJackpot = Bet.betTotal * 100 + "$";
            if(IsCheckedMines == true)
            {
                MinesMbWin = Bet.betTotal * 5 + "$";
            }
            else
            {
                MinesMbWin = Bet.betTotal * 100 + "$";
            }

            NineMbWin = Bet.betTotal * 100 + "$";
        }

        #endregion

        #region BetDown

        public ICommand BetDownCommand { get; }

        private bool CanBetDownExecuted(object p)
        {
            if (Bet.betTotal >= 10) return true;
            else return false;
        }

        private void OnBetDownExecuted(object p)
        {
            bet.betDown(10);
            BetValue = Bet.betTotal;
            SlotInfoBetText = Bet.betTotal + "$";
            SlotInfoBetTextJackpot = Bet.betTotal * 100 + "$";
            if (IsCheckedMines == true)
            {
                MinesMbWin = Bet.betTotal * 5 + "$";
            }
            else
            {
                MinesMbWin = Bet.betTotal * 100 + "$";
            }
            NineMbWin = Bet.betTotal * 100 + "$";
        }

        #endregion

        #region Открыть окно ставки
        public void CloseBetWindow()
        {
            BetWindow.Close();
        }

        public void CloseDepositWindow()
        {
            DepositWindow.Close();
        }

        
        


        public ICommand OpenBetCommand { get; set; }
        public void OnOpenBetCommandExecuted(object p)
        {
            Status.changeInt = 1;
            BetWindow = new CountWindow();
            BetWindow.DataContext = new CountBetWindowViewModel(this);
            BetWindow.ShowDialog();
        }

        public bool CanOpenBetCommandExecute(object p) => true;
        #endregion
        #region Открыть окно депозита
        public ICommand OpenDepositCommand { get; set; }
        public void OnOpenDepositCommandExecuted(object p)
        {
            checkDep = true;
            if(Language.checkRu == true)
                DepTextMain = "Введите сумму для депозита";
            else
                DepTextMain = "Enter amount for deposit";

            Status.changeInt = 2;
            DepositWindow = new DepositWindow();
            DepositWindow.DataContext = new DepositWindowViewModel(this);
            DepositWindow.ShowDialog();
        }
        public bool CanOpenDepositCommandExecute(object p) => true;
        #endregion

        #region Открыть окно вывода
        public ICommand OpenConclusionCommand { get; set; }
        public void OnOpenConclusionCommandExecuted(object p)
        {
            checkDep = false;
            if (Language.checkRu == true)
                DepTextMain = "Введите сумму для вывода";
            else
                DepTextMain = "Enter amount to withdraw";
            Status.changeInt = 2;
            DepositWindow = new DepositWindow();
            DepositWindow.DataContext = new DepositWindowViewModel(this);
            DepositWindow.ShowDialog();
        }
        public bool CanOpenConclusionCommandExecute(object p) => true;
        #endregion

        #region Открыть окно аккаунта

        public ICommand OpenAccountCommand { get; set; }
        public void OnOpenAccountCommandExecuted(object p)
        {
            Status.changeInt = 1;
            Account accWindow = new Account();

            accWindow.ShowDialog();
        }

        public bool CanOpenAccountCommandExecute(object p) => true;
        #endregion

        #region Выход из аккаунта
        public ICommand ExitAccountCommand { get; }

        private bool CanExitAccountCommandExecuted(object p) => true;

        private void OnExitAccountCommandExecuted(object p)
        {
            var mnWin = p as Window;
            LoginWindow loginWin = new LoginWindow();

            ActiveUser.activeUser = null;

            mnWin.Close();
            loginWin.ShowDialog();
        }
        #endregion


        #region C
        public ICommand CloseApplicationCommand { get; }

        private bool CanCloseApplicationCommandExecuted(object p) => true;

        private void OnCloseApplicationCommandExecuted(object p)
        {
            Application.Current.Shutdown();
        }
        #endregion

        #region HelpCommand
        public ICommand HelpCommand { get; }

        private bool CanHelpCommandExecuted(object p) => true;

        private void OnHelpCommandExecuted(object p)
        {
            if(Language.checkRu == true)
                MessageBox.Show("Если у вас есть вопросы или предложения,\nто обратитесь пожалуйста к администратору!\n\nEmail: shasha161280@gmail.com");
            else
                MessageBox.Show("If you have any questions or suggestions,\nplease contact the administrator!\n\nEmail: shasha161280@gmail.com");

        }
        #endregion

        #region HelpGamesCommand
        public ICommand HelpGamesCommand { get; }

        private bool CanHelpGamesCommandExecuted(object p) => true;

        private void OnHelpGamesCommandExecuted(object p)
        {
            if (Language.checkRu == true)
            {
                if (zIndexTabs == 0)
                    MessageBox.Show("КАЗИНО DOUBLE\n\nКак играть:\n-Вы делаете ставку на 7 различных вариантов\nи запускаете колесо!\n-Mожно ставить как на что-то одно, так и на всё сразу!" +
                        "\n-В случае победы на всех ставках, кроме красной,\nваша ставка удваивается и возвращается на баланс\n-Если же вы победили на красном, то ставка умножается на 14\nи возвращается на баланс!");
                else if (zIndexTabs == 1)
                    MessageBox.Show("КАЗИНО SLOT\n\nКак играть:\n-Вы указываете значение ставки и запускаете барабан!\n-Если на барабане 2 одинаковых числа, то ваша ставка\nумножается на 1.5 и возвращается на баланс" +
                        "\n-Если на барабане 3 одинаковых числа, то вы выигрываете ДЖЕКПОТ!");
                else if (zIndexTabs == 2)
                    MessageBox.Show("КАЗИНО MINES\n\nКак играть:\n-Вы указываете значение ставки и запускаете поле!\n-Вы должны нажимать на доступные клетки и проходить по шагу поле\n-Каждая клетка имеет свой коэффициент\n-Коэффициент зависит от уровня сложности и количества пройденных шагов" +
                        "\n-Также можно досрочно забирать свой выйгрыш!");
                else if (zIndexTabs == 3)
                    MessageBox.Show("КАЗИНО NINE\n\nКак играть:\n-Вы указываете значение ставки и запускаете поля!\nВы должны нажимать на доступные клетки и найти 3 одинаковых коэффициента\n-Коэффициенты каждый раз разные\nЕсли вы не уверены, что справитесь за 4 попытки, то можно" +
                        "\nвзять дополнитульную, но выйгрыш будет делиться на 2!");
            }
            else
            {
                if (zIndexTabs == 0)
                    MessageBox.Show("CASINO DOUBLE\n\nHow to play:\n-You bet on 7 different options\nand spin the wheel!\n-You can bet on one or all at once!" +
                        "\n-If you win on all bets except red,\nyour bet is doubled and returned to your balance\n-If you win on red, then your bet is multiplied by 14\nand returned to your balance!");
                else if (zIndexTabs == 1)
                    MessageBox.Show("SLOT CASINO\n\nHow to play:\n-You specify the bet value and start the reel!\n-If there are 2 identical numbers on the reel, then your bet\nis multiplied by 1.5 and returned to the balance" +
                        "\n-If there are 3 identical numbers on the reel, then you win the JACKPOT!");
                else if (zIndexTabs == 2)
                    MessageBox.Show("MINES CASINO\n\nHow to play:\n-You specify the bet value and start the field!\n-You must click on the available cells and step through the field\n-Each cell has its own coefficient\n-Coefficient depends on the level of difficulty and the number of steps taken" +
                        "\n-You can also pick up your winnings early!");
                else if (zIndexTabs == 3)
                    MessageBox.Show("NINE CASINO\n\nHow to play:\n-You enter the bet value and start the fields!\nYou must click on the available cells and find 3 identical odds\n-Odds are different each time\nIf you are not sure what If you can do it in 4 attempts, then you can" +
                        "\ntake an additional one, but the winnings will be divided by 2!");
            }
            
        }
        #endregion

        #region ChangeLanguageCommand
        public ICommand ChangeLanguageCommand { get; }

        private bool CanChangeLanguageCommandExecuted(object p) => true;

        private void OnChangeLanguageCommandExecuted(object p)
        {
            if(Language.checkRu == true)
            {
                Language.checkRu = false;
                ResourceDictionary dict = new ResourceDictionary();
                dict.Source = new Uri(@"..\Views\Resources\LocalizationENG.xaml", UriKind.Relative);
                Language.local = @"..\LocalizationENG.xaml";
                Application.Current.Resources.MergedDictionaries.Add(dict);
                

            }
            else
            {
                Language.checkRu = true;
                ResourceDictionary dict = new ResourceDictionary();
                dict.Source = new Uri(@"..\Views\Resources\LocalizationRU.xaml", UriKind.Relative);
                Language.local = @"..\LocalizationRU.xaml";
                Application.Current.Resources.MergedDictionaries.Add(dict);
            }
            

        }
        #endregion

        #region Ненужный хлам для копирования
        #region Заголовок окна
        private string _Title = "BWC Lobby";

        public string Title
        {
            get => _Title;
            //set
            //{
            //    //if (Equals(_Title, value)) return;
            //    //_Title = value;
            //    //OnPropertyChanged();

            //    Set(ref _Title, value);
            //}
            set => Set(ref _Title, value);
        }
        #endregion
        #region Заголовок Double
        private string _TitleDouble = "Double";

        public string TitleDouble
        {
            get => _TitleDouble;
            set => Set(ref _TitleDouble, value);
        }
        #endregion
        #region Заголовок Slot
        private string _TitleSlot = "Slot";

        public string TitleSlot
        {
            get => _TitleSlot;
            set => Set(ref _TitleSlot, value);
        }
        #endregion
        #region Заголовок Mines
        private string _TitleMines = "Mines";

        public string TitleMines
        {
            get => _TitleMines;
            set => Set(ref _TitleMines, value);
        }
        #endregion
        #region Заголовок Nine
        private string _TitleNine = "Nine";

        public string TitleNine
        {
            get => _TitleNine;
            set => Set(ref _TitleNine, value);
        }
        #endregion 
        #endregion

        #region Ready Button Spin
        private bool _RdyButSpin = true;

        public bool RdyButSpin
        {
            get => _RdyButSpin;
            set => Set(ref _RdyButSpin, value);
        }
        #endregion

        #region AccIsEnabled
        private bool _AccIsEnabled = true;

        public bool AccIsEnabled
        {
            get => _AccIsEnabled;
            set => Set(ref _AccIsEnabled, value);
        }
        #endregion

        #region OpenMenuCommand

        public ICommand OpenMenuCommand { get; }

        private bool CanOpenMenuCommandExecuted(object p)
        {
            return true;
        }

        private async void OnOpenMenuCommandExecuted(object p)
        {
            AccIsEnabled = false;
            var border = p as Border;
            ThicknessAnimation OpenMn = new ThicknessAnimation();
            if(opnmntrue == true)
            {
                OpenMn.From = new Thickness(0, -177.12, 0, 177.12); /*0,-167.12,0,167.12*/
                OpenMn.To = new Thickness(0, 0, 0, 0);
                opnmntrue = false;
            }
            else
            {
                OpenMn.From = new Thickness(0, 0, 0, 0); /*0,-167.12,0,167.12*/
                OpenMn.To = new Thickness(0, -177.12, 0, 177.12);
                opnmntrue = true;
            }
            
            OpenMn.Duration = TimeSpan.FromSeconds(0.5);
            easingFunction1.EasingMode = EasingMode.EaseOut;
            OpenMn.EasingFunction = easingFunction1;
            Storyboard strbrdmn = new Storyboard();
            Storyboard.SetTargetName(OpenMn, border.Name);
            Storyboard.SetTargetProperty(OpenMn, new PropertyPath("Margin"));
            strbrdmn.Children.Add(OpenMn);
            strbrdmn.Begin(border);

            await Task.Delay(500);
            AccIsEnabled = true;
        }

        #endregion

        //DOUBLE
        #region double
        #region Значение ставки
        private int _BetValue;

        public int BetValue
        {
            get
            {
                _BetValue = Bet.betTotal;
                return _BetValue;
            }
            set => Set(ref _BetValue, value);
        }
        #endregion

        #region Инфрмация о сделанных ставках
        private string _InformBets;

        public string InformBets
        {
            get
            {
                _InformBets = doubleBets.ToString();
                return _InformBets;
            }
            set => Set(ref _InformBets, value);
        }
        #endregion

        #region Угол From
        private double _AngleFrom = -171.41;

        public double AngleFrom
        {
            get
            {
                return _AngleFrom;
            }
            set
            {
                Set(ref _AngleFrom, value);
            }
        }
        #endregion

        #region Угол To
        private double _AngleTo;

        public double AngleTo
        {
            get
            {
                return _AngleTo;
            }
            set
            {
                Set(ref _AngleTo, value);
            }
        }
        #endregion

        #region Результат вывод
        private string _resultDouble = "0, Красное";

        public string resultDouble
        {
            get => _resultDouble;
            set => Set(ref _resultDouble, value);
        }
        #endregion



        #region Ставка на белое
        public ICommand WhiteBetCommand { get; }

        private bool CanWhiteBetCommandExecuted(object p)
        {
            if (Total.TotalSumm >= Bet.betTotal)
                return true;
            else
                return false;
        }

        private void OnWhiteBetCommandExecuted(object p)
        {
            ResultsSpins.WhiteBet = true;
            doubleBets.TotalBetWhiteUp(bet);
            doubleBets.WhiteUp(bet);
            doubleBets.TotalBetUp(bet);
            InformBets = doubleBets.ToString();
            total.TotalDown(bet);
            TotalValue = total.ToString();
        }
        #endregion

        #region Ставка на черное
        public ICommand BlackBetCommand { get; }

        private bool CanBlackBetCommandExecuted(object p)
        {
            if (Total.TotalSumm >= Bet.betTotal)
                return true;
            else
                return false;
        }

        private void OnBlackBetCommandExecuted(object p)
        {
            ResultsSpins.BlackBet = true;
            doubleBets.TotalBetBlackUp(bet);
            doubleBets.BlackUp(bet);
            doubleBets.TotalBetUp(bet);
            InformBets = doubleBets.ToString();
            total.TotalDown(bet);
            TotalValue = total.ToString();
        }
        #endregion

        #region Ставка на красное
        public ICommand RedBetCommand { get; }

        private bool CanRedBetCommandExecuted(object p)
        {
            if (Total.TotalSumm >= Bet.betTotal)
                return true;
            else
                return false;
        }

        private void OnRedBetCommandExecuted(object p)
        {
            ResultsSpins.RedBet = true;
            doubleBets.TotalBetRedUp(bet);
            doubleBets.RedUp(bet);
            doubleBets.TotalBetUp(bet);
            InformBets = doubleBets.ToString();
            total.TotalDown(bet);
            TotalValue = total.ToString();
        }
        #endregion

        #region Ставка на четное
        public ICommand EvenBetCommand { get; }

        private bool CanEvenBetCommandExecuted(object p)
        {
            if (Total.TotalSumm >= Bet.betTotal)
                return true;
            else
                return false;
        }

        private void OnEvenBetCommandExecuted(object p)
        {
            ResultsSpins.EvenBet = true;
            doubleBets.TotalBetEvenUp(bet);
            doubleBets.EvenUp(bet);
            doubleBets.TotalBetUp(bet);
            InformBets = doubleBets.ToString();
            total.TotalDown(bet);
            TotalValue = total.ToString();
        }
        #endregion

        #region Ставка на neчетное
        public ICommand NotEvenBetCommand { get; }

        private bool CanNotEvenBetCommandExecuted(object p)
        {
            if (Total.TotalSumm >= Bet.betTotal)
                return true;
            else
                return false;
        }

        private void OnNotEvenBetCommandExecuted(object p)
        {
            ResultsSpins.NotEvenBet = true;
            doubleBets.TotalBetNotEvenUp(bet);
            doubleBets.NotEvenUp(bet);
            doubleBets.TotalBetUp(bet);
            InformBets = doubleBets.ToString();
            total.TotalDown(bet);
            TotalValue = total.ToString();
        }
        #endregion

        #region Ставка на 0-9
        public ICommand LowRangeBetCommand { get; }

        private bool CanLowRangeBetCommandExecuted(object p)
        {
            if (Total.TotalSumm >= Bet.betTotal)
                return true;
            else
                return false;
        }

        private void OnLowRangeBetCommandExecuted(object p)
        {
            ResultsSpins.LowRangeBet = true;
            doubleBets.TotalBetLowRangeUp(bet);
            doubleBets.LowRangeUp(bet);
            doubleBets.TotalBetUp(bet);
            InformBets = doubleBets.ToString();
            total.TotalDown(bet);
            TotalValue = total.ToString();
        }
        #endregion

        #region Ставка на 10-19
        public ICommand BigRangeBetCommand { get; }

        private bool CanBigRangeBetCommandExecuted(object p)
        {
            if (Total.TotalSumm >= Bet.betTotal)
                return true;
            else
                return false;
        }

        private void OnBigRangeBetCommandExecuted(object p)
        {
            ResultsSpins.BigRangeBet = true;
            doubleBets.TotalBetBigRangeUp(bet);
            doubleBets.BigRangeUp(bet);
            doubleBets.TotalBetUp(bet);
            InformBets = doubleBets.ToString();
            total.TotalDown(bet);
            TotalValue = total.ToString();
        }
        #endregion

        #region Очистить ставки
        public ICommand ClearBetCommand { get; }

        private bool CanClearBetCommandExecuted(object p)
        {
            return true;
        }

        private void OnClearBetCommandExecuted(object p)
        {
            ResultsSpins.WhiteBet = false;
            ResultsSpins.BlackBet = false;
            ResultsSpins.RedBet = false;
            ResultsSpins.EvenBet = false;
            ResultsSpins.NotEvenBet = false;
            ResultsSpins.LowRangeBet = false;
            ResultsSpins.BigRangeBet = false;

            doubleBets.TotalBetWhiteClear();
            doubleBets.TotalBetBlackClear();
            doubleBets.TotalBetRedClear();
            doubleBets.TotalBetEvenClear();
            doubleBets.TotalBetNotEvenClear();
            doubleBets.TotalBetLowRangeClear();
            doubleBets.TotalBetBigRangeClear();
            total.TotalUp(DoubleBets.TotalBet);
            doubleBets.BetsClear();
            doubleBets.TotalBetClear();

            InformBets = doubleBets.ToString();
            TotalValue = total.ToString();
        }
        #endregion 
        #endregion

        //SLOT
        #region slot
        #region Roll 1 From
        private Thickness _Roll1From = new Thickness(0, 60, 0, -60);

        public Thickness Roll1From
        {
            get
            {

                return _Roll1From;
            }
            set
            {
                Set(ref _Roll1From, value);
            }
        }
        #endregion
        #region Roll 2 From
        private Thickness _Roll2From = new Thickness(0, 60, 0, -60);

        public Thickness Roll2From
        {
            get
            {

                return _Roll2From;
            }
            set
            {
                Set(ref _Roll2From, value);
            }
        }
        #endregion
        #region Roll 3 From
        private Thickness _Roll3From = new Thickness(0, 60, 0, -60);

        public Thickness Roll3From
        {
            get
            {

                return _Roll3From;
            }
            set
            {
                Set(ref _Roll3From, value);
            }
        }
        #endregion

        #region Roll 1 To
        private Thickness _Roll1To = new Thickness();

        public Thickness Roll1To
        {
            get
            {

                return _Roll1To;
            }
            set
            {
                Set(ref _Roll1To, value);
            }
        }
        #endregion
        #region Roll 2 To
        private Thickness _Roll2To = new Thickness();

        public Thickness Roll2To
        {
            get
            {

                return _Roll2To;
            }
            set
            {
                Set(ref _Roll2To, value);
            }
        }
        #endregion
        #region Roll 3 To
        private Thickness _Roll3To = new Thickness();

        public Thickness Roll3To
        {
            get
            {

                return _Roll3To;
            }
            set
            {
                Set(ref _Roll3To, value);
            }
        }
        #endregion

        #region SlotInfoText
        private string _SlotInfoText = "WELCOME!!!";

        public string SlotInfoText
        {
            get
            {

                return _SlotInfoText;
            }
            set
            {
                Set(ref _SlotInfoText, value);
            }
        }
        #endregion

        #region SlotInfoBetText
        private string _SlotInfoBetText = "0$";

        public string SlotInfoBetText
        {
            get
            {
                return _SlotInfoBetText;
            }
            set
            {
                Set(ref _SlotInfoBetText, value);
            }
        }
        #endregion
        #region SlotInfoBetTextJackpot
        private string _SlotInfoBetTextJackpot = "0$";

        public string SlotInfoBetTextJackpot
        {
            get
            {
                return _SlotInfoBetTextJackpot;
            }
            set
            {
                Set(ref _SlotInfoBetTextJackpot, value);
            }
        }
        #endregion

        #region Check1
        private bool _IsChecked1 = false;

        public bool IsChecked1
        {
            get
            {
                return _IsChecked1;
            }
            set
            {
                Set(ref _IsChecked1, value);
            }
        }
        #endregion
        #region Check2
        private bool _IsChecked2 = false;

        public bool IsChecked2
        {
            get
            {
                return _IsChecked2;
            }
            set
            {
                Set(ref _IsChecked2, value);
            }
        }
        #endregion
        #region Check3
        private bool _IsChecked3 = false;

        public bool IsChecked3
        {
            get
            {
                return _IsChecked3;
            }
            set
            {
                Set(ref _IsChecked3, value);
            }
        }
        #endregion
        #region Check4
        private bool _IsChecked4 = false;

        public bool IsChecked4
        {
            get
            {
                return _IsChecked4;
            }
            set
            {
                Set(ref _IsChecked4, value);
            }
        }
        #endregion 
        #endregion

        //MINES
        #region mines
        #region MinesMbWin
        private string _MinesMbWin = "0$";

        public string MinesMbWin
        {
            get
            {
                return _MinesMbWin;
            }
            set
            {
                Set(ref _MinesMbWin, value);
            }
        }
        #endregion
        #region MinesUrWin
        private string _MinesUrWin = "0$";

        public string MinesUrWin
        {
            get
            {
                return _MinesUrWin;
            }
            set
            {
                Set(ref _MinesUrWin, value);
            }
        }
        #endregion

        #region CheckMines
        private bool _IsCheckedMines = true;

        public bool IsCheckedMines
        {
            get
            {
                return _IsCheckedMines;
            }
            set
            {
                Set(ref _IsCheckedMines, value);
            }
        }
        #endregion
        #region CheckMinesEnabled
        private bool _IsCheckedMinesEnabled = true;

        public bool IsCheckedMinesEnabled
        {
            get
            {
                return _IsCheckedMinesEnabled;
            }
            set
            {
                Set(ref _IsCheckedMinesEnabled, value);
            }
        }
        #endregion

        #region MinesBut11IsEnabled
        private bool _MinesBut11IsEnabled = false;

        public bool MinesBut11IsEnabled
        {
            get
            {
                return _MinesBut11IsEnabled;
            }
            set
            {
                Set(ref _MinesBut11IsEnabled, value);
            }
        }
        #endregion
        #region MinesBut22IsEnabled
        private bool _MinesBut22IsEnabled = false;

        public bool MinesBut22IsEnabled
        {
            get
            {
                return _MinesBut22IsEnabled;
            }
            set
            {
                Set(ref _MinesBut22IsEnabled, value);
            }
        }
        #endregion
        #region MinesBut33IsEnabled
        private bool _MinesBut33IsEnabled = false;

        public bool MinesBut33IsEnabled
        {
            get
            {
                return _MinesBut33IsEnabled;
            }
            set
            {
                Set(ref _MinesBut33IsEnabled, value);
            }
        }
        #endregion
        #region MinesBut44IsEnabled
        private bool _MinesBut44IsEnabled = false;

        public bool MinesBut44IsEnabled
        {
            get
            {
                return _MinesBut44IsEnabled;
            }
            set
            {
                Set(ref _MinesBut44IsEnabled, value);
            }
        }
        #endregion
        #region MinesBut55IsEnabled
        private bool _MinesBut55IsEnabled = false;

        public bool MinesBut55IsEnabled
        {
            get
            {
                return _MinesBut55IsEnabled;
            }
            set
            {
                Set(ref _MinesBut55IsEnabled, value);
            }
        }
        #endregion

        #region MinesBut11Text
        private string _MinesBut11Text = "";

        public string MinesBut11Text
        {
            get
            {
                return _MinesBut11Text;
            }
            set
            {
                Set(ref _MinesBut11Text, value);
            }
        }
        #endregion
        #region MinesBut11Pick
        private double _MinesBut11Pick = 0;

        public double MinesBut11Pick
        {
            get
            {
                return _MinesBut11Pick;
            }
            set
            {
                Set(ref _MinesBut11Pick, value);
            }
        }
        #endregion
        #region MinesBut11Bimb
        private double _MinesBut11Bimb = 0;

        public double MinesBut11Bimb
        {
            get
            {
                return _MinesBut11Bimb;
            }
            set
            {
                Set(ref _MinesBut11Bimb, value);
            }
        }
        #endregion
        #region MinesBut11Back
        private SolidColorBrush _MinesBut11Back = new SolidColorBrush(Color.FromArgb(100, 255, 255, 255));  //new SolidColorBrush(Color.FromArgb(100, 255, 138, 138))

        public SolidColorBrush MinesBut11Back
        {
            get
            {
                return _MinesBut11Back;
            }
            set
            {
                Set(ref _MinesBut11Back, value);
            }
        }
        #endregion

        #region MinesBut12Text
        private string _MinesBut12Text = "";

        public string MinesBut12Text
        {
            get
            {
                return _MinesBut12Text;
            }
            set
            {
                Set(ref _MinesBut12Text, value);
            }
        }
        #endregion
        #region MinesBut12Pick
        private double _MinesBut12Pick = 0;

        public double MinesBut12Pick
        {
            get
            {
                return _MinesBut12Pick;
            }
            set
            {
                Set(ref _MinesBut12Pick, value);
            }
        }
        #endregion
        #region MinesBut12Bimb
        private double _MinesBut12Bimb = 0;

        public double MinesBut12Bimb
        {
            get
            {
                return _MinesBut12Bimb;
            }
            set
            {
                Set(ref _MinesBut12Bimb, value);
            }
        }
        #endregion
        #region MinesBut12Back
        private SolidColorBrush _MinesBut12Back = new SolidColorBrush(Color.FromArgb(100, 255, 255, 255));  //new SolidColorBrush(Color.FromArgb(100, 255, 138, 138))

        public SolidColorBrush MinesBut12Back
        {
            get
            {
                return _MinesBut12Back;
            }
            set
            {
                Set(ref _MinesBut12Back, value);
            }
        }
        #endregion

        #region MinesBut13Text
        private string _MinesBut13Text = "";

        public string MinesBut13Text
        {
            get
            {
                return _MinesBut13Text;
            }
            set
            {
                Set(ref _MinesBut13Text, value);
            }
        }
        #endregion
        #region MinesBut13Pick
        private double _MinesBut13Pick = 0;

        public double MinesBut13Pick
        {
            get
            {
                return _MinesBut13Pick;
            }
            set
            {
                Set(ref _MinesBut13Pick, value);
            }
        }
        #endregion
        #region MinesBut13Bimb
        private double _MinesBut13Bimb = 0;

        public double MinesBut13Bimb
        {
            get
            {
                return _MinesBut13Bimb;
            }
            set
            {
                Set(ref _MinesBut13Bimb, value);
            }
        }
        #endregion
        #region MinesBut13Back
        private SolidColorBrush _MinesBut13Back = new SolidColorBrush(Color.FromArgb(100, 255, 255, 255));  //new SolidColorBrush(Color.FromArgb(100, 255, 138, 138))

        public SolidColorBrush MinesBut13Back
        {
            get
            {
                return _MinesBut13Back;
            }
            set
            {
                Set(ref _MinesBut13Back, value);
            }
        }
        #endregion

        #region MinesBut21Text
        private string _MinesBut21Text = "";

        public string MinesBut21Text
        {
            get
            {
                return _MinesBut21Text;
            }
            set
            {
                Set(ref _MinesBut21Text, value);
            }
        }
        #endregion
        #region MinesBut21Pick
        private double _MinesBut21Pick = 0;

        public double MinesBut21Pick
        {
            get
            {
                return _MinesBut21Pick;
            }
            set
            {
                Set(ref _MinesBut21Pick, value);
            }
        }
        #endregion
        #region MinesBut21Bimb
        private double _MinesBut21Bimb = 0;

        public double MinesBut21Bimb
        {
            get
            {
                return _MinesBut21Bimb;
            }
            set
            {
                Set(ref _MinesBut21Bimb, value);
            }
        }
        #endregion
        #region MinesBut21Back
        private SolidColorBrush _MinesBut21Back = new SolidColorBrush(Color.FromArgb(100, 255, 255, 255));  //new SolidColorBrush(Color.FromArgb(100, 255, 138, 138))

        public SolidColorBrush MinesBut21Back
        {
            get
            {
                return _MinesBut21Back;
            }
            set
            {
                Set(ref _MinesBut21Back, value);
            }
        }
        #endregion

        #region MinesBut22Text
        private string _MinesBut22Text = "";

        public string MinesBut22Text
        {
            get
            {
                return _MinesBut22Text;
            }
            set
            {
                Set(ref _MinesBut22Text, value);
            }
        }
        #endregion
        #region MinesBut22Pick
        private double _MinesBut22Pick = 0;

        public double MinesBut22Pick
        {
            get
            {
                return _MinesBut22Pick;
            }
            set
            {
                Set(ref _MinesBut22Pick, value);
            }
        }
        #endregion
        #region MinesBut22Bimb
        private double _MinesBut22Bimb = 0;

        public double MinesBut22Bimb
        {
            get
            {
                return _MinesBut22Bimb;
            }
            set
            {
                Set(ref _MinesBut22Bimb, value);
            }
        }
        #endregion
        #region MinesBut22Back
        private SolidColorBrush _MinesBut22Back = new SolidColorBrush(Color.FromArgb(100, 255, 255, 255));  //new SolidColorBrush(Color.FromArgb(100, 255, 138, 138))

        public SolidColorBrush MinesBut22Back
        {
            get
            {
                return _MinesBut22Back;
            }
            set
            {
                Set(ref _MinesBut22Back, value);
            }
        }
        #endregion

        #region MinesBut23Text
        private string _MinesBut23Text = "";

        public string MinesBut23Text
        {
            get
            {
                return _MinesBut23Text;
            }
            set
            {
                Set(ref _MinesBut23Text, value);
            }
        }
        #endregion
        #region MinesBut23Pick
        private double _MinesBut23Pick = 0;

        public double MinesBut23Pick
        {
            get
            {
                return _MinesBut23Pick;
            }
            set
            {
                Set(ref _MinesBut23Pick, value);
            }
        }
        #endregion
        #region MinesBut23Bimb
        private double _MinesBut23Bimb = 0;

        public double MinesBut23Bimb
        {
            get
            {
                return _MinesBut23Bimb;
            }
            set
            {
                Set(ref _MinesBut23Bimb, value);
            }
        }
        #endregion
        #region MinesBut23Back
        private SolidColorBrush _MinesBut23Back = new SolidColorBrush(Color.FromArgb(100, 255, 255, 255));  //new SolidColorBrush(Color.FromArgb(100, 255, 138, 138))

        public SolidColorBrush MinesBut23Back
        {
            get
            {
                return _MinesBut23Back;
            }
            set
            {
                Set(ref _MinesBut23Back, value);
            }
        }
        #endregion

        #region MinesBut31Text
        private string _MinesBut31Text = "";

        public string MinesBut31Text
        {
            get
            {
                return _MinesBut31Text;
            }
            set
            {
                Set(ref _MinesBut31Text, value);
            }
        }
        #endregion
        #region MinesBut31Pick
        private double _MinesBut31Pick = 0;

        public double MinesBut31Pick
        {
            get
            {
                return _MinesBut31Pick;
            }
            set
            {
                Set(ref _MinesBut31Pick, value);
            }
        }
        #endregion
        #region MinesBut31Bimb
        private double _MinesBut31Bimb = 0;

        public double MinesBut31Bimb
        {
            get
            {
                return _MinesBut31Bimb;
            }
            set
            {
                Set(ref _MinesBut31Bimb, value);
            }
        }
        #endregion
        #region MinesBut31Back
        private SolidColorBrush _MinesBut31Back = new SolidColorBrush(Color.FromArgb(100, 255, 255, 255));  //new SolidColorBrush(Color.FromArgb(100, 255, 138, 138))

        public SolidColorBrush MinesBut31Back
        {
            get
            {
                return _MinesBut31Back;
            }
            set
            {
                Set(ref _MinesBut31Back, value);
            }
        }
        #endregion

        #region MinesBut32Text
        private string _MinesBut32Text = "";

        public string MinesBut32Text
        {
            get
            {
                return _MinesBut32Text;
            }
            set
            {
                Set(ref _MinesBut32Text, value);
            }
        }
        #endregion
        #region MinesBut32Pick
        private double _MinesBut32Pick = 0;

        public double MinesBut32Pick
        {
            get
            {
                return _MinesBut32Pick;
            }
            set
            {
                Set(ref _MinesBut32Pick, value);
            }
        }
        #endregion
        #region MinesBut32Bimb
        private double _MinesBut32Bimb = 0;

        public double MinesBut32Bimb
        {
            get
            {
                return _MinesBut32Bimb;
            }
            set
            {
                Set(ref _MinesBut32Bimb, value);
            }
        }
        #endregion
        #region MinesBut32Back
        private SolidColorBrush _MinesBut32Back = new SolidColorBrush(Color.FromArgb(100, 255, 255, 255));  //new SolidColorBrush(Color.FromArgb(100, 255, 138, 138))

        public SolidColorBrush MinesBut32Back
        {
            get
            {
                return _MinesBut32Back;
            }
            set
            {
                Set(ref _MinesBut32Back, value);
            }
        }
        #endregion

        #region MinesBut33Text
        private string _MinesBut33Text = "";

        public string MinesBut33Text
        {
            get
            {
                return _MinesBut33Text;
            }
            set
            {
                Set(ref _MinesBut33Text, value);
            }
        }
        #endregion
        #region MinesBut33Pick
        private double _MinesBut33Pick = 0;

        public double MinesBut33Pick
        {
            get
            {
                return _MinesBut33Pick;
            }
            set
            {
                Set(ref _MinesBut33Pick, value);
            }
        }
        #endregion
        #region MinesBut33Bimb
        private double _MinesBut33Bimb = 0;

        public double MinesBut33Bimb
        {
            get
            {
                return _MinesBut33Bimb;
            }
            set
            {
                Set(ref _MinesBut33Bimb, value);
            }
        }
        #endregion
        #region MinesBut33Back
        private SolidColorBrush _MinesBut33Back = new SolidColorBrush(Color.FromArgb(100, 255, 255, 255));  //new SolidColorBrush(Color.FromArgb(100, 255, 138, 138))

        public SolidColorBrush MinesBut33Back
        {
            get
            {
                return _MinesBut33Back;
            }
            set
            {
                Set(ref _MinesBut33Back, value);
            }
        }
        #endregion

        #region MinesBut41Text
        private string _MinesBut41Text = "";

        public string MinesBut41Text
        {
            get
            {
                return _MinesBut41Text;
            }
            set
            {
                Set(ref _MinesBut41Text, value);
            }
        }
        #endregion
        #region MinesBut41Pick
        private double _MinesBut41Pick = 0;

        public double MinesBut41Pick
        {
            get
            {
                return _MinesBut41Pick;
            }
            set
            {
                Set(ref _MinesBut41Pick, value);
            }
        }
        #endregion
        #region MinesBut41Bimb
        private double _MinesBut41Bimb = 0;

        public double MinesBut41Bimb
        {
            get
            {
                return _MinesBut41Bimb;
            }
            set
            {
                Set(ref _MinesBut41Bimb, value);
            }
        }
        #endregion
        #region MinesBut41Back
        private SolidColorBrush _MinesBut41Back = new SolidColorBrush(Color.FromArgb(100, 255, 255, 255));  //new SolidColorBrush(Color.FromArgb(100, 255, 138, 138))

        public SolidColorBrush MinesBut41Back
        {
            get
            {
                return _MinesBut41Back;
            }
            set
            {
                Set(ref _MinesBut41Back, value);
            }
        }
        #endregion

        #region MinesBut42Text
        private string _MinesBut42Text = "";

        public string MinesBut42Text
        {
            get
            {
                return _MinesBut42Text;
            }
            set
            {
                Set(ref _MinesBut42Text, value);
            }
        }
        #endregion
        #region MinesBut42Pick
        private double _MinesBut42Pick = 0;

        public double MinesBut42Pick
        {
            get
            {
                return _MinesBut42Pick;
            }
            set
            {
                Set(ref _MinesBut42Pick, value);
            }
        }
        #endregion
        #region MinesBut42Bimb
        private double _MinesBut42Bimb = 0;

        public double MinesBut42Bimb
        {
            get
            {
                return _MinesBut42Bimb;
            }
            set
            {
                Set(ref _MinesBut42Bimb, value);
            }
        }
        #endregion
        #region MinesBut42Back
        private SolidColorBrush _MinesBut42Back = new SolidColorBrush(Color.FromArgb(100, 255, 255, 255));  //new SolidColorBrush(Color.FromArgb(100, 255, 138, 138))

        public SolidColorBrush MinesBut42Back
        {
            get
            {
                return _MinesBut42Back;
            }
            set
            {
                Set(ref _MinesBut42Back, value);
            }
        }
        #endregion

        #region MinesBut43Text
        private string _MinesBut43Text = "";

        public string MinesBut43Text
        {
            get
            {
                return _MinesBut43Text;
            }
            set
            {
                Set(ref _MinesBut43Text, value);
            }
        }
        #endregion
        #region MinesBut43Pick
        private double _MinesBut43Pick = 0;

        public double MinesBut43Pick
        {
            get
            {
                return _MinesBut43Pick;
            }
            set
            {
                Set(ref _MinesBut43Pick, value);
            }
        }
        #endregion
        #region MinesBut43Bimb
        private double _MinesBut43Bimb = 0;

        public double MinesBut43Bimb
        {
            get
            {
                return _MinesBut43Bimb;
            }
            set
            {
                Set(ref _MinesBut43Bimb, value);
            }
        }
        #endregion
        #region MinesBut43Back
        private SolidColorBrush _MinesBut43Back = new SolidColorBrush(Color.FromArgb(100, 255, 255, 255));  //new SolidColorBrush(Color.FromArgb(100, 255, 138, 138))

        public SolidColorBrush MinesBut43Back
        {
            get
            {
                return _MinesBut43Back;
            }
            set
            {
                Set(ref _MinesBut43Back, value);
            }
        }
        #endregion

        #region MinesBut51Text
        private string _MinesBut51Text = "";

        public string MinesBut51Text
        {
            get
            {
                return _MinesBut51Text;
            }
            set
            {
                Set(ref _MinesBut51Text, value);
            }
        }
        #endregion
        #region MinesBut51Pick
        private double _MinesBut51Pick = 0;

        public double MinesBut51Pick
        {
            get
            {
                return _MinesBut51Pick;
            }
            set
            {
                Set(ref _MinesBut51Pick, value);
            }
        }
        #endregion
        #region MinesBut51Bimb
        private double _MinesBut51Bimb = 0;

        public double MinesBut51Bimb
        {
            get
            {
                return _MinesBut51Bimb;
            }
            set
            {
                Set(ref _MinesBut51Bimb, value);
            }
        }
        #endregion
        #region MinesBut51Back
        private SolidColorBrush _MinesBut51Back = new SolidColorBrush(Color.FromArgb(100, 255, 255, 255));  //new SolidColorBrush(Color.FromArgb(100, 255, 138, 138))

        public SolidColorBrush MinesBut51Back
        {
            get
            {
                return _MinesBut51Back;
            }
            set
            {
                Set(ref _MinesBut51Back, value);
            }
        }
        #endregion

        #region MinesBut52Text
        private string _MinesBut52Text = "";

        public string MinesBut52Text
        {
            get
            {
                return _MinesBut52Text;
            }
            set
            {
                Set(ref _MinesBut52Text, value);
            }
        }
        #endregion
        #region MinesBut52Pick
        private double _MinesBut52Pick = 0;

        public double MinesBut52Pick
        {
            get
            {
                return _MinesBut52Pick;
            }
            set
            {
                Set(ref _MinesBut52Pick, value);
            }
        }
        #endregion
        #region MinesBut52Bimb
        private double _MinesBut52Bimb = 0;

        public double MinesBut52Bimb
        {
            get
            {
                return _MinesBut52Bimb;
            }
            set
            {
                Set(ref _MinesBut52Bimb, value);
            }
        }
        #endregion
        #region MinesBut52Back
        private SolidColorBrush _MinesBut52Back = new SolidColorBrush(Color.FromArgb(100, 255, 255, 255));  //new SolidColorBrush(Color.FromArgb(100, 255, 138, 138))

        public SolidColorBrush MinesBut52Back
        {
            get
            {
                return _MinesBut52Back;
            }
            set
            {
                Set(ref _MinesBut52Back, value);
            }
        }
        #endregion

        #region MinesBut53Text
        private string _MinesBut53Text = "";

        public string MinesBut53Text
        {
            get
            {
                return _MinesBut53Text;
            }
            set
            {
                Set(ref _MinesBut53Text, value);
            }
        }
        #endregion
        #region MinesBut53Pick
        private double _MinesBut53Pick = 0;

        public double MinesBut53Pick
        {
            get
            {
                return _MinesBut53Pick;
            }
            set
            {
                Set(ref _MinesBut53Pick, value);
            }
        }
        #endregion
        #region MinesBut53Bimb
        private double _MinesBut53Bimb = 0;

        public double MinesBut53Bimb
        {
            get
            {
                return _MinesBut53Bimb;
            }
            set
            {
                Set(ref _MinesBut53Bimb, value);
            }
        }
        #endregion
        #region MinesBut53Back
        private SolidColorBrush _MinesBut53Back = new SolidColorBrush(Color.FromArgb(100, 255, 255, 255));  //new SolidColorBrush(Color.FromArgb(100, 255, 138, 138))

        public SolidColorBrush MinesBut53Back
        {
            get
            {
                return _MinesBut53Back;
            }
            set
            {
                Set(ref _MinesBut53Back, value);
            }
        }
        #endregion



        #region Кнпока 1 1
        public ICommand MinesBut11Command { get; }

        private bool CanMinesBut11CommandExecuted(object p)
        {
            return true;
        }

        private void OnMinesBut11CommandExecuted(object p)
        {
            if (zIndexTabs == 2)
            {
                RdyButSpin = false;
                IsCheckedMinesEnabled = false;
                MinesBut11IsEnabled = false;

                MinesBut11Pick = 0;
                MinesBut12Pick = 0;
                MinesBut13Pick = 0;

                if (IsCheckedMines == true)
                {
                    if (elemNumber1[0] == 3)
                    {
                        BetMines.betMinesWin = 0;
                        MinesBut11Bimb = 1;
                        MinesBut12Text = "0.25x";
                        MinesBut13Text = "0.25x";
                        MinesUrWin = Convert.ToString(BetMines.betMinesWin) + "$";
                        MinesBut11Back = new SolidColorBrush(Color.FromArgb(100, 255, 138, 138));

                        RdyButSpin = true;
                        IsCheckedMinesEnabled = true;
                        GameAddMines(BetMines.betMinesWin, Bet.betTotal);
                    }
                    else
                    {
                        BetMines.betMinesWin = Bet.betTotal * 0.25;
                        MinesUrWin = Convert.ToString(BetMines.betMinesWin) + "$";

                        MinesBut22IsEnabled = true;
                        MinesBut21Pick = 1;
                        MinesBut22Pick = 1;
                        MinesBut23Pick = 1;

                        MinesBut11Text = "0.25x";

                        if (elemNumber1[1] == 3)
                        {
                            MinesBut12Bimb = 1;
                            MinesBut13Text = "0.25x";
                        }
                        else if (elemNumber1[2] == 3)
                        {
                            MinesBut13Bimb = 1;
                            MinesBut12Text = "0.25x";
                        }

                        MinesBut11Back = new SolidColorBrush(Color.FromArgb(100, 170, 255, 177));
                        
                    }
                }
                else
                {
                    if (elemNumber1[0] == 3)
                    {
                        BetMines.betMinesWin = Bet.betTotal * 1;
                        MinesUrWin = Convert.ToString(BetMines.betMinesWin) + "$";

                        MinesBut22IsEnabled = true;
                        MinesBut21Pick = 1;
                        MinesBut22Pick = 1;
                        MinesBut23Pick = 1;

                        MinesBut11Text = "1x";
                        MinesBut12Bimb = 1;
                        MinesBut13Bimb = 1;
                        MinesBut11Back = new SolidColorBrush(Color.FromArgb(100, 170, 255, 177));
                    }
                    else
                    {
                        BetMines.betMinesWin = 0;
                        MinesUrWin = Convert.ToString(BetMines.betMinesWin) + "$";
                        GameAddMines(BetMines.betMinesWin, Bet.betTotal);
                        RdyButSpin = true;
                        IsCheckedMinesEnabled = true;
                        if (elemNumber1[1] == 3)
                        {
                            MinesBut11Bimb = 1;
                            MinesBut13Bimb = 1;
                            MinesBut12Text = "1x";

                        }
                        else if (elemNumber1[2] == 3)
                        {
                            MinesBut11Bimb = 1;
                            MinesBut12Bimb = 1;
                            MinesBut13Text = "1x";
                        }

                        MinesBut11Back = new SolidColorBrush(Color.FromArgb(100, 255, 138, 138));
                    }
                }
            }
            BLACK_WHITE_CASINOContext context = new BLACK_WHITE_CASINOContext();
            ActiveUser.activeUser.Total = Convert.ToDecimal(Total.TotalSumm);
            ActiveUser.UpdateState(context);
            context.SaveChanges();
        }

        #endregion
        #region Кнпока 1 2
        public ICommand MinesBut12Command { get; }

        private bool CanMinesBut12CommandExecuted(object p)
        {
            return true;
        }

        private void OnMinesBut12CommandExecuted(object p)
        {
            if (zIndexTabs == 2)
            {
                RdyButSpin = false;
                IsCheckedMinesEnabled = false;
                MinesBut11IsEnabled = false;

                MinesBut11Pick = 0;
                MinesBut12Pick = 0;
                MinesBut13Pick = 0;

                if (IsCheckedMines == true)
                {
                    if (elemNumber1[1] == 3)
                    {
                        BetMines.betMinesWin = 0;
                        MinesBut12Bimb = 1;
                        MinesBut11Text = "0.25x";
                        MinesBut13Text = "0.25x";
                        MinesUrWin = Convert.ToString(BetMines.betMinesWin) + "$";
                        MinesBut12Back = new SolidColorBrush(Color.FromArgb(100, 255, 138, 138));

                        RdyButSpin = true;
                        IsCheckedMinesEnabled = true;

                        GameAddMines(BetMines.betMinesWin, Bet.betTotal);
                    }
                    else
                    {
                        BetMines.betMinesWin = Bet.betTotal * 0.25;
                        MinesUrWin = Convert.ToString(BetMines.betMinesWin) + "$";


                        MinesBut22IsEnabled = true;
                        MinesBut21Pick = 1;
                        MinesBut22Pick = 1;
                        MinesBut23Pick = 1;

                        MinesBut12Text = "0.25x";

                        if (elemNumber1[0] == 3)
                        {
                            MinesBut11Bimb = 1;
                            MinesBut13Text = "0.25x";
                        }
                        else if (elemNumber1[2] == 3)
                        {
                            MinesBut13Bimb = 1;
                            MinesBut11Text = "0.25x";
                        }

                        MinesBut12Back = new SolidColorBrush(Color.FromArgb(100, 170, 255, 177));
                    }
                }
                else
                {
                    if (elemNumber1[1] == 3)
                    {
                        BetMines.betMinesWin = Bet.betTotal * 1;
                        MinesUrWin = Convert.ToString(BetMines.betMinesWin) + "$";

                        MinesBut22IsEnabled = true;
                        MinesBut21Pick = 1;
                        MinesBut22Pick = 1;
                        MinesBut23Pick = 1;

                        MinesBut12Text = "1x";
                        MinesBut11Bimb = 1;
                        MinesBut13Bimb = 1;
                        MinesBut12Back = new SolidColorBrush(Color.FromArgb(100, 170, 255, 177));
                    }
                    else
                    {
                        BetMines.betMinesWin = 0;
                        MinesUrWin = Convert.ToString(BetMines.betMinesWin) + "$";
                        GameAddMines(BetMines.betMinesWin, Bet.betTotal);
                        RdyButSpin = true;
                        IsCheckedMinesEnabled = true;
                        if (elemNumber1[0] == 3)
                        {
                            MinesBut12Bimb = 1;
                            MinesBut13Bimb = 1;
                            MinesBut11Text = "1x";

                        }
                        else if (elemNumber1[2] == 3)
                        {
                            MinesBut12Bimb = 1;
                            MinesBut11Bimb = 1;
                            MinesBut13Text = "1x";
                        }

                        MinesBut12Back = new SolidColorBrush(Color.FromArgb(100, 255, 138, 138));
                    }
                }
            }
            BLACK_WHITE_CASINOContext context = new BLACK_WHITE_CASINOContext();
            ActiveUser.activeUser.Total = Convert.ToDecimal(Total.TotalSumm);
            ActiveUser.UpdateState(context);
            context.SaveChanges();
        }

        #endregion
        #region Кнпока 1 3
        public ICommand MinesBut13Command { get; }

        private bool CanMinesBut13CommandExecuted(object p)
        {
            return true;
        }

        private void OnMinesBut13CommandExecuted(object p)
        {
            if (zIndexTabs == 2)
            {
                RdyButSpin = false;
                IsCheckedMinesEnabled = false;
                MinesBut11IsEnabled = false;

                MinesBut11Pick = 0;
                MinesBut12Pick = 0;
                MinesBut13Pick = 0;

                if (IsCheckedMines == true)
                {
                    if (elemNumber1[2] == 3)
                    {
                        BetMines.betMinesWin = 0;
                        MinesBut13Bimb = 1;
                        MinesBut12Text = "0.25x";
                        MinesBut11Text = "0.25x";
                        MinesUrWin = Convert.ToString(BetMines.betMinesWin) + "$";
                        MinesBut13Back = new SolidColorBrush(Color.FromArgb(100, 255, 138, 138));

                        RdyButSpin = true;
                        IsCheckedMinesEnabled = true;
                        GameAddMines(BetMines.betMinesWin, Bet.betTotal);
                    }
                    else
                    {
                        BetMines.betMinesWin = Bet.betTotal * 0.25;
                        MinesUrWin = Convert.ToString(BetMines.betMinesWin) + "$";


                        MinesBut22IsEnabled = true;
                        MinesBut23Pick = 1;
                        MinesBut22Pick = 1;
                        MinesBut21Pick = 1;

                        MinesBut13Text = "0.25x";

                        if (elemNumber1[1] == 3)
                        {
                            MinesBut12Bimb = 1;
                            MinesBut11Text = "0.25x";
                        }
                        else if (elemNumber1[0] == 3)
                        {
                            MinesBut11Bimb = 1;
                            MinesBut12Text = "0.25x";
                        }

                        MinesBut13Back = new SolidColorBrush(Color.FromArgb(100, 170, 255, 177));
                    }
                }
                else
                {
                    if (elemNumber1[2] == 3)
                    {
                        BetMines.betMinesWin = Bet.betTotal * 1;
                        MinesUrWin = Convert.ToString(BetMines.betMinesWin) + "$";

                        MinesBut22IsEnabled = true;
                        MinesBut23Pick = 1;
                        MinesBut22Pick = 1;
                        MinesBut21Pick = 1;

                        MinesBut13Text = "1x";
                        MinesBut12Bimb = 1;
                        MinesBut11Bimb = 1;
                        MinesBut13Back = new SolidColorBrush(Color.FromArgb(100, 170, 255, 177));
                    }
                    else
                    {
                        BetMines.betMinesWin = 0;
                        MinesUrWin = Convert.ToString(BetMines.betMinesWin) + "$";
                        GameAddMines(BetMines.betMinesWin, Bet.betTotal);
                        RdyButSpin = true;
                        IsCheckedMinesEnabled = true;
                        if (elemNumber1[1] == 3)
                        {
                            MinesBut13Bimb = 1;
                            MinesBut11Bimb = 1;
                            MinesBut12Text = "1x";

                        }
                        else if (elemNumber1[0] == 3)
                        {
                            MinesBut13Bimb = 1;
                            MinesBut12Bimb = 1;
                            MinesBut11Text = "1x";
                        }

                        MinesBut13Back = new SolidColorBrush(Color.FromArgb(100, 255, 138, 138));
                    }
                }
            }
            BLACK_WHITE_CASINOContext context = new BLACK_WHITE_CASINOContext();
            ActiveUser.activeUser.Total = Convert.ToDecimal(Total.TotalSumm);
            ActiveUser.UpdateState(context);
            context.SaveChanges();
        }

        #endregion

        #region Кнпока 2 1
        public ICommand MinesBut21Command { get; }

        private bool CanMinesBut21CommandExecuted(object p)
        {
            return true;
        }

        private void OnMinesBut21CommandExecuted(object p)
        {
            if (zIndexTabs == 2)
            {
                RdyButSpin = false;
                IsCheckedMinesEnabled = false;
                MinesBut22IsEnabled = false;

                MinesBut21Pick = 0;
                MinesBut22Pick = 0;
                MinesBut23Pick = 0;

                if (IsCheckedMines == true)
                {
                    if (elemNumber2[0] == 3)
                    {
                        BetMines.betMinesWin = 0;
                        MinesBut21Bimb = 1;
                        MinesBut22Text = "0.5x";
                        MinesBut23Text = "0.5x";
                        MinesUrWin = Convert.ToString(BetMines.betMinesWin) + "$";
                        MinesBut21Back = new SolidColorBrush(Color.FromArgb(100, 255, 138, 138));

                        RdyButSpin = true;
                        IsCheckedMinesEnabled = true;
                        GameAddMines(BetMines.betMinesWin, Bet.betTotal);
                    }
                    else
                    {
                        BetMines.betMinesWin = Bet.betTotal * 0.5;
                        MinesUrWin = Convert.ToString(BetMines.betMinesWin) + "$";


                        MinesBut33IsEnabled = true;
                        MinesBut31Pick = 1;
                        MinesBut32Pick = 1;
                        MinesBut33Pick = 1;

                        MinesBut21Text = "0.5x";

                        if (elemNumber2[1] == 3)
                        {
                            MinesBut22Bimb = 1;
                            MinesBut23Text = "0.5x";
                        }
                        else if (elemNumber2[2] == 3)
                        {
                            MinesBut23Bimb = 1;
                            MinesBut22Text = "0.5x";
                        }

                        MinesBut21Back = new SolidColorBrush(Color.FromArgb(100, 170, 255, 177));
                    }
                }
                else
                {
                    if (elemNumber2[0] == 3)
                    {
                        BetMines.betMinesWin = Bet.betTotal * 3;
                        MinesUrWin = Convert.ToString(BetMines.betMinesWin) + "$";

                        MinesBut33IsEnabled = true;
                        MinesBut31Pick = 1;
                        MinesBut32Pick = 1;
                        MinesBut33Pick = 1;

                        MinesBut21Text = "3x";
                        MinesBut22Bimb = 1;
                        MinesBut23Bimb = 1;
                        MinesBut21Back = new SolidColorBrush(Color.FromArgb(100, 170, 255, 177));
                    }
                    else
                    {
                        BetMines.betMinesWin = 0;
                        MinesUrWin = Convert.ToString(BetMines.betMinesWin) + "$";
                        GameAddMines(BetMines.betMinesWin, Bet.betTotal);
                        RdyButSpin = true;
                        IsCheckedMinesEnabled = true;
                        if (elemNumber2[1] == 3)
                        {
                            MinesBut21Bimb = 1;
                            MinesBut23Bimb = 1;
                            MinesBut22Text = "3x";

                        }
                        else if (elemNumber2[2] == 3)
                        {
                            MinesBut21Bimb = 1;
                            MinesBut22Bimb = 1;
                            MinesBut23Text = "3x";
                        }

                        MinesBut21Back = new SolidColorBrush(Color.FromArgb(100, 255, 138, 138));
                    }
                }
            }
            BLACK_WHITE_CASINOContext context = new BLACK_WHITE_CASINOContext();
            ActiveUser.activeUser.Total = Convert.ToDecimal(Total.TotalSumm);
            ActiveUser.UpdateState(context);
            context.SaveChanges();
        }

        #endregion
        #region Кнпока 2 2
        public ICommand MinesBut22Command { get; }

        private bool CanMinesBut22CommandExecuted(object p)
        {
            return true;
        }

        private void OnMinesBut22CommandExecuted(object p)
        {
            if (zIndexTabs == 2)
            {
                RdyButSpin = false;
                IsCheckedMinesEnabled = false;
                MinesBut22IsEnabled = false;

                MinesBut21Pick = 0;
                MinesBut22Pick = 0;
                MinesBut23Pick = 0;

                if (IsCheckedMines == true)
                {
                    if (elemNumber2[1] == 3)
                    {
                        BetMines.betMinesWin = 0;
                        MinesBut22Bimb = 1;
                        MinesBut21Text = "0.5x";
                        MinesBut23Text = "0.5x";
                        MinesUrWin = Convert.ToString(BetMines.betMinesWin) + "$";
                        MinesBut22Back = new SolidColorBrush(Color.FromArgb(100, 255, 138, 138));

                        RdyButSpin = true;
                        IsCheckedMinesEnabled = true;
                        GameAddMines(BetMines.betMinesWin, Bet.betTotal);
                    }
                    else
                    {
                        BetMines.betMinesWin = Bet.betTotal * 0.5;
                        MinesUrWin = Convert.ToString(BetMines.betMinesWin) + "$";


                        MinesBut33IsEnabled = true;
                        MinesBut31Pick = 1;
                        MinesBut32Pick = 1;
                        MinesBut33Pick = 1;

                        MinesBut22Text = "0.5x";

                        if (elemNumber2[0] == 3)
                        {
                            MinesBut21Bimb = 1;
                            MinesBut23Text = "0.5x";
                        }
                        else if (elemNumber2[2] == 3)
                        {
                            MinesBut23Bimb = 1;
                            MinesBut21Text = "0.5x";
                        }

                        MinesBut22Back = new SolidColorBrush(Color.FromArgb(100, 170, 255, 177));
                    }
                }
                else
                {
                    if (elemNumber2[1] == 3)
                    {
                        BetMines.betMinesWin = Bet.betTotal * 3;
                        MinesUrWin = Convert.ToString(BetMines.betMinesWin) + "$";

                        MinesBut33IsEnabled = true;
                        MinesBut31Pick = 1;
                        MinesBut32Pick = 1;
                        MinesBut33Pick = 1;

                        MinesBut22Text = "3x";
                        MinesBut21Bimb = 1;
                        MinesBut23Bimb = 1;
                        MinesBut22Back = new SolidColorBrush(Color.FromArgb(100, 170, 255, 177));
                    }
                    else
                    {
                        BetMines.betMinesWin = 0;
                        MinesUrWin = Convert.ToString(BetMines.betMinesWin) + "$";
                        GameAddMines(BetMines.betMinesWin, Bet.betTotal);
                        RdyButSpin = true;
                        IsCheckedMinesEnabled = true;
                        if (elemNumber2[0] == 3)
                        {
                            MinesBut22Bimb = 1;
                            MinesBut23Bimb = 1;
                            MinesBut21Text = "3x";

                        }
                        else if (elemNumber2[2] == 3)
                        {
                            MinesBut22Bimb = 1;
                            MinesBut21Bimb = 1;
                            MinesBut23Text = "3x";
                        }

                        MinesBut22Back = new SolidColorBrush(Color.FromArgb(100, 255, 138, 138));
                    }
                }
            }
            BLACK_WHITE_CASINOContext context = new BLACK_WHITE_CASINOContext();
            ActiveUser.activeUser.Total = Convert.ToDecimal(Total.TotalSumm);
            ActiveUser.UpdateState(context);
            context.SaveChanges();
        }

        #endregion
        #region Кнпока 2 3
        public ICommand MinesBut23Command { get; }

        private bool CanMinesBut23CommandExecuted(object p)
        {
            return true;
        }

        private void OnMinesBut23CommandExecuted(object p)
        {
            if (zIndexTabs == 2)
            {
                RdyButSpin = false;
                IsCheckedMinesEnabled = false;
                MinesBut22IsEnabled = false;

                MinesBut21Pick = 0;
                MinesBut22Pick = 0;
                MinesBut23Pick = 0;

                if (IsCheckedMines == true)
                {
                    if (elemNumber2[2] == 3)
                    {
                        BetMines.betMinesWin = 0;
                        MinesBut23Bimb = 1;
                        MinesBut22Text = "0.5x";
                        MinesBut21Text = "0.5x";
                        MinesUrWin = Convert.ToString(BetMines.betMinesWin) + "$";
                        MinesBut23Back = new SolidColorBrush(Color.FromArgb(100, 255, 138, 138));

                        RdyButSpin = true;
                        IsCheckedMinesEnabled = true;
                        GameAddMines(BetMines.betMinesWin, Bet.betTotal);
                    }
                    else
                    {
                        BetMines.betMinesWin = Bet.betTotal * 0.5;
                        MinesUrWin = Convert.ToString(BetMines.betMinesWin) + "$";


                        MinesBut33IsEnabled = true;
                        MinesBut33Pick = 1;
                        MinesBut32Pick = 1;
                        MinesBut31Pick = 1;

                        MinesBut23Text = "0.5x";

                        if (elemNumber2[1] == 3)
                        {
                            MinesBut22Bimb = 1;
                            MinesBut21Text = "0.5x";
                        }
                        else if (elemNumber2[0] == 3)
                        {
                            MinesBut21Bimb = 1;
                            MinesBut22Text = "0.5x";
                        }

                        MinesBut23Back = new SolidColorBrush(Color.FromArgb(100, 170, 255, 177));
                    }
                }
                else
                {
                    if (elemNumber2[2] == 3)
                    {
                        BetMines.betMinesWin = Bet.betTotal * 3;
                        MinesUrWin = Convert.ToString(BetMines.betMinesWin) + "$";

                        MinesBut33IsEnabled = true;
                        MinesBut31Pick = 1;
                        MinesBut32Pick = 1;
                        MinesBut33Pick = 1;

                        MinesBut23Text = "3x";
                        MinesBut22Bimb = 1;
                        MinesBut21Bimb = 1;
                        MinesBut23Back = new SolidColorBrush(Color.FromArgb(100, 170, 255, 177));
                    }
                    else
                    {
                        BetMines.betMinesWin = 0;
                        MinesUrWin = Convert.ToString(BetMines.betMinesWin) + "$";
                        GameAddMines(BetMines.betMinesWin, Bet.betTotal);
                        RdyButSpin = true;
                        IsCheckedMinesEnabled = true;
                        if (elemNumber2[1] == 3)
                        {
                            MinesBut23Bimb = 1;
                            MinesBut21Bimb = 1;
                            MinesBut22Text = "3x";

                        }
                        else if (elemNumber2[0] == 3)
                        {
                            MinesBut23Bimb = 1;
                            MinesBut22Bimb = 1;
                            MinesBut21Text = "3x";
                        }

                        MinesBut23Back = new SolidColorBrush(Color.FromArgb(100, 255, 138, 138));
                    }
                }
            }
            BLACK_WHITE_CASINOContext context = new BLACK_WHITE_CASINOContext();
            ActiveUser.activeUser.Total = Convert.ToDecimal(Total.TotalSumm);
            ActiveUser.UpdateState(context);
            context.SaveChanges();
        }

        #endregion

        #region Кнпока 3 1
        public ICommand MinesBut31Command { get; }

        private bool CanMinesBut31CommandExecuted(object p)
        {
            return true;
        }

        private void OnMinesBut31CommandExecuted(object p)
        {
            if (zIndexTabs == 2)
            {
                RdyButSpin = false;
                IsCheckedMinesEnabled = false;
                MinesBut33IsEnabled = false;

                MinesBut31Pick = 0;
                MinesBut32Pick = 0;
                MinesBut33Pick = 0;

                if (IsCheckedMines == true)
                {
                    if (elemNumber3[0] == 3)
                    {
                        BetMines.betMinesWin = 0;
                        MinesBut31Bimb = 1;
                        MinesBut32Text = "1x";
                        MinesBut33Text = "1x";
                        MinesUrWin = Convert.ToString(BetMines.betMinesWin) + "$";
                        MinesBut31Back = new SolidColorBrush(Color.FromArgb(100, 255, 138, 138));

                        RdyButSpin = true;
                        IsCheckedMinesEnabled = true;
                        GameAddMines(BetMines.betMinesWin, Bet.betTotal);
                    }
                    else
                    {
                        BetMines.betMinesWin = Bet.betTotal * 1;
                        MinesUrWin = Convert.ToString(BetMines.betMinesWin) + "$";


                        MinesBut44IsEnabled = true;
                        MinesBut41Pick = 1;
                        MinesBut42Pick = 1;
                        MinesBut43Pick = 1;

                        MinesBut31Text = "1x";

                        if (elemNumber3[1] == 3)
                        {
                            MinesBut32Bimb = 1;
                            MinesBut33Text = "1x";
                        }
                        else if (elemNumber3[2] == 3)
                        {
                            MinesBut33Bimb = 1;
                            MinesBut32Text = "1x";
                        }

                        MinesBut31Back = new SolidColorBrush(Color.FromArgb(100, 170, 255, 177));
                    }
                }
                else
                {
                    if (elemNumber3[0] == 3)
                    {
                        BetMines.betMinesWin = Bet.betTotal * 10;
                        MinesUrWin = Convert.ToString(BetMines.betMinesWin) + "$";

                        MinesBut44IsEnabled = true;
                        MinesBut41Pick = 1;
                        MinesBut42Pick = 1;
                        MinesBut43Pick = 1;

                        MinesBut31Text = "10x";
                        MinesBut32Bimb = 1;
                        MinesBut33Bimb = 1;
                        MinesBut31Back = new SolidColorBrush(Color.FromArgb(100, 170, 255, 177));
                    }
                    else
                    {
                        BetMines.betMinesWin = 0;
                        MinesUrWin = Convert.ToString(BetMines.betMinesWin) + "$";
                        GameAddMines(BetMines.betMinesWin, Bet.betTotal);
                        RdyButSpin = true;
                        IsCheckedMinesEnabled = true;
                        if (elemNumber3[1] == 3)
                        {
                            MinesBut31Bimb = 1;
                            MinesBut33Bimb = 1;
                            MinesBut32Text = "10x";

                        }
                        else if (elemNumber3[2] == 3)
                        {
                            MinesBut31Bimb = 1;
                            MinesBut32Bimb = 1;
                            MinesBut33Text = "10x";
                        }

                        MinesBut31Back = new SolidColorBrush(Color.FromArgb(100, 255, 138, 138));
                    }
                }
            }
            BLACK_WHITE_CASINOContext context = new BLACK_WHITE_CASINOContext();
            ActiveUser.activeUser.Total = Convert.ToDecimal(Total.TotalSumm);
            ActiveUser.UpdateState(context);
            context.SaveChanges();
        }

        #endregion
        #region Кнпока 3 2
        public ICommand MinesBut32Command { get; }

        private bool CanMinesBut32CommandExecuted(object p)
        {
            return true;
        }

        private void OnMinesBut32CommandExecuted(object p)
        {
            if (zIndexTabs == 2)
            {
                RdyButSpin = false;
                IsCheckedMinesEnabled = false;
                MinesBut33IsEnabled = false;

                MinesBut31Pick = 0;
                MinesBut32Pick = 0;
                MinesBut33Pick = 0;

                if (IsCheckedMines == true)
                {
                    if (elemNumber3[1] == 3)
                    {
                        BetMines.betMinesWin = 0;
                        MinesBut32Bimb = 1;
                        MinesBut31Text = "1x";
                        MinesBut33Text = "1x";
                        MinesUrWin = Convert.ToString(BetMines.betMinesWin) + "$";
                        MinesBut32Back = new SolidColorBrush(Color.FromArgb(100, 255, 138, 138));

                        RdyButSpin = true;
                        IsCheckedMinesEnabled = true;
                        GameAddMines(BetMines.betMinesWin, Bet.betTotal);
                    }
                    else
                    {
                        BetMines.betMinesWin = Bet.betTotal * 1;
                        MinesUrWin = Convert.ToString(BetMines.betMinesWin) + "$";


                        MinesBut44IsEnabled = true;
                        MinesBut41Pick = 1;
                        MinesBut42Pick = 1;
                        MinesBut43Pick = 1;

                        MinesBut32Text = "1x";

                        if (elemNumber3[0] == 3)
                        {
                            MinesBut31Bimb = 1;
                            MinesBut33Text = "1x";
                        }
                        else if (elemNumber3[2] == 3)
                        {
                            MinesBut33Bimb = 1;
                            MinesBut31Text = "1x";
                        }

                        MinesBut32Back = new SolidColorBrush(Color.FromArgb(100, 170, 255, 177));
                    }
                }
                else
                {
                    if (elemNumber3[1] == 3)
                    {
                        BetMines.betMinesWin = Bet.betTotal * 10;
                        MinesUrWin = Convert.ToString(BetMines.betMinesWin) + "$";

                        MinesBut44IsEnabled = true;
                        MinesBut41Pick = 1;
                        MinesBut42Pick = 1;
                        MinesBut43Pick = 1;

                        MinesBut32Text = "10x";
                        MinesBut31Bimb = 1;
                        MinesBut33Bimb = 1;
                        MinesBut32Back = new SolidColorBrush(Color.FromArgb(100, 170, 255, 177));
                    }
                    else
                    {
                        BetMines.betMinesWin = 0;
                        MinesUrWin = Convert.ToString(BetMines.betMinesWin) + "$";
                        GameAddMines(BetMines.betMinesWin, Bet.betTotal);
                        RdyButSpin = true;
                        IsCheckedMinesEnabled = true;
                        if (elemNumber3[0] == 3)
                        {
                            MinesBut32Bimb = 1;
                            MinesBut33Bimb = 1;
                            MinesBut31Text = "10x";

                        }
                        else if (elemNumber3[2] == 3)
                        {
                            MinesBut32Bimb = 1;
                            MinesBut31Bimb = 1;
                            MinesBut33Text = "10x";
                        }

                        MinesBut32Back = new SolidColorBrush(Color.FromArgb(100, 255, 138, 138));
                    }
                }
            }
            BLACK_WHITE_CASINOContext context = new BLACK_WHITE_CASINOContext();
            ActiveUser.activeUser.Total = Convert.ToDecimal(Total.TotalSumm);
            ActiveUser.UpdateState(context);
            context.SaveChanges();
        }

        #endregion
        #region Кнпока 3 3
        public ICommand MinesBut33Command { get; }

        private bool CanMinesBut33CommandExecuted(object p)
        {
            return true;
        }

        private void OnMinesBut33CommandExecuted(object p)
        {
            if (zIndexTabs == 2)
            {
                RdyButSpin = false;
                IsCheckedMinesEnabled = false;
                MinesBut33IsEnabled = false;

                MinesBut31Pick = 0;
                MinesBut32Pick = 0;
                MinesBut33Pick = 0;

                if (IsCheckedMines == true)
                {
                    if (elemNumber3[2] == 3)
                    {
                        BetMines.betMinesWin = 0;
                        MinesBut33Bimb = 1;
                        MinesBut32Text = "1x";
                        MinesBut31Text = "1x";
                        MinesUrWin = Convert.ToString(BetMines.betMinesWin) + "$";
                        MinesBut33Back = new SolidColorBrush(Color.FromArgb(100, 255, 138, 138));

                        RdyButSpin = true;
                        IsCheckedMinesEnabled = true;
                        GameAddMines(BetMines.betMinesWin, Bet.betTotal);
                    }
                    else
                    {
                        BetMines.betMinesWin = Bet.betTotal * 1;
                        MinesUrWin = Convert.ToString(BetMines.betMinesWin) + "$";


                        MinesBut44IsEnabled = true;
                        MinesBut41Pick = 1;
                        MinesBut42Pick = 1;
                        MinesBut43Pick = 1;

                        MinesBut33Text = "1x";

                        if (elemNumber3[1] == 3)
                        {
                            MinesBut32Bimb = 1;
                            MinesBut31Text = "1x";
                        }
                        else if (elemNumber3[0] == 3)
                        {
                            MinesBut31Bimb = 1;
                            MinesBut32Text = "1x";
                        }

                        MinesBut33Back = new SolidColorBrush(Color.FromArgb(100, 170, 255, 177));
                    }
                }
                else
                {
                    if (elemNumber3[2] == 3)
                    {
                        BetMines.betMinesWin = Bet.betTotal * 10;
                        MinesUrWin = Convert.ToString(BetMines.betMinesWin) + "$";

                        MinesBut44IsEnabled = true;
                        MinesBut41Pick = 1;
                        MinesBut42Pick = 1;
                        MinesBut43Pick = 1;

                        MinesBut33Text = "10x";
                        MinesBut32Bimb = 1;
                        MinesBut31Bimb = 1;
                        MinesBut33Back = new SolidColorBrush(Color.FromArgb(100, 170, 255, 177));
                    }
                    else
                    {
                        BetMines.betMinesWin = 0;
                        MinesUrWin = Convert.ToString(BetMines.betMinesWin) + "$";
                        GameAddMines(BetMines.betMinesWin, Bet.betTotal);
                        RdyButSpin = true;
                        IsCheckedMinesEnabled = true;
                        if (elemNumber3[1] == 3)
                        {
                            MinesBut33Bimb = 1;
                            MinesBut31Bimb = 1;
                            MinesBut32Text = "10x";

                        }
                        else if (elemNumber3[0] == 3)
                        {
                            MinesBut33Bimb = 1;
                            MinesBut32Bimb = 1;
                            MinesBut31Text = "10x";
                        }

                        MinesBut33Back = new SolidColorBrush(Color.FromArgb(100, 255, 138, 138));
                    }
                }
            }
            BLACK_WHITE_CASINOContext context = new BLACK_WHITE_CASINOContext();
            ActiveUser.activeUser.Total = Convert.ToDecimal(Total.TotalSumm);
            ActiveUser.UpdateState(context);
            context.SaveChanges();
        }

        #endregion

        #region Кнпока 4 1
        public ICommand MinesBut41Command { get; }

        private bool CanMinesBut41CommandExecuted(object p)
        {
            return true;
        }

        private void OnMinesBut41CommandExecuted(object p)
        {
            if (zIndexTabs == 2)
            {
                RdyButSpin = false;
                IsCheckedMinesEnabled = false;
                MinesBut44IsEnabled = false;

                MinesBut41Pick = 0;
                MinesBut42Pick = 0;
                MinesBut43Pick = 0;

                if (IsCheckedMines == true)
                {
                    if (elemNumber4[0] == 3)
                    {
                        BetMines.betMinesWin = 0;
                        MinesBut41Bimb = 1;
                        MinesBut42Text = "2x";
                        MinesBut43Text = "2x";
                        MinesUrWin = Convert.ToString(BetMines.betMinesWin) + "$";
                        MinesBut41Back = new SolidColorBrush(Color.FromArgb(100, 255, 138, 138));
                        GameAddMines(BetMines.betMinesWin, Bet.betTotal);
                        RdyButSpin = true;
                        IsCheckedMinesEnabled = true;
                    }
                    else
                    {
                        BetMines.betMinesWin = Bet.betTotal * 2;
                        MinesUrWin = Convert.ToString(BetMines.betMinesWin) + "$";


                        MinesBut55IsEnabled = true;
                        MinesBut51Pick = 1;
                        MinesBut52Pick = 1;
                        MinesBut53Pick = 1;

                        MinesBut41Text = "2x";

                        if (elemNumber4[1] == 3)
                        {
                            MinesBut42Bimb = 1;
                            MinesBut43Text = "2x";
                        }
                        else if (elemNumber4[2] == 3)
                        {
                            MinesBut43Bimb = 1;
                            MinesBut42Text = "2x";
                        }

                        MinesBut41Back = new SolidColorBrush(Color.FromArgb(100, 170, 255, 177));
                    }
                }
                else
                {
                    if (elemNumber4[0] == 3)
                    {
                        BetMines.betMinesWin = Bet.betTotal * 25;
                        MinesUrWin = Convert.ToString(BetMines.betMinesWin) + "$";

                        MinesBut55IsEnabled = true;
                        MinesBut51Pick = 1;
                        MinesBut52Pick = 1;
                        MinesBut53Pick = 1;

                        MinesBut41Text = "25x";
                        MinesBut42Bimb = 1;
                        MinesBut43Bimb = 1;
                        MinesBut41Back = new SolidColorBrush(Color.FromArgb(100, 170, 255, 177));
                    }
                    else
                    {
                        BetMines.betMinesWin = 0;
                        MinesUrWin = Convert.ToString(BetMines.betMinesWin) + "$";
                        GameAddMines(BetMines.betMinesWin, Bet.betTotal);
                        RdyButSpin = true;
                        IsCheckedMinesEnabled = true;
                        if (elemNumber4[1] == 3)
                        {
                            MinesBut41Bimb = 1;
                            MinesBut43Bimb = 1;
                            MinesBut42Text = "25x";

                        }
                        else if (elemNumber4[2] == 3)
                        {
                            MinesBut41Bimb = 1;
                            MinesBut42Bimb = 1;
                            MinesBut43Text = "25x";
                        }

                        MinesBut41Back = new SolidColorBrush(Color.FromArgb(100, 255, 138, 138));
                    }
                }
            }
            BLACK_WHITE_CASINOContext context = new BLACK_WHITE_CASINOContext();
            ActiveUser.activeUser.Total = Convert.ToDecimal(Total.TotalSumm);
            ActiveUser.UpdateState(context);
            context.SaveChanges();
        }

        #endregion
        #region Кнпока 4 2
        public ICommand MinesBut42Command { get; }

        private bool CanMinesBut42CommandExecuted(object p)
        {
            return true;
        }

        private void OnMinesBut42CommandExecuted(object p)
        {
            if (zIndexTabs == 2)
            {
                RdyButSpin = false;
                IsCheckedMinesEnabled = false;
                MinesBut44IsEnabled = false;

                MinesBut41Pick = 0;
                MinesBut42Pick = 0;
                MinesBut43Pick = 0;

                if (IsCheckedMines == true)
                {
                    if (elemNumber4[1] == 3)
                    {
                        BetMines.betMinesWin = 0;
                        MinesBut42Bimb = 1;
                        MinesBut41Text = "2x";
                        MinesBut43Text = "2x";
                        MinesUrWin = Convert.ToString(BetMines.betMinesWin) + "$";
                        MinesBut42Back = new SolidColorBrush(Color.FromArgb(100, 255, 138, 138));
                        GameAddMines(BetMines.betMinesWin, Bet.betTotal);
                        RdyButSpin = true;
                        IsCheckedMinesEnabled = true;
                    }
                    else
                    {
                        BetMines.betMinesWin = Bet.betTotal * 2;
                        MinesUrWin = Convert.ToString(BetMines.betMinesWin) + "$";


                        MinesBut55IsEnabled = true;
                        MinesBut51Pick = 1;
                        MinesBut52Pick = 1;
                        MinesBut53Pick = 1;

                        MinesBut42Text = "2x";

                        if (elemNumber4[0] == 3)
                        {
                            MinesBut41Bimb = 1;
                            MinesBut43Text = "2x";
                        }
                        else if (elemNumber4[2] == 3)
                        {
                            MinesBut43Bimb = 1;
                            MinesBut41Text = "2x";
                        }

                        MinesBut42Back = new SolidColorBrush(Color.FromArgb(100, 170, 255, 177));
                    }
                }
                else
                {
                    if (elemNumber4[1] == 3)
                    {
                        BetMines.betMinesWin = Bet.betTotal * 25;
                        MinesUrWin = Convert.ToString(BetMines.betMinesWin) + "$";

                        MinesBut55IsEnabled = true;
                        MinesBut51Pick = 1;
                        MinesBut52Pick = 1;
                        MinesBut53Pick = 1;

                        MinesBut42Text = "25x";
                        MinesBut41Bimb = 1;
                        MinesBut43Bimb = 1;
                        MinesBut42Back = new SolidColorBrush(Color.FromArgb(100, 170, 255, 177));
                    }
                    else
                    {
                        BetMines.betMinesWin = 0;
                        MinesUrWin = Convert.ToString(BetMines.betMinesWin) + "$";
                        GameAddMines(BetMines.betMinesWin, Bet.betTotal);
                        RdyButSpin = true;
                        IsCheckedMinesEnabled = true;
                        if (elemNumber4[0] == 3)
                        {
                            MinesBut42Bimb = 1;
                            MinesBut43Bimb = 1;
                            MinesBut41Text = "25x";

                        }
                        else if (elemNumber4[2] == 3)
                        {
                            MinesBut42Bimb = 1;
                            MinesBut41Bimb = 1;
                            MinesBut43Text = "25x";
                        }

                        MinesBut42Back = new SolidColorBrush(Color.FromArgb(100, 255, 138, 138));
                    }
                }
            }
            BLACK_WHITE_CASINOContext context = new BLACK_WHITE_CASINOContext();
            ActiveUser.activeUser.Total = Convert.ToDecimal(Total.TotalSumm);
            ActiveUser.UpdateState(context);
            context.SaveChanges();
        }

        #endregion
        #region Кнпока 4 3
        public ICommand MinesBut43Command { get; }

        private bool CanMinesBut43CommandExecuted(object p)
        {
            return true;
        }

        private void OnMinesBut43CommandExecuted(object p)
        {
            if (zIndexTabs == 2)
            {
                RdyButSpin = false;
                IsCheckedMinesEnabled = false;
                MinesBut44IsEnabled = false;

                MinesBut41Pick = 0;
                MinesBut42Pick = 0;
                MinesBut43Pick = 0;

                if (IsCheckedMines == true)
                {
                    if (elemNumber4[2] == 3)
                    {
                        BetMines.betMinesWin = 0;
                        MinesBut43Bimb = 1;
                        MinesBut42Text = "2x";
                        MinesBut41Text = "2x";
                        MinesUrWin = Convert.ToString(BetMines.betMinesWin) + "$";
                        MinesBut43Back = new SolidColorBrush(Color.FromArgb(100, 255, 138, 138));
                        GameAddMines(BetMines.betMinesWin, Bet.betTotal);
                        RdyButSpin = true;
                        IsCheckedMinesEnabled = true;
                    }
                    else
                    {
                        BetMines.betMinesWin = Bet.betTotal * 2;
                        MinesUrWin = Convert.ToString(BetMines.betMinesWin) + "$";


                        MinesBut55IsEnabled = true;
                        MinesBut51Pick = 1;
                        MinesBut52Pick = 1;
                        MinesBut53Pick = 1;

                        MinesBut43Text = "2x";

                        if (elemNumber4[1] == 3)
                        {
                            MinesBut42Bimb = 1;
                            MinesBut41Text = "2x";
                        }
                        else if (elemNumber4[0] == 3)
                        {
                            MinesBut41Bimb = 1;
                            MinesBut42Text = "2x";
                        }

                        MinesBut43Back = new SolidColorBrush(Color.FromArgb(100, 170, 255, 177));
                    }
                }
                else
                {
                    if (elemNumber4[2] == 3)
                    {
                        BetMines.betMinesWin = Bet.betTotal * 25;
                        MinesUrWin = Convert.ToString(BetMines.betMinesWin) + "$";

                        MinesBut55IsEnabled = true;
                        MinesBut51Pick = 1;
                        MinesBut52Pick = 1;
                        MinesBut53Pick = 1;

                        MinesBut43Text = "25x";
                        MinesBut42Bimb = 1;
                        MinesBut41Bimb = 1;
                        MinesBut43Back = new SolidColorBrush(Color.FromArgb(100, 170, 255, 177));
                    }
                    else
                    {
                        BetMines.betMinesWin = 0;
                        MinesUrWin = Convert.ToString(BetMines.betMinesWin) + "$";
                        GameAddMines(BetMines.betMinesWin, Bet.betTotal);
                        RdyButSpin = true;
                        IsCheckedMinesEnabled = true;
                        if (elemNumber4[1] == 3)
                        {
                            MinesBut43Bimb = 1;
                            MinesBut41Bimb = 1;
                            MinesBut42Text = "25x";

                        }
                        else if (elemNumber4[0] == 3)
                        {
                            MinesBut43Bimb = 1;
                            MinesBut42Bimb = 1;
                            MinesBut41Text = "25x";
                        }

                        MinesBut43Back = new SolidColorBrush(Color.FromArgb(100, 255, 138, 138));
                    }
                }
            }
            BLACK_WHITE_CASINOContext context = new BLACK_WHITE_CASINOContext();
            ActiveUser.activeUser.Total = Convert.ToDecimal(Total.TotalSumm);
            ActiveUser.UpdateState(context);
            context.SaveChanges();
        }

        #endregion

        #region Кнпока 5 1
        public ICommand MinesBut51Command { get; }

        private bool CanMinesBut51CommandExecuted(object p)
        {
            return true;
        }

        private void OnMinesBut51CommandExecuted(object p)
        {
            if (zIndexTabs == 2)
            {
                RdyButSpin = true;
                IsCheckedMinesEnabled = true;
                MinesBut11IsEnabled = false;
                MinesBut22IsEnabled = false;
                MinesBut33IsEnabled = false;
                MinesBut44IsEnabled = false;
                MinesBut55IsEnabled = false;

                MinesBut51Pick = 0;
                MinesBut52Pick = 0;
                MinesBut53Pick = 0;

                if (IsCheckedMines == true)
                {
                    if (elemNumber5[0] == 3)
                    {
                        BetMines.betMinesWin = 0;
                        MinesBut51Bimb = 1;
                        MinesBut52Text = "5x";
                        MinesBut53Text = "5x";
                        MinesUrWin = Convert.ToString(BetMines.betMinesWin) + "$";
                        MinesBut51Back = new SolidColorBrush(Color.FromArgb(100, 255, 138, 138));
                    }
                    else
                    {
                        BetMines.betMinesWin = Bet.betTotal * 5;
                        total.TotalUp(BetMines.betMinesWin);
                        TotalValue = total.ToString();
                        MinesUrWin = Convert.ToString(BetMines.betMinesWin) + "$";
                        checkResultForDB = true;

                        MinesBut51Text = "5x";

                        if (elemNumber5[1] == 3)
                        {
                            MinesBut52Bimb = 1;
                            MinesBut53Text = "5x";
                        }
                        else if (elemNumber5[2] == 3)
                        {
                            MinesBut53Bimb = 1;
                            MinesBut52Text = "5x";
                        }

                        MinesBut51Back = new SolidColorBrush(Color.FromArgb(100, 170, 255, 177));
                    }
                }
                else
                {
                    if (elemNumber5[0] == 3)
                    {
                        BetMines.betMinesWin = Bet.betTotal * 100;
                        total.TotalUp(BetMines.betMinesWin);
                        TotalValue = total.ToString();
                        MinesUrWin = Convert.ToString(BetMines.betMinesWin) + "$";
                        checkResultForDB = true;
                        MinesBut51Text = "100x";
                        MinesBut52Bimb = 1;
                        MinesBut53Bimb = 1;
                        MinesBut51Back = new SolidColorBrush(Color.FromArgb(100, 170, 255, 177));
                    }
                    else
                    {
                        BetMines.betMinesWin = 0;
                        MinesUrWin = Convert.ToString(BetMines.betMinesWin) + "$";
                        if (elemNumber5[1] == 3)
                        {
                            MinesBut51Bimb = 1;
                            MinesBut53Bimb = 1;
                            MinesBut52Text = "100x";

                        }
                        else if (elemNumber5[2] == 3)
                        {
                            MinesBut51Bimb = 1;
                            MinesBut52Bimb = 1;
                            MinesBut53Text = "100x";
                        }

                        MinesBut51Back = new SolidColorBrush(Color.FromArgb(100, 255, 138, 138));
                    }
                }
                GameAddMines(BetMines.betMinesWin, Bet.betTotal);
            }
            BLACK_WHITE_CASINOContext context = new BLACK_WHITE_CASINOContext();
            ActiveUser.activeUser.Total = Convert.ToDecimal(Total.TotalSumm);
            ActiveUser.UpdateState(context);
            context.SaveChanges();
        }

        #endregion
        #region Кнпока 5 2
        public ICommand MinesBut52Command { get; }

        private bool CanMinesBut52CommandExecuted(object p)
        {
            return true;
        }

        private void OnMinesBut52CommandExecuted(object p)
        {
            if (zIndexTabs == 2)
            {
                RdyButSpin = true;
                IsCheckedMinesEnabled = true;
                MinesBut11IsEnabled = false;
                MinesBut22IsEnabled = false;
                MinesBut33IsEnabled = false;
                MinesBut44IsEnabled = false;
                MinesBut55IsEnabled = false;

                MinesBut51Pick = 0;
                MinesBut52Pick = 0;
                MinesBut53Pick = 0;

                if (IsCheckedMines == true)
                {
                    if (elemNumber5[1] == 3)
                    {
                        BetMines.betMinesWin = 0;
                        MinesBut52Bimb = 1;
                        MinesBut51Text = "5x";
                        MinesBut53Text = "5x";
                        MinesUrWin = Convert.ToString(BetMines.betMinesWin) + "$";
                        MinesBut52Back = new SolidColorBrush(Color.FromArgb(100, 255, 138, 138));
                    }
                    else
                    {
                        BetMines.betMinesWin = Bet.betTotal * 5;
                        total.TotalUp(BetMines.betMinesWin);
                        TotalValue = total.ToString();
                        MinesUrWin = Convert.ToString(BetMines.betMinesWin) + "$";
                        checkResultForDB = true;
                        MinesBut52Text = "5x";

                        if (elemNumber5[0] == 3)
                        {
                            MinesBut51Bimb = 1;
                            MinesBut53Text = "5x";
                        }
                        else if (elemNumber5[2] == 3)
                        {
                            MinesBut53Bimb = 1;
                            MinesBut51Text = "5x";
                        }

                        MinesBut52Back = new SolidColorBrush(Color.FromArgb(100, 170, 255, 177));
                    }
                }
                else
                {
                    if (elemNumber5[1] == 3)
                    {
                        BetMines.betMinesWin = Bet.betTotal * 100;
                        total.TotalUp(BetMines.betMinesWin);
                        TotalValue = total.ToString();
                        MinesUrWin = Convert.ToString(BetMines.betMinesWin) + "$";
                        checkResultForDB = true;
                        MinesBut52Text = "100x";
                        MinesBut51Bimb = 1;
                        MinesBut53Bimb = 1;
                        MinesBut52Back = new SolidColorBrush(Color.FromArgb(100, 170, 255, 177));
                    }
                    else
                    {
                        BetMines.betMinesWin = 0;
                        MinesUrWin = Convert.ToString(BetMines.betMinesWin) + "$";
                        if (elemNumber5[0] == 3)
                        {
                            MinesBut52Bimb = 1;
                            MinesBut53Bimb = 1;
                            MinesBut51Text = "100x";

                        }
                        else if (elemNumber5[2] == 3)
                        {
                            MinesBut52Bimb = 1;
                            MinesBut51Bimb = 1;
                            MinesBut53Text = "100x";
                        }

                        MinesBut52Back = new SolidColorBrush(Color.FromArgb(100, 255, 138, 138));
                    }
                }
                GameAddMines(BetMines.betMinesWin, Bet.betTotal);
            }
            BLACK_WHITE_CASINOContext context = new BLACK_WHITE_CASINOContext();
            ActiveUser.activeUser.Total = Convert.ToDecimal(Total.TotalSumm);
            ActiveUser.UpdateState(context);
            context.SaveChanges();
        }

        #endregion
        #region Кнпока 5 3
        public ICommand MinesBut53Command { get; }

        private bool CanMinesBut53CommandExecuted(object p)
        {
            return true;
        }

        private void OnMinesBut53CommandExecuted(object p)
        {
            if (zIndexTabs == 2)
            {
                RdyButSpin = true;
                IsCheckedMinesEnabled = true;
                MinesBut11IsEnabled = false;
                MinesBut22IsEnabled = false;
                MinesBut33IsEnabled = false;
                MinesBut44IsEnabled = false;
                MinesBut55IsEnabled = false;

                MinesBut51Pick = 0;
                MinesBut52Pick = 0;
                MinesBut53Pick = 0;

                if (IsCheckedMines == true)
                {
                    if (elemNumber5[2] == 3)
                    {
                        BetMines.betMinesWin = 0;
                        MinesBut53Bimb = 1;
                        MinesBut52Text = "5x";
                        MinesBut51Text = "5x";
                        MinesUrWin = Convert.ToString(BetMines.betMinesWin) + "$";
                        MinesBut53Back = new SolidColorBrush(Color.FromArgb(100, 255, 138, 138));
                    }
                    else
                    {
                        BetMines.betMinesWin = Bet.betTotal * 5;
                        total.TotalUp(BetMines.betMinesWin);
                        TotalValue = total.ToString();
                        MinesUrWin = Convert.ToString(BetMines.betMinesWin) + "$";
                        checkResultForDB = true;
                        MinesBut53Text = "5x";

                        if (elemNumber5[1] == 3)
                        {
                            MinesBut52Bimb = 1;
                            MinesBut51Text = "5x";
                        }
                        else if (elemNumber5[0] == 3)
                        {
                            MinesBut51Bimb = 1;
                            MinesBut52Text = "5x";
                        }

                        MinesBut53Back = new SolidColorBrush(Color.FromArgb(100, 170, 255, 177));
                    }

                }
                else
                {
                    if (elemNumber5[2] == 3)
                    {
                        BetMines.betMinesWin = Bet.betTotal * 100;
                        total.TotalUp(BetMines.betMinesWin);
                        TotalValue = total.ToString();
                        MinesUrWin = Convert.ToString(BetMines.betMinesWin) + "$";
                        checkResultForDB = true;
                        MinesBut53Text = "100x";
                        MinesBut52Bimb = 1;
                        MinesBut51Bimb = 1;
                        MinesBut53Back = new SolidColorBrush(Color.FromArgb(100, 170, 255, 177));
                    }
                    else
                    {
                        BetMines.betMinesWin = 0;
                        MinesUrWin = Convert.ToString(BetMines.betMinesWin) + "$";
                        if (elemNumber5[1] == 3)
                        {
                            MinesBut53Bimb = 1;
                            MinesBut51Bimb = 1;
                            MinesBut52Text = "100x";

                        }
                        else if (elemNumber5[0] == 3)
                        {
                            MinesBut53Bimb = 1;
                            MinesBut52Bimb = 1;
                            MinesBut51Text = "100x";
                        }

                        MinesBut53Back = new SolidColorBrush(Color.FromArgb(100, 255, 138, 138));
                    }
                }
                GameAddMines(BetMines.betMinesWin, Bet.betTotal);
            }
            BLACK_WHITE_CASINOContext context = new BLACK_WHITE_CASINOContext();
            ActiveUser.activeUser.Total = Convert.ToDecimal(Total.TotalSumm);
            ActiveUser.UpdateState(context);
            context.SaveChanges();
        }

        #endregion

        #region Кнпока Забрать
        public ICommand MinesButClearCommand { get; }

        private bool CanMinesButClearCommandExecuted(object p)
        {
            if (BetMines.betMinesWin > 0)
            {
                return true;
            }
            else
                return false;
        }

        private void OnMinesButClearCommandExecuted(object p)
        {
            if (zIndexTabs == 2)
            {
                checkResultForDB = true;
                total.TotalUp(BetMines.betMinesWin);
                TotalValue = total.ToString();
                GameAddMines(BetMines.betMinesWin, Bet.betTotal);

                BetMines.betMinesWin = 0;
                MinesUrWin = Convert.ToString(BetMines.betMinesWin) + "$";

                RdyButSpin = true;
                IsCheckedMinesEnabled = true;

                MinesBut11IsEnabled = false;
                MinesBut22IsEnabled = false;
                MinesBut33IsEnabled = false;
                MinesBut44IsEnabled = false;
                MinesBut55IsEnabled = false;

                MinesBut11Pick = 0;
                MinesBut12Pick = 0;
                MinesBut13Pick = 0;
                MinesBut21Pick = 0;
                MinesBut22Pick = 0;
                MinesBut23Pick = 0;
                MinesBut31Pick = 0;
                MinesBut32Pick = 0;
                MinesBut33Pick = 0;
                MinesBut41Pick = 0;
                MinesBut42Pick = 0;
                MinesBut43Pick = 0;
                MinesBut51Pick = 0;
                MinesBut52Pick = 0;
                MinesBut53Pick = 0;

                MinesBut11Bimb = 0;
                MinesBut12Bimb = 0;
                MinesBut13Bimb = 0;
                MinesBut21Bimb = 0;
                MinesBut22Bimb = 0;
                MinesBut23Bimb = 0;
                MinesBut31Bimb = 0;
                MinesBut32Bimb = 0;
                MinesBut33Bimb = 0;
                MinesBut41Bimb = 0;
                MinesBut42Bimb = 0;
                MinesBut43Bimb = 0;
                MinesBut51Bimb = 0;
                MinesBut52Bimb = 0;
                MinesBut53Bimb = 0;

                MinesBut11Back = new SolidColorBrush(Color.FromArgb(100, 255, 255, 255));
                MinesBut12Back = new SolidColorBrush(Color.FromArgb(100, 255, 255, 255));
                MinesBut13Back = new SolidColorBrush(Color.FromArgb(100, 255, 255, 255));
                MinesBut21Back = new SolidColorBrush(Color.FromArgb(100, 255, 255, 255));
                MinesBut22Back = new SolidColorBrush(Color.FromArgb(100, 255, 255, 255));
                MinesBut23Back = new SolidColorBrush(Color.FromArgb(100, 255, 255, 255));
                MinesBut31Back = new SolidColorBrush(Color.FromArgb(100, 255, 255, 255));
                MinesBut32Back = new SolidColorBrush(Color.FromArgb(100, 255, 255, 255));
                MinesBut33Back = new SolidColorBrush(Color.FromArgb(100, 255, 255, 255));
                MinesBut41Back = new SolidColorBrush(Color.FromArgb(100, 255, 255, 255));
                MinesBut42Back = new SolidColorBrush(Color.FromArgb(100, 255, 255, 255));
                MinesBut43Back = new SolidColorBrush(Color.FromArgb(100, 255, 255, 255));
                MinesBut51Back = new SolidColorBrush(Color.FromArgb(100, 255, 255, 255));
                MinesBut52Back = new SolidColorBrush(Color.FromArgb(100, 255, 255, 255));
                MinesBut53Back = new SolidColorBrush(Color.FromArgb(100, 255, 255, 255));

                MinesBut11Text = "";
                MinesBut12Text = "";
                MinesBut13Text = "";
                MinesBut21Text = "";
                MinesBut22Text = "";
                MinesBut23Text = "";
                MinesBut31Text = "";
                MinesBut32Text = "";
                MinesBut33Text = "";
                MinesBut41Text = "";
                MinesBut42Text = "";
                MinesBut43Text = "";
                MinesBut51Text = "";
                MinesBut52Text = "";
                MinesBut53Text = "";
            }
            BLACK_WHITE_CASINOContext context = new BLACK_WHITE_CASINOContext();
            ActiveUser.activeUser.Total = Convert.ToDecimal(Total.TotalSumm);
            ActiveUser.UpdateState(context);
            context.SaveChanges();
        }

        #endregion

        #endregion

        //NINE
        #region nine
        #region IsCheckedNine
        private bool _IsCheckedNinev = false;

        public bool IsCheckedNine
        {
            get
            {
                return _IsCheckedNinev;
            }
            set
            {
                Set(ref _IsCheckedNinev, value);
            }
        }
        #endregion

        #region NineChances
        private int _NineChances = 4;

        public int NineChances
        {
            get
            {
                return _NineChances;
            }
            set
            {
                Set(ref _NineChances, value);
            }
        }
        #endregion

        #region NineMbWin
        private string _NineMbWin = "0$";

        public string NineMbWin
        {
            get
            {
                return _NineMbWin;
            }
            set
            {
                Set(ref _NineMbWin, value);
            }
        }
        #endregion

        #region NineButCheckedIsEnabled
        private bool _NineButCheckedIsEnabled = true;

        public bool NineButCheckedIsEnabled
        {
            get
            {
                return _NineButCheckedIsEnabled;
            }
            set
            {
                Set(ref _NineButCheckedIsEnabled, value);
            }
        }
        #endregion




        #region NineBut1Text
        private string _NineBut1Text = "";

        public string NineBut1Text
        {
            get
            {
                return _NineBut1Text;
            }
            set
            {
                Set(ref _NineBut1Text, value);
            }
        }
        #endregion
        #region NineBut1Opacity
        private double _NineBut1Opacity = 0;

        public double NineBut1Opacity
        {
            get
            {
                return _NineBut1Opacity;
            }
            set
            {
                Set(ref _NineBut1Opacity, value);
            }
        }
        #endregion
        #region NineBut1Pick
        private double _NineBut1Pick = 0;

        public double NineBut1Pick
        {
            get
            {
                return _NineBut1Pick;
            }
            set
            {
                Set(ref _NineBut1Pick, value);
            }
        }
        #endregion
        #region NineBut1Back
        private SolidColorBrush _NineBut1Back = new SolidColorBrush(Color.FromArgb(100, 255, 255, 255));  //new SolidColorBrush(Color.FromArgb(100, 255, 138, 138))

        public SolidColorBrush NineBut1Back
        {
            get
            {
                return _NineBut1Back;
            }
            set
            {
                Set(ref _NineBut1Back, value);
            }
        }
        #endregion
        #region NineBut1IsEnabled
        private bool _NineBut1IsEnabled = false;

        public bool NineBut1IsEnabled
        {
            get
            {
                return _NineBut1IsEnabled;
            }
            set
            {
                Set(ref _NineBut1IsEnabled, value);
            }
        }
        #endregion

        #region NineBut2Text
        private string _NineBut2Text = "";

        public string NineBut2Text
        {
            get
            {
                return _NineBut2Text;
            }
            set
            {
                Set(ref _NineBut2Text, value);
            }
        }
        #endregion
        #region NineBut2Opacity
        private double _NineBut2Opacity = 0;

        public double NineBut2Opacity
        {
            get
            {
                return _NineBut2Opacity;
            }
            set
            {
                Set(ref _NineBut2Opacity, value);
            }
        }
        #endregion
        #region NineBut2Pick
        private double _NineBut2Pick = 0;

        public double NineBut2Pick
        {
            get
            {
                return _NineBut2Pick;
            }
            set
            {
                Set(ref _NineBut2Pick, value);
            }
        }
        #endregion
        #region NineBut2Back
        private SolidColorBrush _NineBut2Back = new SolidColorBrush(Color.FromArgb(100, 255, 255, 255));  //new SolidColorBrush(Color.FromArgb(100, 255, 138, 138))

        public SolidColorBrush NineBut2Back
        {
            get
            {
                return _NineBut2Back;
            }
            set
            {
                Set(ref _NineBut2Back, value);
            }
        }
        #endregion
        #region NineBut2IsEnabled
        private bool _NineBut2IsEnabled = false;

        public bool NineBut2IsEnabled
        {
            get
            {
                return _NineBut2IsEnabled;
            }
            set
            {
                Set(ref _NineBut2IsEnabled, value);
            }
        }
        #endregion

        #region NineBut3Text
        private string _NineBut3Text = "";

        public string NineBut3Text
        {
            get
            {
                return _NineBut3Text;
            }
            set
            {
                Set(ref _NineBut3Text, value);
            }
        }
        #endregion
        #region NineBut3Opacity
        private double _NineBut3Opacity = 0;

        public double NineBut3Opacity
        {
            get
            {
                return _NineBut3Opacity;
            }
            set
            {
                Set(ref _NineBut3Opacity, value);
            }
        }
        #endregion
        #region NineBut3Pick
        private double _NineBut3Pick = 0;

        public double NineBut3Pick
        {
            get
            {
                return _NineBut3Pick;
            }
            set
            {
                Set(ref _NineBut3Pick, value);
            }
        }
        #endregion
        #region NineBut3Back
        private SolidColorBrush _NineBut3Back = new SolidColorBrush(Color.FromArgb(100, 255, 255, 255));  //new SolidColorBrush(Color.FromArgb(100, 255, 138, 138))

        public SolidColorBrush NineBut3Back
        {
            get
            {
                return _NineBut3Back;
            }
            set
            {
                Set(ref _NineBut3Back, value);
            }
        }
        #endregion
        #region NineBut3IsEnabled
        private bool _NineBut3IsEnabled = false;

        public bool NineBut3IsEnabled
        {
            get
            {
                return _NineBut3IsEnabled;
            }
            set
            {
                Set(ref _NineBut3IsEnabled, value);
            }
        }
        #endregion

        #region NineBut4Text
        private string _NineBut4Text = "";

        public string NineBut4Text
        {
            get
            {
                return _NineBut4Text;
            }
            set
            {
                Set(ref _NineBut4Text, value);
            }
        }
        #endregion
        #region NineBut4Opacity
        private double _NineBut4Opacity = 0;

        public double NineBut4Opacity
        {
            get
            {
                return _NineBut4Opacity;
            }
            set
            {
                Set(ref _NineBut4Opacity, value);
            }
        }
        #endregion
        #region NineBut4Pick
        private double _NineBut4Pick = 0;

        public double NineBut4Pick
        {
            get
            {
                return _NineBut4Pick;
            }
            set
            {
                Set(ref _NineBut4Pick, value);
            }
        }
        #endregion
        #region NineBut4Back
        private SolidColorBrush _NineBut4Back = new SolidColorBrush(Color.FromArgb(100, 255, 255, 255));  //new SolidColorBrush(Color.FromArgb(100, 255, 138, 138))

        public SolidColorBrush NineBut4Back
        {
            get
            {
                return _NineBut4Back;
            }
            set
            {
                Set(ref _NineBut4Back, value);
            }
        }
        #endregion
        #region NineBut4IsEnabled
        private bool _NineBut4IsEnabled = false;

        public bool NineBut4IsEnabled
        {
            get
            {
                return _NineBut4IsEnabled;
            }
            set
            {
                Set(ref _NineBut4IsEnabled, value);
            }
        }
        #endregion

        #region NineBut5Text
        private string _NineBut5Text = "";

        public string NineBut5Text
        {
            get
            {
                return _NineBut5Text;
            }
            set
            {
                Set(ref _NineBut5Text, value);
            }
        }
        #endregion
        #region NineBut5Opacity
        private double _NineBut5Opacity = 0;

        public double NineBut5Opacity
        {
            get
            {
                return _NineBut5Opacity;
            }
            set
            {
                Set(ref _NineBut5Opacity, value);
            }
        }
        #endregion
        #region NineBut5Pick
        private double _NineBut5Pick = 0;

        public double NineBut5Pick
        {
            get
            {
                return _NineBut5Pick;
            }
            set
            {
                Set(ref _NineBut5Pick, value);
            }
        }
        #endregion
        #region NineBut5Back
        private SolidColorBrush _NineBut5Back = new SolidColorBrush(Color.FromArgb(100, 255, 255, 255));  //new SolidColorBrush(Color.FromArgb(100, 255, 138, 138))

        public SolidColorBrush NineBut5Back
        {
            get
            {
                return _NineBut5Back;
            }
            set
            {
                Set(ref _NineBut5Back, value);
            }
        }
        #endregion
        #region NineBut5IsEnabled
        private bool _NineBut5IsEnabled = false;

        public bool NineBut5IsEnabled
        {
            get
            {
                return _NineBut5IsEnabled;
            }
            set
            {
                Set(ref _NineBut5IsEnabled, value);
            }
        }
        #endregion

        #region NineBut6Text
        private string _NineBut6Text = "";

        public string NineBut6Text
        {
            get
            {
                return _NineBut6Text;
            }
            set
            {
                Set(ref _NineBut6Text, value);
            }
        }
        #endregion
        #region NineBut6Opacity
        private double _NineBut6Opacity = 0;

        public double NineBut6Opacity
        {
            get
            {
                return _NineBut6Opacity;
            }
            set
            {
                Set(ref _NineBut6Opacity, value);
            }
        }
        #endregion
        #region NineBut6Pick
        private double _NineBut6Pick = 0;

        public double NineBut6Pick
        {
            get
            {
                return _NineBut6Pick;
            }
            set
            {
                Set(ref _NineBut6Pick, value);
            }
        }
        #endregion
        #region NineBut6Back
        private SolidColorBrush _NineBut6Back = new SolidColorBrush(Color.FromArgb(100, 255, 255, 255));  //new SolidColorBrush(Color.FromArgb(100, 255, 138, 138))

        public SolidColorBrush NineBut6Back
        {
            get
            {
                return _NineBut6Back;
            }
            set
            {
                Set(ref _NineBut6Back, value);
            }
        }
        #endregion
        #region NineBut6IsEnabled
        private bool _NineBut6IsEnabled = false;

        public bool NineBut6IsEnabled
        {
            get
            {
                return _NineBut6IsEnabled;
            }
            set
            {
                Set(ref _NineBut6IsEnabled, value);
            }
        }
        #endregion

        #region NineBut7Text
        private string _NineBut7Text = "";

        public string NineBut7Text
        {
            get
            {
                return _NineBut7Text;
            }
            set
            {
                Set(ref _NineBut7Text, value);
            }
        }
        #endregion
        #region NineBut7Opacity
        private double _NineBut7Opacity = 0;

        public double NineBut7Opacity
        {
            get
            {
                return _NineBut7Opacity;
            }
            set
            {
                Set(ref _NineBut7Opacity, value);
            }
        }
        #endregion
        #region NineBut7Pick
        private double _NineBut7Pick = 0;

        public double NineBut7Pick
        {
            get
            {
                return _NineBut7Pick;
            }
            set
            {
                Set(ref _NineBut7Pick, value);
            }
        }
        #endregion
        #region NineBut7Back
        private SolidColorBrush _NineBut7Back = new SolidColorBrush(Color.FromArgb(100, 255, 255, 255));  //new SolidColorBrush(Color.FromArgb(100, 255, 138, 138))

        public SolidColorBrush NineBut7Back
        {
            get
            {
                return _NineBut7Back;
            }
            set
            {
                Set(ref _NineBut7Back, value);
            }
        }
        #endregion
        #region NineBut7IsEnabled
        private bool _NineBut7IsEnabled = false;

        public bool NineBut7IsEnabled
        {
            get
            {
                return _NineBut7IsEnabled;
            }
            set
            {
                Set(ref _NineBut7IsEnabled, value);
            }
        }
        #endregion

        #region NineBut8Text
        private string _NineBut8Text = "";

        public string NineBut8Text
        {
            get
            {
                return _NineBut8Text;
            }
            set
            {
                Set(ref _NineBut8Text, value);
            }
        }
        #endregion
        #region NineBut8Opacity
        private double _NineBut8Opacity = 0;

        public double NineBut8Opacity
        {
            get
            {
                return _NineBut8Opacity;
            }
            set
            {
                Set(ref _NineBut8Opacity, value);
            }
        }
        #endregion
        #region NineBut8Pick
        private double _NineBut8Pick = 0;

        public double NineBut8Pick
        {
            get
            {
                return _NineBut8Pick;
            }
            set
            {
                Set(ref _NineBut8Pick, value);
            }
        }
        #endregion
        #region NineBut8Back
        private SolidColorBrush _NineBut8Back = new SolidColorBrush(Color.FromArgb(100, 255, 255, 255));  //new SolidColorBrush(Color.FromArgb(100, 255, 138, 138))

        public SolidColorBrush NineBut8Back
        {
            get
            {
                return _NineBut8Back;
            }
            set
            {
                Set(ref _NineBut8Back, value);
            }
        }
        #endregion
        #region NineBut8IsEnabled
        private bool _NineBut8IsEnabled = false;

        public bool NineBut8IsEnabled
        {
            get
            {
                return _NineBut8IsEnabled;
            }
            set
            {
                Set(ref _NineBut8IsEnabled, value);
            }
        }
        #endregion

        #region NineBut9Text
        private string _NineBut9Text = "";

        public string NineBut9Text
        {
            get
            {
                return _NineBut9Text;
            }
            set
            {
                Set(ref _NineBut9Text, value);
            }
        }
        #endregion
        #region NineBut9Opacity
        private double _NineBut9Opacity = 0;

        public double NineBut9Opacity
        {
            get
            {
                return _NineBut9Opacity;
            }
            set
            {
                Set(ref _NineBut9Opacity, value);
            }
        }
        #endregion
        #region NineBut9Pick
        private double _NineBut9Pick = 0;

        public double NineBut9Pick
        {
            get
            {
                return _NineBut9Pick;
            }
            set
            {
                Set(ref _NineBut9Pick, value);
            }
        }
        #endregion
        #region NineBut9Back
        private SolidColorBrush _NineBut9Back = new SolidColorBrush(Color.FromArgb(100, 255, 255, 255));  //new SolidColorBrush(Color.FromArgb(100, 255, 138, 138))

        public SolidColorBrush NineBut9Back
        {
            get
            {
                return _NineBut9Back;
            }
            set
            {
                Set(ref _NineBut9Back, value);
            }
        }
        #endregion
        #region NineBut9IsEnabled
        private bool _NineBut9IsEnabled = false;

        public bool NineBut9IsEnabled
        {
            get
            {
                return _NineBut9IsEnabled;
            }
            set
            {
                Set(ref _NineBut9IsEnabled, value);
            }
        }
        #endregion


        #region IsCheckedNineCommand

        public ICommand IsCheckedNineCommand { get; }

        private bool CanIsCheckedNineCommandExecuted(object p)
        {
            return true;
        }

        private void OnIsCheckedNineCommandExecuted(object p)
        {
            if (IsCheckedNine == false)
                NineChances = 4;
            else
                NineChances = 5;

        }

        #endregion

        #region NineBut1Command

        public ICommand NineBut1Command { get; }

        private bool CanNineBut1CommandExecuted(object p)
        {
            return true;
        }

        private void OnNineBut1CommandExecuted(object p)
        {
            NineBut1Pick = 0;
            NineBut1Back = new SolidColorBrush(Color.FromArgb(100, 170, 255, 177));
            NineBut1Opacity = 1;
            NineChances--;
            xNineWin = NineBut1Text;
            xNineWinMethod(NineBut1Text);
            if (WinState == true)
            {
                
                if (xNineWin == "0.25x")
                    xNineWinBet = Bet.betTotal * 0.25;
                else if (xNineWin == "0.5x")
                    xNineWinBet = Bet.betTotal * 0.5;
                else if (xNineWin == "1x")
                    xNineWinBet = Bet.betTotal * 1;
                else if (xNineWin == "1.5x")
                    xNineWinBet = Bet.betTotal * 1.5;
                else if (xNineWin == "2x")
                    xNineWinBet = Bet.betTotal * 2;
                else if (xNineWin == "3x")
                    xNineWinBet = Bet.betTotal * 3;
                else if (xNineWin == "4x")
                    xNineWinBet = Bet.betTotal * 4;
                else if (xNineWin == "5x")
                    xNineWinBet = Bet.betTotal * 5;
                else if (xNineWin == "6x")
                    xNineWinBet = Bet.betTotal * 6;
                else if (xNineWin == "7x")
                    xNineWinBet = Bet.betTotal * 7;
                else if (xNineWin == "10x")
                    xNineWinBet = Bet.betTotal * 10;
                else if (xNineWin == "15x")
                    xNineWinBet = Bet.betTotal * 15;
                else if (xNineWin == "20x")
                    xNineWinBet = Bet.betTotal * 20;
                else if (xNineWin == "50x")
                    xNineWinBet = Bet.betTotal * 50;
                else if (xNineWin == "100x")
                    xNineWinBet = Bet.betTotal * 100;

                NineChances = 0;
                if (IsCheckedNine == false)
                    total.TotalUp(xNineWinBet);                
                else
                    total.TotalUp(xNineWinBet * 0.5);
                checkResultForDB = true;
                TotalValue = total.ToString();
            }
            

            if (NineChances == 0)
            {
                GameAddNine(xNineWinBet, Bet.betTotal);

                NineBut1Pick = 0;
                NineBut2Pick = 0;
                NineBut3Pick = 0;
                NineBut4Pick = 0;
                NineBut5Pick = 0;
                NineBut6Pick = 0;
                NineBut7Pick = 0;
                NineBut8Pick = 0;
                NineBut9Pick = 0;

                NineBut1Opacity = 1;
                NineBut2Opacity = 1;
                NineBut3Opacity = 1;
                NineBut4Opacity = 1;
                NineBut5Opacity = 1;
                NineBut6Opacity = 1;
                NineBut7Opacity = 1;
                NineBut8Opacity = 1;
                NineBut9Opacity = 1;

                NineBut1IsEnabled = false;
                NineBut2IsEnabled = false;
                NineBut3IsEnabled = false;
                NineBut4IsEnabled = false;
                NineBut5IsEnabled = false;
                NineBut6IsEnabled = false;
                NineBut7IsEnabled = false;
                NineBut8IsEnabled = false;
                NineBut9IsEnabled = false;

                RdyButSpin = true;
                NineButCheckedIsEnabled = true;

            }
            BLACK_WHITE_CASINOContext context = new BLACK_WHITE_CASINOContext();
            ActiveUser.activeUser.Total = Convert.ToDecimal(Total.TotalSumm);
            ActiveUser.UpdateState(context);
            context.SaveChanges();
        }

        #endregion
        #region NineBut2Command

        public ICommand NineBut2Command { get; }

        private bool CanNineBut2CommandExecuted(object p)
        {
            return true;
        }

        private void OnNineBut2CommandExecuted(object p)
        {
            NineBut2Pick = 0;

            NineBut2Back = new SolidColorBrush(Color.FromArgb(100, 170, 255, 177));
            NineBut2Opacity = 1;
            NineChances--;
            xNineWin = NineBut2Text;
            xNineWinMethod(NineBut2Text);
            if (WinState == true)
            {

                if (xNineWin == "0.25x")
                    xNineWinBet = Bet.betTotal * 0.25;
                else if (xNineWin == "0.5x")
                    xNineWinBet = Bet.betTotal * 0.5;
                else if (xNineWin == "1x")
                    xNineWinBet = Bet.betTotal * 1;
                else if (xNineWin == "1.5x")
                    xNineWinBet = Bet.betTotal * 1.5;
                else if (xNineWin == "2x")
                    xNineWinBet = Bet.betTotal * 2;
                else if (xNineWin == "3x")
                    xNineWinBet = Bet.betTotal * 3;
                else if (xNineWin == "4x")
                    xNineWinBet = Bet.betTotal * 4;
                else if (xNineWin == "5x")
                    xNineWinBet = Bet.betTotal * 5;
                else if (xNineWin == "6x")
                    xNineWinBet = Bet.betTotal * 6;
                else if (xNineWin == "7x")
                    xNineWinBet = Bet.betTotal * 7;
                else if (xNineWin == "10x")
                    xNineWinBet = Bet.betTotal * 10;
                else if (xNineWin == "15x")
                    xNineWinBet = Bet.betTotal * 15;
                else if (xNineWin == "20x")
                    xNineWinBet = Bet.betTotal * 20;
                else if (xNineWin == "50x")
                    xNineWinBet = Bet.betTotal * 50;
                else if (xNineWin == "100x")
                    xNineWinBet = Bet.betTotal * 100;

                NineChances = 0;
                if (IsCheckedNine == false)
                    total.TotalUp(xNineWinBet);
                else
                    total.TotalUp(xNineWinBet * 0.5);
                checkResultForDB = true;
                TotalValue = total.ToString();
            }

            if (NineChances == 0)
            {
                GameAddNine(xNineWinBet, Bet.betTotal);

                NineBut1Pick = 0;
                NineBut2Pick = 0;
                NineBut3Pick = 0;
                NineBut4Pick = 0;
                NineBut5Pick = 0;
                NineBut6Pick = 0;
                NineBut7Pick = 0;
                NineBut8Pick = 0;
                NineBut9Pick = 0;

                NineBut1Opacity = 1;
                NineBut2Opacity = 1;
                NineBut3Opacity = 1;
                NineBut4Opacity = 1;
                NineBut5Opacity = 1;
                NineBut6Opacity = 1;
                NineBut7Opacity = 1;
                NineBut8Opacity = 1;
                NineBut9Opacity = 1;

                NineBut1IsEnabled = false;
                NineBut2IsEnabled = false;
                NineBut3IsEnabled = false;
                NineBut4IsEnabled = false;
                NineBut5IsEnabled = false;
                NineBut6IsEnabled = false;
                NineBut7IsEnabled = false;
                NineBut8IsEnabled = false;
                NineBut9IsEnabled = false;

                RdyButSpin = true;
                NineButCheckedIsEnabled = true;

            }
            BLACK_WHITE_CASINOContext context = new BLACK_WHITE_CASINOContext();
            ActiveUser.activeUser.Total = Convert.ToDecimal(Total.TotalSumm);
            ActiveUser.UpdateState(context);
            context.SaveChanges();
        }

        #endregion
        #region NineBut3Command

        public ICommand NineBut3Command { get; }

        private bool CanNineBut3CommandExecuted(object p)
        {
            return true;
        }

        private void OnNineBut3CommandExecuted(object p)
        {
            NineBut3Pick = 0;

            NineBut3Back = new SolidColorBrush(Color.FromArgb(100, 170, 255, 177));
            NineBut3Opacity = 1;
            NineChances--;
            xNineWin = NineBut3Text;
            xNineWinMethod(NineBut3Text);
            if (WinState == true)
            {

                if (xNineWin == "0.25x")
                    xNineWinBet = Bet.betTotal * 0.25;
                else if (xNineWin == "0.5x")
                    xNineWinBet = Bet.betTotal * 0.5;
                else if (xNineWin == "1x")
                    xNineWinBet = Bet.betTotal * 1;
                else if (xNineWin == "1.5x")
                    xNineWinBet = Bet.betTotal * 1.5;
                else if (xNineWin == "2x")
                    xNineWinBet = Bet.betTotal * 2;
                else if (xNineWin == "3x")
                    xNineWinBet = Bet.betTotal * 3;
                else if (xNineWin == "4x")
                    xNineWinBet = Bet.betTotal * 4;
                else if (xNineWin == "5x")
                    xNineWinBet = Bet.betTotal * 5;
                else if (xNineWin == "6x")
                    xNineWinBet = Bet.betTotal * 6;
                else if (xNineWin == "7x")
                    xNineWinBet = Bet.betTotal * 7;
                else if (xNineWin == "10x")
                    xNineWinBet = Bet.betTotal * 10;
                else if (xNineWin == "15x")
                    xNineWinBet = Bet.betTotal * 15;
                else if (xNineWin == "20x")
                    xNineWinBet = Bet.betTotal * 20;
                else if (xNineWin == "50x")
                    xNineWinBet = Bet.betTotal * 50;
                else if (xNineWin == "100x")
                    xNineWinBet = Bet.betTotal * 100;

                NineChances = 0;
                if (IsCheckedNine == false)
                    total.TotalUp(xNineWinBet);
                else
                    total.TotalUp(xNineWinBet * 0.5);
                checkResultForDB = true;
                TotalValue = total.ToString();
            }

            if (NineChances == 0)
            {

                GameAddNine(xNineWinBet, Bet.betTotal);

                NineBut1Pick = 0;
                NineBut2Pick = 0;
                NineBut3Pick = 0;
                NineBut4Pick = 0;
                NineBut5Pick = 0;
                NineBut6Pick = 0;
                NineBut7Pick = 0;
                NineBut8Pick = 0;
                NineBut9Pick = 0;

                NineBut1Opacity = 1;
                NineBut2Opacity = 1;
                NineBut3Opacity = 1;
                NineBut4Opacity = 1;
                NineBut5Opacity = 1;
                NineBut6Opacity = 1;
                NineBut7Opacity = 1;
                NineBut8Opacity = 1;
                NineBut9Opacity = 1;

                NineBut1IsEnabled = false;
                NineBut2IsEnabled = false;
                NineBut3IsEnabled = false;
                NineBut4IsEnabled = false;
                NineBut5IsEnabled = false;
                NineBut6IsEnabled = false;
                NineBut7IsEnabled = false;
                NineBut8IsEnabled = false;
                NineBut9IsEnabled = false;

                RdyButSpin = true;
                NineButCheckedIsEnabled = true;

            }
            BLACK_WHITE_CASINOContext context = new BLACK_WHITE_CASINOContext();
            ActiveUser.activeUser.Total = Convert.ToDecimal(Total.TotalSumm);
            ActiveUser.UpdateState(context);
            context.SaveChanges();
        }

        #endregion
        #region NineBut4Command

        public ICommand NineBut4Command { get; }

        private bool CanNineBut4CommandExecuted(object p)
        {
            return true;
        }

        private void OnNineBut4CommandExecuted(object p)
        {
            NineBut4Pick = 0;

            NineBut4Back = new SolidColorBrush(Color.FromArgb(100, 170, 255, 177));
            NineBut4Opacity = 1;
            NineChances--;
            xNineWin = NineBut4Text;
            xNineWinMethod(NineBut4Text);
            if (WinState == true)
            {

                if (xNineWin == "0.25x")
                    xNineWinBet = Bet.betTotal * 0.25;
                else if (xNineWin == "0.5x")
                    xNineWinBet = Bet.betTotal * 0.5;
                else if (xNineWin == "1x")
                    xNineWinBet = Bet.betTotal * 1;
                else if (xNineWin == "1.5x")
                    xNineWinBet = Bet.betTotal * 1.5;
                else if (xNineWin == "2x")
                    xNineWinBet = Bet.betTotal * 2;
                else if (xNineWin == "3x")
                    xNineWinBet = Bet.betTotal * 3;
                else if (xNineWin == "4x")
                    xNineWinBet = Bet.betTotal * 4;
                else if (xNineWin == "5x")
                    xNineWinBet = Bet.betTotal * 5;
                else if (xNineWin == "6x")
                    xNineWinBet = Bet.betTotal * 6;
                else if (xNineWin == "7x")
                    xNineWinBet = Bet.betTotal * 7;
                else if (xNineWin == "10x")
                    xNineWinBet = Bet.betTotal * 10;
                else if (xNineWin == "15x")
                    xNineWinBet = Bet.betTotal * 15;
                else if (xNineWin == "20x")
                    xNineWinBet = Bet.betTotal * 20;
                else if (xNineWin == "50x")
                    xNineWinBet = Bet.betTotal * 50;
                else if (xNineWin == "100x")
                    xNineWinBet = Bet.betTotal * 100;

                NineChances = 0;
                if (IsCheckedNine == false)
                    total.TotalUp(xNineWinBet);
                else
                    total.TotalUp(xNineWinBet * 0.5);
                checkResultForDB = true;
                TotalValue = total.ToString();
            }

            if (NineChances == 0)
            {
                GameAddNine(xNineWinBet, Bet.betTotal);

                NineBut1Pick = 0;
                NineBut2Pick = 0;
                NineBut3Pick = 0;
                NineBut4Pick = 0;
                NineBut5Pick = 0;
                NineBut6Pick = 0;
                NineBut7Pick = 0;
                NineBut8Pick = 0;
                NineBut9Pick = 0;

                NineBut1Opacity = 1;
                NineBut2Opacity = 1;
                NineBut3Opacity = 1;
                NineBut4Opacity = 1;
                NineBut5Opacity = 1;
                NineBut6Opacity = 1;
                NineBut7Opacity = 1;
                NineBut8Opacity = 1;
                NineBut9Opacity = 1;

                NineBut1IsEnabled = false;
                NineBut2IsEnabled = false;
                NineBut3IsEnabled = false;
                NineBut4IsEnabled = false;
                NineBut5IsEnabled = false;
                NineBut6IsEnabled = false;
                NineBut7IsEnabled = false;
                NineBut8IsEnabled = false;
                NineBut9IsEnabled = false;

                RdyButSpin = true;
                NineButCheckedIsEnabled = true;

            }
            BLACK_WHITE_CASINOContext context = new BLACK_WHITE_CASINOContext();
            ActiveUser.activeUser.Total = Convert.ToDecimal(Total.TotalSumm);
            ActiveUser.UpdateState(context);
            context.SaveChanges();
        }

        #endregion
        #region NineBut5Command

        public ICommand NineBut5Command { get; }

        private bool CanNineBut5CommandExecuted(object p)
        {
            return true;
        }

        private void OnNineBut5CommandExecuted(object p)
        {
            NineBut5Pick = 0;

            NineBut5Back = new SolidColorBrush(Color.FromArgb(100, 170, 255, 177));
            NineBut5Opacity = 1;
            NineChances--;
            xNineWin = NineBut5Text;
            xNineWinMethod(NineBut5Text);
            if (WinState == true)
            {

                if (xNineWin == "0.25x")
                    xNineWinBet = Bet.betTotal * 0.25;
                else if (xNineWin == "0.5x")
                    xNineWinBet = Bet.betTotal * 0.5;
                else if (xNineWin == "1x")
                    xNineWinBet = Bet.betTotal * 1;
                else if (xNineWin == "1.5x")
                    xNineWinBet = Bet.betTotal * 1.5;
                else if (xNineWin == "2x")
                    xNineWinBet = Bet.betTotal * 2;
                else if (xNineWin == "3x")
                    xNineWinBet = Bet.betTotal * 3;
                else if (xNineWin == "4x")
                    xNineWinBet = Bet.betTotal * 4;
                else if (xNineWin == "5x")
                    xNineWinBet = Bet.betTotal * 5;
                else if (xNineWin == "6x")
                    xNineWinBet = Bet.betTotal * 6;
                else if (xNineWin == "7x")
                    xNineWinBet = Bet.betTotal * 7;
                else if (xNineWin == "10x")
                    xNineWinBet = Bet.betTotal * 10;
                else if (xNineWin == "15x")
                    xNineWinBet = Bet.betTotal * 15;
                else if (xNineWin == "20x")
                    xNineWinBet = Bet.betTotal * 20;
                else if (xNineWin == "50x")
                    xNineWinBet = Bet.betTotal * 50;
                else if (xNineWin == "100x")
                    xNineWinBet = Bet.betTotal * 100;

                NineChances = 0;
                if (IsCheckedNine == false)
                    total.TotalUp(xNineWinBet);
                else
                    total.TotalUp(xNineWinBet * 0.5);
                checkResultForDB = true;
                TotalValue = total.ToString();
            }

            if (NineChances == 0)
            {
                GameAddNine(xNineWinBet, Bet.betTotal);

                NineBut1Pick = 0;
                NineBut2Pick = 0;
                NineBut3Pick = 0;
                NineBut4Pick = 0;
                NineBut5Pick = 0;
                NineBut6Pick = 0;
                NineBut7Pick = 0;
                NineBut8Pick = 0;
                NineBut9Pick = 0;

                NineBut1Opacity = 1;
                NineBut2Opacity = 1;
                NineBut3Opacity = 1;
                NineBut4Opacity = 1;
                NineBut5Opacity = 1;
                NineBut6Opacity = 1;
                NineBut7Opacity = 1;
                NineBut8Opacity = 1;
                NineBut9Opacity = 1;

                NineBut1IsEnabled = false;
                NineBut2IsEnabled = false;
                NineBut3IsEnabled = false;
                NineBut4IsEnabled = false;
                NineBut5IsEnabled = false;
                NineBut6IsEnabled = false;
                NineBut7IsEnabled = false;
                NineBut8IsEnabled = false;
                NineBut9IsEnabled = false;

                RdyButSpin = true;
                NineButCheckedIsEnabled = true;

            }
            BLACK_WHITE_CASINOContext context = new BLACK_WHITE_CASINOContext();
            ActiveUser.activeUser.Total = Convert.ToDecimal(Total.TotalSumm);
            ActiveUser.UpdateState(context);
            context.SaveChanges();
        }

        #endregion
        #region NineBut6Command

        public ICommand NineBut6Command { get; }

        private bool CanNineBut6CommandExecuted(object p)
        {
            return true;
        }

        private void OnNineBut6CommandExecuted(object p)
        {
            NineBut6Pick = 0;

            NineBut6Back = new SolidColorBrush(Color.FromArgb(100, 170, 255, 177));
            NineBut6Opacity = 1;
            NineChances--;
            xNineWin = NineBut6Text;
            xNineWinMethod(NineBut6Text);
            if (WinState == true)
            {

                if (xNineWin == "0.25x")
                    xNineWinBet = Bet.betTotal * 0.25;
                else if (xNineWin == "0.5x")
                    xNineWinBet = Bet.betTotal * 0.5;
                else if (xNineWin == "1x")
                    xNineWinBet = Bet.betTotal * 1;
                else if (xNineWin == "1.5x")
                    xNineWinBet = Bet.betTotal * 1.5;
                else if (xNineWin == "2x")
                    xNineWinBet = Bet.betTotal * 2;
                else if (xNineWin == "3x")
                    xNineWinBet = Bet.betTotal * 3;
                else if (xNineWin == "4x")
                    xNineWinBet = Bet.betTotal * 4;
                else if (xNineWin == "5x")
                    xNineWinBet = Bet.betTotal * 5;
                else if (xNineWin == "6x")
                    xNineWinBet = Bet.betTotal * 6;
                else if (xNineWin == "7x")
                    xNineWinBet = Bet.betTotal * 7;
                else if (xNineWin == "10x")
                    xNineWinBet = Bet.betTotal * 10;
                else if (xNineWin == "15x")
                    xNineWinBet = Bet.betTotal * 15;
                else if (xNineWin == "20x")
                    xNineWinBet = Bet.betTotal * 20;
                else if (xNineWin == "50x")
                    xNineWinBet = Bet.betTotal * 50;
                else if (xNineWin == "100x")
                    xNineWinBet = Bet.betTotal * 100;

                NineChances = 0;
                if (IsCheckedNine == false)
                    total.TotalUp(xNineWinBet);
                else
                    total.TotalUp(xNineWinBet * 0.5);
                checkResultForDB = true;
                TotalValue = total.ToString();
            }

            if (NineChances == 0)
            {
                GameAddNine(xNineWinBet, Bet.betTotal);

                NineBut1Pick = 0;
                NineBut2Pick = 0;
                NineBut3Pick = 0;
                NineBut4Pick = 0;
                NineBut5Pick = 0;
                NineBut6Pick = 0;
                NineBut7Pick = 0;
                NineBut8Pick = 0;
                NineBut9Pick = 0;

                NineBut1Opacity = 1;
                NineBut2Opacity = 1;
                NineBut3Opacity = 1;
                NineBut4Opacity = 1;
                NineBut5Opacity = 1;
                NineBut6Opacity = 1;
                NineBut7Opacity = 1;
                NineBut8Opacity = 1;
                NineBut9Opacity = 1;

                NineBut1IsEnabled = false;
                NineBut2IsEnabled = false;
                NineBut3IsEnabled = false;
                NineBut4IsEnabled = false;
                NineBut5IsEnabled = false;
                NineBut6IsEnabled = false;
                NineBut7IsEnabled = false;
                NineBut8IsEnabled = false;
                NineBut9IsEnabled = false;

                RdyButSpin = true;
                NineButCheckedIsEnabled = true;

            }
            BLACK_WHITE_CASINOContext context = new BLACK_WHITE_CASINOContext();
            ActiveUser.activeUser.Total = Convert.ToDecimal(Total.TotalSumm);
            ActiveUser.UpdateState(context);
            context.SaveChanges();
        }

        #endregion
        #region NineBut7Command

        public ICommand NineBut7Command { get; }

        private bool CanNineBut7CommandExecuted(object p)
        {
            return true;
        }

        private void OnNineBut7CommandExecuted(object p)
        {
            NineBut7Pick = 0;

            NineBut7Back = new SolidColorBrush(Color.FromArgb(100, 170, 255, 177));
            NineBut7Opacity = 1;
            NineChances--;
            xNineWin = NineBut7Text;
            xNineWinMethod(NineBut7Text);
            if (WinState == true)
            {

                if (xNineWin == "0.25x")
                    xNineWinBet = Bet.betTotal * 0.25;
                else if (xNineWin == "0.5x")
                    xNineWinBet = Bet.betTotal * 0.5;
                else if (xNineWin == "1x")
                    xNineWinBet = Bet.betTotal * 1;
                else if (xNineWin == "1.5x")
                    xNineWinBet = Bet.betTotal * 1.5;
                else if (xNineWin == "2x")
                    xNineWinBet = Bet.betTotal * 2;
                else if (xNineWin == "3x")
                    xNineWinBet = Bet.betTotal * 3;
                else if (xNineWin == "4x")
                    xNineWinBet = Bet.betTotal * 4;
                else if (xNineWin == "5x")
                    xNineWinBet = Bet.betTotal * 5;
                else if (xNineWin == "6x")
                    xNineWinBet = Bet.betTotal * 6;
                else if (xNineWin == "7x")
                    xNineWinBet = Bet.betTotal * 7;
                else if (xNineWin == "10x")
                    xNineWinBet = Bet.betTotal * 10;
                else if (xNineWin == "15x")
                    xNineWinBet = Bet.betTotal * 15;
                else if (xNineWin == "20x")
                    xNineWinBet = Bet.betTotal * 20;
                else if (xNineWin == "50x")
                    xNineWinBet = Bet.betTotal * 50;
                else if (xNineWin == "100x")
                    xNineWinBet = Bet.betTotal * 100;

                NineChances = 0;
                if (IsCheckedNine == false)
                    total.TotalUp(xNineWinBet);
                else
                    total.TotalUp(xNineWinBet * 0.5);
                checkResultForDB = true;
                TotalValue = total.ToString();
            }

            if (NineChances == 0)
            {
                GameAddNine(xNineWinBet, Bet.betTotal);

                NineBut1Pick = 0;
                NineBut2Pick = 0;
                NineBut3Pick = 0;
                NineBut4Pick = 0;
                NineBut5Pick = 0;
                NineBut6Pick = 0;
                NineBut7Pick = 0;
                NineBut8Pick = 0;
                NineBut9Pick = 0;

                NineBut1Opacity = 1;
                NineBut2Opacity = 1;
                NineBut3Opacity = 1;
                NineBut4Opacity = 1;
                NineBut5Opacity = 1;
                NineBut6Opacity = 1;
                NineBut7Opacity = 1;
                NineBut8Opacity = 1;
                NineBut9Opacity = 1;

                NineBut1IsEnabled = false;
                NineBut2IsEnabled = false;
                NineBut3IsEnabled = false;
                NineBut4IsEnabled = false;
                NineBut5IsEnabled = false;
                NineBut6IsEnabled = false;
                NineBut7IsEnabled = false;
                NineBut8IsEnabled = false;
                NineBut9IsEnabled = false;

                RdyButSpin = true;
                NineButCheckedIsEnabled = true;

            }
            BLACK_WHITE_CASINOContext context = new BLACK_WHITE_CASINOContext();
            ActiveUser.activeUser.Total = Convert.ToDecimal(Total.TotalSumm);
            ActiveUser.UpdateState(context);
            context.SaveChanges();
        }

        #endregion
        #region NineBut8Command

        public ICommand NineBut8Command { get; }

        private bool CanNineBut8CommandExecuted(object p)
        {
            return true;
        }

        private void OnNineBut8CommandExecuted(object p)
        {
            NineBut8Pick = 0;

            NineBut8Back = new SolidColorBrush(Color.FromArgb(100, 170, 255, 177));
            NineBut8Opacity = 1;
            NineChances--;
            xNineWin = NineBut8Text;
            xNineWinMethod(NineBut8Text);
            if (WinState == true)
            {

                if (xNineWin == "0.25x")
                    xNineWinBet = Bet.betTotal * 0.25;
                else if (xNineWin == "0.5x")
                    xNineWinBet = Bet.betTotal * 0.5;
                else if (xNineWin == "1x")
                    xNineWinBet = Bet.betTotal * 1;
                else if (xNineWin == "1.5x")
                    xNineWinBet = Bet.betTotal * 1.5;
                else if (xNineWin == "2x")
                    xNineWinBet = Bet.betTotal * 2;
                else if (xNineWin == "3x")
                    xNineWinBet = Bet.betTotal * 3;
                else if (xNineWin == "4x")
                    xNineWinBet = Bet.betTotal * 4;
                else if (xNineWin == "5x")
                    xNineWinBet = Bet.betTotal * 5;
                else if (xNineWin == "6x")
                    xNineWinBet = Bet.betTotal * 6;
                else if (xNineWin == "7x")
                    xNineWinBet = Bet.betTotal * 7;
                else if (xNineWin == "10x")
                    xNineWinBet = Bet.betTotal * 10;
                else if (xNineWin == "15x")
                    xNineWinBet = Bet.betTotal * 15;
                else if (xNineWin == "20x")
                    xNineWinBet = Bet.betTotal * 20;
                else if (xNineWin == "50x")
                    xNineWinBet = Bet.betTotal * 50;
                else if (xNineWin == "100x")
                    xNineWinBet = Bet.betTotal * 100;

                NineChances = 0;
                if (IsCheckedNine == false)
                    total.TotalUp(xNineWinBet);
                else
                    total.TotalUp(xNineWinBet * 0.5);
                checkResultForDB = true;
                TotalValue = total.ToString();
            }

            if (NineChances == 0)
            {
                GameAddNine(xNineWinBet, Bet.betTotal);

                NineBut1Pick = 0;
                NineBut2Pick = 0;
                NineBut3Pick = 0;
                NineBut4Pick = 0;
                NineBut5Pick = 0;
                NineBut6Pick = 0;
                NineBut7Pick = 0;
                NineBut8Pick = 0;
                NineBut9Pick = 0;

                NineBut1Opacity = 1;
                NineBut2Opacity = 1;
                NineBut3Opacity = 1;
                NineBut4Opacity = 1;
                NineBut5Opacity = 1;
                NineBut6Opacity = 1;
                NineBut7Opacity = 1;
                NineBut8Opacity = 1;
                NineBut9Opacity = 1;

                NineBut1IsEnabled = false;
                NineBut2IsEnabled = false;
                NineBut3IsEnabled = false;
                NineBut4IsEnabled = false;
                NineBut5IsEnabled = false;
                NineBut6IsEnabled = false;
                NineBut7IsEnabled = false;
                NineBut8IsEnabled = false;
                NineBut9IsEnabled = false;

                RdyButSpin = true;
                NineButCheckedIsEnabled = true;

            }
            BLACK_WHITE_CASINOContext context = new BLACK_WHITE_CASINOContext();
            ActiveUser.activeUser.Total = Convert.ToDecimal(Total.TotalSumm);
            ActiveUser.UpdateState(context);
            context.SaveChanges();
        }

        #endregion
        #region NineBut9Command

        public ICommand NineBut9Command { get; }

        private bool CanNineBut9CommandExecuted(object p)
        {
            return true;
        }

        private void OnNineBut9CommandExecuted(object p)
        {
            NineBut9Pick = 0;

            NineBut9Back = new SolidColorBrush(Color.FromArgb(100, 170, 255, 177));
            NineBut9Opacity = 1;
            NineChances--;
            xNineWin = NineBut9Text;
            xNineWinMethod(NineBut9Text);
            if (WinState == true)
            {

                if (xNineWin == "0.25x")
                    xNineWinBet = Bet.betTotal * 0.25;
                else if (xNineWin == "0.5x")
                    xNineWinBet = Bet.betTotal * 0.5;
                else if (xNineWin == "1x")
                    xNineWinBet = Bet.betTotal * 1;
                else if (xNineWin == "1.5x")
                    xNineWinBet = Bet.betTotal * 1.5;
                else if (xNineWin == "2x")
                    xNineWinBet = Bet.betTotal * 2;
                else if (xNineWin == "3x")
                    xNineWinBet = Bet.betTotal * 3;
                else if (xNineWin == "4x")
                    xNineWinBet = Bet.betTotal * 4;
                else if (xNineWin == "5x")
                    xNineWinBet = Bet.betTotal * 5;
                else if (xNineWin == "6x")
                    xNineWinBet = Bet.betTotal * 6;
                else if (xNineWin == "7x")
                    xNineWinBet = Bet.betTotal * 7;
                else if (xNineWin == "10x")
                    xNineWinBet = Bet.betTotal * 10;
                else if (xNineWin == "15x")
                    xNineWinBet = Bet.betTotal * 15;
                else if (xNineWin == "20x")
                    xNineWinBet = Bet.betTotal * 20;
                else if (xNineWin == "50x")
                    xNineWinBet = Bet.betTotal * 50;
                else if (xNineWin == "100x")
                    xNineWinBet = Bet.betTotal * 100;

                NineChances = 0;
                if (IsCheckedNine == false)
                    total.TotalUp(xNineWinBet);
                else
                    total.TotalUp(xNineWinBet * 0.5);
                checkResultForDB = true;
                TotalValue = total.ToString();
            }

            if (NineChances == 0)
            {
                GameAddNine(xNineWinBet, Bet.betTotal);

                NineBut1Pick = 0;
                NineBut2Pick = 0;
                NineBut3Pick = 0;
                NineBut4Pick = 0;
                NineBut5Pick = 0;
                NineBut6Pick = 0;
                NineBut7Pick = 0;
                NineBut8Pick = 0;
                NineBut9Pick = 0;

                NineBut1Opacity = 1;
                NineBut2Opacity = 1;
                NineBut3Opacity = 1;
                NineBut4Opacity = 1;
                NineBut5Opacity = 1;
                NineBut6Opacity = 1;
                NineBut7Opacity = 1;
                NineBut8Opacity = 1;
                NineBut9Opacity = 1;

                NineBut1IsEnabled = false;
                NineBut2IsEnabled = false;
                NineBut3IsEnabled = false;
                NineBut4IsEnabled = false;
                NineBut5IsEnabled = false;
                NineBut6IsEnabled = false;
                NineBut7IsEnabled = false;
                NineBut8IsEnabled = false;
                NineBut9IsEnabled = false;

                RdyButSpin = true;
                NineButCheckedIsEnabled = true;

            }
            BLACK_WHITE_CASINOContext context = new BLACK_WHITE_CASINOContext();
            ActiveUser.activeUser.Total = Convert.ToDecimal(Total.TotalSumm);
            ActiveUser.UpdateState(context);
            context.SaveChanges();
        }

        #endregion 
        #endregion

        //-----------------------------------------------------------------------------

        #region Spin

        public ICommand Spin { get; }

        private bool CanSpinExecuted(object p)
        {
            //Total.TotalSumm = Convert.ToDouble(ActiveUser.activeUser.Total);
            if (zIndexTabs == 0)
            {
                if (Total.TotalSumm >= 0)
                    return true;
                else
                    return false;
            }
            else if (zIndexTabs == 1)
            {
                if (Bet.betTotal <= Total.TotalSumm && Bet.betTotal >= 0)
                    return true;
                else
                    return false;
            }
            else if (zIndexTabs == 2)
            {
                if (Bet.betTotal <= Total.TotalSumm && Bet.betTotal >= 0)
                    return true;
                else
                    return false;
            }
            else if (zIndexTabs == 3)
            {
                if (Bet.betTotal <= Total.TotalSumm)
                    return true;
                else
                    return false;
            }
            else
                return false;  
        }

        private async void OnSpinExecuted(object p)
        {
        qwe:
            BLACK_WHITE_CASINOContext context = new BLACK_WHITE_CASINOContext();
            try
            {
                ActiveUser.activeUser.GameQuantity++;
                checkResultForDB = false;
                profitForDB = 0;

                var tab = p as TabControl;

                //double
                if (zIndexTabs == 0)
                {
                    

                    RdyButSpin = false;

                    double angleValueRandom = rndAngle.Next(1440, 1800);

                    AngleTo = AngleFrom - angleValueRandom;

                    #region поиск картинки
                    DoubleAnimation spin = new DoubleAnimation();
                    spin.From = AngleFrom;
                    spin.To = AngleTo;
                    spin.Duration = TimeSpan.FromSeconds(5);
                    easingFunction.EasingMode = EasingMode.EaseInOut;
                    spin.EasingFunction = easingFunction;

                    var item = tab.Items.GetItemAt(0) as TabItem;
                    var grid = item.Content as Grid;
                    foreach (var i in grid.Children)
                    {
                        var viewbox = i as Viewbox;
                        if (viewbox != null)
                        {
                            if (viewbox.Name == "DoubleViewBox")
                            {
                                var img = viewbox.Child as Image;
                                if (img != null && img.Name == "RotateImage")
                                {
                                    Storyboard strbrd = new Storyboard();
                                    Storyboard.SetTargetName(spin, img.Name);
                                    Storyboard.SetTargetProperty(spin, new PropertyPath("(UIElement.RenderTransform).(RotateTransform.Angle)"));
                                    strbrd.Children.Add(spin);
                                    strbrd.Begin(img);
                                }
                            }
                        }
                    }
                    #endregion

                    AngleFrom = Math.Round(AngleTo % 360, 2);

                    //определение результата
                    result = Math.Abs(AngleTo + 171.41) % 360;

                    await Task.Delay(5000);
                    #region проверка значений
                    if (result >= 0 && result < 18.94736842105263)
                    {
                        resultDouble = ResultsSpins.ResultSpin(0, "Красное");
                    }
                    else if (result >= 18.94736842105263 && result < 18.94736842105263 * 2)
                    {
                        resultDouble = ResultsSpins.ResultSpin(17, "Белое");
                    }
                    else if (result >= 18.94736842105263 * 2 && result < 18.94736842105263 * 3)
                    {
                        resultDouble = ResultsSpins.ResultSpin(7, "Чёрное");
                    }
                    else if (result >= 18.94736842105263 * 3 && result < 18.94736842105263 * 4)
                    {
                        resultDouble = ResultsSpins.ResultSpin(4, "Белое");
                    }
                    else if (result >= 18.94736842105263 * 4 && result < 18.94736842105263 * 5)
                    {
                        resultDouble = ResultsSpins.ResultSpin(12, "Чёрное");
                    }
                    else if (result >= 18.94736842105263 * 5 && result < 18.94736842105263 * 6)
                    {
                        resultDouble = ResultsSpins.ResultSpin(9, "Белое");
                    }
                    else if (result >= 18.94736842105263 * 6 && result < 18.94736842105263 * 7)
                    {
                        resultDouble = ResultsSpins.ResultSpin(15, "Чёрное");
                    }
                    else if (result >= 18.94736842105263 * 7 && result < 18.94736842105263 * 8)
                    {
                        resultDouble = ResultsSpins.ResultSpin(18, "Белое");
                    }
                    else if (result >= 18.94736842105263 * 8 && result < 18.94736842105263 * 9)
                    {
                        resultDouble = ResultsSpins.ResultSpin(6, "Чёрное");
                    }
                    else if (result >= 18.94736842105263 * 9 && result < 18.94736842105263 * 10)
                    {
                        resultDouble = ResultsSpins.ResultSpin(1, "Белое");
                    }
                    else if (result >= 18.94736842105263 * 10 && result < 18.94736842105263 * 11)
                    {
                        resultDouble = ResultsSpins.ResultSpin(13, "Чёрное");
                    }
                    else if (result >= 18.94736842105263 * 11 && result < 18.94736842105263 * 12)
                    {
                        resultDouble = ResultsSpins.ResultSpin(8, "Белое");
                    }
                    else if (result >= 18.94736842105263 * 12 && result < 18.94736842105263 * 13)
                    {
                        resultDouble = ResultsSpins.ResultSpin(14, "Чёрное");
                    }
                    else if (result >= 18.94736842105263 * 13 && result < 18.94736842105263 * 14)
                    {
                        resultDouble = ResultsSpins.ResultSpin(11, "Белое");
                    }
                    else if (result >= 18.94736842105263 * 14 && result < 18.94736842105263 * 15)
                    {
                        resultDouble = ResultsSpins.ResultSpin(3, "Чёрное");
                    }
                    else if (result >= 18.94736842105263 * 15 && result < 18.94736842105263 * 16)
                    {
                        resultDouble = ResultsSpins.ResultSpin(16, "Белое");
                    }
                    else if (result >= 18.94736842105263 * 16 && result < 18.94736842105263 * 17)
                    {
                        resultDouble = ResultsSpins.ResultSpin(10, "Чёрное");
                    }
                    else if (result >= 18.94736842105263 * 17 && result < 18.94736842105263 * 18)
                    {
                        resultDouble = ResultsSpins.ResultSpin(5, "Белое");
                    }
                    else if (result >= 18.94736842105263 * 18 && result < 18.94736842105263 * 19)
                    {
                        resultDouble = ResultsSpins.ResultSpin(19, "Чёрное");
                    }
                    #endregion

                    #region Проверка результатов
                    if (ResultsSpins.WhiteBet == true && ResultsSpins.WhiteBet == ResultsSpins.WhiteWin)
                    {
                        total.TotalUp(DoubleBets.TotalBetWhite * 2);
                        checkResultForDB = true;
                        profitForDB += DoubleBets.TotalBetWhite * 2;
                    }
                    if (ResultsSpins.BlackBet == true && ResultsSpins.BlackBet == ResultsSpins.BlackWin)
                    {
                        total.TotalUp(DoubleBets.TotalBetBlack * 2);
                        checkResultForDB = true;
                        profitForDB += DoubleBets.TotalBetWhite * 2;
                    }
                    if (ResultsSpins.RedBet == true && ResultsSpins.RedBet == ResultsSpins.RedWin)
                    {
                        total.TotalUp(DoubleBets.TotalBetRed * 14);
                        checkResultForDB = true;
                        profitForDB += DoubleBets.TotalBetWhite * 14;
                    }
                    if (ResultsSpins.EvenBet == true && ResultsSpins.EvenBet == ResultsSpins.EvenWin)
                    {
                        total.TotalUp(DoubleBets.TotalBetEven * 2);
                        checkResultForDB = true;
                        profitForDB += DoubleBets.TotalBetWhite * 2;
                    }
                    if (ResultsSpins.NotEvenBet == true && ResultsSpins.NotEvenBet == ResultsSpins.NotEvenWin)
                    {
                        total.TotalUp(DoubleBets.TotalBetNotEven * 2);
                        checkResultForDB = true;
                        profitForDB += DoubleBets.TotalBetWhite * 2;
                    }
                    if (ResultsSpins.LowRangeBet == true && ResultsSpins.LowRangeBet == ResultsSpins.LowRangeWin)
                    {
                        total.TotalUp(DoubleBets.TotalBetLowRange * 2);
                        checkResultForDB = true;
                        profitForDB += DoubleBets.TotalBetWhite * 2;
                    }
                    if (ResultsSpins.BigRangeBet == true && ResultsSpins.BigRangeBet == ResultsSpins.BigRangeWin)
                    {
                        total.TotalUp(DoubleBets.TotalBetBigRange * 2);
                        checkResultForDB = true;
                        profitForDB += DoubleBets.TotalBetWhite * 2;
                    }
                    #endregion

                    profitForDB = profitForDB - DoubleBets.TotalBetWhite;

                    if (checkResultForDB == true)
                        resultForDB = "Победа";
                    else
                        resultForDB = "Проигрыш";

                    Game game = new Game
                    {
                        UserId = ActiveUser.activeUser.Id,
                        UserGameId = ActiveUser.activeUser.GameQuantity,
                        Name = "Double",
                        Bet = DoubleBets.TotalBet + "$",
                        Result = resultForDB,
                        Profit = profitForDB + "$",
                        Date = DateTime.Now
                    };

                    // Добавить в DbSet
                    context.Games.Add(game);

                    // Сохранить изменения в базе данных
                    context.SaveChanges();


                    #region сброс
                    ResultsSpins.WhiteWin = false;
                    ResultsSpins.BlackWin = false;
                    ResultsSpins.RedWin = false;
                    ResultsSpins.EvenWin = false;
                    ResultsSpins.NotEvenWin = false;
                    ResultsSpins.LowRangeWin = false;
                    ResultsSpins.BigRangeWin = false;

                    ResultsSpins.WhiteBet = false;
                    ResultsSpins.BlackBet = false;
                    ResultsSpins.RedBet = false;
                    ResultsSpins.EvenBet = false;
                    ResultsSpins.NotEvenBet = false;
                    ResultsSpins.LowRangeBet = false;
                    ResultsSpins.BigRangeBet = false;

                    doubleBets.TotalBetWhiteClear();
                    doubleBets.TotalBetBlackClear();
                    doubleBets.TotalBetRedClear();
                    doubleBets.TotalBetEvenClear();
                    doubleBets.TotalBetNotEvenClear();
                    doubleBets.TotalBetLowRangeClear();
                    doubleBets.TotalBetBigRangeClear();
                    doubleBets.BetsClear();
                    doubleBets.TotalBetClear();
                    #endregion

                    InformBets = doubleBets.ToString();
                    TotalValue = total.ToString();

                    ActiveUser.activeUser.Total = Convert.ToDecimal(Total.TotalSumm);
                    ActiveUser.UpdateState(context);
                    context.SaveChanges();

                    RdyButSpin = true;      
                }
                //slot
                else if (zIndexTabs == 1)
                {
                    RdyButSpin = false;
                    provSlot = false;

                    total.TotalDown(Bet.betTotal);
                    TotalValue = total.ToString();

                    int valueRnd1 = rndMrgn.Next(1, 10);
                    int valueRnd2 = rndMrgn.Next(1, 10);
                    int valueRnd3 = rndMrgn.Next(1, 10);
                    int lossMess = lossText.Next(1, 4);

                    if(Language.checkRu == true)
                    {
                        if (lossMess == 1)
                            SlotInfoText = "ПОЕХАЛИ!";
                        if (lossMess == 2)
                            SlotInfoText = "КРУТИМ!";
                        if (lossMess == 3)
                            SlotInfoText = "УДАЧИ!";
                    }
                    else
                    {
                        if (lossMess == 1)
                            SlotInfoText = "lets go!";
                        if (lossMess == 2)
                            SlotInfoText = "spin!";
                        if (lossMess == 3)
                            SlotInfoText = "good luck!";
                    }
                    

                    #region первая полоса
                    valueRnd1 = rndMrgn.Next(1, 10);

                    if (valueRnd1 == 1)
                    {
                        Roll1To = new Thickness(0, 3244, 0, -3244);
                        Roll1FromNext = new Thickness(0, 640, 0, -640);
                    }
                    else if (valueRnd1 == 2)
                    {
                        Roll1To = new Thickness(0, 3145, 0, -3145);
                        Roll1FromNext = new Thickness(0, 544, 0, -544);
                    }
                    else if (valueRnd1 == 3)
                    {
                        Roll1To = new Thickness(0, 3050, 0, -3050);
                        Roll1FromNext = new Thickness(0, 446, 0, -446);
                    }
                    else if (valueRnd1 == 4)
                    {
                        Roll1To = new Thickness(0, 2955, 0, -2955);
                        Roll1FromNext = new Thickness(0, 352, 0, -352);
                    }
                    else if (valueRnd1 == 5)
                    {
                        Roll1To = new Thickness(0, 2856, 0, -2856);
                        Roll1FromNext = new Thickness(0, 250, 0, -250);
                    }
                    else if (valueRnd1 == 6)
                    {
                        Roll1To = new Thickness(0, 2760, 0, -2760);
                        Roll1FromNext = new Thickness(0, 158, 0, -158);
                    }
                    else if (valueRnd1 == 7)
                    {
                        Roll1To = new Thickness(0, 2665, 0, -2665);
                        Roll1FromNext = new Thickness(0, 60, 0, -60);
                    }
                    else if (valueRnd1 == 8)
                    {
                        Roll1To = new Thickness(0, 2568, 0, -2568);
                        Roll1FromNext = new Thickness(0, -34, 0, 34);
                    }
                    else if (valueRnd1 == 9)
                    {
                        Roll1To = new Thickness(0, 2473, 0, -2473);
                        Roll1FromNext = new Thickness(0, -130, 0, 130);
                    }
                    else
                        throw new Exception("что-то пошло не так");
                    #endregion

                    #region вторая полоса
                    valueRnd2 = rndMrgn.Next(1, 10);

                    if (valueRnd2 == 1)
                    {
                        Roll2To = new Thickness(0, 3244, 0, -3244);
                        Roll2FromNext = new Thickness(0, 640, 0, -640);
                    }
                    else if (valueRnd2 == 2)
                    {
                        Roll2To = new Thickness(0, 3145, 0, -3145);
                        Roll2FromNext = new Thickness(0, 544, 0, -544);
                    }
                    else if (valueRnd2 == 3)
                    {
                        Roll2To = new Thickness(0, 3050, 0, -3050);
                        Roll2FromNext = new Thickness(0, 446, 0, -446);
                    }
                    else if (valueRnd2 == 4)
                    {
                        Roll2To = new Thickness(0, 2955, 0, -2955);
                        Roll2FromNext = new Thickness(0, 352, 0, -352);
                    }
                    else if (valueRnd2 == 5)
                    {
                        Roll2To = new Thickness(0, 2856, 0, -2856);
                        Roll2FromNext = new Thickness(0, 250, 0, -250);
                    }
                    else if (valueRnd2 == 6)
                    {
                        Roll2To = new Thickness(0, 2760, 0, -2760);
                        Roll2FromNext = new Thickness(0, 158, 0, -158);
                    }
                    else if (valueRnd2 == 7)
                    {
                        Roll2To = new Thickness(0, 2665, 0, -2665);
                        Roll2FromNext = new Thickness(0, 60, 0, -60);
                    }
                    else if (valueRnd2 == 8)
                    {
                        Roll2To = new Thickness(0, 2568, 0, -2568);
                        Roll2FromNext = new Thickness(0, -34, 0, 34);
                    }
                    else if (valueRnd2 == 9)
                    {
                        Roll2To = new Thickness(0, 2473, 0, -2473);
                        Roll2FromNext = new Thickness(0, -130, 0, 130);
                    }
                    else
                        throw new Exception("что-то пошло не так");
                    #endregion

                    #region третья полоса
                    valueRnd3 = rndMrgn.Next(1, 10);

                    if (valueRnd3 == 1)
                    {
                        Roll3To = new Thickness(0, 3244, 0, -3244);
                        Roll3FromNext = new Thickness(0, 640, 0, -640);
                    }
                    else if (valueRnd3 == 2)
                    {
                        Roll3To = new Thickness(0, 3145, 0, -3145);
                        Roll3FromNext = new Thickness(0, 544, 0, -544);
                    }
                    else if (valueRnd3 == 3)
                    {
                        Roll3To = new Thickness(0, 3050, 0, -3050);
                        Roll3FromNext = new Thickness(0, 446, 0, -446);
                    }
                    else if (valueRnd3 == 4)
                    {
                        Roll3To = new Thickness(0, 2955, 0, -2955);
                        Roll3FromNext = new Thickness(0, 352, 0, -352);
                    }
                    else if (valueRnd3 == 5)
                    {
                        Roll3To = new Thickness(0, 2856, 0, -2856);
                        Roll3FromNext = new Thickness(0, 250, 0, -250);
                    }
                    else if (valueRnd3 == 6)
                    {
                        Roll3To = new Thickness(0, 2760, 0, -2760);
                        Roll3FromNext = new Thickness(0, 158, 0, -158);
                    }
                    else if (valueRnd3 == 7)
                    {
                        Roll3To = new Thickness(0, 2665, 0, -2665);
                        Roll3FromNext = new Thickness(0, 60, 0, -60);
                    }
                    else if (valueRnd3 == 8)
                    {
                        Roll3To = new Thickness(0, 2568, 0, -2568);
                        Roll3FromNext = new Thickness(0, -34, 0, 34);
                    }
                    else if (valueRnd3 == 9)
                    {
                        Roll3To = new Thickness(0, 2473, 0, -2473);
                        Roll3FromNext = new Thickness(0, -130, 0, 130);
                    }
                    else
                        throw new Exception("что-то пошло не так");
                    #endregion

                    #region Описние анимаций
                    ThicknessAnimation roll1 = new ThicknessAnimation();
                    roll1.From = Roll1From;
                    roll1.To = Roll1To;
                    if (IsChecked3 == false)
                    {
                        roll1.Duration = TimeSpan.FromSeconds(1);
                        easingFunction.EasingMode = EasingMode.EaseInOut;
                        roll1.EasingFunction = easingFunction;
                    }
                    else
                    {
                        roll1.Duration = TimeSpan.FromSeconds(0);
                    }



                    ThicknessAnimation roll2 = new ThicknessAnimation();
                    roll2.From = Roll2From;
                    roll2.To = Roll2To;
                    if (IsChecked3 == false)
                    {
                        roll2.Duration = TimeSpan.FromSeconds(1);
                        easingFunction.EasingMode = EasingMode.EaseInOut;
                        roll2.EasingFunction = easingFunction;
                    }
                    else
                    {
                        roll2.Duration = TimeSpan.FromSeconds(0);
                    }

                    ThicknessAnimation roll3 = new ThicknessAnimation();
                    roll3.From = Roll3From;
                    roll3.To = Roll3To;
                    if (IsChecked3 == false)
                    {
                        roll3.Duration = TimeSpan.FromSeconds(1);
                        easingFunction.EasingMode = EasingMode.EaseInOut;
                        roll3.EasingFunction = easingFunction;
                    }
                    else
                    {
                        roll3.Duration = TimeSpan.FromSeconds(0);
                    }
                    #endregion

                    #region Запуск анимаций
                    var item = tab.Items.GetItemAt(1) as TabItem;
                    var grid = item.Content as Grid;


                    foreach (var i in grid.Children)
                    {
                        var viewbox = i as Viewbox;
                        if (viewbox != null)
                        {
                            if (viewbox.Name == "ViewRoll1")
                            {
                                var img = viewbox.Child as Image;
                                if (img != null && img.Name == "ImgRoll1")
                                {
                                    Storyboard strbrd = new Storyboard();
                                    Storyboard.SetTargetName(roll1, img.Name);
                                    Storyboard.SetTargetProperty(roll1, new PropertyPath("Margin"));
                                    strbrd.Children.Add(roll1);
                                    strbrd.Begin(img);
                                }
                            }

                            if (viewbox.Name == "ViewRoll2")
                            {
                                var img = viewbox.Child as Image;
                                if (img != null && img.Name == "ImgRoll2")
                                {
                                    Storyboard strbrd = new Storyboard();
                                    Storyboard.SetTargetName(roll2, img.Name);
                                    Storyboard.SetTargetProperty(roll2, new PropertyPath("Margin"));
                                    strbrd.Children.Add(roll2);
                                    if (IsChecked2 == false)
                                    {
                                        await Task.Delay(1000);

                                    }

                                    strbrd.Begin(img);
                                }
                            }

                            if (viewbox.Name == "ViewRoll3")
                            {
                                var img = viewbox.Child as Image;
                                if (img != null && img.Name == "ImgRoll3")
                                {
                                    Storyboard strbrd = new Storyboard();
                                    Storyboard.SetTargetName(roll3, img.Name);
                                    Storyboard.SetTargetProperty(roll3, new PropertyPath("Margin"));
                                    strbrd.Children.Add(roll3);
                                    if (IsChecked2 == false)
                                    {
                                        await Task.Delay(1000);
                                    }

                                    strbrd.Begin(img);
                                }
                            }
                        }
                    }
                    #endregion

                    Roll1From = Roll1FromNext;
                    Roll2From = Roll2FromNext;
                    Roll3From = Roll3FromNext;

                    await Task.Delay(1000);

                    #region подсчёт результата
                    int[] resultSlot = new int[3] { valueRnd1, valueRnd2, valueRnd3 };

                    if (resultSlot[0] == resultSlot[1] && resultSlot[0] == resultSlot[2])
                    {
                        total.TotalUp(Bet.betTotal * 100);
                        profitForDB += Bet.betTotal * 100;
                        checkResultForDB = true;
                        TotalValue = total.ToString();

                        if (Language.checkRu == true)
                        {
                            if (lossMess == 1)
                                SlotInfoText = "ДЖЕКПОТ!!!";
                            if (lossMess == 2)
                                SlotInfoText = "НЕВЕРОЯТНО!";
                            if (lossMess == 3)
                                SlotInfoText = "ЭТО ПОБЕДА!";
                        }
                        else
                        {
                            if (lossMess == 1)
                                SlotInfoText = "JACKPOT!!!";
                            if (lossMess == 2)
                                SlotInfoText = "INCREDIBLE!";
                            if (lossMess == 3)
                                SlotInfoText = "victory!";

                        }
                    }
                    else if (resultSlot[0] == resultSlot[1] || resultSlot[1] == resultSlot[2] || resultSlot[0] == resultSlot[2])
                    {
                        total.TotalUp(Bet.betTotal * 1.5);
                        profitForDB += Bet.betTotal * 1.5;
                        checkResultForDB = true;
                        TotalValue = total.ToString();

                        if (Language.checkRu == true)
                        {
                            if (lossMess == 1)
                                SlotInfoText = "ПРОБИТИЕ!!!";
                            if (lossMess == 2)
                                SlotInfoText = "ХОТЬ ЧТО-ТО!";
                            if (lossMess == 3)
                                SlotInfoText = "ЭТО МНЕ?!";
                        }
                        else
                        {
                            if (lossMess == 1)
                                SlotInfoText = "penetration!!!";
                            if (lossMess == 2)
                                SlotInfoText = "something!";
                            if (lossMess == 3)
                                SlotInfoText = "damn!!!";
                        }
                    }
                    else
                    {
                        if (Language.checkRu == true)
                        {
                            checkResultForDB = false;
                            if (lossMess == 1)
                                SlotInfoText = "ЛУЗЕР!!!";
                            if (lossMess == 2)
                                SlotInfoText = "М-ДА :(";
                            if (lossMess == 3)
                                SlotInfoText = "ХА-ХА-ХА!";
                        }
                        else
                        {
                            checkResultForDB = false;
                            if (lossMess == 1)
                                SlotInfoText = "LOSER!!!";
                            if (lossMess == 2)
                                SlotInfoText = "try again!";
                            if (lossMess == 3)
                                SlotInfoText = "HA-HA-HA!";
                        }
                    }
                    #endregion


                    profitForDB = profitForDB - Bet.betTotal;

                    if (checkResultForDB == true)
                        resultForDB = "Победа";
                    else
                        resultForDB = "Проигрыш";

                    Game game = new Game
                    {
                        UserId = ActiveUser.activeUser.Id,
                        UserGameId = ActiveUser.activeUser.GameQuantity,
                        Name = "Slot",
                        Bet = Bet.betTotal + "$",
                        Result = resultForDB,
                        Profit = profitForDB + "$",
                        Date = DateTime.Now
                    };

                    // Добавить в DbSet
                    context.Games.Add(game);

                    // Сохранить изменения в базе данных
                    context.SaveChanges();

                    if (IsChecked1 == true && Bet.betTotal <= Total.TotalSumm)
                    {
                        if (IsChecked4 == true)
                            await Task.Delay(1);
                        else
                            await Task.Delay(1000);
                        goto qwe;
                    }

                    provSlot = true;
                    RdyButSpin = true;
                }
                //mines
                else if (zIndexTabs == 2)
                {
                    MinesUrWin = "0$";
                    total.TotalDown(Bet.betTotal);
                    TotalValue = total.ToString();

                    #region рандомайзер
                    rndMssMns1.RandMass();
                    rndMssMns2.RandMass();
                    rndMssMns3.RandMass();
                    rndMssMns4.RandMass();
                    rndMssMns5.RandMass();

                    for (int a = 0; a < 3; a++)
                    {
                        elemNumber1[a] = rndMssMns1.elemMass[a];
                    }
                    for (int a = 0; a < 3; a++)
                    {
                        elemNumber2[a] = rndMssMns2.elemMass[a];
                    }
                    for (int a = 0; a < 3; a++)
                    {
                        elemNumber3[a] = rndMssMns3.elemMass[a];
                    }
                    for (int a = 0; a < 3; a++)
                    {
                        elemNumber4[a] = rndMssMns4.elemMass[a];
                    }
                    for (int a = 0; a < 3; a++)
                    {
                        elemNumber5[a] = rndMssMns5.elemMass[a];
                    }
                    #endregion

                    RdyButSpin = false;
                    IsCheckedMinesEnabled = false;

                    MinesBut11IsEnabled = true;
                    MinesBut22IsEnabled = false;
                    MinesBut33IsEnabled = false;
                    MinesBut44IsEnabled = false;
                    MinesBut55IsEnabled = false;

                    MinesBut11Text = "";
                    MinesBut11Pick = 1;
                    MinesBut11Bimb = 0;
                    MinesBut11Back = new SolidColorBrush(Color.FromArgb(100, 255, 255, 255));

                    MinesBut12Text = "";
                    MinesBut12Pick = 1;
                    MinesBut12Bimb = 0;
                    MinesBut12Back = new SolidColorBrush(Color.FromArgb(100, 255, 255, 255));

                    MinesBut13Text = "";
                    MinesBut13Pick = 1;
                    MinesBut13Bimb = 0;
                    MinesBut13Back = new SolidColorBrush(Color.FromArgb(100, 255, 255, 255));

                    MinesBut21Text = "";
                    MinesBut21Pick = 0;
                    MinesBut21Bimb = 0;
                    MinesBut21Back = new SolidColorBrush(Color.FromArgb(100, 255, 255, 255));

                    MinesBut22Text = "";
                    MinesBut22Pick = 0;
                    MinesBut22Bimb = 0;
                    MinesBut22Back = new SolidColorBrush(Color.FromArgb(100, 255, 255, 255));

                    MinesBut23Text = "";
                    MinesBut23Pick = 0;
                    MinesBut23Bimb = 0;
                    MinesBut23Back = new SolidColorBrush(Color.FromArgb(100, 255, 255, 255));

                    MinesBut31Text = "";
                    MinesBut31Pick = 0;
                    MinesBut31Bimb = 0;
                    MinesBut31Back = new SolidColorBrush(Color.FromArgb(100, 255, 255, 255));

                    MinesBut32Text = "";
                    MinesBut32Pick = 0;
                    MinesBut32Bimb = 0;
                    MinesBut32Back = new SolidColorBrush(Color.FromArgb(100, 255, 255, 255));

                    MinesBut33Text = "";
                    MinesBut33Pick = 0;
                    MinesBut33Bimb = 0;
                    MinesBut33Back = new SolidColorBrush(Color.FromArgb(100, 255, 255, 255));

                    MinesBut41Text = "";
                    MinesBut41Pick = 0;
                    MinesBut41Bimb = 0;
                    MinesBut41Back = new SolidColorBrush(Color.FromArgb(100, 255, 255, 255));

                    MinesBut42Text = "";
                    MinesBut42Pick = 0;
                    MinesBut42Bimb = 0;
                    MinesBut42Back = new SolidColorBrush(Color.FromArgb(100, 255, 255, 255));

                    MinesBut43Text = "";
                    MinesBut43Pick = 0;
                    MinesBut43Bimb = 0;
                    MinesBut43Back = new SolidColorBrush(Color.FromArgb(100, 255, 255, 255));

                    MinesBut51Text = "";
                    MinesBut51Pick = 0;
                    MinesBut51Bimb = 0;
                    MinesBut51Back = new SolidColorBrush(Color.FromArgb(100, 255, 255, 255));

                    MinesBut52Text = "";
                    MinesBut52Pick = 0;
                    MinesBut52Bimb = 0;
                    MinesBut52Back = new SolidColorBrush(Color.FromArgb(100, 255, 255, 255));

                    MinesBut53Text = "";
                    MinesBut53Pick = 0;
                    MinesBut53Bimb = 0;
                    MinesBut53Back = new SolidColorBrush(Color.FromArgb(100, 255, 255, 255));

                }
                //nine
                else if (zIndexTabs == 3)
                {
                    total.TotalDown(Bet.betTotal);
                    TotalValue = total.ToString();

                    NineBut1Pick = 1;
                    NineBut2Pick = 1;
                    NineBut3Pick = 1;
                    NineBut4Pick = 1;
                    NineBut5Pick = 1;
                    NineBut6Pick = 1;
                    NineBut7Pick = 1;
                    NineBut8Pick = 1;
                    NineBut9Pick = 1;

                    #region выключение старых кнопок
                    NineBut1Opacity = 0;
                    NineBut1Back = new SolidColorBrush(Color.FromArgb(100, 255, 255, 255));

                    NineBut2Opacity = 0;
                    NineBut2Back = new SolidColorBrush(Color.FromArgb(100, 255, 255, 255));

                    NineBut3Opacity = 0;
                    NineBut3Back = new SolidColorBrush(Color.FromArgb(100, 255, 255, 255));

                    NineBut4Opacity = 0;
                    NineBut4Back = new SolidColorBrush(Color.FromArgb(100, 255, 255, 255));

                    NineBut5Opacity = 0;
                    NineBut5Back = new SolidColorBrush(Color.FromArgb(100, 255, 255, 255));

                    NineBut6Opacity = 0;
                    NineBut6Back = new SolidColorBrush(Color.FromArgb(100, 255, 255, 255));

                    NineBut7Opacity = 0;
                    NineBut7Back = new SolidColorBrush(Color.FromArgb(100, 255, 255, 255));

                    NineBut8Opacity = 0;
                    NineBut8Back = new SolidColorBrush(Color.FromArgb(100, 255, 255, 255));

                    NineBut9Opacity = 0;
                    NineBut9Back = new SolidColorBrush(Color.FromArgb(100, 255, 255, 255)); 
                    #endregion

                    #region вычисления для заполнения
                    int nineHelp = 0;
                    do
                    {
                        xNineHelp[0] = xNineRandom.Next(1, 15);
                        xNineHelp[1] = xNineRandom.Next(1, 15);
                        xNineHelp[2] = xNineRandom.Next(1, 15);

                        if (xNineHelp[1] == xNineHelp[0])
                            xNineHelp[1] = xNineRandom.Next(1, 15);
                        else if (xNineHelp[2] == xNineHelp[1] || xNineHelp[2] == xNineHelp[0])
                            xNineHelp[2] = xNineRandom.Next(1, 15);
                        else
                            nineHelp++;
                    }
                    while (nineHelp != 3);

                    for (int ninei = 0; ninei < xNineAll.Length; ninei++)
                    {
                        if (xNineHelp[0] == ninei)
                            xNine1 = xNineAll[ninei];

                        if (xNineHelp[1] == ninei)
                            xNine2 = xNineAll[ninei];

                        if (xNineHelp[2] == ninei)
                            xNine3 = xNineAll[ninei];
                    }

                    string[] xNineStart = new string[9] { xNine1, xNine1, xNine1, xNine2, xNine2, xNine2, xNine3, xNine3, xNine3 };

                    for (int ninei = xNineStart.Length - 1; ninei >= 1; ninei--)
                    {
                        int j = xNineRandom.Next(ninei + 1);
                        // обменять значения data[j] и data[i]
                        var temp = xNineStart[j];
                        xNineStart[j] = xNineStart[ninei];
                        xNineStart[ninei] = temp;
                    }

                    NineBut1Text = xNineStart[0];
                    NineBut2Text = xNineStart[1];
                    NineBut3Text = xNineStart[2];
                    NineBut4Text = xNineStart[3];
                    NineBut5Text = xNineStart[4];
                    NineBut6Text = xNineStart[5];
                    NineBut7Text = xNineStart[6];
                    NineBut8Text = xNineStart[7];
                    NineBut9Text = xNineStart[8];
                    #endregion

                    XWin0025 = 0;
                    XWin005 = 0;
                    XWin01 = 0;
                    XWin015 = 0;
                    XWin02 = 0;
                    XWin03 = 0;
                    XWin04 = 0;
                    XWin05 = 0;
                    XWin06 = 0;
                    XWin07 = 0;
                    XWin10 = 0;
                    XWin15 = 0;
                    XWin20 = 0;
                    XWin50 = 0;
                    XWin100 = 0;

                    xNineWinBet = 0;


                    NineBut1IsEnabled = true;
                    NineBut2IsEnabled = true;
                    NineBut3IsEnabled = true;
                    NineBut4IsEnabled = true;
                    NineBut5IsEnabled = true;
                    NineBut6IsEnabled = true;
                    NineBut7IsEnabled = true;
                    NineBut8IsEnabled = true;
                    NineBut9IsEnabled = true;

                    WinState = false;
                    RdyButSpin = false;
                    NineButCheckedIsEnabled = false;

                    if (IsCheckedNine == true)
                        NineChances = 5;
                    else
                        NineChances = 4;

                }

                ActiveUser.activeUser.Total = Convert.ToDecimal(Total.TotalSumm);
                ActiveUser.UpdateState(context);
                context.SaveChanges();
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        #endregion

        //-----------------------

 

        public MainWindowViewModel()
        {
            #region Команды
            Spin = new LambdaCommand(OnSpinExecuted, CanSpinExecuted);
            BetUpCommand = new LambdaCommand(OnBetUpExecuted, CanBetUpExecuted);
            BetDownCommand = new LambdaCommand(OnBetDownExecuted, CanBetDownExecuted);
            OpenBetCommand = new LambdaCommand(OnOpenBetCommandExecuted, CanOpenBetCommandExecute);
            OpenDepositCommand = new LambdaCommand(OnOpenDepositCommandExecuted, CanOpenDepositCommandExecute);
            OpenConclusionCommand = new LambdaCommand(OnOpenConclusionCommandExecuted, CanOpenConclusionCommandExecute);

            OpenAccountCommand = new LambdaCommand(OnOpenAccountCommandExecuted, CanOpenAccountCommandExecute);

            HelpCommand = new LambdaCommand(OnHelpCommandExecuted, CanHelpCommandExecuted);
            HelpGamesCommand = new LambdaCommand(OnHelpGamesCommandExecuted, CanHelpGamesCommandExecuted);
            ChangeLanguageCommand = new LambdaCommand(OnChangeLanguageCommandExecuted, CanChangeLanguageCommandExecuted);

            OpenMenuCommand = new LambdaCommand(OnOpenMenuCommandExecuted, CanOpenMenuCommandExecuted);
            ExitAccountCommand = new LambdaCommand(OnExitAccountCommandExecuted, CanExitAccountCommandExecuted);

            #region double
            WhiteBetCommand = new LambdaCommand(OnWhiteBetCommandExecuted, CanWhiteBetCommandExecuted);
            BlackBetCommand = new LambdaCommand(OnBlackBetCommandExecuted, CanBlackBetCommandExecuted);
            RedBetCommand = new LambdaCommand(OnRedBetCommandExecuted, CanRedBetCommandExecuted);
            EvenBetCommand = new LambdaCommand(OnEvenBetCommandExecuted, CanEvenBetCommandExecuted);
            NotEvenBetCommand = new LambdaCommand(OnNotEvenBetCommandExecuted, CanNotEvenBetCommandExecuted);
            LowRangeBetCommand = new LambdaCommand(OnLowRangeBetCommandExecuted, CanLowRangeBetCommandExecuted);
            BigRangeBetCommand = new LambdaCommand(OnBigRangeBetCommandExecuted, CanBigRangeBetCommandExecuted);
            ClearBetCommand = new LambdaCommand(OnClearBetCommandExecuted, CanClearBetCommandExecuted);
            #endregion

            #region mines
            MinesBut11Command = new LambdaCommand(OnMinesBut11CommandExecuted, CanMinesBut11CommandExecuted);
            MinesBut12Command = new LambdaCommand(OnMinesBut12CommandExecuted, CanMinesBut12CommandExecuted);
            MinesBut13Command = new LambdaCommand(OnMinesBut13CommandExecuted, CanMinesBut13CommandExecuted);

            MinesBut21Command = new LambdaCommand(OnMinesBut21CommandExecuted, CanMinesBut21CommandExecuted);
            MinesBut22Command = new LambdaCommand(OnMinesBut22CommandExecuted, CanMinesBut22CommandExecuted);
            MinesBut23Command = new LambdaCommand(OnMinesBut23CommandExecuted, CanMinesBut23CommandExecuted);

            MinesBut31Command = new LambdaCommand(OnMinesBut31CommandExecuted, CanMinesBut31CommandExecuted);
            MinesBut32Command = new LambdaCommand(OnMinesBut32CommandExecuted, CanMinesBut32CommandExecuted);
            MinesBut33Command = new LambdaCommand(OnMinesBut33CommandExecuted, CanMinesBut33CommandExecuted);

            MinesBut41Command = new LambdaCommand(OnMinesBut41CommandExecuted, CanMinesBut41CommandExecuted);
            MinesBut42Command = new LambdaCommand(OnMinesBut42CommandExecuted, CanMinesBut42CommandExecuted);
            MinesBut43Command = new LambdaCommand(OnMinesBut43CommandExecuted, CanMinesBut43CommandExecuted);

            MinesBut51Command = new LambdaCommand(OnMinesBut51CommandExecuted, CanMinesBut51CommandExecuted);
            MinesBut52Command = new LambdaCommand(OnMinesBut52CommandExecuted, CanMinesBut52CommandExecuted);
            MinesBut53Command = new LambdaCommand(OnMinesBut53CommandExecuted, CanMinesBut53CommandExecuted);

            MinesButClearCommand = new LambdaCommand(OnMinesButClearCommandExecuted, CanMinesButClearCommandExecuted);

            #endregion

            #region nine
            IsCheckedNineCommand = new LambdaCommand(OnIsCheckedNineCommandExecuted, CanIsCheckedNineCommandExecuted);

            NineBut1Command = new LambdaCommand(OnNineBut1CommandExecuted, CanNineBut1CommandExecuted);
            NineBut2Command = new LambdaCommand(OnNineBut2CommandExecuted, CanNineBut2CommandExecuted);
            NineBut3Command = new LambdaCommand(OnNineBut3CommandExecuted, CanNineBut3CommandExecuted);
            NineBut4Command = new LambdaCommand(OnNineBut4CommandExecuted, CanNineBut4CommandExecuted);
            NineBut5Command = new LambdaCommand(OnNineBut5CommandExecuted, CanNineBut5CommandExecuted);
            NineBut6Command = new LambdaCommand(OnNineBut6CommandExecuted, CanNineBut6CommandExecuted);
            NineBut7Command = new LambdaCommand(OnNineBut7CommandExecuted, CanNineBut7CommandExecuted);
            NineBut8Command = new LambdaCommand(OnNineBut8CommandExecuted, CanNineBut8CommandExecuted);
            NineBut9Command = new LambdaCommand(OnNineBut9CommandExecuted, CanNineBut9CommandExecuted);
            #endregion

            #endregion
        }
    }
}
