   M S B A M L   `   `   `  ????K  GBLACKWHITECASINO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:BLACKWHITECASINO.ViewModelsBLACKWHITECASINO.ViewModels  5   	   O,clr-namespace:BLACKWHITECASINO.Views.WindowsBLACKWHITECASINO.Views.Windows  5   	   3    -BLACKWHITECASINO.Views.Windows.RegisterWindow   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   8vm)clr-namespace:BLACKWHITECASINO.ViewModels     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   >local,clr-namespace:BLACKWHITECASINO.Views.Windows     5   	      
LoginTitle  ? Title#  ?   5
   	   $	??800??6.   $	??400??6;    ? 
ResizeMode$ NoResize=?6G    ? WindowStartupLocation$ CenterScreen=?6]    ? DataContext 5      6  0BLACKWHITECASINO.ViewModels.LoginWindowViewModel  5   
   .??5      ?  ? ColumnDefinitions 5   
   ?? 5      6!   ?? 5      6!    ? RowDefinitions 5   
   ?? 5      $
??1.5* ?6   6,   ?? 5      6   ?? 5      6   ?? 5      6   ?? 5      6   ?? 5      6   ?? 5      6   .+?5   
   ?? $??2??6   $??Center=?6$   $??Center=?6A   $
??Aqum)?6\   $??40(?6n     RegLabel#???  6|   6?   ?? 5!   
   $??1??6   $??2??6   $
??Aqum)?61   $??20(?6C   $??10,0,0,0q?6Q     RegLogin#???  6c   6?   ?? 5"   
   -   5         ??Name$ loginReg??5"      $??1??6$   $??2??61   $??10,30,10,20q?6E   
???   ?$??5q?6n   $??Center=?6?   $??Arial Rounded MT Bold)?6?   $??20(?6?   ??6?   ?? *UserLoginReg+ ?? ValidatesOnExceptions$
 True?? ?? UpdateSourceTrigger$ PropertyChanged=?66  ?? 5#   
   $??1??6   $??2??6!   $
??Aqum)?65   $??10(?6G   $??	10,0,10,5q?6U   $??Bottom=?6h   ???	#FFDC5454??6?   ?? *%#(Validation.Errors)[0].ErrorContent+	 ?? ElementName$	 loginReg??6?   ?? 5%   
   $??2??6   $??2??6   $
??Aqum)?61   $??20(?6C   $??10,0,0,0q?6Q     RegEmail#???  6c   6?   ?? 5&   
   -   5        $ emailReg??5&      $??2??6$   $??2??61   $??10,30,10,20q?6E   
???   ?$??5q?6n   $??Center=?6?   $??Arial Rounded MT Bold)?6?   $??20(?6?   ??6?   ?? *UserMailReg+$
 True??$ PropertyChanged=?65  ?? 5'   
   $??2??6   $??2??6!   $
??Aqum)?65   $??10(?6G   $??	10,0,10,5q?6U   $??Bottom=?6h   ???	#FFDC5454??6?   ?? *%#(Validation.Errors)[0].ErrorContent+$	 emailReg??6?   ?? 5)   
   $??3??6   $??2??6   $
??Aqum)?61   $??20(?6C   $??10,0,0,0q?6Q     RegPassword#???  6c   6?   ?? 5*   
   -   5        $ passwordReg??5*      $??3??6'   $??2??64   $??10,30,10,20q?6H   
???   ?$??5q?6q   $??Center=?6?   $??Arial Rounded MT Bold)?6?   $??20(?6?   ??6?   ?? *UserPasswordReg+$
 True??$ PropertyChanged=?6=  ?? 5+   
   $??3??6   $??2??6!   $
??Aqum)?65   $??10(?6G   $??	10,0,10,5q?6U   $??Bottom=?6h   ???	#FFDC5454??6?   ?? *%#(Validation.Errors)[0].ErrorContent+$	 passwordReg??6?   ?? 5-   
   $??4??6   $??2??6   $
??Aqum)?61   $??20(?6C   $??10,0,0,0q?6Q     	RegMobile#???  6c   6?   ?? 5.   
   -   5        $ 	mobileReg??5.      $??4??6%   $??2??62   $??10,30,10,20q?6F   
???   ?$??5q?6o   $??Center=?6?   $??Arial Rounded MT Bold)?6?   $??20(?6?   ??6?   ?? *UserMobileReg+$
 True??$ PropertyChanged=??? 5/   
   $??4??6   $??2??6!   $
??Aqum)?65   $??10(?6G   $??	10,0,10,5q?6U   $??Bottom=?6h   ???	#FFDC5454??6?   ?? *%#(Validation.Errors)[0].ErrorContent+$	 	mobileReg??6?   ?? 51   
   $??5??6   $??2??6   $
??Aqum)?61   $??20(?6C   $??10,0,0,0q?6Q    	 RegBD#???  6c   6?   (  "System.Windows.Controls.DatePicker  52   
   -   5        
  Name$
 dateReg??52      $??5??6'   $??2??64   $??10,30,10,20q?6H   
???   ?$??5q?6q   $??Center=?6?   $
??Aqum)?6?   $??20(?6?      Text$ Выберите дату??6?      SelectedDate 6?   ?? *UserDateReg+$ PropertyChanged=?6(  ?? 53   
   $??4??6   $??2??6!   $
??Aqum)?65   $??10(?6G   $??	10,0,10,5q?6U   $??Bottom=?6h   ???	#FFDC5454??6?   ?? *%#(Validation.Errors)[0].ErrorContent+$	 dateReg??6?   ?? 55   
     DefaultButtonTemplate5#???  6   $??6??6k   $??2??6x   $??10,10,10,50q?6?   ???	#FFCDFFD1
???   ?$??5q?6?   $
??Aqum)?6?   $??25(?6?    ? Cursor$
 Hand??6     RegEnter#???  6  ??6B   ?? *RegisterEnterCommand+65  ?? 56   
    	 DefaultButtonTemplate3#??? 	 6   $??6??6h   $??2??6u   $??10,65,10,10q?6?   
???????
???   ?$??3q?6?   $
??Aqum)?6?   $??15(?6?    
 RegSwapLogin#??? 
 6?   ??6C   ?? *LoginSwapCommand+6$  57      58      