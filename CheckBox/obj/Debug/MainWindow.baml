   M S B A M L   `   `   `  ����C  ?CheckBox, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:CheckBoxCheckBox  5   	       CheckBox.MainWindow   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   (localclr-namespace:CheckBox     5   	   -   5          � Title$  MediaPlayer��5   	   $	��359��6   $	��525��6*    � 
ResizeMode$ NoResize=�5   	   ��5	      �� 5
   
    �� ImageSource$+ %bin\Debug\PlayerImages\BackGround.jpg��6    � 	Resources 5         ButtonSelectStyle �� 
TargetType �� Property �� Value �� 
TargetType �� Triggers	 P� Property
 P� Value��%�  &	        �� 5   
   " ��6*   .�5      ��  � ��
 ���� 6+   �� 5       � ��$ 29(�6)   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� #��z��6!   ._�5      �� $
��Left=�6/   $	��Top=�6J   5      5      5       5      P� 5      	 �@J�IsMouseOver
 . . �5      ��  � ��
 �����63   5      5!      5"      .��5$      � $��
0,0,-8,-21q�6    � ColumnDefinitions 5%   
   �� 5&      $
��189* �6   �� 5'      $
��328* �6   .+�5)   
   �� -   5        $��label1��5)      $��Right=�6"   $��00:00:00��5*      $
��Left=�6&   $��
31,214,0,0q�6A   $	��Top=�5+      $��71��6+   $��14(�66    J� RenderTransformOrigin$ 0.437,1.103&�5,      ���	#FFD4CBCB67   �� 5.   
   -   5        $��label2��5.      $
��left=�6"   $��00:00:00��5/      $
��Left=�6'   $��226.416,214,0,0q�6B   $	��Top=�50      $��72��6,   $��14(�67   ���	#FFD4D2D2$��1��51   +   �� 53   
   -   5        $	��Bal��53       � Minimum$
 -100Q�6     � Maximum$	 100Q�60    � Value$ 0Q�6>   $
��Left=�54   6   $��
44,260,0,0q�55      $	��Top=�6)   $��20��56      $��70��6!   $ 0.5,0.5&�6,   �� 58   
   -   5        $
��Mysl��58   9   $ 0Q�6   $��102,214,102,95q�6    $	 700Q�5:      $ 50Q�5;       �� TickFrequency$ 1Q�5<      $ 0.509,9.055&�6)    �� IsSnapToTickEnabled . $��2��5=   0   5?         CheckBox.ControlVolume  5A   
   -   5          Name$ volumeslider��5A         CheckBox.ControlVolume   VolClick$ 	MuteClick��65      	VolChange$ Slider_ValueChanged��5B      $��1��5C      $��85,129,-73,53q�6.   $ 0.5,0.5&�5D      z�5E      V� 5F      .~�5G      �� �� 5H      �� 5I       �� Angle$ 0.125Q�6&   T� 5J      5K      5M      �� 5O   
   -   5         ��Name$
 Play��5O   B   #��[  6   $��41,243,236,45q�5P   1   $��1��6H   .��5Q      �� -   5        $��pl��5Q      $(��"bin\Debug\PlayerImages\Button1.png��6    6P   5R      �� 5S   
   -	   5        $ 	Play_Copy��5T   ;   #��[  5S      $��0q�5U      $��134,243,0,45q�5V      .��5W      �� $%��bin\Debug\PlayerImages\But2.png��6   $��59��5X      $��52��6"   61   5Y      �� 5Z   
   -
   5        $ 
Play_Copy1��5Z   ;   #��[  5[      $��129,243,146,45q�5]      $��1��6*   .��5^      �� $%��bin\Debug\PlayerImages\But1.png��6   $��57��5_      $��53��6    5`      �� 5b   
   $��0,0,141,143q�6   .+�5c      �� -   5        #��[  5c      .��5d      �� $&�� bin\Debug\PlayerImages\Lines.png��6   5e      �� 5f      -   5        #��[  5f      .��5g      �� $%��bin\Debug\PlayerImages\list.png��6   5h      �� 5i      -   5        #��[  5i      $��0q�6V   .��5j      �� $&�� bin\Debug\PlayerImages\album.png��6   5k      �� 5l      -   5        $��0,10,0,0q�5l      $��30��6'   $��30��63   #��[  6>   $��0q�6~   .��5m      �� $)��#bin\Debug\PlayerImages\question.png��6   5n      5o      �� 5q   
   -   5        $��	BestSongs��5q   <    K� ZIndex$ 15��6   $y�Hidden=�6(   $��2��5r      $��84,10,73,167q�6*   .+�5s      � $	��158��6   .+�5t      �� -   5        $	��Add��5t   *   $��293,0,10,87q�68   �� 5u      -   5        $��Songs��5u      $��0,0,80,7q�6(   �� 5v      -   5        $��Remove��5v   (   $��293,80,10,7q�69   5w      5x      �� 5z   
   -   5        $��ImageBox��5z   '   $��84,10,258,152q�67   $��2��6N   �� 5|   
   -   5        $
��list��5|   &   $ 15��6   $y�Hidden=�62   $��2��5}      $��56,10,35,152q�6'   �� 5~   
   -   5        $��SongName��5~   3   $y�Hidden=�6   $��20(�6%   $
��Left=�5      $	��Top=�6,   $��1��5�      $��
104,25,0,0q�6!   $��49��65   $	��199��6A   5�      �� 5�   
   -   5        $��
SongArtist��5�   2   $y�Hidden=�6   $��15(�6$   $��
SongArtist��6D   $
��Left=�5�      $	��Top=�6+   $��1��6C   $��
155,72,0,0q�5�      $��30��6$   $	��130��60   $ 	0.531,0.8&�6<   �� 5�   
   -   5        $��	SongAlbum��5�   2   $y�Hidden=�6   $��15(�6$   $��	SongAlbum��6C   $
��Left=�5�      $	��Top=�6+   $��1��6C   $��155,107,0,0q�5�      $��31��6%   $	��139��61   �� 5�   
   -   5        $��
listartist��5�   2   $y�Hidden=�6   $��13(�6$   
�������$��Artist:��5�   %   $
��Left=�67   $	��Top=�5�      $��1��6(   $��
102,75,0,0q�68   �� 5�   
   -   5        $��	listalbum��5�   2   $y�Hidden=�6   $��13(�6$   
�������$��Album:��5�   %   $
��Left=�66   $	��Top=�5�      $��1��6(   $��102,109,0,0q�68   �� 5�   
   -   5        $��Circle��5�   >   #��[  6   $
��Left=�5�   %   $	��Top=�5�      $��32��6)   $��233,277,0,0q�64   $��35��5�      $��1��6   .��5�      �� -   5        $��CircleImage��5�      $-��'bin\Debug\PlayerImages\CircleArrow2.png��6(   5�      �� 5�   
   -   5        $��0q�5�   $   $
��Left=�68   $	��Top=�5�      $��40��6)   $��275,282,0,0q�64   $��30��5�      $��1��6   ��5�      �� 5�      $% bin\Debug\PlayerImages\rand.jpg��6   5�      �� 5�   
   -   5        #��[  5�   %   $
��Left=�5�      $	��Top=�6,   $��32��5�      $��
10,277,0,0q�6   $��29��60   .��5�      �� $%��bin\Debug\PlayerImages\like.png��6   5�      5�      5�      