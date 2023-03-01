using BetClass;
using BLACKWHITECASINO.Data;
using BLACKWHITECASINO.Infrastructure.Commands;
using BLACKWHITECASINO.Models;
using BLACKWHITECASINO.ViewModels.Base;
using BLACKWHITECASINO.Views.Windows;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TotalClass;

namespace BLACKWHITECASINO.ViewModels
{
    internal class ChangePasswordViewModel : ViewModel
    {
        private void ValidateProperty<T>(T value, string name)
        {
            Validator.ValidateProperty(value, new ValidationContext(this, null, null)
            {
                MemberName = name
            });
        }

        #region ChangeText
        private string _ChangeText;

        [Required(ErrorMessage = "Поле не должно быть пустым!")]
        [StringLength(20, MinimumLength = 8, ErrorMessage = "Минимум 8 и максимум 20 символов!")]
        [RegularExpression(@"(?=^.{8,}$)((?=.*\d)|(?=.*\W+))(?![.\n])(?=.*[A-Z])(?=.*[a-z]).*$", ErrorMessage = "Пароль должен содержать a-z, A-Z, 0-9")]
        public string ChangeText
        {
            get
            {
                return _ChangeText;
            }
            set
            {
                ValidateProperty(value, "ChangeText");
                Set(ref _ChangeText, value);
            }
        }
        #endregion

        #region ChangeText
        private string _codeText;

        public string codeText
        {
            get
            {
                return _codeText;
            }
            set
            {
                Set(ref _codeText, value);
            }
        }
        #endregion

        #region CloseApplicationCommand
        public ICommand CloseApplicationCommand { get; }

        private bool CanCloseApplicationCommandExecuted(object p) => true;

        private void OnCloseApplicationCommandExecuted(object p)
        {
            Window logWin = new LoginWindow();
            lWindowVW.ChangePasswordWindow.Close();
            logWin.Show();
        }
        #endregion

        #region AcceptApplicationCommand
        public ICommand AcceptApplicationCommand { get; }

        private bool CanAcceptApplicationCommandExecuted(object p) => true;

        private void OnAcceptApplicationCommandExecuted(object p)
        {
            try
            {
                BLACK_WHITE_CASINOContext context = new BLACK_WHITE_CASINOContext();

                if (codeText == lWindowVW.Code)
                {
                    if (codeText == null || ChangeText == null)
                    {
                        if (Language.checkRu == true)
                            throw new Exception("Введите все значения!");
                        else
                            throw new Exception("Enter all values!");

                    }
                    var hashP = HashPassword.Hash(ChangeText);

                    lWindowVW.thisUser.Password = hashP;

                    Window logWin1 = new LoginWindow();
                    context.Entry(lWindowVW.thisUser).State = EntityState.Modified;
                    context.SaveChanges();
                    lWindowVW.ChangePasswordWindow.Close();
                    logWin1.Show();
                }
                else
                {
                    if (Language.checkRu == true)
                    {
                        MessageBox.Show("Код не верный!");
                    }
                    else
                        MessageBox.Show("Wrong code!");
                }
                    
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        #endregion

        private LoginWindowViewModel lWindowVW;

        public ChangePasswordViewModel(LoginWindowViewModel lWindowVW)
        {
            this.lWindowVW = lWindowVW;
            #region Команды
            AcceptApplicationCommand = new LambdaCommand(OnAcceptApplicationCommandExecuted, CanAcceptApplicationCommandExecuted);
            CloseApplicationCommand = new LambdaCommand(OnCloseApplicationCommandExecuted, CanCloseApplicationCommandExecuted);
            #endregion
        }

    }
}
