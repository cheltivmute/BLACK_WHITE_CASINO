using BetClass;
using BLACKWHITECASINO.Data;
using BLACKWHITECASINO.Infrastructure.Commands;
using BLACKWHITECASINO.Models;
using BLACKWHITECASINO.ViewModels.Base;
using BLACKWHITECASINO.Views.Windows;
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
    internal class ForgotPasswordViewModel : ViewModel
    {
        Random rndCode = new Random();

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
        [StringLength(25, MinimumLength = 5, ErrorMessage = "Минимум 5 и максимум 25 символов!")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Формат для почты xxx@xxx.xxx")]
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

        #region CloseApplicationCommand
        public ICommand CloseApplicationCommand { get; }

        private bool CanCloseApplicationCommandExecuted(object p) => true;

        private void OnCloseApplicationCommandExecuted(object p)
        {
            Window logWin = new LoginWindow();
            lWindowVW.ForgotPasswordWindow.Close();
            logWin.Show();
        }
        #endregion

        #region AcceptApplicationCommand
        public ICommand AcceptApplicationCommand { get; }

        private bool CanAcceptApplicationCommandExecuted(object p) => true;

        private async void OnAcceptApplicationCommandExecuted(object p)
        {
            try
            {
                BLACK_WHITE_CASINOContext context = new BLACK_WHITE_CASINOContext();

                var provLog = context.Users.Where(u => u.Email == ChangeText).FirstOrDefault();
                if (provLog == null)
                {
                    if(Language.checkRu == true)
                        throw new Exception("Аккаунта с такой почтой не существует!");
                    else
                        throw new Exception("Account with this email does not exist!");

                }
                lWindowVW.Code = Convert.ToString(rndCode.Next(1, 9)) + Convert.ToString(rndCode.Next(1, 9)) + Convert.ToString(rndCode.Next(1, 9)) + Convert.ToString(rndCode.Next(1, 9));

                MailAddress fromAdress = new MailAddress("shasha161280@gmail.com", "BLACK-WHITE CASINO ВОССТАНОВЛЕНИЕ ПАРОЛЯ");
                MailAddress toAdress = new MailAddress(provLog.Email);
                MailMessage message = new MailMessage(fromAdress, toAdress);

                message.Body = $"Здравствуйте, {provLog.Login}.\n" +
                $"На Ваш Email поступил запрос на восстановление пароля к учётной записи.\n" +
                $"Мы Вам отправили код подтверждения.\n\n\n" +
                $"Код: {lWindowVW.Code}\n" +
                $"С уважением, администрация BLACK-WHITE CASINO";
                message.Subject = "Восстановление доступа к учётной записи";

                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.Credentials = new NetworkCredential("shasha161280@gmail.com", "rqpkzfsgkpglpsqd");
                smtp.EnableSsl = true;
                smtp.Send(message);
                await smtp.SendMailAsync(message);
                MessageBox.Show("Письмо отправлено на вашу почту!");

                lWindowVW.thisUser = provLog;

                lWindowVW.ChangePasswordWindow = new ChangePasswordWindow();
                lWindowVW.ChangePasswordWindow.DataContext = new ChangePasswordViewModel(lWindowVW);
                lWindowVW.ForgotPasswordWindow.Close();
                lWindowVW.ChangePasswordWindow.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
        #endregion

        private LoginWindowViewModel lWindowVW;

        public ForgotPasswordViewModel(LoginWindowViewModel lWindowVW)
        {
            this.lWindowVW = lWindowVW;
            #region Команды
            AcceptApplicationCommand = new LambdaCommand(OnAcceptApplicationCommandExecuted, CanAcceptApplicationCommandExecuted);
            CloseApplicationCommand = new LambdaCommand(OnCloseApplicationCommandExecuted, CanCloseApplicationCommandExecuted);
            #endregion
        }

    }
}
