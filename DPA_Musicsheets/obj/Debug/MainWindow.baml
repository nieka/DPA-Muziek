   M S B A M L   `   `   `  ����P  LPSAMWPFControlLibrary, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null\Bclr-namespace:PSAMWPFControlLibrary;assembly=PSAMWPFControlLibraryPSAMWPFControlLibrary  5   	   J FDPA_Musicsheets, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:DPA_MusicsheetsDPA_Musicsheets 5   	       DPA_Musicsheets.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ]PSAMWPFControlBclr-namespace:PSAMWPFControlLibrary;assembly=PSAMWPFControlLibrary     5   	   /localclr-namespace:DPA_Musicsheets     5   	   -   5          � Title$  
MainWindow��5	   	   $	��500��6   $	��525��6)   .��5
      � -   5         �Name$ MainGrid��5
      .+�5   
   �� -   5         ��Name$ txt_MidiFilePath��5      $
��Left=�6,   $��19��6G   $��	10,11,0,0q�6S    �� TextWrapping$
 Wrap=�6f   $��../../../smb1-Theme.mid��6z   $	��Top=�6�   $	��233��6�   �� 5   
   -   5         ��Name$ btnPlay��5      $
��Play��6"   $
��Left=�61   $��
353,11,0,0q�6L   $	��Top=�6`   $��75��6x   6�   �� 5   
   -   5        $ btnOpen��5      $
��Open��6"   $
��Left=�61   $��
248,11,0,0q�6L   $	��Top=�6`   $��75��6x   6�   �� 5   
   -   5        $ btn_Stop��5      $
��Stop��6#   $
��Left=�62   $��
433,11,0,0q�6M   $	��Top=�6a   $��75��6y   6�   �� 5   
   -   5         ��Name$ 	saveState��5       �� Text$ Save to��6&   $	��233��65   $��19��6A   $
��Left=�6M   $	��Top=�6h   $��	10,38,0,0q�6�   .@�5      �� -   5        $��Lilypont��5      .��6+   
Lilypont65   �� 5      -	   5        $	��Pdf��5      .��6&   Pdf6+   5      �� 5   
   -
   5        $ btnSave��5      $
��Save��6"   $
��Left=�61   $��
248,38,0,0q�6L   $	��Top=�6`   $��75��6x   6�   �� 5   
   -   5        $ btn_Edit��5      $��	Edit mode��6#   $
��Left=�67   $��
353,35,0,0q�6R   $	��Top=�6f   $	��155��6~   6�   �� 5   
   -   5        $ EditBox��5      $��21,105,22,149q�6#   {�.  6\   ,   &PSAMWPFControlLibrary.IncipitViewerWPF  5   
   -   5          Name$ staff��5   d   $
��Left=�6*   $��	0,300,0,0q�6E   $	��525��6X   5      �� 5   
   -   5        $ btn_Undo��5      $
��Undo��6#   $
��Left=�62   $��
352,65,0,0q�6M   $	��Top=�6a   $��75��6y   6�   �� 5   
   -   5        $ btn_Redo��5      $
��Redo��6#   $
��Left=�62   $��
432,65,0,0q�6M   $	��Top=�6a   $��75��6y   6�   5      5      