   M S B A M L   `   `   `  ����@  <NBMFS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:NBMFSNBMFS  5   	       NBMFS.AddMessage   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:NBMFS     5   	     � Title$  
AddMessage��5   	   $	��356��6   $	��410��6)   .��5	      � .+�5
   
   �� -   5         ��Name$ 
btn_cancel��5
      $��Cancel��6%   $
��Left=�66   $��147,294,0,0q�6Q   $	��Top=�6f   $��75��6~    �� IsCancel . 6�   �� 5   
   -   5        $ 	btn_clear��5      $��Clear��6$   $
��Left=�64   $��227,294,0,0q�6O   $	��Top=�6d   $��75��6|   6�   �� 5   
   -   5        $ btn_add��5      $	��Add��6"   $
��Left=�60   $��307,294,0,0q�6K   $	��Top=�6`   $��75��6x    �� 	IsDefault . 6�   �� 5   
   -   5         ��Name$ lbl_ID��5      $��
Message ID��6    $
��Left=�65   $	��Top=�6P    J� RenderTransformOrigin$ 0.605,-0.538&�6h   $��6,0,0,0q�6�   �� 5   
   -   5         ��Name$ txt_id��5      $
��Left=�6"   $��23��6=   $��	10,26,0,0q�6I    �� TextWrapping$
 Wrap=�6\   $	��Top=�6p   $	��180��6�   6�   �� 5   
   -   5        $ 
lbl_Sender��5      $��Sender��6$   $
��Left=�65   $��	198,0,0,0q�6P   $	��Top=�6c   �� 5   
   -   5        $ lbl_subject��5      $��Subject��6%   $
��Left=�67   $��6,54,0,0q�6R   $	��Top=�6d   �� 5   
   -   5        $ 
txt_sender��5      $
��Left=�6&   $��23��6A   $��
202,26,0,0q�6M   $
 Wrap=�6a   $	��Top=�6u   $	��180��6�   �� 5   
   -	   5        $ txt_subject��5      $
��Left=�6'   $��23��6B   $��	10,80,0,0q�6N   $
 Wrap=�6a   $	��Top=�6u   $	��372��6�   �� 5   
   -
   5        $ txt_message��5      $
��Left=�6'   " �� VerticalScrollBarVisibility$
 Auto=�6B   $	��150��6e   $��
10,134,0,0q�6r   $
 Wrap=�6�   	 �� AcceptsReturn	 . $	��Top=�6�   $	��372��6�   �� 5   
   -   5        $ lbl_message��5      $��Message Text��6%   $
��Left=�6<   $��	6,108,0,0q�6W   $	��Top=�6j   5      5      