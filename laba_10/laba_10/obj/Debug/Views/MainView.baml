   M S B A M L   `   `   `  ����B  >laba_10, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:laba_10.commandslaba_10.commands  5          laba_10.Views.MainView   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      ,cclr-namespace:laba_10.commands     5        � Title$  Вклады��5      $	��400��6   $	��350��6!   .��5      �  � ColumnDefinitions 5   
   �� 5	      �� 5
      .+�5   
   �� $ �� IsSynchronizedWithCurrentItem$
 TrueY�65   ��6   �� *	BooksList+��5      �� 5      .R�5      �� 
�������$��1q�62   $��10q�6F   ._�5      �� $��10q�6%   .+�5      �� $
��Bold"�6?   ��6(   �� *Title+6?   �� 5      ��6(   �� *Name+�� 5      ��6(   �� *Date+�� 5       �� Orientation$ 
Horizontal=�6)   .+�5   "   �� $��Осталось:��6,   �� 5   "   $
��Bold"�6P   $
��10,0q�6b   ��6,   �� *Count+ �� Mode$ TwoWay=�6b   �� 5   "   $
��шт��6,   5      5      5      5      5      �� 5    
   $��1��6   ��6)   �� *
BankksList+��5!      �� 5"      .R�5#      �� 
�������$��1q�62   $��10q�6F   ._�5$      �� $��10q�6%   .+�5%      �� $��Название:��6(   �� 5&      $��0,0,0,10q�6b   ��6&   �� *Title+ �� UpdateSourceTrigger$ PropertyChanged=�6b   �� 5(      $��Автор:��6(   �� 5)      $��0,0,0,10q�6a   ��6&   �� *Name+$ PropertyChanged=�6a   �� 5*      $��0,0,0,10q�6a   ��6&   �� *Date+$ PropertyChanged=�6a   �� 5,      $ 
Horizontal=�6)   .+�5-   "   �� $��Выдать��6)   $
��10,0q�6^   ��6:   �� *GiveItemCommand+6^   �� 5.   "   $��Забрать��6)   $
��10,0q�6^   ��6;   �� *GetItemCommand+6^   5/      50      51      52      54      55      56      