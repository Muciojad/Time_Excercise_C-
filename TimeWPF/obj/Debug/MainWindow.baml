   M S B A M L   `   `   `  ����B  >TimeWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:TimeWPFTimeWPF  5   	       TimeWPF.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:TimeWPF     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      � .+�5
   
   �� -   5         ��Name$ SimpleClockLabel��5
      $��Prosty zegar(Time)��6*   $
��Left=�6G   $��	70,46,0,0q�6b   $	��Top=�6u   $	��121��6�   �� 5   
   -   5        $ SimpleClockValueLabel��5      $��00:00:00��6/   $
��Left=�6B   $��	81,77,0,0q�6]   $	��Top=�6p   �� 5   
   -   5         ��Name$ TimePeriodSlider��5      $
��Left=�6+   $��
238,69,0,0q�6F   $	��Top=�6Z    �� Orientation$ 
Horizontal=�6r   $	��248��6�   $��31��6�    � Minimum$ 0Q�6�    � Maximum$ 23Q�6�    �� TickPlacement$ BottomRight=�6�    �� TickFrequency$ 1Q�6�    �� IsSnapToTickEnabled . 6  �� 5   
   -   5        $ TimePeriod1_Label��5      $��TimePeriod1��6+   $
��Left=�6A   $��	298,7,0,0q�6\   $	��Top=�6o   $	��122��6�   �� 5   
   -   5        $ TimePeriodSlider_Mins��5      $
��Left=�60   $��238,136,0,0q�6K   $	��Top=�6`   $ 
Horizontal=�6x   $	��248��6�   $��31��6�   $ 0Q�6�   $ 59Q�6�   $ BottomRight=�6�   $ 1Q�6�    . 6  �� 5   
   -   5        $ TimePeriod1_LabelMinutes��5      $��Minuty��62   $
��Left=�6C   $��298,105,0,0q�6^   $	��Top=�6s   $	��122��6�   �� 5   
   -   5        $ TimePeriod1_LabelHours��5      $��Godziny��60   $
��Left=�6B   $��
298,38,0,0q�6]   $	��Top=�6q   $	��122��6�   �� 5   
   -   5        $ TimePeriodSlider_Sec��5      $
��Left=�6/   $��238,215,0,0q�6J   $	��Top=�6_   $ 
Horizontal=�6w   $	��248��6�   $��32��6�   $ 0Q�6�   $ 59Q�6�   $ BottomRight=�6�   $ 1Q�6�    . 6
  �� 5   
   -	   5        $ TimePeriod1_LabelSeconds��5      $��Sekundy��62   $
��Left=�6D   $��298,185,0,0q�6_   $	��Top=�6t   $	��122��6�   �� 5   
   -
   5        $ TimePeriod2Slider_Hours��5      $
��Left=�62   $��
529,69,0,0q�6M   $	��Top=�6a   $ 
Horizontal=�6y   $	��248��6�   $��31��6�   $ 0Q�6�   $ 23Q�6�   $ BottomRight=�6�   $ 1Q�6�    . 6  �� 5   
   -   5        $ TimePeriod2_Label��5      $��TimePeriod2��6+   $
��Left=�6A   $��	589,7,0,0q�6\   $	��Top=�6o   $	��122��6�   �� 5   
   -   5        $ TimePeriod2Slider_Mins��5      $
��Left=�61   $��529,136,0,0q�6L   $	��Top=�6a   $ 
Horizontal=�6y   $	��248��6�   $��31��6�   $ 0Q�6�   $ 59Q�6�   $ BottomRight=�6�   $ 1Q�6�    . 6  �� 5   
   -   5        $# TimePeriod1_LabelMinutes_Copy��5      $��Minuty��67   $
��Left=�6H   $��589,105,0,0q�6c   $	��Top=�6x   $	��122��6�   �� 5   
   -   5        $! TimePeriod1_LabelHours_Copy��5      $��Godziny��65   $
��Left=�6G   $��
589,38,0,0q�6b   $	��Top=�6v   $	��122��6�   �� 5   
   -   5        $ TimePeriod2Slider_Sec��5      $
��Left=�60   $��529,215,0,0q�6K   $	��Top=�6`   $ 
Horizontal=�6x   $	��248��6�   $��32��6�   $ 0Q�6�   $ 59Q�6�   $ BottomRight=�6�   $ 1Q�6�    . 6  �� 5   
   -   5        $# TimePeriod1_LabelSeconds_Copy��5      $��Sekundy��67   $
��Left=�6I   $��589,185,0,0q�6d   $	��Top=�6y   $	��122��6�   �� 5   
   -   5        $ SimpleClockLabel_Copy��5      $0��*Time stworzony z TimePeriod1 i TimePeriod2��6/   $
��Left=�6d   $��525,352,0,0q�6   $	��Top=�6�   $	��252��6�   �� 5   
   -   5        $ TimeFromTPS_Label��5      $��00:00:00��6+   $��Center=�6>   $��480,378,0,0q�6[   $	��Top=�6p   $	��250��6�   $��Center=�6�   �� 5   
   -   5        $ TimePeriod1ValueLabel��5      $��00:00:00��6/   $
��Left=�6B   $��332,252,0,0q�6]   $	��Top=�6r   �� 5   
   -   5        $ TimePeriod2Value_Label��5      $��00:00:00��60   $
��Left=�6C   $��626,252,0,0q�6^   $	��Top=�6s   5      5       