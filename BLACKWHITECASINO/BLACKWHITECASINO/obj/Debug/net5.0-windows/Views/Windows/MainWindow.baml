   M S B A M L   `   `   `  ????K  GBLACKWHITECASINO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:BLACKWHITECASINO.ViewModelsBLACKWHITECASINO.ViewModels  5   	   3clr-namespace:BLACKWHITECASINOBLACKWHITECASINO  5   	   !    BLACKWHITECASINO.MainWindow   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   8vm)clr-namespace:BLACKWHITECASINO.ViewModels     5   	   0localclr-namespace:BLACKWHITECASINO     5   	   -   5          ?Name$  MainWin??5   d    ? WindowState$ 	Maximized=?5	   	      MWTitle ? Title# ?   5
   	   $	??768??5   	   $
??1024??6   $
??1024??6#   $	??768??63   $
??1920??6C   $
??1080??6S    ? DataContext 5      5  /BLACKWHITECASINO.ViewModels.MainWindowViewModel  5   
   .??5      ?  ? Cursor$
 Hand??6    ? ColumnDefinitions 5   
   ?? 5      6!   ?? 5      6!   ?? 5      6!   ?? 5      6!   ?? 5      6!   ?? 5      6!   ?? 5      6!   ?? 5      6!    ? RowDefinitions 5   
   ?? 5      6   ?? 5      6   ?? 5      6   ?? 5       6   ?? 5!      6   ?? 5"      6   ?? 5#      6   ?? 5$      6   ?? 5%      6   ?? 5&      6   ?? 5'      6   ?? 5(      6   ?? 5)      6   ?? 5*      6   ?? 5+      6   ?? 5,      6   ?? 5-      6   ?? 5.      6   .+?52   
   (? $??2??6   $??4??6#   $
??Left=?67   $??Center=?6R   $??5,0,5,0q?6m    K? ZIndex$ 21??6~   $ Arrow??6?   .??53      ?? 
???   ?$
??Aqum)?6+   BLACK-WHITE CASINO6Q   54      ?? 55   
   -   5         ??Name$ OpenMenu??55      $??2??6#   $??4??60   $??7??6A   $??1??6Q   $ 10??6e   
???   ?$??10q?6?   
???????$??0,-177.12,0,177.12q?6?   ._?56      ?  57      ?? 58      6&   ?? 59      6&   ?? 5:      6&   ?? 5;      6&   .+?5=      ??   OpenMenuButton#???  6   $??0??6B   $
 Hand??6v    	 MWAcc#???  6?   ??6O   ?? *OpenAccountCommand+6?   ?? 5>      #???  6   $??1??6B   $
 Hand??6o    
 MWHelp#???  6}   ??6O   ?? *HelpCommand+6?   ?? 5?      #???  6   $??2??6B     MWChange#???  6y   ??6O   ?? *ChangeLanguageCommand+6?   ?? 5@      #???  6   $??3??6B    
 MWExit#???  6?   ??6O   ?? *ExitAccountCommand+??6v   ?? 	 ?? ElementName$	 MainWin??6?   5A      5B      ?? 5D   
     RoundButtonTemplateHigh#??[ 6   $??7??6?   $??2??6?   $??10,10,10,10q?6?   $??30(?6?   $
 Hand??6?   $ 21??6?   
?????????6B   ?? *OpenMenuCommand+??6f   ?? $	 OpenMenu??{?6  ?? *AccIsEnabled+
 ?? UpdateSourceTrigger$
 PropertyChanged=?.??5E      (? $??5,0,5,0q?6   .??5F      ?? ??6   ?? *LoginMainWindow+$
 PropertyChanged=?6d   5G      5H      ?? 5I   
   
???????$??6??6$   $??0??64   $??5,5,5,0q?6A   
???   ? ?? CornerRadius$ 	20,20,0,0??6o   $??
10,10,10,0q?6?   $ 21??6?   $ Arrow??6?   ._?5J      (? $??Center=?6   $??Center=?61   $??5,0,5,0q?6N   .??5K      ?? 
???   ?$
??Aqum)?6/     MWTotal#???  6A   6d   5L      5M      ?? 5N   
   
???????$??6??6$   $??1??64   $??5,0,5,5q?6A   
???   ?$ 	0,0,20,20??6o   $??
10,0,10,10q?6?   $ 21??6?   $ Arrow??6?   ._?5O      ?? 
???   ?$
??Aqum)?6+   $??18(?6Y   $??Center=?6g   $??Center=?6?   ??6=   ?? *
TotalValue+6?   5P      ?? 5Q   
     RoundButtonTemplateLow#??[ 6   $
 Hand??6A   $??5??6O   $??0??6_   $??0q?6l   $??20(?6x   $??
10,10,10,2q?6?   $ 23??6?   ??6?   ?? *OpenDepositCommand+.??5R      (? .??5S      ??  		 MWDEp#??? 	 6   6=   5T      5U      ?? 5V   
   #??[ 6   $
 Hand??6A   $??5??6O   $??1??6_   $??0q?6l   $??20(?6x   $??
10,2,10,10q?6?   $ 21??6?   ??6?   ?? *OpenConclusionCommand+.??5W      (? .??5X      ??  
 MWConclusion#??? 
 6   6D   5Y      5Z      ?? 5^   
   -   5         ??Name$ 
TabControl??5^      $??2??6)   $??16??66   $??8??6H   
???????
???????$??0q?6?   $??
-1,10,-1,0q?6?    ?? SelectedIndex 6?   ?? *
zIndexTabs+.@?5_      ?? $
 Hand??65   
???????$
??Aqum)?6W   $??25(?6i   $	??383??6w   $??2,-2,0,0q?6?   ??6   ?? *TitleDouble+.??5a      ? $ Arrow??6   
???????$??-2,-2,-2,-300q?69    5b      ?? 5c      6-   ?? 5d      6-   ?? 5e      6-   ?? 5f      6-   ?? 5g      6-   ?? 5h      6-   ?? 5i      6-   ?? 5j      6-   ?? 5k      6-   ?? 5l      6-   ?? 5m      6-   ?? 5n      6-   ?? 5o      6-    5q      ?? 5r      6*   ?? 5s      6*   ?? 5t      6*   ?? 5u      6*   ?? 5v      6*   ?? 5w      6*   ?? 5x      6*   ?? 5y      6*   ?? 5z      6*   ?? 5{      6*   ?? 5|      6*   ?? 5}      6*   .+?5?      (? -   5         (?Name$ DoubleViewBox??5?      $??1??65   $??11??6B   $??1??6T   $??11??6d   $??
25,75,25,0q?6y   .??5?      ?? -   5         ??Name$ RotateImage??5?       $
??Fill=?65   $??/Images/casino1.png??6D   $??0,0,0,0q?6a   $	??700??6r   $	??700??6~   $??Stretch=?6?   $??Stretch=?6?   $	 -10??6?    J? RenderTransformOrigin$ 0.5,0.5&?6?   z?5?      ?? 5?   "    ?? Angle$ -171.41Q?62   5?      5?      (? 5?      $??1??6   $??3??6+   $??6??6<   $??	0,60,0,20q?6L   $??Center=?6_   $	??Top=?6|   .??5?      ?? $	??140??6    $??36??6-   $??/Images/casino2.png??68   6W   5?      ?? 5?        RoundButtonTemplateCircle#??[ 6   $??5??6?   $??5??6?   $??25(?6?   $??
25,0,-5,20q?6?   $
 Hand??6?   ??6P   ?? *WhiteBetCommand+$
 PropertyChanged=?{?6?   ?? *
RdyButSpin+6	  ?? 5?      #??[ 6   $??6??6?   $??5??6?   ???	#FFB71C24$??25(?6?   $??
10,0,10,20q?6?   ??6P   ?? *RedBetCommand+$
 PropertyChanged=?{?6?   ?? *
RdyButSpin+6  ?? 5?      #??[ 6   $??7??6?   $??5??6?   
???   ?$??25(?6?   $??
-5,0,25,20q?6?   ??6P   ?? *BlackBetCommand+$
 PropertyChanged=?{?6?   ?? *
RdyButSpin+6  ?? 5?      #??[ 6   $??4??6?   $??6??6?   $??25(?6?   $??35,0,-15,20q?6?   ??6P   ?? *EvenBetCommand+$
 PropertyChanged=?{?6?   ?? *
RdyButSpin+.??5?      (? .??5?      ??   
DoubleEven#???  6(   6N   5?      5?      ?? 5?      #??[ 6   $??5??6?   $??6??6?   $??25(?6?   $??20,0,-37.5,20q?6?   ??6P   ?? *LowRangeBetCommand+$
 PropertyChanged=?{?6?   ?? *
RdyButSpin+.??5?      (? .??5?      ?? 0-96-   5?      5?      ?? 5?      #??[ 6   $??7??6?   $??6??6?   $??25(?6?   $??-37.5,0,20,20q?6?   ??6P   ?? *BigRangeBetCommand+$
 PropertyChanged=?{?6?   ?? *
RdyButSpin+.??5?      (? .??5?      ?? 10-196/   5?      5?      ?? 5?      #??[ 6   $??8??6?   $??6??6?   $??25(?6?   $??-15,0,35,20q?6?   $
 Hand??6?   ??6P   ?? *NotEvenBetCommand+$
 PropertyChanged=?{?6?   ?? *
RdyButSpin+.??5?      (? .??5?      ??   DoubleNotEven#???  6(   6Q   5?      5?      ?? 5?      $??4??6    $??5??61   $??30(?6E   $??10,0,0,0q?6S   ??6e   ?? *
InformBets+$
 PropertyChanged=? ?? Mode$ TwoWay=?5?      ?? 5?      #??[ 6   $??2??6?   $??4??6?   $??10,-30,10,50q?6?   $
 Hand??6?   ??6N   ?? *ClearBetCommand+$
 PropertyChanged=?{?6?   ?? *
RdyButSpin+.??5?      (? $??5,0,5,0q?6"   .??5?      ??   DoubleClear#???  6(   6O   5?      5?      ?? 5?      $??10??6    $??3??61   $??Center=?6E   $??30(?6b     DoubleResult#???  6p   5?      ?? 5?      $??10??6    $??3??61   $??Center=?6E   $??25(?6b   $??Bottom=?6?   ??6p   ?? *resultDouble+6?   5?      5?      ?? 5?      $
 Hand??63   
???????$
??Aqum)?6U   $??25(?6g   $	??383??6u   $??0,-2,0,0q?6?   ??6   ?? *	TitleSlot+.??5?      ? 
???????$??-2,-6000,-2,-2q?6*   $ Arrow??6B    5?      ?? 5?      6-   ?? 5?      6-   ?? 5?      6-   ?? 5?      6-   ?? 5?      6-   ?? 5?      6-   ?? 5?      6-   ?? 5?      6-   ?? 5?      6-    5?      ?? 5?      $
??8.8* ?6(   68   ?? 5?      $??0.11* ?6(   69   ?? 5?      $??0.11* ?6(   69   ?? 5?      $??0.11* ?6(   69   ?? 5?      $??0.11* ?6(   69   ?? 5?      $??0.11* ?6(   69   ?? 5?      $??0.11* ?6(   69   ?? 5?      $??0.11* ?6(   69   ?? 5?      $??0.11* ?6(   69   .+?5?      (? -   5        $ 	ViewRoll1??5?      $??9??61   $??2??6B   $??2??6R   $??Right=?6f   $??0,0,0,0q?6?   .??5?      ?? -   5        $ ImgRoll1??5?       $
??4168??62   $??
0,60,0,-60q?6@   $	??100??6T   $%??/Images/roll — копия.png??6`   $??Bottom=?6?   5?      (? 5?      -   5        $ 	ViewRoll2??5?      $??9??61   $??3??6B   $??3??6R   .??5?      ?? -	   5        $ ImgRoll2??5?       $
??4168??63   $??	0,0,0,-63q?6A   $	??100??6T   $%??/Images/roll — копия.png??6`   $??Bottom=?6?   5?      (? 5?      -
   5        $ 	ViewRoll3??5?      $??9??61   $??5??6B   $??2??6R   $
??Left=?6f   $??0,0,0,0q?6?   .??5?      ?? -   5        $ ImgRoll3??5?       $
??4168??62   $??	0,0,0,-63q?6@   $	??100??6S   $%??/Images/roll — копия.png??6_   $??Bottom=?6?   5?      (? 5?      $??0??6   $??8??6+   $??2??6<   $??5??6L   .??5?      ?? $??15000??6    $??0,0,0,0q?6/   $
??1100??6@   $??/Images/casino433.png??6M   $??Bottom=?6l   5?      ?? 5?      $??1??6    $??3??6-   $??	10,0,50,0q?6A   $??30(?6T   $??Center=?6b   $??Bottom=?6     	SlotUrBet#???  6?   6?   ?? 5?      $??2??6    $??3??6-   $??	10,0,50,0q?6A   $??Center=?6T   $??Center=?6q   ??6?   ?? *SlotInfoBetText+$
 PropertyChanged=?$ TwoWay=?6?   ?? 5?      $??3??6    $??3??6-   $??	10,0,50,0q?6A   $??30(?6T   $??Center=?6b   $??Bottom=?6     SlotJackpot#???  6?   6?   ?? 5?      $??4??6    $??3??6-   $??	10,0,50,0q?6A   $??Center=?6T   $??Center=?6q   ??6?   ?? *SlotInfoBetTextJackpot+$
 PropertyChanged=?$ TwoWay=?6?   (? 5?      $??3??6   $??3??6+   $??3??6;   $??
0,-25,0,45q?6O   .??5?      ?? $
??Aqum)?6$   $??25(?66   
???????$
??Left=?6W   $	??Top=?6r   $??0,0,0,0q?6?   $??2??6?   ??6?   ?? *SlotInfoText+6?   5?      ?? 5?      $??6??6   $??2??6,   $??3??6=     SlotAuto#???  6Q   $
??Left=?6v   $??10,0,0,0q?6?   $??20(?6?   $??5,-6,0,0q?6?    d? 	IsChecked 6?   ?? *
IsChecked1+?? 5?      $??6??6   $??2??6,   $??3??6=     SlotSpinAll#???  6Q   $
??Left=?6y   $??	10,25,0,0q?6?   $??20(?6?   $??5,-6,0,0q?6?    6?   ?? *
IsChecked2+?? 5?      $??6??6   $??2??6,   $??3??6=     SlotAnimOff#???  6Q   $
??Left=?6y   $??	10,50,0,0q?6?   $??20(?6?   $??5,-6,0,0q?6?    6?   ?? *
IsChecked3+?? 5?      $??6??6   $??2??6,   $??3??6=     SlotDelayOff#???  6Q   $
??Left=?6z   $??	10,75,0,0q?6?   $??20(?6?   $??5,-6,0,0q?6?    6?   ?? *
IsChecked4+5?      5?      ?? 5?      $
 Hand??64   
???????$
??Aqum)?6V   $??25(?6h   $	??383??6v   $??0,-2,0,0q?6?   ??6   ?? *
TitleMines+.??5?      ? 
???????$??-2,-2,-2,-2q?6*   $ Arrow??6?    5?      ?? 5?      6-   ?? 5?      6-   ?? 5?      6-   ?? 5?      6-   ?? 5?      6-   ?? 5?      6-   ?? 5?      6-   ?? 5?      6-   ?? 5?      6-    5?      ?? 5?      6*   ?? 5?      6*   ?? 5?      6*   ?? 5?      $??0.46* ?6(   69   .+?5?      ?? -   5         ??Name$ MinesButClear??5?        DefaultButtonTemplate#??[ 64   $??2??6c   $??2??6w   $??35(?6?   $??-10,120,-10,-10q?6?   $
 Hand??6?   ??6?   ?? *MinesButClearCommand+.??5?      (? $??0,0,0,5q?6"   .??5?      ??   	MinesTake#???  6(   6M   5      5     (? 5     $??3??6   $??2??6/   $
??Left=?6?   $??	0,0,0,-10q?6Z   .??5     ?? $??/Images/start.png??6    6=   5     (? 5     $??3??6   $??8??6/   $??Right=?6?   $??	0,0,0,-10q?6[   .??5     ?? $??/Images/finish.png??6    6>   5     ?? 5	     $??0??6    $??2??6-   $??0,20,0,0q?6A   $??28(?6S   $??Center=?6a   $	??Top=?6~     	MinesLvl1#???  6?   6?   ?? 5
     $??0??6    $??2??6-   $??0,50,0,0q?6A   $??28(?6S   $??Center=?6a   $	??Top=?6~     	MinesLvl2#???  6?   6?   	? 5     $??2??6"     	MinesEasy#???  66   $??Center=?6\   $??0,40,0,0q?6w   $??Center=?6?   $??4,-9,0,0q?6?    6?   ?? *IsCheckedMines+{?6?   ?? *IsCheckedMinesEnabled+6  	? 5     $??2??6"     	MinesHard#???  66   $??Center=?6\   $??0,90,0,0q?6w   $??Center=?6?   $??4,-9,0,0q?6?   {?6?   ?? *IsCheckedMinesEnabled+6?   ?? 5     $??1??6    $??2??6-   $??0,20,0,0q?6A   $??28(?6S   $??Center=?6a   $	??Top=?6~     MinesMB1#???  6?   6?   ?? 5     $??1??6    $??2??6-   $??0,50,0,0q?6A   $??28(?6S   $??Center=?6a   $	??Top=?6~     MinesMB2#???  6?   6?   ?? 5     $??1??6    $??2??6-   $??0,90,0,0q?6A   $??28(?6S   $??Center=?6a   $	??Top=?6~   ??6?   ?? *
MinesMbWin+$
 PropertyChanged=?6?   ?? 5     $??2??6    $??2??6-   $??0,0,0,0q?6A   $??28(?6R   $??Center=?6`   $	??Top=?6}     MinesUR1#???  6?   6?   ?? 5     $??2??6    $??2??6-   $??0,30,0,0q?6A   $??28(?6S   $??Center=?6a   $	??Top=?6~     MinesUR2#???  6?   6?   ?? 5     $??2??6    $??2??6-   $??0,70,0,0q?6A   $??28(?6S   $??Center=?6a   $	??Top=?6~   ??6?   ?? *
MinesUrWin+$
 PropertyChanged=?6?   ?? 5     -   5        $ 
MinesBut11??5     #??[ 6W   $??3??6?   $??0??6?   $??35(?6  $??
10,40,10,0q?6  $
 Hand??6$  ??61   ?? *MinesBut11Back+??6?   ?? *MinesBut11Command+??6?   ?? $	 
TabControl??{?62  ?? *MinesBut11IsEnabled+.??5     ? .+?5     (? -   5        $ MinesBut11Text??5  &   $??10q?6>   .??5  "   ??  J? Opacity$	 0.7Q?6L   ??6,   ?? *MinesBut11Text+6\   5     (? 5     -   5        $ MinesBut11Pick??5  &   $??10q?6>   .??5  "   ?? $??/Images/pick.png??6(   ${?False??6B    6T   ?? *MinesBut11Pick+6y   5     (? 5      -   5        $ MinesBut11Bimb??5   &   $??10q?6>   .??5!  "   ?? $??/Images/bimba.png??6(   ${?False??6C    6U   ?? *MinesBut11Bimb+6z   5"     5#     5$     ?? 5%     -   5        $ 
MinesBut12??5%     #??[ 6W   $??3??6?   $??1??6?   $??35(?6  $??10,20q?6  $
 Hand??6  ??61   ?? *MinesBut12Back+??6?   ?? *MinesBut12Command+??6?   ?? $	 
TabControl??{?6.  ?? *MinesBut11IsEnabled+.??5&     ? .+?5'     (? -   5        $ MinesBut12Text??5'  &   $??10q?6>   .??5(  "   ?? $	 0.7Q?6L   ??6,   ?? *MinesBut12Text+6\   5)     (? 5*     -   5        $ MinesBut12Pick??5*  &   $??10q?6>   .??5+  "   ?? $??/Images/pick.png??6(   ${?False??6B    6T   ?? *MinesBut12Pick+6y   5,     (? 5-     -   5        $ MinesBut12Bimb??5-  &   $??10q?6>   .??5.  "   ?? $??/Images/bimba.png??6(   ${?False??6C    6U   ?? *MinesBut12Bimb+6z   5/     50     51     ?? 52     -   5        $ 
MinesBut13??52     #??[ 6W   $??3??6?   $??2??6?   $??35(?6  $??
10,0,10,40q?6  $
 Hand??6$  ??61   ?? *MinesBut13Back+??6?   ?? *MinesBut13Command+??6?   ?? $	 
TabControl??{?63  ?? *MinesBut11IsEnabled+.??53     ? .+?54     (? -   5        $ MinesBut13Text??54  &   $??10q?6>   .??55  "   ?? $	 0.7Q?6L   ??6,   ?? *MinesBut13Text+6\   56     (? 57     -   5        $ MinesBut13Pick??57  &   $??10q?6>   .??58  "   ?? $??/Images/pick.png??6(   ${?False??6B    6T   ?? *MinesBut13Pick+6y   59     (? 5:     -   5        $ MinesBut13Bimb??5:  &   $??10q?6>   .??5;  "   ?? $??/Images/bimba.png??6(   ${?False??6C    6U   ?? *MinesBut13Bimb+6z   5<     5=     5>     ?? 5@     -   5        $ 
MinesBut21??5@     #??[ 6W   $??4??6?   $??0??6?   $??35(?6  $??
10,40,10,0q?6  $
 Hand??6$  ??61   ?? *MinesBut21Back+??6?   ?? *MinesBut21Command+??6?   ?? $	 
TabControl??{?63  ?? *MinesBut22IsEnabled+.??5A     ? .+?5B     (? -   5        $ MinesBut21Text??5B  &   $??10q?6>   .??5C  "   ?? $	 0.7Q?6L   ??6,   ?? *MinesBut21Text+6\   5D     (? 5E     -   5        $ MinesBut21Pick??5E  &   $??10q?6>   .??5F  "   ?? $??/Images/pick.png??6(   ${?False??6B    6T   ?? *MinesBut21Pick+6y   5G     (? 5H     -   5        $ MinesBut21Bimb??5H  &   $??10q?6>   .??5I  "   ?? $??/Images/bimba.png??6(   ${?False??6C    6U   ?? *MinesBut21Bimb+6z   5J     5K     5L     ?? 5M     -   5        $ 
MinesBut22??5M     #??[ 6W   $??4??6?   $??1??6?   $??35(?6  $??10,20q?6  $
 Hand??6  ??61   ?? *MinesBut22Back+??6?   ?? *MinesBut22Command+??6?   ?? $	 
TabControl??{?6.  ?? *MinesBut22IsEnabled+.??5N     ? .+?5O     (? -   5        $ MinesBut22Text??5O  &   $??10q?6>   .??5P  "   ?? $	 0.7Q?6L   ??6,   ?? *MinesBut22Text+6\   5Q     (? 5R     -   5        $ MinesBut22Pick??5R  &   $??10q?6>   .??5S  "   ?? $??/Images/pick.png??6(   ${?False??6B    6T   ?? *MinesBut22Pick+6y   5T     (? 5U     -    5        $ MinesBut22Bimb??5U  &   $??10q?6>   .??5V  "   ?? $??/Images/bimba.png??6(   ${?False??6C    6U   ?? *MinesBut22Bimb+6z   5W     5X     5Y     ?? 5Z     -!   5        $ 
MinesBut23??5Z     #??[ 6W   $??4??6?   $??2??6?   $??35(?6  $??
10,0,10,40q?6  $
 Hand??6$  ??61   ?? *MinesBut23Back+??6?   ?? *MinesBut23Command+??6?   ?? $	 
TabControl??{?62  ?? *MinesBut22IsEnabled+.??5[     ? .+?5\     (? -"   5        $ MinesBut23Text??5\  &   $??10q?6>   .??5]  "   ?? $	 0.7Q?6L   ??6,   ?? *MinesBut23Text+6\   5^     (? 5_     -#   5        $ MinesBut23Pick??5_  &   $??10q?6>   .??5`  "   ?? $??/Images/pick.png??6(   ${?False??6B    6T   ?? *MinesBut23Pick+6y   5a     (? 5b     -$   5        $ MinesBut23Bimb??5b  &   $??10q?6>   .??5c  "   ?? $??/Images/bimba.png??6(   ${?False??6C    6U   ?? *MinesBut23Bimb+6z   5d     5e     5f     ?? 5h     -%   5        $ 
MinesBut31??5h     #??[ 6W   $??5??6?   $??0??6?   $??35(?6  $??
10,40,10,0q?6  $
 Hand??6$  ??61   ?? *MinesBut31Back+??6?   ?? *MinesBut31Command+??6?   ?? $	 
TabControl??{?62  ?? *MinesBut33IsEnabled+.??5i     ? .+?5j     (? -&   5        $ MinesBut31Text??5j  &   $??10q?6>   .??5k  "   ?? $	 0.7Q?6L   ??6,   ?? *MinesBut31Text+6\   5l     (? 5m     -'   5        $ MinesBut31Pick??5m  &   $??10q?6>   .??5n  "   ?? $??/Images/pick.png??6(   ${?False??6B    6T   ?? *MinesBut31Pick+6y   5o     (? 5p     -(   5        $ MinesBut31Bimb??5p  &   $??10q?6>   .??5q  "   ?? $??/Images/bimba.png??6(   ${?False??6C    6U   ?? *MinesBut31Bimb+6z   5r     5s     5t     ?? 5u     -)   5        $ 
MinesBut32??5u     #??[ 6W   $??5??6?   $??1??6?   $??35(?6  $??10,20q?6  $
 Hand??6  ??61   ?? *MinesBut32Back+??6?   ?? *MinesBut32Command+??6?   ?? $	 
TabControl??{?6-  ?? *MinesBut33IsEnabled+.??5v     ? .+?5w     (? -*   5        $ MinesBut32Text??5w  &   $??10q?6>   .??5x  "   ?? $	 0.7Q?6L   ??6,   ?? *MinesBut32Text+6\   5y     (? 5z     -+   5        $ MinesBut32Pick??5z  &   $??10q?6>   .??5{  "   ?? $??/Images/pick.png??6(   ${?False??6B    6T   ?? *MinesBut32Pick+6y   5|     (? 5}     -,   5        $ MinesBut32Bimb??5}  &   $??10q?6>   .??5~  "   ?? $??/Images/bimba.png??6(   ${?False??6C    6U   ?? *MinesBut32Bimb+6z   5     5?     5?     ?? 5?     --   5        $ 
MinesBut33??5?     #??[ 6W   $??5??6?   $??2??6?   $??35(?6  $??
10,0,10,40q?6  $
 Hand??6%  ??61   ?? *MinesBut33Back+??6?   ?? *MinesBut33Command+??6?   ?? $	 
TabControl??{?63  ?? *MinesBut33IsEnabled+.??5?     ? .+?5?     (? -.   5        $ MinesBut33Text??5?  &   $??10q?6>   .??5?  "   ?? $	 0.7Q?6L   ??6,   ?? *MinesBut33Text+6\   5?     (? 5?     -/   5        $ MinesBut33Pick??5?  &   $??10q?6>   .??5?  "   ?? $??/Images/pick.png??6(   ${?False??6B    6T   ?? *MinesBut33Pick+6y   5?     (? 5?     -0   5        $ MinesBut33Bimb??5?  &   $??10q?6>   .??5?  "   ?? $??/Images/bimba.png??6(   ${?False??6C    6U   ?? *MinesBut33Bimb+6z   5?     5?     5?     ?? 5?     -1   5        $ 
MinesBut41??5?     #??[ 6W   $??6??6?   $??0??6?   $??35(?6  $??
10,40,10,0q?6  $
 Hand??6%  ??61   ?? *MinesBut41Back+??6?   ?? *MinesBut41Command+??6?   ?? $	 
TabControl??{?63  ?? *MinesBut44IsEnabled+.??5?     ? .+?5?     (? -2   5        $ MinesBut41Text??5?  &   $??10q?6>   .??5?  "   ?? $	 0.7Q?6L   ??6,   ?? *MinesBut41Text+6\   5?     (? 5?     -3   5        $ MinesBut41Pick??5?  &   $??10q?6>   .??5?  "   ?? $??/Images/pick.png??6(   ${?False??6B    6T   ?? *MinesBut41Pick+6y   5?     (? 5?     -4   5        $ MinesBut41Bimb??5?  &   $??10q?6>   .??5?  "   ?? $??/Images/bimba.png??6(   ${?False??6C    6U   ?? *MinesBut41Bimb+6z   5?     5?     5?     ?? 5?     -5   5        $ 
MinesBut42??5?     #??[ 6W   $??6??6?   $??1??6?   $??35(?6  $??10,20q?6  $
 Hand??6  ??61   ?? *MinesBut42Back+??6?   ?? *MinesBut42Command+??6?   ?? $	 
TabControl??{?6-  ?? *MinesBut44IsEnabled+.??5?     ? .+?5?     (? -6   5        $ MinesBut42Text??5?  &   $??10q?6>   .??5?  "   ?? $	 0.7Q?6L   ??6,   ?? *MinesBut42Text+6\   5?     (? 5?     -7   5        $ MinesBut42Pick??5?  &   $??10q?6>   .??5?  "   ?? $??/Images/pick.png??6(   ${?False??6B    6T   ?? *MinesBut42Pick+6y   5?     (? 5?     -8   5        $ MinesBut42Bimb??5?  &   $??10q?6>   .??5?  "   ?? $??/Images/bimba.png??6(   ${?False??6C    6U   ?? *MinesBut42Bimb+6z   5?     5?     5?     ?? 5?     -9   5        $ 
MinesBut43??5?     #??[ 6X   $??6??6?   $??2??6?   $??35(?6  $??
10,0,10,40q?6  $
 Hand??6&  ??61   ?? *MinesBut43Back+??6?   ?? *MinesBut43Command+??6?   ?? $	 
TabControl??{?64  ?? *MinesBut44IsEnabled+.??5?     ? .+?5?     (? -:   5        $ MinesBut43Text??5?  &   $??10q?6>   .??5?  "   ?? $	 0.7Q?6L   ??6,   ?? *MinesBut43Text+6\   5?     (? 5?     -;   5        $ MinesBut43Pick??5?  &   $??10q?6>   .??5?  "   ?? $??/Images/pick.png??6(   ${?False??6B    6T   ?? *MinesBut43Pick+6y   5?     (? 5?     -<   5        $ MinesBut43Bimb??5?  &   $??10q?6>   .??5?  "   ?? $??/Images/bimba.png??6(   ${?False??6C    6U   ?? *MinesBut43Bimb+6z   5?     5?     5?     ?? 5?     -=   5        $ 
MinesBut51??5?     #??[ 6X   $??7??6?   $??0??6?   $??35(?6  $??
10,40,10,0q?6  $
 Hand??6%  ??61   ?? *MinesBut51Back+??6?   ?? *MinesBut51Command+??6?   ?? $	 
TabControl??{?63  ?? *MinesBut55IsEnabled+.??5?     ? .+?5?     (? ->   5        $ MinesBut51Text??5?  &   $??10q?6>   .??5?  "   ?? $	 0.7Q?6L   ??6,   ?? *MinesBut51Text+6\   5?     (? 5?     -?   5        $ MinesBut51Pick??5?  &   $??10q?6>   .??5?  "   ?? $??/Images/pick.png??6(   ${?False??6B    6T   ?? *MinesBut51Pick+6y   5?     (? 5?     -@   5        $ MinesBut51Bimb??5?  &   $??10q?6>   .??5?  "   ?? $??/Images/bimba.png??6(   ${?False??6C    6U   ?? *MinesBut51Bimb+6z   5?     5?     5?     ?? 5?     -A   5        $ 
MinesBut52??5?     #??[ 6X   $??7??6?   $??1??6?   $??35(?6  $??10,20q?6  $
 Hand??6   ??61   ?? *MinesBut52Back+??6?   ?? *MinesBut52Command+??6?   ?? $	 
TabControl??{?6.  ?? *MinesBut55IsEnabled+.??5?     ? .+?5?     (? -B   5        $ MinesBut52Text??5?  &   $??10q?6?   .??5?  "   ?? $	 0.7Q?6L   ??6,   ?? *MinesBut52Text+6\   5?     (? 5?     -C   5        $ MinesBut52Pick??5?  &   $??10q?6>   .??5?  "   ?? $??/Images/pick.png??6(   ${?False??6B    6T   ?? *MinesBut52Pick+6y   5?     (? 5?     -D   5        $ MinesBut52Bimb??5?  &   $??10q?6>   .??5?  "   ?? $??/Images/bimba.png??6(   ${?False??6C    6U   ?? *MinesBut52Bimb+6z   5?     5?     5?     ?? 5?     -E   5        $ 
MinesBut53??5?     #??[ 6X   $??7??6?   $??2??6?   $??35(?6  $??
10,0,10,40q?6  $
 Hand??6%  ??61   ?? *MinesBut53Back+??6?   ?? *MinesBut53Command+??6?   ?? $	 
TabControl??{?64  ?? *MinesBut55IsEnabled+.??5?     ? .+?5?     (? -F   5        $ MinesBut53Text??5?  &   $??10q?6>   .??5?  "   ?? $	 0.7Q?6L   ??6,   ?? *MinesBut53Text+6\   5?     (? 5?     -G   5        $ MinesBut53Pick??5?  &   $??10q?6>   .??5?  "   ?? $??/Images/pick.png??6(   ${?False??6B    6T   ?? *MinesBut53Pick+6y   5?     (? 5?     -H   5        $ MinesBut53Bimb??5?  &   $??10q?6>   .??5?  "   ?? $??/Images/bimba.png??6(   ${?False??6C    6U   ?? *MinesBut53Bimb+6z   5?     5?     5?     5?     5?     ?? 5?     $
 Hand??63   
???????$
??Aqum)?6U   $??25(?6g   $	??383??6u   $??0,-2,0,0q?6?   ??6   ?? *	TitleNine+.??5?     ? 
???????$??-2,-2,-2,-2q?6*   $ Arrow??6@    5?     ?? 5?     $
??1.5* ?6+   6:   ?? 5?     6-   ?? 5?     6-   ?? 5?     6-   ?? 5?     $
??1.5* ?6+   6:    5?     ?? 5?     6*   ?? 5?     6*   ?? 5?     6*   ?? 5?     $??0.46* ?6(   69   .+?5?     ?? $??0??6    $??0??6-   $??0,20,0,0q?6=   $??28(?6O   $??Center=?6]   $	??Top=?6z      NineDop1#???   6?   6?   ?? 5?     $??0??6    $??0??6-   $??0,50,0,0q?6=   $??28(?6O   $??Center=?6]   $	??Top=?6z    ! NineDop2#??? ! 6?   6?   ?? 5?     $??0??6    $??0??6-   $??0,80,0,0q?6=   $??28(?6O   $??Center=?6]   $	??Top=?6z    " NineDop3#??? " 6?   6?   ?? 5?      # 
NineDopYes#??? # 6H   $??Center=?6o   $??	0,100,0,0q?6?   $??Center=?6?   $??4,-9,0,0q?6?   ??6   ?? *IsCheckedNineCommand+ 6?   ?? *IsCheckedNine+{?6?   ?? *NineButCheckedIsEnabled+6"  ?? 5?     $??1??6    $??0??6-   $??0,20,0,0q?6=   $??28(?6O   $??Center=?6]   $	??Top=?6z    $ NineOst1#??? $ 6?   6?   ?? 5?     $??1??6    $??0??6-   $??0,50,0,0q?6=   $??28(?6O   $??Center=?6]   $	??Top=?6z    % NineOst2#??? % 6?   6?   ?? 5?     $??1??6    $??0??6-   $??0,90,0,0q?6=   $??28(?6O   $??Center=?6]   $	??Top=?6z   ??6?   ?? *NineChances+$
 PropertyChanged=?6?   ?? 5?     $??2??6    $??0??6-   $??0,20,0,0q?6=   $??28(?6O   $??Center=?6]   $	??Top=?6z   #???  6?   6?   ?? 5?     $??2??6    $??0??6-   $??0,50,0,0q?6=   $??28(?6O   $??Center=?6]   $	??Top=?6z   #???  6?   6?   ?? 5?     $??2??6    $??0??6-   $??0,90,0,0q?6=   $??28(?6O   $??Center=?6]   $	??Top=?6z   ??6?   ?? *	NineMbWin+$
 PropertyChanged=?6?   ?? 5?     #??[ 6e   $??0??6?   $??1??6?   $??	20,20,0,0q?6?   ??6   ?? *NineBut1Command+??6A   ?? *NineBut1Back+{?6?   ?? *NineBut1IsEnabled+.??5?     ? .+?5      (? $??20q?6&   .??5  "   ?? ??6,   ?? *NineBut1Text+ 6J   ?? *NineBut1Opacity+6p   5     (? 5     -I   5        $ NineBut1Pick??5  &   $??10q?6<   .??5  "   ?? $??/Images/pick.png??6(   ${?False??6B    6T   ?? *NineBut1Pick+6w   5     5     5     ?? 5     #??[ 6e   $??0??6?   $??2??6?   $??
10,20,10,0q?6?   ??6   ?? *NineBut2Command+??6A   ?? *NineBut2Back+{?6?   ?? *NineBut2IsEnabled+.??5	     ? .+?5
     (? $??20q?6&   .??5  "   ?? ??6,   ?? *NineBut2Text+ 6J   ?? *NineBut2Opacity+6p   5     (? 5     $??10q?6&   .??5  "   ?? $??/Images/pick.png??6(   ${?False??6B    6T   ?? *NineBut2Pick+6w   5     5     5     ?? 5     #??[ 6e   $??0??6?   $??3??6?   $??	0,20,20,0q?6?   ??6   ?? *NineBut3Command+??6A   ?? *NineBut3Back+{?6?   ?? *NineBut3IsEnabled+.??5     ? .+?5     (? $??20q?6&   .??5  "   ?? ??6,   ?? *NineBut3Text+ 6J   ?? *NineBut3Opacity+6p   5     (? 5     $??10q?6&   .??5  "   ?? $??/Images/pick.png??6(   ${?False??6B    6T   ?? *NineBut3Pick+6w   5     5     5     ?? 5     #??[ 6e   $??1??6?   $??1??6?   $??
20,10,0,10q?6?   ??6   ?? *NineBut4Command+??6A   ?? *NineBut4Back+{?6?   ?? *NineBut4IsEnabled+.??5     ? .+?5      (? $??20q?6&   .??5!  "   ?? ??6,   ?? *NineBut4Text+ 6J   ?? *NineBut4Opacity+6p   5"     (? 5#     $??10q?6&   .??5$  "   ?? $??/Images/pick.png??6(   ${?False??6B    6T   ?? *NineBut4Pick+6w   5%     5&     5(     ?? 5)     #??[ 6e   $??1??6?   $??2??6?   $??10q?6?   ??6   ?? *NineBut5Command+??6A   ?? *NineBut5Back+{?6?   ?? *NineBut5IsEnabled+.??5*     ? .+?5+     (? $??20q?6&   .??5,  "   ?? ??6,   ?? *NineBut5Text+ 6J   ?? *NineBut5Opacity+6p   5-     (? 5.     $??10q?6&   .??5/  "   ?? $??/Images/pick.png??6(   ${?False??6B    6T   ?? *NineBut5Pick+6w   50     51     53     ?? 54     #??[ 6e   $??1??6?   $??3??6?   $??
0,10,20,10q?6?   ??6   ?? *NineBut6Command+??6A   ?? *NineBut6Back+{?6?   ?? *NineBut6IsEnabled+.??55     ? .+?56     (? $??20q?6&   .??57  "   ?? ??6,   ?? *NineBut6Text+ 6J   ?? *NineBut6Opacity+6p   58     (? 59     $??10q?6&   .??5:  "   ?? $??/Images/pick.png??6(   ${?False??6B    6T   ?? *NineBut6Pick+6w   5;     5<     5>     ?? 5?     #??[ 6e   $??2??6?   $??1??6?   $??	20,0,0,20q?6?   ??6   ?? *NineBut7Command+??6A   ?? *NineBut7Back+{?6?   ?? *NineBut7IsEnabled+.??5@     ? .+?5A     (? $??20q?6&   .??5B  "   ?? ??6,   ?? *NineBut7Text+ 6J   ?? *NineBut7Opacity+6p   5C     (? 5D     $??10q?6&   .??5E  "   ?? $??/Images/pick.png??6(   ${?False??6B    6T   ?? *NineBut7Pick+6w   5F     5G     5I     ?? 5J     #??[ 6e   $??2??6?   $??2??6?   $??
10,0,10,20q?6?   ??6   ?? *NineBut8Command+??6A   ?? *NineBut8Back+{?6?   ?? *NineBut8IsEnabled+.??5K     ? .+?5L     (? $??20q?6&   .??5M  "   ?? ??6,   ?? *NineBut8Text+ 6J   ?? *NineBut8Opacity+6p   5N     (? 5O     $??10q?6&   .??5P  "   ?? $??/Images/pick.png??6(   ${?False??6B    6T   ?? *NineBut8Pick+6w   5Q     5R     5T     ?? 5U     #??[ 6e   $??2??6?   $??3??6?   $??	0,0,20,20q?6?   ??6   ?? *NineBut9Command+??6A   ?? *NineBut9Back+{?6?   ?? *NineBut9IsEnabled+.??5V     ? .+?5W     (? $??20q?6&   .??5X  "   ?? ??6,   ?? *NineBut9Text+ 6J   ?? *NineBut9Opacity+6p   5Y     (? 5Z     $??10q?6&   .??5[  "   ?? $??/Images/pick.png??6(   ${?False??6B    6T   ?? *NineBut9Pick+6w   5\     5]     5_     5`     5a     5b     ? 5e  
   $??16??6   $??2??6   $??8??6.   $??
-1,12,-1,0q?6B    5f     ?? 5g     6%   ?? 5h     6%   ?? 5i     6%   ?? 5j     6%   ?? 5k     6%   ?? 5l     6%   ?? 5m     6%   ?? 5n     6%   ?? 5o     6%   ?? 5p     6%   ?? 5q     6%   ?? 5r     6%   ?? 5s     6%   .+?5u     ?? $??7??6   $??13??6"   
???   ?$??0,10,0,0q?6K   $??	0,-10,0,0q?6f   
???????6?   (? 5w     $??7??6   $??3??6#   $??	20,0,20,0q?67   .??5x     ?? $
??Aqum)?6    & MWUrBet#??? & 6.   6Q   5y     ?? 5z     #??[ 6   $??3??6G   $??7??6W   $??40(?6d   $??10,10,15,10q?6r   $
 Hand??6?   ??6?   ?? *BetDownCommand+{?6?   ?? *
RdyButSpin+$
 PropertyChanged=?.??5{     (? .??5|     ?? -6#   5}     5~     ?? 5     #??[ 6   $??4??6G   $??7??6W   $??25(?6d   $??-10,10,-20,10q?6r   $
 Hand??6?   ??6?   ?? *OpenBetCommand+{?6?   ?? *
RdyButSpin+$
 PropertyChanged=?.??5?     (? $??5,0,5,0q?6   .??5?     ?? ??6    ?? *
BetValue+$
 PropertyChanged=?$ TwoWay=?6o   5?     5?     ?? 5?     #??[ 6   $??5??6G   $??7??6W   $??40(?6d   $??
25,10,0,10q?6r   $
 Hand??6?   ??6?   ?? *BetUpCommand+{?6?   ?? *
RdyButSpin+$
 PropertyChanged=?.??5?     (? .??5?     ?? +6#   5?     5?     ?? 5?     #??[ 6   $??7??6?   $??3??6?   $??7??6?   $??35(?6?   $??
0,10,10,10q?6?   $
 Hand??6  $ 9??6  ??6F   ?? *Spin+$
 PropertyChanged=???6?   ?? $	 
TabControl??{?6+  ?? *
RdyButSpin+$
 PropertyChanged=?.??5?     (? .??5?     ??  
' MWSPIN#??? ' 6    6B   5?     5?     ?? 5?     #??[ 6   $??12??6m   $??7??6~   $??35(?6?   $??10q?6?   $
 Hand??6?   ??6G   ?? *HelpGamesCommand+.??5?     (? .??5?     ?? ?6#   5?     5?     5?     ?? 5?  
   $??2??6   $??13??6"   
???   ?$??0,0,0,10q?6K   $??	0,0,0,-10q?6f   
???????$ 20??6?   $ Arrow??6?   5?     5?     