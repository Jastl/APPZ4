   M S B A M L   `   `   `  ����  FitnessClub.UI*    $FitnessClub.UI.Pages.MembershipsPage   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5        N� Title$  Memberships��5      .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��0��6    �� Orientation$ 
Horizontal=�6"   $��10q�6;   .+�5      �� -   5         ��Name$ btnAddMembership��5      $��Add New Membership��6/   $��0,0,10,0q�6k   �� 5      -   5        $ 
btnRefresh��5      $��Refresh��6)   6;   5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ membershipsGrid��5      $��1��5         AutoGenerateColumns$ False��5         
IsReadOnly$
 True��5         SelectionMode$ Single=�5         Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn	   Header$	 Client��6%   
   Width5  /System.Windows.Controls.DataGridLengthConverter$
 * 6Y   1  +System.Windows.Controls.DataGridBoundColumn   Binding 65   �� *Client.FullName+6Y     5      $
	 Club��6%   $
 * 6Q    63   �� *	Club.Name+6Q     5      $	 
Start Date��6%   $
 * 6g    69   �� *	StartDate+ �� StringFormat$ d��6g     5      $	 End Date��6%   $
 * 6c    67   �� *	EndDate+$ d��6c     5      $	 Duration (Days)��6%   $
 * 6a    6>   �� *DurationInDays+6a   4  .System.Windows.Controls.DataGridTemplateColumn  5      $

 Auto 6)      CellTemplate 5      �� 5      .R�5      �� $ 
Horizontal=�6)   .+�5    "   �� -   5        $
��Edit��5    )   $��2q�6X   �� 5!   "   -   5        $��Delete��5!   )   $��2q�6\   5"      5#      5%      5'      5(      5)      