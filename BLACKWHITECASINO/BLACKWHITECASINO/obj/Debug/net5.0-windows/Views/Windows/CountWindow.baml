   M S B A M L   `   `   `  ????K  GBLACKWHITECASINO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:BLACKWHITECASINO.ViewModelsBLACKWHITECASINO.ViewModels  5   	   O,clr-namespace:BLACKWHITECASINO.Views.WindowsBLACKWHITECASINO.Views.Windows  5   	   0    *BLACKWHITECASINO.Views.Windows.CountWindow   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   8vm)clr-namespace:BLACKWHITECASINO.ViewModels     5   	   >local,clr-namespace:BLACKWHITECASINO.Views.Windows     5   	     ? WindowStyle$
  None=?5	      $??5q?6-   $	??150??5
   	   $	??400??6    ? 
ResizeMode$ NoResize=?6"    ? Topmost$
 True??68    ? WindowStartupLocation$ CenterScreen=?6G    ? DataContext 5      5  /BLACKWHITECASINO.ViewModels.MainWindowViewModel  5   
   .??5      ?  ? ColumnDefinitions 5   
   ?? 5      6!   ?? 5      6!   ?? 5      6!    ? RowDefinitions 5   
   ?? 5      6   ?? 5      6   .+?5   
   ?? $??0??6   $??3??6      CWLabel#???   61   $??Center=?6U   $??0,10,0,0q?6r   $??Center=?6?   $
??Aqum)?6?   $??20(?6?   ?? 5   
   -   5         ??Name$ 	countText??5      $??1??6%   $??3??62   $??2q?6F   $??Center=?6Z   $??0,0,0,0q?6w    ?? TextWrapping$
 Wrap=?6?   $	??Top=?6?   $	??350??6?   $??Center=?6  $??Center=?6(  $
??Aqum)?6J  $??14(?6\  
???   ?$??30??6~  ??6?   ?? *CountBetValue+	 ?? UpdateSourceTrigger$	 PropertyChanged=?6?  ?? 5   
   $??1??6   $??2??6   $??2,2,1,2q?62   $
??ок??6L   $
??Left=?6Y   $??	20,0,0,12q?6t   $??Bottom=?6?   $	??175??6?   
???   ????	#FF88FF9A$
??Aqum)?6?   $??10(?6?   $??30??6?   ??6  ?? *AcceptApplicationCommand+?? 5   
   $??1??6   $??2??6   $??1,2,2,2q?62    
 Cancel#???  6L   $??Right=?6o   $??	0,0,20,12q?6?   $??Bottom=?6?   $	??175??6?   
???   ????	#FFFF8888$
??Aqum)?6?   $??10(?6  $??30??6  $??1??6  ??6,  ?? *CloseApplicationCommand+5      5      