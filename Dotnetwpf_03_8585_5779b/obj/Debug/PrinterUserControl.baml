   M S B A M L   `   `   `  ����R  NDotnetwpf_03_8585_5779b, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:Dotnetwpf_03_8585_5779bDotnetwpf_03_8585_5779b  5      0    *Dotnetwpf_03_8585_5779b.PrinterUserControl   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      7local%clr-namespace:Dotnetwpf_03_8585_5779b     5      $	��0.2��5      
�������$��1q�62   .��5	      �   � RowDefinitions  5
   
   �� 5      $��* �6   �� 5      $
��auto �6   �� 5      $
��auto �6   .+�5   
   � $��2��6    � ColumnDefinitions 5      �� 5      $
��auto �6#   �� 5      $��1* �6#     5      �� 5      $
��auto �6    �� 5      $
��auto �6    .+�5      �� -   5        $��inkLable��5      $
��Ink:��6$   �� 5      -   5        $��	pageLabel��5   !   $��1��6   $��Pages:��62   � 5      -   5        $��inkCountProgressBar��5   *   $��1��6    � Value$ 23Q�6E   
���2�2� � ToolTip 6P   ��  �� ElementName$ inkCountProgressBar�� �� Path$ Value�6�   �� 5      -   5        $��pageCountSlider��5      $��1��6,   $��1��6<   $	 200Q�6I   0   *Dotnetwpf_03_8585_5779b.PrinterUserControl   MaxPages � Maximum# Z 6U    6�   �� $ pageCountSlider��$ Value�5      �� 5   
   $�� 0��6   $��images/printer.jpg��6   �� 5   
   -   5        $��PrinterNameLabel��5      $��1��6   $��printer Name��65   $��Center=�6�   $��16(�6�   5      5!      5#      