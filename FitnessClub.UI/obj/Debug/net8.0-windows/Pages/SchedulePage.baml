   M S B A M L   `   `   `  ����  FitnessClub.UI'    !FitnessClub.UI.Pages.SchedulePage   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     N� Title$  Schedule��5   	   .��5      � $��10q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5	      $��* �6   .+�5   
   �� $��0��6    �� Orientation$ 
Horizontal=�6"   $��0,0,0,10q�6;   .+�5      �� -   5         ��Name$ btnAddSchedule��5      $��Add Schedule��6-   $	��100��6a   $��0,0,10,0q�6m   �� 5      -   5        $ 
btnRefresh��5      $��Refresh��6)   $��70��6T   5      �� 5   
   $��1��6   $ 
Horizontal=�6"   $��0,0,0,10q�6;   .+�5      �� $��Club:��6   $��Center=�6$   �� 5      -   5         ��Name$ clubComboBox��5      $	��200��6-   $��5,0,10,0q�69    �� DisplayMemberPath$
 Name��5       �� SelectedValuePath$ Id��5      5      �� 5      $��Date Range:��6   $��Center=�6*   (  "System.Windows.Controls.DatePicker  5      -   5          Name$ startDatePicker��5      $	��120��62   $��5,0,5,0q�6>   5      �� 5      $��to��6   $��Center=�6!     5      -   5        $ endDatePicker��5      $	��120��60   $��5,0,0,0q�6<   5      5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ scheduleGrid��5      $��2��6)   	   AutoGenerateColumns$	 False��66   
   
IsReadOnly$

 True��5          SelectionMode$ Single=�6%      Columns 5!      0  *System.Windows.Controls.DataGridTextColumn  5"      ,  &System.Windows.Controls.DataGridColumn   Header$ Activity��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6X   1  +System.Windows.Controls.DataGridBoundColumn   Binding 67   �� *ActivityName+6X     5#      $ 
Start Time��6%   $	 150 6m    69   �� *	StartTime+ �� StringFormat$ {0:g}��6m     5$      $ End Time��6%   $	 150 6i    67   �� *	EndTime+$ {0:g}��6i     5%      $ Max Participants��6%   $	 100 6c    6?   �� *MaxParticipants+6c     5&      $ Available Spots��6%   $	 100 6a    6>   �� *AvailableSpots+6a   4  .System.Windows.Controls.DataGridTemplateColumn  5'      $ Actions��6)   $	 100 6:      CellTemplate 5(      �� 5)      .R�5*      �� $ 
Horizontal=�6)   .+�5+   "   �� -   5        $
��Edit��5+   )   $��0,0,5,0q�5,   )   $	��5,0q�6:   �� 5-   "   -   5        $��Delete��5-   )   $	��5,0q�5.   )   5/      50      52      54      55      56      