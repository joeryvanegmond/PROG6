   M S B A M L   `   `   `  ����   MyBlogStarter    MyBlogStarter.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml       � Title$  
MainWindow��$	��350��$	��525�� � DataContext ��  �� Path$
 Main�   ServiceLocator �� Source# [  .���� $��12q�._��� .+��  � ColumnDefinitions �� $��* ��� $��50 ��� $��5 ��� $��50 �.+��� $��Blog Collection��$��28(�$��0���� $��50��$��50��$��28(�$��+��
�������$
��Bold"����	#FF44AE3F$��1������ *ShowAddBlogCommand+�� $��50��$��50��$��28(�$��-��
�������$
��Bold"�
���  ��$��3������ *ShowAddBlogCommand+&   System.Windows.Controls.DataGrid     AutoGenerateColumns .     
IsReadOnly . $��0,6,0,0q����	#FF979494   GridLinesVisibility$ 
Horizontal=�   HorizontalGridLinesBrush �	#FFF0E0E0	   HeadersVisibility$	 Column=����� *Blogs+
   Columns
 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ #��   
Foreground �	#FF1D16161  +System.Windows.Controls.DataGridBoundColumn   Binding �� *Id+  $ Title��   Width5  /System.Windows.Controls.DataGridLengthConverter$ *  �� *Title+  $ Author��$ *  �� *Author+  $ Published on��$ *  �� *	TimeStamp+