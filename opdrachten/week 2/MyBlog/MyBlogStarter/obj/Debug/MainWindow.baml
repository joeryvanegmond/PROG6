   M S B A M L   `   `   `  ����  MyBlogStarter    MyBlogStarter.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  
MainWindow��5   	   $	��350��6   $	��525��6)    � DataContext 5   	   ��  �� Path$
 Main�   ServiceLocator �� Source# [  .��5	      �� $��12q�6   ._�5
   
   �� .+�5      �  � ColumnDefinitions 5      �� 5      $��* �6'   �� 5      $��50 �6'   �� 5      $��5 �6'   �� 5      $��50 �6'   .+�5      �� $��Blog Collection��6   $��28(�63   $��0��6A   �� 5      $��50��6   $��50��6$   $��28(�60   $��+��6>   
�������$
��Bold"�5   ,   ���	#FF44AE3F$��1��5      ��6*   �� *ShowAddBlogCommand+5      �� 5      $��50��6   $��50��6$   $��28(�60   $��-��6>   
�������$
��Bold"�5   ,   
���  ��$��3��5      ��6*   �� *ShowAddBlogCommand+5      5      &   System.Windows.Controls.DataGrid  5          AutoGenerateColumns .     
IsReadOnly . $��0,6,0,0q�6c   ���	#FF979494   GridLinesVisibility$ 
Horizontal=�6�      HorizontalGridLinesBrush �	#FFF0E0E0	   HeadersVisibility$	 Column=�6�   ��6E   �� *Blogs+
   Columns
 5!      0  *System.Windows.Controls.DataGridTextColumn  5"      ,  &System.Windows.Controls.DataGridColumn   Header$ #��6)      
Foreground �	#FF1D16161  +System.Windows.Controls.DataGridBoundColumn   Binding 64   �� *Id+6K     5#      $ Title��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6R    68   �� *Title+6R     5$      $ Author��6)   $ * 6T    69   �� *Author+6T     5%      $ Published on��6)   $ * 6]    6?   �� *	TimeStamp+6]   5'      5)      5*      5+      