   M S B A M L   `   `   `  ����  FitnessClub.UI$    FitnessClub.UI.Pages.ClubsPage   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5        N� Title$  Clubs��5      .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��0��6    �� Orientation$ 
Horizontal=�6"   $��10q�6;   .+�5      �� -   5         ��Name$ 
btnAddClub��5      $��Add New Club��6)   $��0,0,10,0q�6Y   �� 5      -   5        $ 
btnRefresh��5      $��Refresh��6)   6;   5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ 	clubsGrid��5      $��1��5         AutoGenerateColumns$ False��5         
IsReadOnly$
 True��5         SelectionMode$ Single=�5         Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn	   Header$
	 Name��6%   
   Width5  /System.Windows.Controls.DataGridLengthConverter$
 * 6L   1  +System.Windows.Controls.DataGridBoundColumn   Binding 63   �� *Name+6L     5      $	 Address��6%   $
 * 6R    66   �� *	Address+6R     5      $	 Phone��6%   $
 * 6T    64   �� *PhoneNumber+6T   4  .System.Windows.Controls.DataGridTemplateColumn  5      $

 Auto 6)      CellTemplate 5      �� 5      .R�5      �� $ 
Horizontal=�6)   .+�5   "   �� -   5        $
��Edit��5   )   $��2q�6R   �� 5   "   -   5        $��Delete��5   )   $��2q�6V   5       5!      5#      5%      5&      5'      