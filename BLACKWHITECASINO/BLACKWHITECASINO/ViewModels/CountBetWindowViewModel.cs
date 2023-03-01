using BetClass;
using BLACKWHITECASINO.Infrastructure.Commands;
using BLACKWHITECASINO.Models;
using BLACKWHITECASINO.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TotalClass;

namespace BLACKWHITECASINO.ViewModels
{
    internal class CountBetWindowViewModel : ViewModel
    {

        #region Значение
        private int _CountBetValue = 99999;

        public int CountBetValue
        {
            get => _CountBetValue;
            set
            {
                Set(ref _CountBetValue, value);
            }
        }
        #endregion

        #region CloseApplicationCommand
        public ICommand CloseApplicationCommand { get; }

        private bool CanCloseApplicationCommandExecuted(object p) => true;

        private void OnCloseApplicationCommandExecuted(object p)
        {
            mWindowVW.CloseBetWindow();
        }
        #endregion

        #region AcceptApplicationCommand
        public ICommand AcceptApplicationCommand { get; }

        private bool CanAcceptApplicationCommandExecuted(object p) => true;

        private void OnAcceptApplicationCommandExecuted(object p)
        {
            try
            {
                if (CountBetValue <= 0 || CountBetValue > 99999)
                    throw new Exception("Значение должно быть больше 0 и меньше 99999!");

                Bet.betTotal = CountBetValue;
                mWindowVW.BetValue = Bet.betTotal;
                mWindowVW.SlotInfoBetText = Bet.betTotal + "$";
                mWindowVW.SlotInfoBetTextJackpot = Bet.betTotal * 1000 + "$";
                if (mWindowVW.IsCheckedMines == true)
                {
                    mWindowVW.MinesMbWin = Bet.betTotal * 5 + "$";
                }
                else
                {
                    mWindowVW.MinesMbWin = Bet.betTotal * 100 + "$";
                }
                mWindowVW.NineMbWin = Bet.betTotal * 100 + "$";
                mWindowVW.CloseBetWindow();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
        #endregion

        private MainWindowViewModel mWindowVW;

        public CountBetWindowViewModel(MainWindowViewModel mWindowVW)
        {
            this.mWindowVW = mWindowVW;
            #region Команды
            AcceptApplicationCommand = new LambdaCommand(OnAcceptApplicationCommandExecuted, CanAcceptApplicationCommandExecuted);
            CloseApplicationCommand = new LambdaCommand(OnCloseApplicationCommandExecuted, CanCloseApplicationCommandExecuted);
            #endregion
        }

    }
}
