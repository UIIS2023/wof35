   M S B A M L   `   `   `  ����E  ABiblioteka, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:Biblioteka.FormeBiblioteka.Forme  5   	        Biblioteka.Forme.FrmKnjiga   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:Biblioteka.Forme     5   	     � Title$  Knjiga��5   	   $	��450��6   $	��800��6%   
�������$��20q�5
      ��5      �� 5   
    �� ImageSource$2 ,C:\Users\38169\Downloads\slikaProjekat1.jpeg��6    j� Stretch$
 None=�6P   .��5      � .+�5   
   �� 
�������$��ISBN:��6-   $��	UltraBold"�6=   $��18(�6T   $
��Left=�6b   $��
180,45,0,0q�6}   $	��Top=�6�   �� 5   
   
�������$��Naslov:��6-   $��	UltraBold"�6?   $��18(�6V   $
��Left=�6d   $��
180,75,0,0q�6   $	��Top=�6�   �� 5   
   
�������$��Autor:��6.   $��	UltraBold"�6?   $��18(�6V   $
��Left=�6d   $��180,105,0,0q�6   $	��Top=�6�   �� 5   
   
�������$��Zanr:��6-   $��	UltraBold"�6=   $��18(�6T   $
��Left=�6b   $��180,135,0,0q�6}   $	��Top=�6�   �� 5   
   
�������$��Izdavac:��6.   $��	UltraBold"�6A   $��18(�6X   $
��Left=�6f   $��180,165,0,0q�6�   $	��Top=�6�   �� 5   
   
�������$��Nabavka:��6-   $��	UltraBold"�6@   $��18(�6W   $
��Left=�6e   $��180,195,0,0q�6�   $	��Top=�6�   �� 5   
   
�������$��Clanska kartica:��6-   $��	UltraBold"�6H   $��18(�6_   $
��Left=�6m   $��180,225,0,0q�6�   $	��Top=�6�   �� 5   
   -   5         ��Name$ txtISBN��5      $
��Left=�6#   $��25��6>   $��
300,45,0,0q�6J    �� TextWrapping$
 Wrap=�6^   $�� ��6r   $	��Top=�6z   $	��120��6�   �� 5   
   -   5        $ 	txtNaslov��5      $
��Left=�6%   $��25��6@   $��
300,75,0,0q�6L   $
 Wrap=�6`   $�� ��6t   $	��Top=�6|   $	��120��6�   �� 5   
   -   5         ��Name$ cbAutor��5      $
��Left=�6$   $��300,105,0,0q�6?   $	��Top=�6T   $	��120��6l    �� DisplayMemberPath$ Autor��6x    �� SelectedValuePath$ autorID��6�   �� 5   
   -   5        $ cbZanr��5      $
��Left=�6#   $��300,135,0,0q�6>   $	��Top=�6S   $	��120��6k   $
 Zanr��6x   $ zanrID��6�   �� 5   
   -   5        $ 	cbIzdavac��5      $
��Left=�6&   $��300,165,0,0q�6A   $	��Top=�6V   $	��120��6n   $ Izdavac��6z   $ 	izdavacID��6�   �� 5   
   -   5        $ 	cbNabavka��5      $
��Left=�6&   $��300,195,0,0q�6A   $	��Top=�6V   $	��120��6n   $ Nabavka��6{   $ 	nabavkaID��6�   �� 5   
   -   5        $ cbClanskaKarta��5      $
��Left=�6+   $��350,225,0,0q�6F   $	��Top=�6[   $	��120��6s   �� 5   
   -   5         ��Name$ 
btnSacuvaj��5      $��Sacuvaj��6%   $��Italic$�67   $��15(�6J   $
��Left=�6X   $��240,310,0,0q�6s   $	��Top=�6�   $��75��6�   	 J� RenderTransformOrigin$	 -5.157,1.143&�6�   �� 5   
   -	   5        $ 	btnOtkazi��5      $��Otkazi��6$   $��Italic$�65   $��15(�6H   $
��Left=�6V   $��400,310,0,0q�6q   $	��Top=�6�   $��75��6�   6�   5      5       