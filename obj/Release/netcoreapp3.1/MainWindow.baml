   M S B A M L   `   `   `  ���� E  ABangumiGal, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:BgmDesktop
BgmDesktop      BgmDesktop.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     *localclr-namespace:BgmDesktop       � Title$  Bangumi Gal��$	��450��$	��800�� � WindowStyle$
 None=� � 
ResizeMode$ CanMinimize=� � WindowStartupLocation$ CenterScreen=�.��� ���#c6c6c6$��13(����#2d2e2f � RowDefinitions �� $��25 ��� $��40 ��� $��* �.+�� -   $��0�����#3f3f3f.+��� $"��Resourse/image/UI/icon32.png��$��32��$
��Left=�$��Center=�$��10,2,2,2q��� $��Bangumi Gal v0.01��$��Center=�$
��Left=�$��	42,-2,0,0q�$4��.MyFont, Pescadero, Microsoft Yahei, sans-serif)��� -      TransparentButton#��[  $��Right=�
������ $��30��.���� $!��Resourse/image/UI/close.png��$��7q��� -   $��WindowControlButton��#��[  $��Right=�
������ $��30��$��0,0,30,0q�.��� .+��� -   $��WindowLargeImage��$!��Resourse/image/UI/large.png��$��7q��� -   $��WindowNormalImage��$"��Resourse/image/UI/normal.png��$��7q�$y�Hidden=��� -   #��[  $��Right=�
������ $��30��$��0,0,60,0q�.���� $!��Resourse/image/UI/small.png��$��7q�� $��1�����#353738.+��� 
���   �$��0,0,0,1q��� -   $��
HomeButton��#��[  
������ $��0q�$��0,0,0,2q�$��50��$��38��.���� -   ���#c6c6c6$��首页��$,��&Pescadero, Microsoft Yahei, sans-serif)�$��Center=�$��Center=�$
��Bold"�$��15(��� -	   #��[  
������ $��0q�$��50,0,0,2q�$��70��$��38��.���� -
   ���#c6c6c6$��	排行榜��$,��&Pescadero, Microsoft Yahei, sans-serif)�$��Center=�$��Center=�$
��Bold"�$��15(��� -   #��[  $��Center=�$��Right=�
������ $��0q�$��0,0,10,2q�$��38��$��38���� $
��Auto=�$��2��.��� -   $��HomeGrid�����#2d2e2f �� $
��Auto ��� $��40 ��� $
��Auto ��� $
��Auto �.+�� -   $��UserListGrid��$��0��� $��1��.+��� -   $��	AddButton��#��[  ���#3f3f3f$��0q�$��50��$��38��$��Center=�$��0,0,60,0q�.���� -   ���#c6c6c6$��添加��$,��&Pescadero, Microsoft Yahei, sans-serif)�$��Center=�$��Center=�$
��Bold"�$��15(��� -   $��CheckButton��#��[  ���#3f3f3f$��0q�$��50��$��38��$��Center=�$��60,0,0,0q�.���� -   ���#c6c6c6$��查询��$,��&Pescadero, Microsoft Yahei, sans-serif)�$��Center=�$��Center=�$
��Bold"�$��15(�� -   $��AnsArea��$��2���� -   $��shower��$��3��