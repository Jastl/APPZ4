   M S B A M L   `   `   `  ����  FitnessClub.UI4    .FitnessClub.UI.Dialogs.ClientMembershipsDialog   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Client Memberships��5   	   $	��450��6$   $	��800��61    � WindowStartupLocation$ CenterOwner=�5   	   .��5      � $��10q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5	      $��* �6   �� 5
      $
��Auto �6   .+�5   
   �� $��0��6    �� Orientation$ 
Horizontal=�6"   $��0,0,0,10q�6;   .+�5      �� -   5         ��Name$ btnAddMembership��5      $��Add Membership��6/   $��0,0,10,0q�5      $
��10,5q�6'   �� 5      -   5        $ 
btnRefresh��5      $��Refresh��6)   $
��10,5q�5      5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ membershipsGrid��5      $��1��6,      AutoGenerateColumns$ False��69      
IsReadOnly$
 True��5         SelectionMode$ Single=�6%   $��0,0,0,10q�6<   	   Columns	 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn
   Header$
 
Start Date��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$	 120 6m   1  +System.Windows.Controls.DataGridBoundColumn   Binding 69   �� *	StartDate+ �� StringFormat$ {0:d}��6m     5      $
 End Date��6%   $	 120 6i    67   �� *	EndDate+$ {0:d}��6i     5      $

 Club��6%   $ * 6Q    63   �� *	Club.Name+6Q     5      $
 Status��6%   $	 100 6P    65   �� *Status+6P   4  .System.Windows.Controls.DataGridTemplateColumn  5      $
 Actions��6)   $	 200 6:      CellTemplate 5      �� 5      .R�5      �� $ 
Horizontal=�6)   .+�5   "   �� -   5        $
��Edit��5   )   $��0,0,5,0q�5    )   $
��10,0q�6:   �� 5!   "   -   5        $��Delete��5!   )   $
��10,0q�5"   )   5#      5$      5&      5(      �� 5*   
   -   5        $��2��5*      $��Close��6   $��Right=�5+      $
��20,5q�6-   5,      5-      