   M S B A M L   `   `   `  ����  FitnessClub.UI&     FitnessClub.UI.Pages.MembersPage   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5        N� Title$  Members��5      .��5      � $��10q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��0��6    �� Orientation$ 
Horizontal=�6"   $��0,0,0,10q�6;   .+�5      �� -   5         ��Name$ btnAddMember��5      $��
Add Member��6+   $��0,0,10,0q�5      $
��10,5q�6'   �� 5      -   5        $ 
btnRefresh��5      $��Refresh��6)   $
��10,5q�5      5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ membersGrid��5      $��1��6(      AutoGenerateColumns$ False��65      
IsReadOnly$
 True��5         SelectionMode$ Single=�6%      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn	   Header$	 
First Name��6%   
   Width5  /System.Windows.Controls.DataGridLengthConverter$
 * 6W   1  +System.Windows.Controls.DataGridBoundColumn   Binding 69   �� *	FirstName+6W     5      $	 	Last Name��6%   $
 * 6U    68   �� *
LastName+6U     5      $	 Email��6%   $
 * 6N    64   �� *Email+6N     5      $	 Phone��6%   $
 * 6N    64   �� *Phone+6N   4  .System.Windows.Controls.DataGridTemplateColumn  5      $	 Actions��6)   $	
 300 6:      CellTemplate 5      �� 5      .R�5      �� $ 
Horizontal=�6)   .+�5   "   �� -   5        $
��Edit��5   )   $��0,0,5,0q�5   )   $
��10,0q�6:   �� 5   "   -   5        $��Delete��5   )   $��0,0,5,0q�5    )   $
��10,0q�6:   �� 5!   "   -   5        $��View Memberships��5!   )   $
��10,0q�5"   )   5#      5$      5&      5(      5)      5*      