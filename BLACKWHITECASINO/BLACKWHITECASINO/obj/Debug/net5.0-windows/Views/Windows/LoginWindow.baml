   M S B A M L   `   `   `  ????K  GBLACKWHITECASINO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:BLACKWHITECASINO.ViewModelsBLACKWHITECASINO.ViewModels  5   	   O,clr-namespace:BLACKWHITECASINO.Views.WindowsBLACKWHITECASINO.Views.Windows  5   	   0    *BLACKWHITECASINO.Views.Windows.LoginWindow   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   8vm)clr-namespace:BLACKWHITECASINO.ViewModels     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   >local,clr-namespace:BLACKWHITECASINO.Views.Windows     5   	   -   5          ?Name$  WindowNameTobeClose??5   ?      
LoginTitle ? Title# ?   6	   $	??500??6.   $	??400??6;    ? 
ResizeMode$ NoResize=?6G    ? WindowStartupLocation$ CenterScreen=?6]    ? DataContext 5      6  0BLACKWHITECASINO.ViewModels.LoginWindowViewModel  5   
   .??5      ?  ? ColumnDefinitions 5   
   ?? 5      6!   ?? 5      6!    ? RowDefinitions 5   
   ?? 5      $
??1.5* ?6   6,   ?? 5      6   ?? 5      6   ?? 5      6   .+?5   
   ?? $??2??6   $??Center=?6$   $??Center=?6A   $
??Aqum)?6\   $??50(?6n     
LoginLabel#???  6|   6?   ?? 5   
   $??1??6   $??2??6   $
??Aqum)?61   $??20(?6C   $??10,0,0,0q?6Q     
LoginLogin#???  6c   6?   ?? 5   
   $??1??6   $??2??6   $??10,30,10,20q?63   
???   ?$??5q?6\   $??Center=?6p   $??Arial Rounded MT Bold)?6?   $??20(?6?   $??Normal"?6  ??6?   ?? *UserLoginLog+ ?? UpdateSourceTrigger$ PropertyChanged=?6  ?? 5!   
   $??2??6   $??2??6   $
??Aqum)?61   $??20(?6C   $??10,0,0,0q?6Q     LoginPassword#???  6c   6?   G? 5"   
   -   5         G?Name$ PasswordBox??5"      $??2??6+   $??2??68   $??10,30,10,20q?6L   
???   ?$??5q?6u   $??Center=?6?   $??Arial Rounded MT Bold)?6?   $??20(?6?   $
??Bold"?6?   5$      ?? 5&   
     DefaultButtonTemplate5#???  6   $??3??6?   $??2??6?   $??10,10,10,50q?6?   ???	#FFCDFFD1
???   ?$??5q?6  $
??Aqum)?6  $??25(?6'    
LoginEnter#???  65  ??6B   ?? *EnterCommand+??6c   ?? 	 ?? ElementName$	 WindowNameTobeClose??6^  ?? 5'   
     DefaultButtonTemplate3#???  6   $??3??6?   $??2??6?   $??10,65,205,10q?6?   
???????
???   ?$??3q?6  $
??Aqum)?6  $??15(?6+    LoginSwapRegistration#???  69  ??6B   ?? *RegisterSwapCommand+??6j   ?? $	 WindowNameTobeClose??6m  ?? 5(   
   #???  6   $??3??6?   $??2??6?   $??205,65,10,10q?6?   
???????
???   ?$??3q?6  $
??Aqum)?6  $??15(?6-  
 ? Cursor$

 Hand??6;    LoginForgot#???  6I  ??6B   ?? *ForgotPasswordCommand+??6l   ?? $	 WindowNameTobeClose??6s  5*      5+      